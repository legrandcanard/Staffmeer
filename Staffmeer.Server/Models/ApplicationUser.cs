using Microsoft.AspNetCore.Identity;

namespace Staffmeer.Server.Models;

public class ApplicationUser : IdentityUser<int>
{
    // optional FK to domain Employee
    public int? EmployeeId { get; set; }

    // navigation property
    public virtual Employee? Employee { get; set; }
}