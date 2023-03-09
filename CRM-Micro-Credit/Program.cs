using CRM_Micro_Credit.Entity;
using CRM_Micro_Credit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace CRM_Micro_Credit
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services.Configure<Salt>(builder.Configuration.GetSection("salt"));

			builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

            builder.Services.AddMvc();

            builder.Services.AddAuthentication("Cookie").AddCookie("Cookie", config =>
            {
                config.LoginPath = "/Login";
                config.AccessDeniedPath = "/Home/AccessDenied";
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "Administrator");
                });

				//options.AddPolicy("Manager", builder =>
				//{
				//    builder.RequireClaim(ClaimTypes.Role, "Manager");
				//});

				options.AddPolicy("Users", builder =>
				{
					builder.RequireClaim(ClaimTypes.Role, "Users");
				});

				options.AddPolicy("Manager", builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "Manager") || x.User.HasClaim(ClaimTypes.Role, "Administrator"));
                });
            });

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();

        }
    }
}