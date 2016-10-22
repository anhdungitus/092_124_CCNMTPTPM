using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DatVeMayBay.Infrastructure.Identity
{
    public class FlightUserManager : UserManager<FlightUser>
    {
        public FlightUserManager(IUserStore<FlightUser> flight)
            : base(flight) { }

        public static FlightUserManager Create(IdentityFactoryOptions<FlightUserManager> options, IOwinContext context)
        {
            FlightIdentityDbContext dbContext = context.Get<FlightIdentityDbContext>();
            FlightUserManager manager = new FlightUserManager(new UserStore<FlightUser>(dbContext));
            return manager;
        }
    }
}