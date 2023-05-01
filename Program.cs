using Microsoft.EntityFrameworkCore;
using TIDSolutions.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AutoContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DBServer")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Listar}/{id?}");

app.Run();
