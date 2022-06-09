using BluetoothBeaconManager.Models;
using System.Collections.Generic;

namespace BluetoothBeaconManager.Repositories.Abstracts
{
    public interface IBeaconRepository
    {
        IEnumerable<Beacon> GetBeacons(string database);
        Beacon GetBeaconById(int Id);
        void AddBeacon(Beacon beacon);
        void EditBeacon(Beacon beacon);
        void DeleteBeacon(int Id);


    }
}
