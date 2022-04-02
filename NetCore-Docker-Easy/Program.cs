using Microsoft.EntityFrameworkCore;
using NetCore_Docker_Easy.Models;
using NetCore_Docker_Easy.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container  ---------------------------------------------------------
builder.Services.AddControllersWithViews();

// EF Core
builder.Services.AddDbContext<FilmDbContext>(options =>
   options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();

// Services
builder.Services.AddScoped<IFilmService, FilmService>();

var app = builder.Build();

// Configure the HTTP request pipeline ----------------------------------------------------
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<FilmDbContext>();
        if (dbContext.Database.IsSqlServer())
            dbContext.Database.Migrate(); // auto migration apply
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();