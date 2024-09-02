using MB.EN.MCPP.SimTaxi.Entities.Bookings;
using MB.EN.MCPP.SimTaxi.Utils.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MB.EN.MCPP.SimTaxi.Entities.Passengers
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [NotMapped]
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        public List<Booking> Bookings { get; set; }
    }
}
