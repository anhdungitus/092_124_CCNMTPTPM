using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatVeMayBay.Models
{
    public interface IRepository
    {
        IEnumerable<Flight> Flights { get; }
        Task<int> SaveFlightAsync(Flight flight);
        Task<Flight> DeleteFlightAsync(int flightID);

        IEnumerable<Booking> Bookings { get; }
        Task<int> SaveBookingAsync(Booking booking);
        Task<Booking> DeleteBookingAsync(int bookingID);
    }
}