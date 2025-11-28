using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Helpers;
using Staffmeer.Server.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Staffmeer.Server.Pages.Orders
{
    public class IndexModel(ApplicationDbContext _context) : PageModel
    {
        const int ServiceEmployeeId = 1;

        [BindProperty]
        [DisplayName("Номенклатура")]
        public int NomenclatureId { get; set; }

        [BindProperty]
        [DisplayName("Тип")]
        public int ProvisionRecordTypeId { get; set; }

        [BindProperty]
        [DisplayName("Описание")]
        public string Description { get; set; }

        [BindProperty]
        [DisplayName("К дате")]
        public DateTime Date { get; set; } = DateTime.Now;

        public void OnGet()
        {
            ViewData["NomenclatureId"] = SmrSelectList.Build(_context.Nomenclatures, "Id", "Name");
            ViewData["ProvisionRecordTypeId"] = SmrSelectList.Build(_context.ProvisionRecordTypes, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var provisionRecord = new ProvisionRecord
            {
                Nomenclature1Id = NomenclatureId,
                Nomenclature2Id = NomenclatureId,
                ProvisionRecordTypeId = ProvisionRecordTypeId,
                Description = Description,
                Date = Date,
                Employee1Id = ServiceEmployeeId,
                Employee2Id = ServiceEmployeeId
            };

            _context.ProvisionRecords.Add(provisionRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
