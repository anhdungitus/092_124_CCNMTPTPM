using System;
using System.ComponentModel.DataAnnotations;
namespace DatVeMayBay.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        [Required]
        public string MaDatCho { get; set; }
        [Required]
        public string DanhXung { get; set; }
        [Required]
        public string Ho { get; set; }
        [Required]
        public string Ten { get; set; }
    }
}