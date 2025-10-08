using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;

namespace Staffmeer.Server.Pages.Bandnames
{
    public class DeleteModel : PageModel
    {
        private readonly Staffmeer.Server.Models.ApplicationDbContext _context;

        public DeleteModel(Staffmeer.Server.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Brandname Brandname { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandname = await _context.Brandnames.FirstOrDefaultAsync(m => m.Id == id);

            if (brandname == null)
            {
                return NotFound();
            }
            else
            {
                Brandname = brandname;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandname = await _context.Brandnames.FindAsync(id);
            if (brandname != null)
            {
                Brandname = brandname;
                _context.Brandnames.Remove(Brandname);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
