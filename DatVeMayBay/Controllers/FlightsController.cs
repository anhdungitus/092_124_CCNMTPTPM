using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatVeMayBay.Models;
using System.Threading.Tasks;

namespace DatVeMayBay.Controllers
{
    [RoutePrefix("api/flights")]
    public class FlightsController : ApiController
    {
        private IRepository Repository { get; set; }
        public FlightsController()
        {
            Repository = (IRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRepository));
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<string> GetSanBayDi()
        {
            return Repository.Flights.Select(x => x.NoiDi);
        }

        [Route("{noidi}")]
        [HttpGet]
        public IEnumerable<string> GetSanBayDenBySanBayDi(string noidi)
        {
            return Repository.Flights.Where(x => x.NoiDi == noidi).Select(x => x.NoiDen);
        }

        public IHttpActionResult GetFlight(int id)
        {
            Flight result = Repository.Flights.Where(p => p.Id == id).FirstOrDefault();
            return result == null ? (IHttpActionResult)BadRequest("No Flight Found") : Ok(result);
        }

        [Authorize(Roles = "Adminstrators")]
        public async Task<IHttpActionResult> PostFlight(Flight flight)
        {
            if (ModelState.IsValid)
            {
                await Repository.SaveFlightAsync(flight);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Adminstrators")]
        public async Task DeleteFlight(int id)
        {
            await Repository.DeleteFlightAsync(id);
        }
    }
}
