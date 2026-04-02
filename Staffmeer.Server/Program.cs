using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Staffmeer.Server.Models;
using Staffmeer.Server.Models.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

#region Authorization Config

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
    options.Cookie.Name = "Staffmeer.Identity";
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.SlidingExpiration = true;
});

#endregion

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// IMPORTANT: authentication before authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

    var idDb = services.GetRequiredService<ApplicationIdentityDbContext>();
    idDb.Database.Migrate();

/*    var emp = await db.Employees.FirstOrDefaultAsync(e => e.LastName == "Admin" && e.FirstName == "Admin");
    if (emp == null)
    {
        emp = new Employee { FirstName = "Admin", LastName = "Admin", Patronymic = string.Empty, DepartmentId = 1 };
        db.Employees.Add(emp);
        await db.SaveChangesAsync();
    }*/

    // ensure role
    if (!await roleManager.RoleExistsAsync("Admin"))
        await roleManager.CreateAsync(new IdentityRole<int>("Admin"));

    // ensure user
    var adminUser = await userManager.FindByNameAsync("admin");
    if (adminUser == null)
    {
        adminUser = new ApplicationUser { UserName = "admin", Email = "admin@local", EmployeeId = null, EmailConfirmed = true };
        var res = await userManager.CreateAsync(adminUser, "P@ssw0rd!");
        if (res.Succeeded)
            await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}

app.Run();
