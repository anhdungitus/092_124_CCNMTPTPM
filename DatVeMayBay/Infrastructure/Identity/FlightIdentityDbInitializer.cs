using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace DatVeMayBay.Infrastructure.Identity
{
    public class FlightIdentityDbInitializer : CreateDatabaseIfNotExists<FlightIdentityDbContext>
    {
        protected override void Seed(FlightIdentityDbContext context)
        {
            FlightUserManager userMgr = new FlightUserManager(new UserStore<FlightUser>(context));
            FlightRoleManager roleMgr = new FlightRoleManager(new RoleStore<FlightRole>(context));

            string roleName = "Adminstrators";
            string userName = "Admin";
            string password = "secret";
            string email = "admin@example.com";

            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new FlightRole(roleName));
            }

            FlightUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new FlightUser { UserName = userName, Email = email }, password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }
            base.Seed(context);
        }
    }
}