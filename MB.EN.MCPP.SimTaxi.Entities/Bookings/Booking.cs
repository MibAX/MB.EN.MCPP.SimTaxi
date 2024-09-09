using MB.EN.MCPP.SimTaxi.Entities.Cars;
using MB.EN.MCPP.SimTaxi.Entities.Drivers;
using MB.EN.MCPP.SimTaxi.Entities.Passengers;
using System.ComponentModel.DataAnnotations.Schema;

namespace MB.EN.MCPP.SimTaxi.Entities.Bookings
{
    public class Booking
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime BookingTime { get; set; }

        [Column(TypeName = "decimal(6,2)")] // $9999.99
        public decimal TotalPrice { get; set; }

        public int? CarId { get; set; }
        public Car? Car { get; set; }

        public int? DriverId { get; set; }
        public Driver? Driver { get; set; }

        public List<Passenger> Passengers { get; set; } = [];
    }
}
