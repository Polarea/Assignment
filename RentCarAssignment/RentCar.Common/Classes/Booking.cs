using RentCar.Common.Enums;
using RentCar.Common.Interfaces;

namespace RentCar.Common.Classes
{
	public class Booking : IBooking
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

		public Booking(int bookingId, int vehicleId, int customerId, int kmRented)
		{
			Id = bookingId;
			IPersonId = customerId;
			VehicleId = vehicleId;
			KmRented = kmRented;
			DateRented = DateTime.Today;
			BookingStatus = BookingStatuses.open;
		}

		public void CloseBooking(double priceKm, double priceDay, int kmReturned)
		{
			KmReturned = (kmReturned <= KmRented) ? KmRented : kmReturned;
			DateReturned = DateTime.Today;
			int totalKm = KmReturned - KmRented;
			int totalDays = DateReturned.Day - DateRented.Day;
			TotalCost = (double)((totalKm * priceKm) + (totalDays * priceDay));
			BookingStatus = BookingStatuses.closed;
		}

	}
	//  public class Booking : Rent, IBooking
	//  {
	////      public int KmReturned { get; set; }
	////      public DateOnly DateRented { get; set; }
	////public DateOnly DateReturned { get; set; }
	////public double TotalCost { get; set; }
	////      public BookingStatuses bookingStatus { get; set; }

	////public Booking (Vehicle vehicle, Customer customer)
	////      {
	////          FirstName = (customer is null) ? string.Empty : customer.FirstName;
	////          LastName = (customer is null) ? string.Empty : customer.LastName;
	////          Ssn = (customer is null) ? string.Empty : customer.Ssn;
	////	RegNo = (customer is null) ? string.Empty : vehicle.RegNo;
	////          Odometer = vehicle.Odometer;
	////          DateRented = DateOnly.MinValue;
	////          bookingStatus = BookingStatuses.open;
	////          DateReturned = default;            
	////      }

	////      public void CloseBooking(Vehicle vehicle, int km)
	////      {
	////	DateReturned = DateOnly.MinValue;
	////          KmReturned = km <= Odometer ? Odometer : km;
	////	int totalKm = KmReturned - Odometer;
	////	int totalDays = DateReturned.Day - DateRented.Day;
	////          bookingStatus = BookingStatuses.closed;
	////          vehicle.VehicleStatus = VehicleStatuses.Available;
	////          vehicle.Odometer = KmReturned;
	////	TotalCost = (double)((totalKm * vehicle.PriceKm) + (totalDays * vehicle.PriceDay));
	//}
	//  }

}
