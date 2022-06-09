using Geotab.Checkmate;
using Geotab.Checkmate.ObjectModel;
using System.Collections.Generic;

namespace BluetoothBeaconManager.Repositories.Abstracts
{
    public interface IApiRepository
    {
        bool Aunthenticate(API api);
        User GetUserByUseName(string name);
        IEnumerable<Device> GetActiveDevices();
        IEnumerable<User> GetUsers();
        Device GetDeviceById(string id);
        Group GetGroupByName(string groupName);
        List<Group> GetGroups();
    }
}
