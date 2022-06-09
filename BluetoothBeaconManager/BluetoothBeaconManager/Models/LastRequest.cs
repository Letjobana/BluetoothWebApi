using System;

namespace BluetoothBeaconManager.Models
{
    public class LastRequest
    {
        public int Id { get; set; }
        public DateTime LastRequestDate { get; set; }
        public Nullable<long> LastVersion { get; set; }
        public string DatabaseName { get; set; }
        public string ServerName { get; set; }
        public string UserEmails { get; set; }
        public bool IsActive { get; set; }
        public string VehicleGroups { get; set; }
        public int DefaultTemperature { get; set; }
        public bool AlertIfBelowDefaultTemperature { get; set; }
        public string LastSession { get; set; }
    }
}
