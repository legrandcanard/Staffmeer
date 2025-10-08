using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;

namespace Staffmeer.Server.Pages.NomenclatureTypes
{
    public class DetailsModel : PageModel
    {
        private readonly Staffmeer.Server.Models.ApplicationDbContext _context;

        public DetailsModel(Staffmeer.Server.Models.ApplicationDbContext context)
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
