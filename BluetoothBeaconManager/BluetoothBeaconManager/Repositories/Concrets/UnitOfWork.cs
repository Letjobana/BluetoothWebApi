using BluetoothBeaconManager.Data;
using BluetoothBeaconManager.Repositories.Abstracts;

namespace BluetoothBeaconManager.Repositories.Concrets
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public IApiRepository ApiRepository { get; private set; }

        public IBeaconRepository BeaconRepository { get; private set; }

        public IConfigurationRepository ConfigurationRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            ApiRepository = new ApiRepository();
            BeaconRepository = new BeaconRepository(context);
            ConfigurationRepository = new ConfigurationRepository(context);

        }
    }
}
