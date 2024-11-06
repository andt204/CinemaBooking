using AutoMapper;
using CinemaBooking.Data;
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
using CinemaBooking.VnPayModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Customer.Payment
{
    public class PaymentModel : PageModel
    {
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

        public Data.Ticket Ticket { get; set; }
        public Data.Movie Movie { get; set; }
        public Data.Theater Theater { get; set; }
		public List<Data.Seat> Seats { get; set; } = new List<Data.Seat>();

		public Data.Room Room { get; set; }
        public Data.Showtime Showtime { get; set; }
        public Data.TicketMovieAssignment TicketMovieAssignment { get; set; }
        private DateTime BookingTime;
        private Data.TicketSeatAssignment TicketSeatAssignment { get; set; }
        public string Status { get; set; }
        private DateTime PublishTime;
        public string formattedBookingTime;
        public string formattedPublishTime;

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
            Ticket = await _ticketRepository.GetByIdAsync(id);
            var ticketMovieAssignmentId = TempData["TicketMovieAssignmentId"] as int?;
			TicketMovieAssignment = await _ticketMovieRepository.GetByIdAsync(ticketMovieAssignmentId ?? 0);
			//Movie = await _movieRepository.GetByIdAsync(TicketMovieAssignment.MovieId);
            //Room = await _roomRepository.GetByIdAsync(TicketMovieAssignment.RoomId);
            // Retrieve the associated seats from the seat repository
            var seatIds = _context.TicketSeatAssignments
	            .Where(x => x.TicketId == id)
	            .Select(tsa => tsa.SeatId)
	            .ToList();

			Seats = _context.Seats
				.Where(s => seatIds.Contains(s.SeatId))
				.ToList();

			Showtime = await _showtimeRepository.GetByIdAsync(Ticket.ShowtimeId);
            //Theater = await _theaterRepository.GetByIdAsync(Showtime.TheaterId);
            BookingTime = Ticket.BookingTime;

            formattedBookingTime = BookingTime.ToString("HH:mm dd-MM-yyyy");
            if (Ticket.Status == 1)
            {
                Status = "Booked";
            }
            else
            {
                Status = "Not Booked";
            }
            PaymentRequest = new VnPaymentRequestModel
            {
                Amount = Math.Floor(Ticket.TicketPrice ?? 0),
                TicketId = Ticket.TicketId
                
            };
            // Console.WriteLine($"OnGetAsync - PaymentRequest.Amount: {PaymentRequest.Amount}");

            //PublishTime = Movie.PublishTime;
            //formattedPublishTime = PublishTime.ToString("dd-MM-yyyy");
            // Showtime = await _showtimeRepository.GetByIdAsync(Showtime.ShowtimeId);

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