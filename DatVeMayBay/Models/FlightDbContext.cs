using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Models
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext()
            : base("FlightDb")
        {
            Database.SetInitializer<FlightDbContext>(new FlightDbInitializer());
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightDetail> FlightDetails { get; set; }
        public DbSet<Booking> Bookings{ get; set; }
        public DbSet<Passenger> Passengers{ get; set; }
    }
}