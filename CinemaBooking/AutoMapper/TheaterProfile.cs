using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.ViewModels;
using System.Linq;

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
                .ReverseMap();
        }
    }
}
