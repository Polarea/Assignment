using RentCar.Common.Classes;
using RentCar.Common.Enums;

namespace RentCar.App.Pages
{
	public partial class Index
	{
		string regNo = string.Empty;
		string brand = string.Empty;
		int odometer;
		double costKm;
		VehicleTypes vehicleType;
		double costDay;
		string? customer;
		string ssn = string.Empty;
		string firstname = string.Empty;
		string lastname = string.Empty;
		static bool processing;
		int updatedKm;
		bool isDisabled	= false;
		string error = string.Empty;
		
		

		void AddVehicle()
		{
			error = string.Empty;

			if ((regNo, brand) == ("", "") || bookingprocessor.Get<Vehicle>().Any(v => v.RegNo == regNo))
			{
				error = "Vehicle already exists or invalid entry!";
			}

			else if (vehicleType == VehicleTypes.Motorcycle)
			{
				Motorcycle mc = new (bookingprocessor.NextVehicleId, regNo, brand, odometer, vehicleType, costKm, costDay);
				bookingprocessor.Add<Motorcycle>(mc);
			}
			else
			{
				Car car = new (bookingprocessor.NextVehicleId, regNo, brand, odometer, vehicleType, costKm, costDay);
				bookingprocessor.Add<Car>(car);
			}

			(regNo, brand, odometer, costKm, costDay) = ("", "", 0, 0, 0);
		}

		void AddCustomer()
		{
			if (bookingprocessor.Get<Customer>().Any(c => c.Ssn == ssn) || (ssn, firstname, lastname) == ("", "", ""))
			{
				error = "Customer already exists or invalid entry!";
			}
			else
			{
				bookingprocessor.Add<Customer>(new Customer(bookingprocessor.NextPersonId ,ssn, firstname, lastname));
			}
			(ssn, firstname, lastname) = ("", "", "");
		}

		async Task RentOrReturn(Vehicle vehicle)
		{
			try
			{
				if (vehicle.VehicleStatus == VehicleStatuses.Available)
				{
					processing = true;
					isDisabled = true;
					await Task.Delay(5000);
					Customer c = (Customer)bookingprocessor.Get<Customer>().Single(c => $"{c.FirstName} {c.LastName}".Equals(customer));
					bookingprocessor.Add<Booking>(new Booking(bookingprocessor.NextBookingId, vehicle.Id, c.Id, vehicle.Odometer));
					vehicle.VehicleStatus = VehicleStatuses.Booked;
					processing = false;
				}
				else
				{
					Booking booking = (Booking)bookingprocessor.Get<Booking>().Single(b => b.VehicleId == vehicle.Id && b.BookingStatus == BookingStatuses.open)!;
					bookingprocessor.ReturnVehicle(vehicle.Id, updatedKm);
				}
			}
			catch
			{
				error = "Invalid entry!";
			}
		}
		//List<T> Get<T>()
		//{
			
		//	try
		//	{
		//		Type type = typeof(BookingProcessor);
		//		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
		//		return (List<T>)fields.Where(f => f.FieldType == typeof(List<T>));
		//	}
		//	catch (Exception ex)
		//	{
				
		//		ex.ToString();
		//		return new List<T>();
		//	}
			
		//}
	}
}
