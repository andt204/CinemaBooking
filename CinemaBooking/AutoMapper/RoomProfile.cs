using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.Enum;
using CinemaBooking.ViewModels;

namespace CinemaBooking.AutoMapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>()
                 .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType))    // Maps RoomType details
                 .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => src.Theater))      // Maps Theater details
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (RoomStatus)src.Status)) // Maps Status enum
                 .ReverseMap()
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (byte)src.Status)); // Converts RoomStatus to byte for database

            CreateMap<RoomType, RoomTypeDto>()
                .ForMember(dest => dest.NumberOfSeat, opt => opt.MapFrom(src => src.NumberOfSeat ?? 0))
                .ForMember(dest => dest.NumberOfColumn, opt => opt.MapFrom(src => src.NumberOfColumn ?? 0))
                .ForMember(dest => dest.NumberOfRow, opt => opt.MapFrom(src => src.NumberOfRow ?? 0))
                .ReverseMap();
        }
    }
}
