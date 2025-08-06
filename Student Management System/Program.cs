using Student_Management_System.Middlewares;
using Student_Management_System.Models;
using Student_Management_System.Repositories;

namespace Student_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Register Repositories to Dependency Injection
            builder.Services.AddScoped<DepartmentRepository>();
            builder.Services.AddScoped<InstructorRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //Custom Middleware
           // app.UseMiddleware<LogRequestMiddleware>();

            app.UseRouting();

            //app.UseAuthorization();
            //app.UseAuthentication();

            app.MapStaticAssets();
            //Convential Routing for Student/index
            app.MapControllerRoute(
              name: "route1",
              pattern: "/AllStudents.com",
              defaults: new { controller = "Student", action = "index"  })
              .WithStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.Run();

        }
    }
}
