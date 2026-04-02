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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<NomenclatureType> NomenclatureType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            NomenclatureType = await _context.NomenclatureTypes.ToListAsync();
        }
    }
}
