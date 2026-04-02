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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProvisionRecord ProvisionRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provisionrecord = await _context.ProvisionRecords
                .Include(p => p.Counterparty)
                .Include(p => p.Employee1)
                .Include(p => p.Employee2)
                .Include(p => p.Nomenclature1)
                    .ThenInclude(n => n.Brandname)
                .Include(p => p.Nomenclature2)
                    .ThenInclude(n => n.Brandname)
                .Include(p => p.ProvisionRecordType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (provisionrecord == null)
            {
                return NotFound();
            }
            else
            {
                ProvisionRecord = provisionrecord;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provisionrecord = await _context.ProvisionRecords.FindAsync(id);
            if (provisionrecord != null)
            {
                ProvisionRecord = provisionrecord;
                _context.ProvisionRecords.Remove(ProvisionRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
