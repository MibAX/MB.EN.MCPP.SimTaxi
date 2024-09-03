using AutoMapper;
using MB.EN.MCPP.SimTaxi.Dtos.Cars;
using MB.EN.MCPP.SimTaxi.Entities.Cars;

namespace MB.EN.MCPP.SimTaxi.WebApi.AutoMapperProfiles
{
    public class CarAutoMapperProfile : Profile
    {
        public CarAutoMapperProfile()
        {
            CreateMap<Car, CarDto>();
            CreateMap<Car, CarDetailsDto>();
            CreateMap<CreateUpdateCarDto, Car>();
        }
    }
}
