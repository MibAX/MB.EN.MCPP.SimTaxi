using MB.EN.MCPP.SimTaxi.Utils.Enums;

namespace MB.EN.MCPP.SimTaxi.Dtos.Cars
{
    public class CreateUpdateCarDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public DateTime ProductionDate { get; set; }
        public CarType CarType { get; set; }
        public PowerType PowerType { get; set; }
        public int? DriverId { get; set; }
    }
}
