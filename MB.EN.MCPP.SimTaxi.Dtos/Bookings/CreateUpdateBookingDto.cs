using System.ComponentModel.DataAnnotations.Schema;

namespace MB.EN.MCPP.SimTaxi.Dtos.Bookings
{
    public class CreateUpdateBookingDto
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime BookingTime { get; set; }

        [Column(TypeName = "decimal(6,2)")] // $9999.99

        public int? CarId { get; set; }

        public int? DriverId { get; set; }

        public List<int> PassengerIds { get; set; } = [];
    }
}
