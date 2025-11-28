using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Staffmeer.Server.Models;

namespace Staffmeer.Server.Pages.ProvisionRecords
{
    public class CreateModel : PageModel
    {
        private readonly Staffmeer.Server.Models.ApplicationDbContext _context;

        public CreateModel(Staffmeer.Server.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CounterpartyId"] = new SelectList(_context.Counterparties, "Id", "Id");
            ViewData["Employee1Id"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["Employee2Id"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["Nomenclature1Id"] = new SelectList(_context.Nomenclatures, "Id", "Id");
            ViewData["Nomenclature2Id"] = new SelectList(_context.Nomenclatures, "Id", "Id");
            ViewData["ProvisionRecordTypeId"] = new SelectList(_context.ProvisionRecordTypes, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ProvisionRecord ProvisionRecord { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProvisionRecords.Add(ProvisionRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
