using AutoMapper;
using MB.EN.MCPP.SimTaxi.Dtos.Passengers;
using MB.EN.MCPP.SimTaxi.Entities.Passengers;

namespace MB.EN.MCPP.SimTaxi.WebApi.AutoMapperProfiles
{
    public class PassengerAutoMapperProfile : Profile
    {
        public PassengerAutoMapperProfile()
        {
            CreateMap<Passenger, PassengerDto>();
            CreateMap<Passenger, PassengerDetailsDto>();
            CreateMap<CreateUpdatePassengerDto, Passenger>();
        }
    }
}
