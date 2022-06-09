using System;

namespace BluetoothBeaconManager.Models
{
    public class Beacon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexValue { get; set; }
        public DateTime DateAdded { get; set; }
        public string DatabaseName { get; set; }
        public string ServerName { get; set; }
        public string DeviceId { get; set; }
    }
}
