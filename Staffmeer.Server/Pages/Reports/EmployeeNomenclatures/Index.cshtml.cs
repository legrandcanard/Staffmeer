using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;
using Staffmeer.Server.Models.Contexts;

namespace Staffmeer.Server.Pages.Reports.EmployeeNomenclatures
{
    public class EmployeeNomenclaturesModel(ApplicationDbContext context) : PageModel
    {
        public Employee Employee { get; set; } = default!;
        public Nomenclature[] Nomenclatures { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (Employee is null)
                return NotFound();

            Nomenclatures = await context.Nomenclatures
                .Include(n => n.Brandname)
                .Include(n => n.NomenclatureType)
                .Where(e => e.EmployeeId == id)
                .ToArrayAsync();

            return Page();
        }
    }
}
