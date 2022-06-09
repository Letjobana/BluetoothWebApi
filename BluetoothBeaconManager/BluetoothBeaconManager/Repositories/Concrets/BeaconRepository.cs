using BluetoothBeaconManager.Data;
using BluetoothBeaconManager.Models;
using BluetoothBeaconManager.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluetoothBeaconManager.Repositories.Concrets
{
    public class BeaconRepository : IBeaconRepository
    {
        private readonly ApplicationDbContext context;

        public BeaconRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddBeacon(Beacon beacon)
        {
            try
            {
                context.Beacon.Add(beacon);
                context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteBeacon(int Id)
        {
            try
            {
                var result = context.Beacon.Where(x => x.Id == Id).FirstOrDefault();
                if (result != null)
                {
                    context.Beacon.Remove(result);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditBeacon(Beacon beacon)
        {
            try
            {
                var result = context.Beacon.Where(x => x.Id == beacon.Id).FirstOrDefault();
                if (result != null)
                {
                    result.Name = beacon.Name;
                    result.HexValue = beacon.HexValue;
                    result.DeviceId = beacon.DeviceId;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Beacon GetBeaconById(int Id)
        {
            try
            {
                return context.Beacon.Where(x => x.Id == Id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Beacon> GetBeacons(string database)
        {
            try
            {
                return context.Beacon.Where(b => b.DatabaseName.ToLower() == database.ToLower());

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
