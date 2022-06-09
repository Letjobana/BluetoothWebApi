using BluetoothBeaconManager.Repositories.Abstracts;
using Geotab.Checkmate;
using Geotab.Checkmate.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluetoothBeaconManager.Repositories.Concrets
{
    public class ApiRepository : IApiRepository
    {
        private API _api;
        public bool Aunthenticate(API api)
        {
            try
            {
                _api = api;
                var user = GetUserByUserName(_api.UserName);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Device> GetActiveDevices()
        {
            try
            {
                return _api.CallAsync<List<Device>>("Get", typeof(Device)).Result.Where(d => d.IsActive());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Device GetDeviceById(string id)
        {
            try
            {
                return _api.CallAsync<List<Device>>("Get", typeof(Device), new
                {
                    search = new DeviceSearch
                    {
                        Id = Id.Create(id)
                    }
                }).Result.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Group GetGroupByName(string groupName)
        {
            try
            {
                return _api.CallAsync<List<Group>>("Get", typeof(Group), new
                {
                    search = new GroupSearch
                    {
                        Name = groupName
                    }
                }).Result.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Group> GetGroups()
        {
            try
            {
                var groups = _api.CallAsync<List<Group>>("Get", typeof(Group)).Result.ToList();
                var groupHelper = new GroupHelper(groups);
                var populatedGroups = groupHelper.Traverse(groups).ToList();
                return populatedGroups;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetUserByUserName(string name)
        {
            try
            {
                return _api.CallAsync<List<User>>("Get", typeof(User), new
                {
                    serach = new UserSearch
                    {
                        Name = name
                    }

                }).Result.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                return _api.CallAsync<List<User>>("Get", typeof(User)).Result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
