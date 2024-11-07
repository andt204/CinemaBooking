using AutoMapper;
using AutoMapper.QueryableExtensions;
using CinemaBooking.Data;
using CinemaBooking.Enum;
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services
{
    public class TheaterAdminService
    {
        private readonly CinemaBookingContext _context;
        private readonly IMapper _mapper;

        public TheaterAdminService(CinemaBookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TheaterDto>> GetAllTheatersAsync()
        {
            var theaters = await _context.Theaters.Include(t => t.Rooms).ThenInclude(r => r.Showtimes).ToListAsync();
            return _mapper.Map<List<TheaterDto>>(theaters);
        }

        public async Task<List<TheaterDto>> GetTheatersByFilterAsync(int? theaterId, string? theaterName, string? location, TheaterStatus? status)
        {
            var query = _context.Theaters
                .Include(t => t.Rooms)
                .ThenInclude(r => r.Showtimes)
                .AsQueryable();

            if (theaterId.HasValue)
            {
                query = query.Where(t => t.TheaterId == theaterId.Value);
            }
            if (!string.IsNullOrEmpty(theaterName))
            {
                query = query.Where(t => t.TheaterName.Contains(theaterName));
            }
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(t => t.Location.Contains(location));
            }
            if (status.HasValue)
            {
                //query = query.Where(t => t.Status == (byte)status.Value);
            }

            var theaters = await query.ToListAsync();

            // Sử dụng Mapper để chuyển đổi từ Theater sang TheaterDto
            return _mapper.Map<List<TheaterDto>>(theaters);
        }


        public async Task<TheaterDto?> GetTheaterByIdAsync(int id)
        {
            var theater = await _context.Theaters.Include(t => t.Rooms).ThenInclude(r => r.Showtimes).FirstOrDefaultAsync(t => t.TheaterId == id);
            return theater != null ? _mapper.Map<TheaterDto>(theater) : null;
        }

        public async Task CreateTheaterAsync(TheaterDto theaterDto)
        {
            var theater = _mapper.Map<Theater>(theaterDto);
            _context.Theaters.Add(theater);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTheaterAsync(TheaterDto theaterDto)
        {
            // Find the existing entity
            var theater = await _context.Theaters.FindAsync(theaterDto.TheaterId);

            if (theater != null)
            {
                // Map the updated properties onto the existing entity
                _mapper.Map(theaterDto, theater);

                // Save changes
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteTheaterAsync(int id)
        {
            var theater = await _context.Theaters.FindAsync(id);
            if (theater != null)
            {
                _context.Theaters.Remove(theater);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SetTheaterStatusAsync(int theaterId, TheaterStatus status)
        {
            var theater = await _context.Theaters.FindAsync(theaterId);
            if (theater != null)
            {
               /* theater.Status = (byte)status;*/  // Assuming Status is stored as a byte in the database
                await _context.SaveChangesAsync();
            }
        }

    }
}
