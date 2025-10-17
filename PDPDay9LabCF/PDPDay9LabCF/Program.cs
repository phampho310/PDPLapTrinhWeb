using Microsoft.EntityFrameworkCore;
using PDPDay9LabCF.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var pdpConnectString = builder.Configuration.GetConnectionString("PDPDay9LabCFConnection");
builder.Services.AddDbContext<PDPDay9LabCFContext>(tvcOptions => tvcOptions.UseSqlServer(pdpConnectString));

var app = builder.Build();

// Configure the HTTP request pipeline.
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
