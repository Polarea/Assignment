using RentCar.Common.Enums;
using RentCar.Common.Interfaces;

namespace RentCar.Common.Classes
{
	public class Car : Vehicle
	{
		public Car(int id, string regNo, string brand, int odometer, VehicleTypes vehicleTypes, double priceKm, double priceDay) :
			base(id, regNo, brand, odometer, vehicleTypes, priceKm, priceDay)
		{
		}
	}
}
