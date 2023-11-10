using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorLinq.Data;
using RazorLinq.Models;

namespace RazorLinq.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly RazorLinq.Data.TempdbContext _context;

        public IndexModel(RazorLinq.Data.TempdbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
            }
        }
    }
}
