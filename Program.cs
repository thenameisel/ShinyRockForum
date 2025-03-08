//Created by El Wisman, 2025

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShinyRockForum.Data;
using Microsoft.AspNetCore.Identity;



namespace ShinyRockForum
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ShinyRockForumContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ShinyRockForumContext") ?? throw new InvalidOperationException("Connection string 'ShinyRockForumContext' not found.")));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ShinyRockForumContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine($"Request Path: {context.Request.Path}");
            //    await next();
            //});
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.MapStaticAssets();
            app.MapRazorPages().WithStaticAssets();

            app.Run();
        }
    }
}
