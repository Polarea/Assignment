namespace AsyncProject.Pages
{
	public partial class Index
	{
		string? message;
		int count;
		int delay;
		public async Task Calc(int a, int b)
		{
			for (int i = 0; i < a; i++)
			{
				await Task.Delay(b * 1000);
				message = $"The count is {i}";
			}
		}
	}
}
