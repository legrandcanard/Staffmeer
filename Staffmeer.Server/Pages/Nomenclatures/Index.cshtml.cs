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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Nomenclature> Nomenclature { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Nomenclature = await _context.Nomenclatures
                .Include(n => n.Brandname)
                .Include(n => n.Counterparty)
                .Include(n => n.NomenclatureType).ToListAsync();
        }
    }
}
