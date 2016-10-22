using System.Collections.Generic;
using System.Data.Entity;

namespace DatVeMayBay.Models
{
    public class FlightDbInitializer : DropCreateDatabaseAlways<FlightDbContext>
    {
        protected override void Seed(FlightDbContext context)
        {
            new List<Flight> {
                new Flight {Ma = "BL326", NoiDi="SGN", NoiDen="TBB", Ngay="2016-10-05", Gio="08:45", Hang="Y", MucGia="E", SoLuongGhe=100, GiaBan = 1000}, 
                new Flight {Ma = "BL326", NoiDi="SGN", NoiDen="TBB", Ngay="2016-10-05", Gio="08:45", Hang="Y", MucGia="F", SoLuongGhe=20, GiaBan = 10000}, 
                new Flight {Ma = "BL326", NoiDi="SGN", NoiDen="TBB", Ngay="2016-10-05", Gio="08:45", Hang="C", MucGia="G", SoLuongGhe=10, GiaBan = 5000},
                new Flight {Ma = "BL327", NoiDi="TBB", NoiDen="SGN", Ngay="2016-10-06", Gio="08:45", Hang="Y", MucGia="E", SoLuongGhe=100, GiaBan = 1000} 
            }.ForEach(flight => context.Flights.Add(flight));
         
            context.SaveChanges();

            

            new List<Booking> {
                new Booking {Ma = "ABCXYZ", ThoiGianDatCho = "2016-05-01 10:00:00", TongTien = 400000, TrangThai = 1, 
                    FlightDetails = new List<FlightDetail> 
                    { 
                        new FlightDetail {MaDatCho = "ABCXYZ", MaChuyenBay="BL326", Ngay="2016-10-05",Hang="Y", MucGia="E"},
                        new FlightDetail {MaDatCho = "ABCXYZ", MaChuyenBay="BL327", Ngay="2016-10-06",Hang="Y", MucGia="E"}
                    }
                }
            }.ForEach(booking => context.Bookings.Add(booking));

            context.SaveChanges();

            new List<Passenger> {
                new Passenger {MaDatCho="ABCXYZ", DanhXung="MR", Ho="NGUYEN", Ten="VAN A"}, 
                new Passenger {MaDatCho="ABCXYZ", DanhXung="MR", Ho="TRAN", Ten="THI B"}
            }.ForEach(passenger => context.Passengers.Add(passenger));

            context.SaveChanges();
        }
    }
}