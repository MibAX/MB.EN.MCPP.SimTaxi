using AutoMapper;
using MB.EN.MCPP.SimTaxi.Dtos.Bookings;
using MB.EN.MCPP.SimTaxi.Entities.Bookings;

namespace MB.EN.MCPP.SimTaxi.WebApi.AutoMapperProfiles
{
    public class BookingAutoMapperProfile : Profile
    {
        public BookingAutoMapperProfile()
        {
            CreateMap<Booking, BookingDto>();
            CreateMap<Booking, BookingDetailsDto>();

            CreateMap<CreateUpdateBookingDto, Booking>();
        }
    }
}
