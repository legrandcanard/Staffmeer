using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;

namespace Staffmeer.Server.Pages.Counterparties
{
    public class IndexModel : PageModel
    {
        private readonly Staffmeer.Server.Models.ApplicationDbContext _context;

        public IndexModel(Staffmeer.Server.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Counterparty> Counterparty { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Counterparty = await _context.Counterparties.ToListAsync();
        }
    }
}
