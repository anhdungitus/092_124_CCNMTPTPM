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
    [RoutePrefix("api/flightdetails")]
    public class FlightDetailsController : ApiController
    {
        private IRepository Repository { get; set; }
        public FlightDetailsController()
        {
            Repository = (IRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRepository));
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<FlightDetail> GetAllFlightDetails()
        {
            return Repository.FlightDetails;
        }

        [Route("{madatcho}")]
        [HttpGet]
        public IEnumerable<FlightDetail> GetThongTinMaDatCho(string madatcho)
        {
            return Repository.FlightDetails.Where(fd => fd.MaDatCho == madatcho);
        }
    }
}
