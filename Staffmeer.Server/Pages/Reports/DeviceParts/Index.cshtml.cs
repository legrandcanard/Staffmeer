using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;
using Staffmeer.Server.Models.Contexts;

namespace Staffmeer.Server.Pages.Reports.DeviceParts
{
    public class DevicePartsModel(ApplicationDbContext context) : PageModel
    {
        public Nomenclature Nomenclature { get; set; } = default!;
        public Nomenclature[] Nomenclatures { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Nomenclature = await context.Nomenclatures
                .FirstOrDefaultAsync(e => e.Id == id);

            if (Nomenclature is null)
                return NotFound();

            Nomenclatures = await context.Nomenclatures
                .Include(n => n.Brandname)
                .Include(n => n.NomenclatureType)
                .Where(e => e.ParentId == id)
                .ToArrayAsync();

            return Page();
        }
    }
}
