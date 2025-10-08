using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;

namespace Staffmeer.Server.Pages.Nomenclatures
{
    public class EditModel : PageModel
    {
        private readonly Staffmeer.Server.Models.ApplicationDbContext _context;

        public EditModel(Staffmeer.Server.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nomenclature Nomenclature { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomenclature =  await _context.Nomenclatures.FirstOrDefaultAsync(m => m.Id == id);
            if (nomenclature == null)
            {
                return NotFound();
            }
            Nomenclature = nomenclature;
           ViewData["BrandnameId"] = new SelectList(_context.Brandnames, "Id", "Id");
           ViewData["CounterpartyId"] = new SelectList(_context.Counterparties, "Id", "Id");
           ViewData["NomenclatureTypeId"] = new SelectList(_context.NomenclatureTypes, "Id", "Id");
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

            _context.Attach(Nomenclature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NomenclatureExists(Nomenclature.Id))
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

        private bool NomenclatureExists(int id)
        {
            return _context.Nomenclatures.Any(e => e.Id == id);
        }
    }
}
