using UserService.Respository;
using Microsoft.EntityFrameworkCore;
using UserService.Controllers;
using UserService.Services;
using Microsoft.Extensions.Options;
using Serilog;

namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Addding serilog for logging
            var log = new LoggerConfiguration()
                .WriteTo.File(@"C:\Users\VMUser\flicker\FlickerServices\FlickerServices\UserService\bin\Log", rollingInterval: RollingInterval.Day)
                  .CreateLogger();
             builder.Logging.AddSerilog(log);

            // Add services to the container.
            builder.Services.AddDbContext<UserContext>((param) =>
            param.UseSqlServer(builder.Configuration.GetConnectionString("Userstring")));
            /*builder.Services.AddCors();*/
            builder.Services.AddScoped<IUserSer, UserSer>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddCors();
            builder.Services.AddControllers();
            

            var app = builder.Build();
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}