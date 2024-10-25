namespace CinemaBooking.ViewModels
{
	public class RoomTypeDto
	{
		public int RoomTypeId { get; set; }
		public string RoomTypeName { get; set; } = null!;
		public int NumberOfSeat { get; set; }
		public int NumberOfColumn { get; set; }
		public int NumberOfRow { get; set; }
	}
}
