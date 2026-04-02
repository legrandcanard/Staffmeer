using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;

namespace Staffmeer.Server.Models.Contexts;

public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Do NOT bring the full domain graph (Employee -> ProvisionRecord -> ...) into this Identity model.
        // Ignore the navigation so EF won't try to include Employee's navigation properties.
        builder.Entity<ApplicationUser>().Ignore(u => u.Employee);

        // Keep EmployeeId as a simple column (you can read/join by EmployeeId at runtime).
        builder.Entity<ApplicationUser>()
               .Property(u => u.EmployeeId)
               .HasColumnName("EmployeeId");
    }
}