using MB.EN.MCPP.SimTaxi.Entities.Bookings;
using MB.EN.MCPP.SimTaxi.Entities.Cars;
using MB.EN.MCPP.SimTaxi.Entities.Drivers;
using MB.EN.MCPP.SimTaxi.Entities.Passengers;
using Microsoft.EntityFrameworkCore;

namespace MB.EN.MCPP.SimTaxi.EntityFrameworkCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }
}
