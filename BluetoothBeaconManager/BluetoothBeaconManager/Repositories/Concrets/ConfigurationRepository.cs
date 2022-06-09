using BluetoothBeaconManager.Data;
using BluetoothBeaconManager.Models;
using BluetoothBeaconManager.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluetoothBeaconManager.Repositories.Concrets
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ApplicationDbContext context;

        public ConfigurationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<LastRequest> All()
        {
            try
            {
                return context.LastRequests.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LastRequest GetById(int Id)
        {
            try
            {
                return context.LastRequests.Where(x => x.Id == Id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LastRequest GetConfiguration(string database)
        {
            try
            {
                return context.LastRequests.Where(x => x.DatabaseName.ToLower() == database.ToLower()).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateConfiguration(LastRequest request)
        {
            try
            {
                var result = context.LastRequests.Where(x => x.Id == request.Id).FirstOrDefault();
                if (result != null)
                {
                    result.DefaultTemperature = request.DefaultTemperature;
                    request.IsActive = request.IsActive;
                    request.UserEmails = request.UserEmails;
                    request.VehicleGroups = request.VehicleGroups;
                    request.AlertIfBelowDefaultTemperature = request.AlertIfBelowDefaultTemperature;
                    context.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
