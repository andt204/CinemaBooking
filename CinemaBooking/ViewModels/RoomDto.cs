using CinemaBooking.Data;
using CinemaBooking.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.ViewModels
{
    public class RoomDto
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Room Type is required.")]
        public int RoomTypeId { get; set; }

        [Required(ErrorMessage = "Theater is required.")]
        public int? TheaterId { get; set; }

        [Required(ErrorMessage = "Room Name is required.")]
        [StringLength(100, ErrorMessage = "Room Name must be less than 100 characters.")]
        public string RoomName { get; set; } = null!;

        public RoomStatus Status { get; set; }

        [ValidateNever]
        public RoomTypeDto RoomType { get; set; } = null!;

        [ValidateNever]
        public TheaterDto Theater { get; set; } = null!;    

        // Seats collection for managing seat information
        public List<SeatDto> Seats { get; set; } = new List<SeatDto>();
    }
}
