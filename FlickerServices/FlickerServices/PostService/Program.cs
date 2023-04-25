using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PostService.Repository;
using PostService.Services;
using System.Text;
using System.Linq;
using Serilog;

namespace PostService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            //Addding serilog for logging
            var log = new LoggerConfiguration()
                .WriteTo.File(@"C:\Users\VMUser\flicker\FlickerServices\FlickerServices\PostService\bin\Log", rollingInterval: RollingInterval.Day)
                  .CreateLogger();
            builder.Logging.AddSerilog(log);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = builder.Configuration["Jwt:Issuer"],
                       ValidAudience = builder.Configuration["Jwt:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                   };
               });
            // Add services to the container.
            builder.Services.AddConsulConfig(Configuration);

            builder.Services.AddConnections();
            builder.Services.AddDbContext<PostContext>((param) =>
            param.UseSqlServer(builder.Configuration.GetConnectionString("PostString")));
            builder.Services.AddScoped<IPostSer, PostSer>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
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
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseConsul(Configuration);
            app.MapControllers();

            app.Run();
        }
    }
}