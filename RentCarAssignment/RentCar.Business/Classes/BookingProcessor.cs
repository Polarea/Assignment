using RentCar.Common.Classes;
using RentCar.Common.Enums;
using RentCar.Common.Interfaces;
using RentCar.Data.Interfaces;
using System.Linq.Expressions;

namespace RentCar.Business.Classes
{
	public class BookingProcessor
	{
		readonly IData _db;
		public BookingProcessor(IData db) => _db = db;
		public string? Error { get; set; } = null;
		public bool Processing = true;
		public int NextPersonId => _db.NextPersonId;
		public int NextVehicleId => _db.NextVehicleId;
		public int NextBookingId => _db.NextBookingId;
		public IEnumerable<T> Get<T>() => _db.Get<T>();
		public T? Single<T>(Expression<Func<T, bool>> expression) => _db.Single<T>(expression);
		public void Add<T>(T item) => _db.Add<T>(item);
		public void RentVehicle(int vehicleId, int customerId) => _db.RentVehicle(vehicleId, customerId);
		public void ReturnVehicle(int vehicleId, int kmReturned) => _db.ReturnVehicle(vehicleId, kmReturned);
		public string[] VehicleStatusNames() => _db.VehicleStatusNames();
		public string[] VehicleTypeNames() => _db.VehicleTypeNames();
		public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);
	}
	//public class BookingProcessor
	//{
	//    IData _data;

	//    public BookingProcessor(IData data) => _data = data;

	//    public IEnumerable<IVehicle> GetVehicles() => _data.GetVehicles();

	//    public IEnumerable<IPerson> GetCustomers() => _data.GetPersons();

	//    public IEnumerable<IBooking> GetBookings() => _data.GetBookings();

	//    public void AddVehicle(IVehicle vehicle) { _data.AddVehicle(vehicle); }
	//    public void AddCustomer(IPerson person) {  _data.AddPerson(person); }
	//    public void AddBooking(IBooking booking) { _data.AddBooking(booking);}
	//}
}
