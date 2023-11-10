using RentCar.Common.Interfaces;
using RentCar.Data.Interfaces;
using RentCar.Common.Enums;
using RentCar.Common.Classes;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections;

namespace RentCar.Data.Classes

{
    public class CollectionData : IData
    {
		List<Vehicle> _vehicles = new List<Vehicle>();
		List<IBooking> _bookings = new List<IBooking>();
		List<IPerson> _customers = new List<IPerson>();
		int personId = 0;
		int vehicleId = 0;
		int bookingId = 0;
		public int NextVehicleId { get { return Interlocked.Increment(ref vehicleId); } }

		public int NextPersonId { get { return Interlocked.Increment(ref personId); } }

		public int NextBookingId { get { return Interlocked.Increment(ref bookingId); } }

		public (List<Vehicle>, List<IBooking>, List<IPerson>) CollectionList()
		{
			return (_vehicles, _bookings, _customers);
		}

		public IList? GetIList<T>()
		{
			foreach (var field in GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
			{
				if (field.FieldType.IsGenericType)
				{
					if (field.FieldType.GetGenericTypeDefinition() == typeof(List<>))
					{
						if (field.FieldType.GetGenericArguments().SequenceEqual(typeof(T).GetInterfaces()))
						{
							return (IList)field.GetValue(this)!;
						}
						else if (field.FieldType.GetGenericArguments()[0] == typeof(T).BaseType)
						{
							return (IList)field.GetValue(this)!;
						}
					}
				}
			}
			return null;
		}

		public IEnumerable<T> Get<T>()
		{
			IList? list = GetIList<T>();
			List<T> listOfT = new();
			foreach (var field in GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
			{
				if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>) && field.FieldType.GetGenericArguments()[0] == typeof(T))
				{
					listOfT = (List<T>?)field.GetValue(this)!;
				}
			}
			if (list is not null)
			{
				foreach (var item in list)
				{
					if (item is T t)
					{
						listOfT.Add(t);
					}
				}
			}
			return listOfT;
		}

		public void Add<T>(T item)
		{
			GetIList<T>()?.Add(item);
		}

		public T Single<T>(Expression<Func<T, bool>>? _expression)
		{
			var expression = _expression?.Compile();
			return Get<T>()!.Single(expression!);
		}
		public void RentVehicle(int vehicleId, int customerId)
		{
			void Book(Vehicle vehicle)
			{
				int kmRented = vehicle.Odometer;
				Booking booking = new(NextBookingId, vehicleId, customerId, kmRented);
				Add<Booking>(booking);
				vehicle.VehicleStatus = VehicleStatuses.Booked;
			}
			if (Single<Vehicle>(v => v.Id == vehicleId) is Car car)
			{
				Book(car);
			}
			else if (Single<Vehicle>(v => v.Id == vehicleId) is Motorcycle mc)
			{
				Book(mc);
			}
		}

		public void ReturnVehicle(int vehicleId, int kmReturned)
		{
			Booking booking = Single<Booking>(b => b.VehicleId == vehicleId && b.BookingStatus == BookingStatuses.open);
			Vehicle? vehicle = Single<Vehicle>(v => v.Id == vehicleId);
			double priceKm = vehicle!.PriceKm;
			double priceDay = vehicle.PriceDay;
			booking?.CloseBooking(priceKm, priceDay, kmReturned);
			vehicle.Odometer = kmReturned;
			vehicle.VehicleStatus = VehicleStatuses.Available;
		}
		//      List<IVehicle> _vehicles = new();
		//      List<IBooking> _bookings = new();
		//      List<IPerson> _persons = new();

		//      public IEnumerable<IBooking> GetBookings() => _bookings;

		//      public IEnumerable<IPerson> GetPersons() => _persons;

		//public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = 0) => _vehicles;

		//      public void AddVehicle(IVehicle vehicle) => _vehicles.Add(vehicle);

		//      public void AddBooking(IBooking booking) => _bookings.Add(booking);

		//      public void AddPerson(IPerson person) => _persons.Add(person);
	}

}
