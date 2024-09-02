using MB.EN.MCPP.SimTaxi.Entities.Drivers;
using MB.EN.MCPP.SimTaxi.Utils.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MB.EN.MCPP.SimTaxi.Entities.Cars
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public DateTime ProductionDate { get; set; }

        public CarType CarType { get; set; }
        public PowerType PowerType { get; set; }


        [NotMapped]
        public int Year
        {
            get
            {
                return ProductionDate.Year;
            }
        }

        [NotMapped]
        public string Info
        {
            get
            {
                return $"{Model} - {PlateNumber}";
            }
        }

        public int? DriverId { get; set; }
        public Driver? Driver { get; set; }

    }
}
