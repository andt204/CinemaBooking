using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services
{
    public class RoomTypeService
    {
        private readonly CinemaBookingContext _context;
        private readonly IMapper _mapper;

        public RoomTypeService(CinemaBookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RoomTypeDto>> GetAllRoomTypesAsync()
        {
            var roomTypes = await _context.RoomTypes.ToListAsync();
            return _mapper.Map<List<RoomTypeDto>>(roomTypes);
        }
    }
}
