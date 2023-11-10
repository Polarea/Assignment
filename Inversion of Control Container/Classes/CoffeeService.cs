using Inversion_of_Control_Container.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Inversion_of_Control_Container.Classes
{
	public class CoffeeService : ICoffeeService
	{

		public CoffeeService(IWaterService waterService) 
		{

		}
	}
}
