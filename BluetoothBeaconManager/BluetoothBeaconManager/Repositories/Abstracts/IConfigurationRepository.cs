using BluetoothBeaconManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluetoothBeaconManager.Repositories.Abstracts
{
    public interface IConfigurationRepository
    {
        IEnumerable<LastRequest> All();
        LastRequest GetConfiguration(string database);
        LastRequest GetById(int Id);
        void UpdateConfiguration(LastRequest request);
    }
}
