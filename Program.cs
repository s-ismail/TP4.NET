using Microsoft.EntityFrameworkCore;
using Prog.NETTp4.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("dbcon");
builder.Services.AddDbContext<Tp4CompanyDbContext>(options => options.UseSqlServer(connectionstring));
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
    pattern: "{controller=Departement}/{action=Index}/{id?}");

app.Run();
