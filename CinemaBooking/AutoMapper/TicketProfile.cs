using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.Enum;
using CinemaBooking.ViewModels;

namespace CinemaBooking.AutoMapper
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>()
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (TicketStatus)src.Status))
           .ReverseMap()
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (byte)src.Status));
        }
    }
}
