using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.Enum;
using CinemaBooking.ViewModels;
using CinemaBooking.ViewModels.Request;

namespace CinemaBooking.AutoMapper
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            CreateMap<Seat, SeatDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (SeatStatus)src.Status))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (byte)src.Status));

            CreateMap<SeatType, SeatTypeDto>().ReverseMap();

            CreateMap<SeatDto, UpdateSeatRequest>().ReverseMap();

            CreateMap<Seat, UpdateSeatRequest>().ReverseMap();
        }
    }
}
