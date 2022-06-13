using Geotab.Checkmate;

namespace BluetoothBeaconManager.Models
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Server { get; set; }
        public string SessionId { get; set; }
        public string Database { get; set; }
        public string groupFilter { get; set; }
        public API API => new API(Username, null, SessionId, Database, Server);
    }
}

