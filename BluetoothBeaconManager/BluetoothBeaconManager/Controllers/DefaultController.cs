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
    public class DefaultController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public DefaultController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetBeacons([FromForm] Credentials credentials)
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
                return Ok(new
                {
                    Vehicles = vehicles,
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
        [HttpPost]
        public IActionResult AddBeacon([FromForm] Credentials credentials, Beacon beacon)
        {
            try
            {
                if (!unitOfWork.ApiRepository.Aunthenticate(credentials.API))
                    return Unauthorized();
                unitOfWork.BeaconRepository.AddBeacon(beacon);
                return Ok(new
                {
                    Status = true,
                    Message = "Added Successfully"
                });
            }
            catch (Exception ex)
            {
                var result = new ObjectResult(new
                {
                    Message = "An error occurred while adding data to the database. " +
                              "Please try again and if the problem persists, contact support@gmail.com",
                    Status = "Error",
                    Exception = ex.Message
                });
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }
        }
        [HttpPut]
        public IActionResult EditBeacon([FromForm] Credentials credentials, [FromForm] Beacon beacon)
        {
            try
            {
                if (!unitOfWork.ApiRepository.Aunthenticate(credentials.API))
                    return Unauthorized();
                unitOfWork.BeaconRepository.EditBeacon(beacon);
                return Ok(new
                {
                    Status = true,
                    Message = "Updated Successfully"
                });
            }
            catch (Exception ex)
            {

                var result = new ObjectResult(new
                {
                    Message = "An error occurred while editing data. " +
                               "Please try again and if the problem persists, contact support@gmail.com",
                    Status = "Error",
                    Exception = ex.Message
                });
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }
        }
        [HttpDelete]
        public IActionResult DeleteBeacon([FromForm] Credentials credentials, [FromForm] Beacon beacon)
        {
            try
            {
                if (!unitOfWork.ApiRepository.Aunthenticate(credentials.API))
                    return Unauthorized();
                unitOfWork.BeaconRepository.DeleteBeacon(beacon.Id);
                return Ok(new
                {
                    Status = true,
                    Message = "Deleted Successfully"
                });
            }
            catch (Exception ex)
            {


                var result = new ObjectResult(new
                {
                    Message = "An error occurred while deleting data. " +
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
