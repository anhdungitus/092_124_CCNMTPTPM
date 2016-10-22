using System;
using System.ComponentModel.DataAnnotations;

namespace DatVeMayBay.Models
{
    public class Flight
    {
        public int Id { get; set; }
        [Required]
        public string Ma { get; set; }
        [Required]
        [StringLength(3)]
        public string NoiDi { get; set; }
        [Required]
        [StringLength(3)]
        public string NoiDen { get; set; }
        [Required]
        public string Ngay { get; set; }
        [Required]
        public string Gio { get; set; }
        [Required]
        public string Hang { get; set; }
        [Required]
        public string MucGia { get; set; }
        [Required]
        public int SoLuongGhe { get; set; }
        [Required]
        public int GiaBan { get; set; }
    }

    public class FlightDetail
    {
        public int Id { get; set; }
        [Required]
        public string MaDatCho { get; set; }
        [Required]
        public string MaChuyenBay { get; set; }
        [Required]
        public string Ngay { get; set; }
        [Required]
        public string Hang { get; set; }
        [Required]
        public string  MucGia { get; set; }
    }
}