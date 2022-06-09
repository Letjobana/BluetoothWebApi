using BluetoothBeaconManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BluetoothBeaconManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<BluetoothStatusData> BluetoothStatusDatas { get; set; }
    }
}
