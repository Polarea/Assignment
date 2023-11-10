using RentCar.Common.Enums;
using RentCar.Common.Interfaces;
using System.Linq.Expressions;

namespace RentCar.Data.Interfaces
{
    public interface IData
    {
		IEnumerable<T> Get<T>();
		T Single<T>(Expression<Func<T, bool>>? expression);
		void Add<T>(T item);
		int NextVehicleId { get; }
		int NextPersonId { get; }
		int NextBookingId { get; }
		void RentVehicle(int vehicleId, int customerId);
		void ReturnVehicle(int vehicleId, int kmReturned);
		string[] VehicleStatusNames() => Enum.GetNames(typeof(VehicleStatuses));
		string[] VehicleTypeNames() => Enum.GetNames(typeof(VehicleTypes));
		VehicleTypes GetVehicleType(string name)
		{
			VehicleTypes vehicleType;
			if (Enum.TryParse(name, out vehicleType))
			{
				return vehicleType;
			}
			return default;
		}
		//IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
		//IEnumerable<IBooking> GetBookings();
		//IEnumerable<IPerson> GetPersons();
		//void AddVehicle(IVehicle vehicle);
		//void AddBooking(IBooking booking);
		//void AddPerson(IPerson person);
	}
}
