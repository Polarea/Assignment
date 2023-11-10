using RentCar.Common.Enums;

namespace RentCar.Common.Classes
{
	public class Motorcycle : Vehicle
	{
		public Motorcycle(int id, string regNo, string brand, int odometer, VehicleTypes vehicleTypes, double priceKm, double priceDay) :
			base(id, regNo, brand, odometer, vehicleTypes, priceKm, priceDay)
		{
		}
	}
}
