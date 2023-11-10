namespace RentCar.Common.Interfaces
{
	public interface IPerson
	{
		public int Id { get; set; }
		public string? Ssn { get; init; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
	//public interface IPerson
	//{
	//    public string? Ssn { get; init; }
	//    public string? FirstName { get; set; }
	//    public string? LastName { get; set; }
	//}
}
