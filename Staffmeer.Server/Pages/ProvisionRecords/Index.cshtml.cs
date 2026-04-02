using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;
using Staffmeer.Server.Models.Contexts;

namespace Staffmeer.Server.Pages.ProvisionRecords
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProvisionRecord> ProvisionRecord { get; set; } = default!;

        // Filter properties
        [BindProperty(SupportsGet = true)]
        public DateTime? DateFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? DateTo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? ProvisionRecordTypeId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Description { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CounterpartyId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Employee1Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Employee2Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Nomenclature1Id { get; set; }

        // Select lists for dropdowns
        public List<ProvisionRecordType> RecordTypes { get; set; } = new();
        public List<Counterparty> Counterparties { get; set; } = new();
        public List<Employee> Employees { get; set; } = new();
        public List<Nomenclature> Nomenclatures { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Load dropdown data
            RecordTypes = await _context.ProvisionRecordTypes.OrderBy(r => r.Name).ToListAsync();
            Counterparties = await _context.Counterparties.OrderBy(c => c.Name).ToListAsync();
            Employees = await _context.Employees.OrderBy(e => e.LastName).ToListAsync();
            Nomenclatures = await _context.Nomenclatures.OrderBy(n => n.Name).ToListAsync();

            // Build query with filters
            var query = _context.ProvisionRecords
                .Include(p => p.Counterparty)
                .Include(p => p.Employee1)
                .Include(p => p.Employee2)
                .Include(p => p.Nomenclature1)
                    .ThenInclude(n => n.Brandname)
                .Include(p => p.ProvisionRecordType)
                .AsQueryable();

            // Apply filters
            if (DateFrom.HasValue)
            {
                query = query.Where(p => p.Date >= DateFrom.Value);
            }

            if (DateTo.HasValue)
            {
                query = query.Where(p => p.Date <= DateTo.Value.AddDays(1)); // Include entire day
            }

            if (ProvisionRecordTypeId.HasValue)
            {
                query = query.Where(p => p.ProvisionRecordTypeId == ProvisionRecordTypeId.Value);
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                query = query.Where(p => p.Description.Contains(Description));
            }

            if (CounterpartyId.HasValue)
            {
                query = query.Where(p => p.CounterpartyId == CounterpartyId.Value);
            }

            if (Employee1Id.HasValue)
            {
                query = query.Where(p => p.Employee1Id == Employee1Id.Value);
            }

            if (Employee2Id.HasValue)
            {
                query = query.Where(p => p.Employee2Id == Employee2Id.Value);
            }

            if (Nomenclature1Id.HasValue)
            {
                query = query.Where(p => p.Nomenclature1Id == Nomenclature1Id.Value);
            }

            // Order and materialize
            ProvisionRecord = await query
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }
    }
}
