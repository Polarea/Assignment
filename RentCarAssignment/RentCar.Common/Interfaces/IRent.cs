namespace RentCar.Common.Interfaces
{
	public interface IRent : IPerson
	{
		public string? RegNo { get; set; }
		public int Odometer { get; set; }
	}
}
