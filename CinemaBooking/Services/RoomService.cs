using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.Enum;
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services
{
    public class RoomService
    {
        private readonly CinemaBookingContext _context;
        private readonly IMapper _mapper;

        public RoomService(CinemaBookingContext context, IMapper mapper)
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
                        Status = room.Theater.Status == 0 ? TheaterStatus.Available : TheaterStatus.Unavailable
                    } : null
                })
                .ToListAsync();
        }

        public async Task CreateRoomAsync(RoomDto roomDto)
        {
            // Map RoomDto to Room entity
            var room = _mapper.Map<Room>(roomDto);

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task<RoomDto?> GetRoomByIdAsync(int roomId)
        {
            var room = await _context.Rooms
                .Include(r => r.RoomType)
                .Include(r => r.Theater)
                .FirstOrDefaultAsync(r => r.RoomId == roomId);

            return room != null ? _mapper.Map<RoomDto>(room) : null;
        }

        public async Task UpdateRoomAsync(RoomDto roomDto)
        {
            // Find the existing room entity
            var room = await _context.Rooms.FindAsync(roomDto.RoomId);

            if (room == null)
            {
                throw new KeyNotFoundException("Room not found.");
            }

            // Update the entity with the new values from the DTO
            _mapper.Map(roomDto, room);

            await _context.SaveChangesAsync();
        }
        public async Task SetRoomStatusAsync(int roomId, RoomStatus status)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room != null)
            {
                room.Status = (byte)status; 
                await _context.SaveChangesAsync();
            }
        }


    }
}
