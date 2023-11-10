using RentCar.Common.Interfaces;

namespace RentCar.Common.Classes
{
	public class Customer : IPerson
	{
		public int Id { get; set; }
		public string? Ssn { get; init; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }

		public Customer(int id, string? ssn, string? firstName, string? lastName)
		{
			Id = id;
			Ssn = ssn;
			FirstName = firstName;
			LastName = lastName;
		}
	}
	//public class Customer : IPerson
	//{
	//    public string? Ssn { get; init; }
	//    public string? FirstName { get; set; }
	//    public string? LastName { get; set; }

	//    public Customer(string ssn, string firstName, string lastName) 
	//    {
	//        Ssn = ssn;
	//        FirstName = firstName;
	//        LastName = lastName;
	//    }
	//}
}
