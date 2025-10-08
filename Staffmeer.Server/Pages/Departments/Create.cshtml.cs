using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Staffmeer.Server.Models;

namespace Staffmeer.Server.Pages.Departments
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
            return Page();
        }

        [BindProperty]
        public Departament Departament { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departaments.Add(Departament);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
