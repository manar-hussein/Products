using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Products.Helpers;
using Products.Infrastructure;
using Products.Models;
using Products.Services;

namespace Products
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Dev")));

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                // Configure identity options if needed
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationContext>()
              .AddDefaultTokenProviders();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Authentication/SignIn"; // Change to your desired path
                //options.AccessDeniedPath = "/YourCustomPath/AccessDenied"; // Optional: Change access denied path
            });
            builder.Services.AddScoped<ProductRepository, ProductRepository>();
            builder.Services.AddScoped<FileServices, FileServices>();
            builder.Services.AddScoped<ProductServices, ProductServices>();
            builder.Services.AddScoped<BuyerRepository, BuyerRepository>();
            builder.Services.AddMapster();
            builder.Services.RegisterMapsterConfiguration();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseStaticFiles();
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
