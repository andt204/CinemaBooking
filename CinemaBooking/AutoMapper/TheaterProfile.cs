using AutoMapper;
using CinemaBooking.ViewModels;
using System.Linq;
using CinemaBooking.Enum;
using CinemaBooking.Data;

namespace CinemaBooking.AutoMapper
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
            CreateMap<Theater, TheaterDto>()
                .ForMember(dest => dest.Showtimes,
                           opt => opt.MapFrom(src =>
                               src.Rooms.SelectMany(r => r.Showtimes).ToList()))
                .ForMember(dest => dest.Status,
                           opt => opt.MapFrom(src => (TheaterStatus)(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status,
                           opt => opt.MapFrom(src => (byte?)src.Status));
        }
    }
}
