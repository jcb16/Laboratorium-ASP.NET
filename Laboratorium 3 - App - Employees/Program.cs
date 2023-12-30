using DataEmployees;
using Laboratorium_3___App___Employees.Models;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium_3___App___Employees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            //var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");


            //builder.Services.AddSingleton<IEmployeesService, MemoryEmployeesService>();
            
            //builder.Services.AddDefaultIdentity<IdentityUser>();


            builder.Services.AddRazorPages();
            //builder.Services.AddSession();
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
            
            builder.Services.AddTransient<IEmployeesService, EFEmployeesService>();

            builder.Services.AddMemoryCache();                        
            builder.Services.AddSession();

            builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseMiddleware<LastVisitCookie>();

            app.UseAuthentication();;

            app.UseAuthorization();

            app.UseSession();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}