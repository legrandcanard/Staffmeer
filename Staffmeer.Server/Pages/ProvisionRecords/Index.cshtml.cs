using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;

namespace Staffmeer.Server.Pages.ProvisionRecords
{
    public class IndexModel : PageModel
    {
        private readonly Staffmeer.Server.Models.ApplicationDbContext _context;

        public IndexModel(Staffmeer.Server.Models.ApplicationDbContext context)
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
                .Include(p => p.Nomenclature2)
                .Include(p => p.ProvisionRecordType)
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }
    }
}
