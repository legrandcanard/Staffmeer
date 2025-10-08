using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Staffmeer.Server.Models;

namespace Staffmeer.Server.Pages.Nomenclatures
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
        ViewData["BrandnameId"] = new SelectList(_context.Brandnames, "Id", "Id");
        ViewData["CounterpartyId"] = new SelectList(_context.Counterparties, "Id", "Id");
        ViewData["NomenclatureTypeId"] = new SelectList(_context.NomenclatureTypes, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Nomenclature Nomenclature { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Nomenclatures.Add(Nomenclature);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
