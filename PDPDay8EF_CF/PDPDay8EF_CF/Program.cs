using Microsoft.EntityFrameworkCore;
using PDPDay8EF_CF.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // 🔹 Lấy chuỗi kết nối từ appsettings.json
        var connectionString = builder.Configuration.GetConnectionString("AppConnection");

        // 🔸 Thêm DbContext và kết nối tới SQL Server
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Thêm MVC (Controllers + Views)
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Cấu hình pipeline HTTP
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
    }
}
