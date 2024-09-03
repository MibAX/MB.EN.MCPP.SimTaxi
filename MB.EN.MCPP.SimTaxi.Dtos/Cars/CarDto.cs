using MB.EN.MCPP.SimTaxi.Utils.Enums;

namespace MB.EN.MCPP.SimTaxi.Dtos.Cars
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public int Year { get; set; }
        public string Info { get; set; }
        public CarType CarType { get; set; }
        public PowerType PowerType { get; set; }
        public string DriverFullName { get; set; }
    }
}
