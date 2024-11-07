using CinemaBooking.Data;
using CinemaBooking.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaBooking.Services
{
    public class SeatTypeService
    {
        private readonly CinemaBookingContext _context;
        private readonly IMapper _mapper;

        public SeatTypeService(CinemaBookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Method to get all seat types from the database
        public async Task<List<SeatTypeDto>> GetAllSeatTypesAsync()
        {
            var seatTypes = await _context.SeatTypes.ToListAsync();
            return _mapper.Map<List<SeatTypeDto>>(seatTypes);
        }
    }
}
