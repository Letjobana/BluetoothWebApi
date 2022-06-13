using Geotab.Checkmate;
using Geotab.Checkmate.ObjectModel;
using System.Collections.Generic;

namespace BluetoothBeaconManager.Repositories.Abstracts
{
    public interface IApiRepository
    {
        bool Aunthenticate(API api);
        User GetUserByUserName(string name);
        IEnumerable<Device> GetActiveVehicles(List<string> groupFilter);
        IEnumerable<Device> GetAllDevices();
        List<string> GetListFromCommaSeparatedString(string items);
        IEnumerable<User> GetUsers();
        Device GetDeviceById(string id);
        Group GetGroupByName(string groupName);
        List<Group> GetGroups();
    }
}
