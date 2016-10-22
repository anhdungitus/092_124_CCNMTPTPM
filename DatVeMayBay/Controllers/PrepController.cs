using System.Threading.Tasks;
using System.Web.Mvc;
using DatVeMayBay.Models;
using DatVeMayBay.Infrastructure.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Security.Claims;

namespace DatVeMayBay.Controllers
{
    public class PrepController : Controller
    {
        IRepository repo;
        public PrepController() {
            repo = new FlightRepository();
        }
        public ActionResult Index()
        {
            return View(repo.Flights);
        }

        public async Task<ActionResult> SignIn()
        {
            IAuthenticationManager authMgr = HttpContext.GetOwinContext().Authentication;
            FlightUserManager userMrg = HttpContext.GetOwinContext().GetUserManager<FlightUserManager>();
            FlightUser user = await userMrg.FindAsync("Admin", "secret");
            authMgr.SignIn(await userMrg.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie));
            return RedirectToAction("Index");
        }
        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }
	}
}