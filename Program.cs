using Microsoft.EntityFrameworkCore;
using MvcLabManager.Models;

var builder = WebApplication.CreateBuilder(args); //configura como a aplicação comporta

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LabManagerContext>(options => options.UseMySQL("server=localhost;database=labmanager;user=root;password=testes-bancos-de-dados;"));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
