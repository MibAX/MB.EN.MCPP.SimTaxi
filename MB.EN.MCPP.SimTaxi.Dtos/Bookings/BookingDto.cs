using System.ComponentModel.DataAnnotations.Schema;

namespace MB.EN.MCPP.SimTaxi.Dtos.Bookings
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime BookingTime { get; set; }

        [Column(TypeName = "decimal(6,2)")] // $9999.99
        public decimal TotalPrice { get; set; }

        public string CarInfo { get; set; }

        public string DriverFullName { get; set; }
    }
}
