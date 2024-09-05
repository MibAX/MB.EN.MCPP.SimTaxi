using AutoMapper;
using MB.EN.MCPP.SimTaxi.Dtos.Drivers;
using MB.EN.MCPP.SimTaxi.Entities.Drivers;

namespace MB.EN.MCPP.SimTaxi.WebApi.AutoMapperProfiles
{
    public class DriverAutoMapperProfile : Profile
    {
        public DriverAutoMapperProfile()
        {
            CreateMap<Driver, DriverDto>();
            CreateMap<Driver, DriverDetailsDto>();
            CreateMap<CreateUpdateDriverDto, Driver>().ReverseMap();
        }
    }
}
