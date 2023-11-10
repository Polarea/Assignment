using System;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace ReflectionConsole
{
	public interface IPerson { string? Name { get; set; } }
	public interface IBooking { int? BookingNo { get; set; } }
	public abstract class Vehicle { public int? RegNo { get; set; } }
	public class Person : IPerson { public string? Name { get; set; } }
	public class Booking : IBooking { public int? BookingNo { get; set; } }
	public class Car : Vehicle { }
	public class PersonCollection
	{
		public List<IPerson> persons = new List<IPerson>();
		public List<IBooking> bookings = new List<IBooking>() { new Booking() { BookingNo = 852 }, new Booking() { BookingNo = 952 } };
		public List<Vehicle> vehicles = new List<Vehicle>();

		IList? GetIList<T>()
		{
			IList? list = null;
			foreach (var field in this.GetType().GetFields())
			{
				if (field.FieldType.GetGenericTypeDefinition() == typeof(List<>))
				{
					if (field.FieldType.GetGenericArguments().SequenceEqual(typeof(T).GetInterfaces()))
					{
						list = (IList)field.GetValue(this)!;
					}
					else if (field.FieldType.GetGenericArguments()[0] == typeof(T).BaseType)
					{
						list = (IList)field.GetValue(this)!;
					}
				}
			}
			return list;
		}

		public List<T>? Get<T>()
		{
			IList? list = GetIList<T>();
			var listOfT = new List<T>();
			foreach (var field in this.GetType().GetFields())
			{
				if (field.FieldType.GetGenericTypeDefinition() == typeof(List<>) && field.FieldType.GetGenericArguments()[0] == typeof(T))
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

		public T Single<T>(Expression<Func<T, bool>> _expression)
		{
			var expression = _expression.Compile();
			return Get<T>()!.Single(expression);
		}
	}
	public static class Program
	{
		static void Main(string[] args)
		{
			PersonCollection collection = new PersonCollection();
			collection.Add(new Person() { Name= "Ali"});
			collection.Add(new Booking() { BookingNo = 213 });
			Console.WriteLine(collection.Single<Booking>(b => b.BookingNo == 852).BookingNo);
			foreach (var item in collection.Get<Booking>())
			{
				Console.WriteLine(item.BookingNo);
			}
			//foreach (var item in collection.GetType().GetFields())
			//{
			//	if (item.FieldType.GetGenericTypeDefinition() == typeof(List<>) && item.FieldType.GetGenericArguments()[0] == typeof(Vehicle))
			//	{
			//		Console.WriteLine(item.Name);
			//	}
			//}
		}
	}
}