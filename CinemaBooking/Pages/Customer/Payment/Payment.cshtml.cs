using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.Helper;
using CinemaBooking.Repositories;
using CinemaBooking.Repositories.Movie;
using CinemaBooking.Repositories.Room;
using CinemaBooking.Repositories.Seat;
using CinemaBooking.Repositories.Showtime;
using CinemaBooking.Repositories.Theater;
using CinemaBooking.Repositories.Ticket;
using CinemaBooking.Repositories.TicketMovie;
using CinemaBooking.Repositories.TicketPrice;
using CinemaBooking.Repositories.TicketSeat;
using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using CinemaBooking.VnPayModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace CinemaBooking.Pages.Customer.Payment
{
    // [Authorize(Roles = "Customer")]
    public class PaymentModel : PageModel
    {
      
        [BindProperty]
        public Data.Account account { get; set; }
        private readonly CinemaBookingContext _context;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IShowtimeRepository _showtimeRepository;
        private readonly ITicketMovieRepository _ticketMovieRepository;
        private readonly ITheaterRepository _theaterRepository;
        private readonly ITicketSeatRepository _ticketSeatRepository;
        private readonly IVnPayService _vnPayService;
        [BindProperty] public VnPaymentRequestModel PaymentRequest { get; set; }
[BindProperty] public List<SeatDto> Seat { get; set; }
      
        private DateTime BookingTime;
        public string Status { get; set; }
        private DateTime PublishTime;
        public string formattedBookingTime;
        public string formattedPublishTime;
        [BindProperty] public PaymentDto TicketInfo { get; set; }

        public PaymentModel(
            IMovieRepository movieRepository,
            ITicketRepository ticketRepository,
            ISeatRepository seatRepository,
            IRoomRepository roomRepository,
            IShowtimeRepository showtimeRepository,
            ITicketMovieRepository ticketMovieRepository,
            ITheaterRepository theaterRepository,
            ITicketSeatRepository ticketSeatRepository,
            IVnPayService vnPayService, CinemaBookingContext context, IMapper mapper
        )
        {
            _movieRepository = movieRepository;
            _ticketRepository = ticketRepository;
            _seatRepository = seatRepository;
            _roomRepository = roomRepository;
            _showtimeRepository = showtimeRepository;
            _ticketMovieRepository = ticketMovieRepository;
            _theaterRepository = theaterRepository;
            _ticketSeatRepository = ticketSeatRepository;
            _vnPayService = vnPayService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // var token = Request.Cookies["jwtToken"];
            // if (token != null)
            // {
            //     var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
            //     if (email != null)
            //     {
            //         account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
            //         ViewData["Account"] = account; // Truyền dữ liệu account vào ViewData
            //     }
            // }
            TicketInfo = await (from t in _context.Tickets
                join s in _context.Showtimes on t.ShowtimeId equals s.ShowtimeId
                join m in _context.Movies on s.MovieId equals m.MovieId
                join r in _context.Rooms on s.RoomId equals r.RoomId
                join th in _context.Theaters on r.TheaterId equals th.TheaterId
                where t.TicketId == id
                select new PaymentDto
                {
                    Title = m.Title,
                    TheaterName = th.TheaterName,
                    Location = th.Location,
                    Date = s.Date,
                    StartHour = s.StartHour,
                    TicketPrice = t.TicketPrice
                }).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
            
            Seat = await (from t in _context.Tickets
                    join ts in _context.TicketSeatAssignments on t.TicketId equals ts.TicketId
                    join s in _context.Seats on ts.SeatId equals s.SeatId
                    where t.TicketId == id
                        select new SeatDto
                    {
                        SeatId = s.SeatId,
                        Column = s.Column,
                        Row = s.Row
                    }
                ).ToListAsync()  ?? throw new InvalidOperationException();
            BookingTime = TicketInfo.Date;

            formattedBookingTime = BookingTime.ToString("dd-MM-yyyy");


            PaymentRequest = new VnPaymentRequestModel
            {
                Amount = Math.Floor(TicketInfo.TicketPrice ?? 0),
                TicketId = id
            };

            return Page();
        }


        public IActionResult OnPost()
        {
            PaymentRequest.OrderId = "1";
            PaymentRequest.Description = "Vé xem phim";
            PaymentRequest.CreatedDate = DateTime.Now;
            return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, PaymentRequest));
        }
    }
}