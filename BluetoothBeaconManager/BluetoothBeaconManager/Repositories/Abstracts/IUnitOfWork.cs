namespace BluetoothBeaconManager.Repositories.Abstracts
{
    public interface IUnitOfWork
    {
        public IApiRepository ApiRepository { get; }
        public IBeaconRepository BeaconRepository { get; }
        public IConfigurationRepository ConfigurationRepository { get; }
    }
}
