using HomeBudgetApp.Application;
using HomeBudgetApp.Infrastructure;
using HomeBudgetApp.Infrastructure.Persistence;
using HomeBudgetApp.MVC.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApp.MVC.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = WebApplication.CreateBuilder(args);
            SerilogService.SerilogSettings(builder.Configuration);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.AddControllersWithViews();
            builder.Services.AddInfrastructureService(builder.Configuration);
            builder.Services.AddApplicationService();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();


            app.Run();
        }
    }
}