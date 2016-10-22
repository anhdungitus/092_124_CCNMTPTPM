using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DatVeMayBay.Infrastructure.Identity
{
    public class FlightRoleManager : RoleManager<FlightRole>
    {
        public FlightRoleManager(RoleStore<FlightRole> store) : base(store) { }
        public static FlightRoleManager Create(IdentityFactoryOptions<FlightRoleManager> options, IOwinContext context)
        {
            return new FlightRoleManager(new
            RoleStore<FlightRole>(context.Get<FlightIdentityDbContext>()));
        }
    }
}