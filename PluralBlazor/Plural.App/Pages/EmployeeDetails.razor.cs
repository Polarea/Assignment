using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace Plural.App.Pages
{
	public partial class EmployeeDetails
	{
        [Parameter]
        public string EmployeeId { get; set; } = null!;

		public Employee? Employee { get; set; } = new Employee();

		protected override Task OnInitializedAsync()
		{
			Employee = MockDataService.Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));
			return base.OnInitializedAsync();
		}
	}
}
