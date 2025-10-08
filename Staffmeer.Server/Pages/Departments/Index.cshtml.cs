using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;

namespace Staffmeer.Server.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly Staffmeer.Server.Models.ApplicationDbContext _context;

        public IndexModel(Staffmeer.Server.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Departament> Departament { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Departament = await _context.Departaments.ToListAsync();
        }
    }
}
