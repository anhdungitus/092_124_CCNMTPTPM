using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatVeMayBay.Models
{
    public class FlightRepository : IRepository
    {
        private FlightDbContext context = new FlightDbContext();

        public IEnumerable<Flight> Flights
        {
            get { return context.Flights; }
        }

        public async Task<int> SaveFlightAsync(Flight flight)
        {
            if (flight.Id == 0)
            {
                context.Flights.Add(flight);
            }
            else
            {
                Flight dbEntry = context.Flights.Find(flight.Id);
                if (dbEntry != null)
                {
                    dbEntry.Ma = flight.Ma;
                    dbEntry.NoiDi = flight.NoiDi;
                    dbEntry.NoiDen = flight.NoiDen;
                    dbEntry.Ngay = flight.Ngay;
                    dbEntry.Gio = flight.Gio;
                    dbEntry.Hang = flight.Hang;
                    dbEntry.MucGia = flight.MucGia;
                    dbEntry.SoLuongGhe = flight.SoLuongGhe;
                    dbEntry.GiaBan = flight.GiaBan;
                }
            }
            return await context.SaveChangesAsync();
        }

        public async Task<Flight> DeleteFlightAsync(int flightID)
        {
            Flight dbEntry = context.Flights.Find(flightID);
            if (dbEntry != null)
            {
                context.Flights.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }

        public IEnumerable<Booking> Bookings
        {
            get { return context.Bookings; }
        }

        public async Task<int> SaveBookingAsync(Booking booking)
        {
            if (booking.Id == 0)
            {
                context.Bookings.Add(booking);
            }
            else
            {
                Booking dbEntry = context.Bookings.Find(booking.Id);
                if (dbEntry != null)
                {
                    dbEntry.Ma = booking.Ma;
                    dbEntry.ThoiGianDatCho = booking.ThoiGianDatCho;
                    dbEntry.TongTien = booking.TongTien;
                    dbEntry.TrangThai = booking.TrangThai;
                }
            }
            return await context.SaveChangesAsync();
        }

        public async Task<Booking> DeleteBookingAsync(int BookingID)
        {
            Booking dbEntry = context.Bookings.Find(BookingID);
            if (dbEntry != null)
            {
                context.Bookings.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }

        public IEnumerable<FlightDetail> FlightDetails
        {
            get { return context.FlightDetails; }
        }

        public async Task<int> SaveFlightDetailAsync(FlightDetail flightdetail)
        {
            if (flightdetail.Id == 0)
            {
                context.FlightDetails.Add(flightdetail);
            }
            else
            {
                FlightDetail dbEntry = context.FlightDetails.Find(flightdetail.Id);
                if (dbEntry != null)
                {
                    dbEntry.MaChuyenBay = flightdetail.MaChuyenBay;
                    dbEntry.MaDatCho = flightdetail.MaDatCho;
                    dbEntry.Ngay = flightdetail.Ngay;
                    dbEntry.Hang = flightdetail.Hang;
                    dbEntry.MucGia = flightdetail.MucGia;
                }
            }
            return await context.SaveChangesAsync();
        }

        public async Task<FlightDetail> DeleteFlightDetailAsync(int FlightdetailID)
        {
            FlightDetail dbEntry = context.FlightDetails.Find(FlightdetailID);
            if (dbEntry != null)
            {
                context.FlightDetails.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }
    }
}