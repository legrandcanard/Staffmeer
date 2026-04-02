using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;
using Staffmeer.Server.Models.Contexts;

namespace Staffmeer.Server.Pages.ProvisionRecords
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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

            var provisionrecord =  await _context.ProvisionRecords.FirstOrDefaultAsync(m => m.Id == id);
            if (provisionrecord == null)
            {
                return NotFound();
            }
            ProvisionRecord = provisionrecord;
           ViewData["CounterpartyId"] = new SelectList(_context.Counterparties, "Id", "Id");
           ViewData["Employee1Id"] = new SelectList(_context.Employees, "Id", "Id");
           ViewData["Employee2Id"] = new SelectList(_context.Employees, "Id", "Id");
           ViewData["Nomenclature1Id"] = new SelectList(_context.Nomenclatures, "Id", "Id");
           ViewData["Nomenclature2Id"] = new SelectList(_context.Nomenclatures, "Id", "Id");
           ViewData["ProvisionRecordTypeId"] = new SelectList(_context.ProvisionRecordTypes, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProvisionRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvisionRecordExists(ProvisionRecord.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProvisionRecordExists(int id)
        {
            return _context.ProvisionRecords.Any(e => e.Id == id);
        }
    }
}
