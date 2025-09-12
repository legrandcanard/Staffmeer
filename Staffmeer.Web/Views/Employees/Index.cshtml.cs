using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Web.Models;

namespace Staffmeer.Web.Views.Employees
{
    public class IndexModel : PageModel
    {
        private readonly Staffmeer.Web.Models.ApplicationContext _context;

        public IndexModel(Staffmeer.Web.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees
                .Include(e => e.Department).ToListAsync();
        }
    }
}
