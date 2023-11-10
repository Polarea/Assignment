using RentCar.Common.Enums;

namespace RentCar.Common.Interfaces
{
	public interface IBooking
	{
		public int Id { get; set; }
		public int IPersonId { get; set; }
		public int VehicleId { get; set; }
		public int KmRented { get; set; }
		public int KmReturned { get; set; }
		public DateTime DateRented { get; set; }
		public DateTime DateReturned { get; set; }
		public double TotalCost { get; set; }
		public BookingStatuses BookingStatus { get; set; }

		public void CloseBooking(double priceKm, double priceDay, int kmReturned);
	}
	//  public interface IBooking: IRent
	//  {
	//      public int KmReturned { get; set; }
	//      public DateOnly DateRented { get; set; }
	//public DateOnly DateReturned { get; set; }
	//public double TotalCost { get; set; }
	//      public BookingStatuses bookingStatus { get; set; }
	//  }
}
