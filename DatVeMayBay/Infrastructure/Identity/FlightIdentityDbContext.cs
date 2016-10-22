using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DatVeMayBay.Infrastructure.Identity
{
    public class FlightIdentityDbContext : IdentityDbContext<FlightUser>
    {
        public FlightIdentityDbContext()
            : base("FlightsIdentityDb")
        {
            Database.SetInitializer<FlightIdentityDbContext>(new FlightIdentityDbInitializer());
        }

        public static FlightIdentityDbContext Create()
        {
            return new FlightIdentityDbContext();
        }
    }
}