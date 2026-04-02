using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;
using Staffmeer.Server.Models.Contexts;

namespace Staffmeer.Server.Pages.ProvisionRecords
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProvisionRecord> ProvisionRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProvisionRecord = await _context.ProvisionRecords
                .Include(p => p.Counterparty)
                .Include(p => p.Employee1)
                .Include(p => p.Employee2)
                .Include(p => p.Nomenclature1)
                    .ThenInclude(n => n.Brandname)
                .Include(p => p.ProvisionRecordType)
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }
    }
}
