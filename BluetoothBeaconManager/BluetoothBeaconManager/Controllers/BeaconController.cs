using BluetoothBeaconManager.Models;
using BluetoothBeaconManager.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluetoothBeaconManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeaconController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public BeaconController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetConfiguration([FromForm] Credentials credentials)
        {
            try
            {
                if (!unitOfWork.ApiRepository.Aunthenticate(credentials.API))
                    return Unauthorized();
                List<string> groups = unitOfWork.ApiRepository.GetListFromCommaSeparatedString(credentials.groupFilter);
                List<string> configuredVehicles = unitOfWork.ApiRepository.GetAllDevices().ToList().Select(d => d.Id.ToString()).ToList();
                var vehicles = unitOfWork.ApiRepository.GetActiveVehicles(groups).Select(device => new
                {
                    Id = device.Id.ToString(),
                    device.Name
                }).ToList();
                var Users = unitOfWork.ApiRepository.GetUsers().Where(u => !u.Name.Contains("gms@geotab") && !u.Name.Contains("admin@geotab") && u.Name.Contains("@"));
                return Ok(new
                {
                    Success = true,
                    Vehicles = vehicles,
                    Users = Users.Select(g => new
                    {
                        Name = g.FirstName + " " + g.LastName + "(" + g.Name + ")",
                        Id = g.Id.ToString()
                    }),
                    Message = "Successfully retrieved"
                });
            }
            catch (Exception ex)
            {
                var result = new ObjectResult(new
                {
                    Message = "An error occurred while retrieving data from the database. " +
                        "Please try again and if the problem persists, contact support@gmail.com",
                    Status = "Error",
                    Exception = ex.Message
                });
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }
        }

        [HttpPut]
        public IActionResult SetConfiguration([FromForm] Credentials credentials, [FromForm] LastRequest request)
        {
            try
            {
                if (!unitOfWork.ApiRepository.Aunthenticate(credentials.API))
                    return Unauthorized();
                //var config = unitOfWork.ConfigurationRepository.GetConfiguration(database);
                unitOfWork.ConfigurationRepository.UpdateConfiguration(request);


                return Ok();
            }
            catch (Exception ex)
            {

                var result = new ObjectResult(new
                {
                    Message = "An error occurred while updating data from the database. " +
                       "Please try again and if the problem persists, contact support@gmail.com",
                    Status = "Error",
                    Exception = ex.Message
                });
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }
        }
    }
}
