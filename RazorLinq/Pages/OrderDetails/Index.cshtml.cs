using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorLinq.Data;
using RazorLinq.Models;

namespace RazorLinq.Pages.OrderDetails
{
    public class IndexModel : PageModel
    {
        private readonly RazorLinq.Data.TempdbContext _context;

        public IndexModel(RazorLinq.Data.TempdbContext context)
        {
            _context = context;
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.OrderDetails != null)
            {
                OrderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product).ToListAsync();
            }
        }
    }
}
