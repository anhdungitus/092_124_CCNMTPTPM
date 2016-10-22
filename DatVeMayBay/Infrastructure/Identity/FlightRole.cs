using Microsoft.AspNet.Identity.EntityFramework;

namespace DatVeMayBay.Infrastructure.Identity
{
    public class FlightRole : IdentityRole
    {
        public FlightRole() : base() { }
        public FlightRole(string name) : base(name) { }
    }
}