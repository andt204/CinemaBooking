using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.Enum;
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services
{
    public class RoomAdminService
    {
        private readonly CinemaBookingContext _context;
        private readonly IMapper _mapper;

        public RoomAdminService(CinemaBookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RoomDto>> GetAllRoomsAsync()
        {
            var rooms = await _context.Rooms
                .Include(room => room.RoomType)
                .Include(room => room.Theater)
                .ToListAsync();

            // Use AutoMapper to map the list of Room entities to RoomDto
            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<List<RoomDto>> GetRoomsByFilterAsync(int? roomId, string? roomName, string? roomType, string? status)
        {
            var query = _context.Rooms
                .Include(r => r.RoomType)   // Include RoomType information
                .Include(r => r.Theater)    // Include Theater information
                .AsQueryable();

            if (roomId.HasValue)
            {
                query = query.Where(r => r.RoomId == roomId.Value);
            }

            if (!string.IsNullOrEmpty(roomName))
            {
                query = query.Where(r => r.RoomName.Contains(roomName));
            }

            if (!string.IsNullOrEmpty(roomType))
            {
                query = query.Where(r => r.RoomType.RoomTypeName == roomType);
            }

            if (!string.IsNullOrEmpty(status))
            {
                byte statusByte = status == "Available" ? (byte)0 : (byte)1;
                query = query.Where(r => r.Status == statusByte);
            }

            // Map results to RoomDto with Theater and RoomType information
            return await query
                .Select(room => new RoomDto
                {
                    RoomId = room.RoomId,
                    RoomName = room.RoomName,
                    Status = room.Status == 0 ? RoomStatus.Available : RoomStatus.Unavailable,

                    // Map RoomType to RoomTypeDto
                    RoomType = room.RoomType != null ? new RoomTypeDto
                    {
                        RoomTypeId = room.RoomType.RoomTypeId,
                        RoomTypeName = room.RoomType.RoomTypeName,
                        NumberOfSeat = room.RoomType.NumberOfSeat ?? 0,
                        NumberOfRow = room.RoomType.NumberOfRow ?? 0,
                        NumberOfColumn = room.RoomType.NumberOfColumn ?? 0
                    } : null,

                    // Map Theater to TheaterDto
                    Theater = room.Theater != null ? new TheaterDto
                    {
                        TheaterId = room.Theater.TheaterId,
                        TheaterName = room.Theater.TheaterName,
                        Location = room.Theater.Location,
                        Status = room.Theater.Status == 0 ? TheaterStatus.Active : TheaterStatus.Inactive
                    } : null
                })
                .ToListAsync();
        }
    }
}
