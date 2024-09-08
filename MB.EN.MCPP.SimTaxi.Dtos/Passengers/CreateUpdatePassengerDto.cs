using MB.EN.MCPP.SimTaxi.Utils.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MB.EN.MCPP.SimTaxi.Dtos.Passengers
{
    public class CreateUpdatePassengerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
