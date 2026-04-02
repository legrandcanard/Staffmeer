using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;
using Staffmeer.Server.Models.Contexts;

namespace Staffmeer.Server.Pages.NomenclatureTypes
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public NomenclatureType NomenclatureType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomenclaturetype = await _context.NomenclatureTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (nomenclaturetype == null)
            {
                return NotFound();
            }
            else
            {
                NomenclatureType = nomenclaturetype;
            }
            return Page();
        }
    }
}
