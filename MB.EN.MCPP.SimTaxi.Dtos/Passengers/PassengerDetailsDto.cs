using MB.EN.MCPP.SimTaxi.Utils.Enums;

namespace MB.EN.MCPP.SimTaxi.Dtos.Passengers
{
    public class PassengerDetailsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

        // TO DO
        //public List<BookingDto> Bookings { get; set; }
    }
}
