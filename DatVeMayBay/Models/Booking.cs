using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;

namespace DatVeMayBay.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Key]
        public string Ma { get; set; }
        [Required]
        public string ThoiGianDatCho { get; set; }
        [Required]
        public int TongTien { get; set; }
        [Required]
        public int TrangThai { get; set; }
    }
}