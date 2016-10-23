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
    [RoutePrefix("api/bookings")]
    public class BooKingsController : ApiController
    {
        private IRepository Repository { get; set; }
        public BooKingsController()
        {
            Repository = (IRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRepository));
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Booking> GetAllBookings()
        {
            return Repository.Bookings;
        }

        [Route("{madatcho}")]
        [HttpGet]
        public Booking GetThongTinMaDatCho(string madatcho)
        {
            return Repository.Bookings.Where(x => x.Ma == madatcho).FirstOrDefault();
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostNewBooking()
        {
            Booking booking = new Booking { 
                Ma = RandomString(6), TongTien = 0, ThoiGianDatCho = DateTime.Now.ToString(), TrangThai = 0
            };
            if (ModelState.IsValid)
            {
                await Repository.SaveBookingAsync(booking);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Adminstrators")]
        public async Task DeleteBooking(int id)
        {
            await Repository.DeleteBookingAsync(id);
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
