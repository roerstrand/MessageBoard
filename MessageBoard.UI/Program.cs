using MessageBoard.BLL.DTOs;
using MessageBoard.BLL.Interfaces;
using MessageBoard.BLL.Services;

//using MessageBoard.BLL.Services;
using MessageBoard.DLL.Data;
using MessageBoard.DLL.Entities;
using MessageBoard.DLL.Interfaces;
using MessageBoard.DLL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

// System includes Identity services + role support,
// configured to use our custom ApplicationUser and the AuthDbContext for storage
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

// Configure cookie settings for authentication
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Index"; // You can change this to your actual login page
    options.AccessDeniedPath = "/NoAccess"; // Om inte behörighet, skicka hit (Ifall du vill ha denna sidan)
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();



// Seed roles and default users (and apply any pending EF Core migrations)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    // Apply pending migrations for application and auth DBs so the database is up-to-date
    try
    {
        var authDb = services.GetRequiredService<MessageBoard.DLL.Data.AuthDbContext>();
        var appDb = services.GetRequiredService<MessageBoard.DLL.Data.AppDbContext>();

        // Ensure databases are created and migrations applied
        await authDb.Database.MigrateAsync();
        await appDb.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        // Log migration error
        logger.LogError(ex, "Database migration error");
        throw;
    }

    // Run identity seeding ONLY in Development environment
    if (app.Environment.IsDevelopment())
    {
        try
        {
            await MessageBoard.DLL.Data.IdentitySeeder.SeedAsync(services);
        }
        catch (Exception ex)
        {
            // Log seeding error but don't crash the app startup
            logger.LogError(ex, "An error occurred while seeding roles and users.");
        }
    }
}

app.Run();
