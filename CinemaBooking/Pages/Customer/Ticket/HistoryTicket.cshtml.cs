using CinemaBooking.Data;
using CinemaBooking.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CinemaBooking.Pages.Customer.Ticket
{
    [Authorize(Roles = "Customer")]
    public class HistoryTicketModel : PageModel
    {
        private readonly CinemaBookingContext _context;
        [BindProperty]
        public Data.Account account { get; set; }

        public HistoryTicketModel(CinemaBookingContext context)
        {
            _context = context;
        }

        [BindProperty] public List<SeatDto> Seat { get; set; }
      
        private DateTime BookingTime;
        public string Status { get; set; }
        private DateTime PublishTime;
        public string formattedBookingTime;
        public string formattedPublishTime;
        [BindProperty] public List<PaymentDto> TicketInfo { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            int idAccount = 0;
            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
                    idAccount = account.AccountId;
                    ViewData["Account"] = account; // Pass account data to ViewData
                }
            }
            TicketInfo = await (from t in _context.Tickets
                join s in _context.Showtimes on t.ShowtimeId equals s.ShowtimeId
                join m in _context.Movies on s.MovieId equals m.MovieId
                join r in _context.Rooms on s.RoomId equals r.RoomId
                join th in _context.Theaters on r.TheaterId equals th.TheaterId
                where t.AccountId == idAccount
                select new PaymentDto
                {
                    TicketId = t.TicketId,
                    Title = m.Title,
                    TheaterName = th.TheaterName,
                    Location = th.Location,
                    Date = s.Date,
                    StartHour = s.StartHour,
                    TicketPrice = t.TicketPrice
                }).ToListAsync() ?? throw new InvalidOperationException();
            
            Seat = await (from t in _context.Tickets
                    join ts in _context.TicketSeatAssignments on t.TicketId equals ts.TicketId
                    join s in _context.Seats on ts.SeatId equals s.SeatId
                    where t.TicketId == idAccount
                    select new SeatDto
                    {
                        SeatId = s.SeatId,
                        Column = s.Column,
                        Row = s.Row
                    }
                ).ToListAsync()  ?? throw new InvalidOperationException();
            // BookingTime = TicketInfo.Date;
            //
            // formattedBookingTime = BookingTime.ToString("dd-MM-yyyy");

            
            
            return Page();
        }

        public class TicketHistoryViewModel
        {
            public int TicketId { get; set; }
            public string MovieTitle { get; set; }
            public string Seat { get; set; }
            public string RoomName { get; set; }
            public string Hour { get; set; }
            public string Date { get; set; }
            public decimal TicketPrice { get; set; }
            public string Status { get; set; }
        }
    }
}