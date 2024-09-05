using MB.EN.MCPP.SimTaxi.Dtos.Cars;
using MB.EN.MCPP.SimTaxi.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.EN.MCPP.SimTaxi.Dtos.Drivers
{
    public class DriverDetailsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }

        public List<CarDto> Cars { get; set; } = [];
    }
}
