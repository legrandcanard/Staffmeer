using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;
using Staffmeer.Server.Models.Contexts;

namespace Staffmeer.Server.Pages.Nomenclatures
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Nomenclature Nomenclature { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomenclature = await _context.Nomenclatures
                .AsNoTracking()
                .Include(n => n.Brandname)
                .Include(n => n.Counterparty)
                .Include(n => n.Employee)
                .Include(n => n.NomenclatureType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nomenclature == null)
            {
                return NotFound();
            }
            else
            {
                Nomenclature = nomenclature;
            }
            return Page();
        }
    }
}
