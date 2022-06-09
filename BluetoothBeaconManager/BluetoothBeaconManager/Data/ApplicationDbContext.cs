using BluetoothBeaconManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BluetoothBeaconManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LastRequest> LastRequests { get; set; }
        public DbSet<Beacon> Beacon { get; set; }
    }
}
