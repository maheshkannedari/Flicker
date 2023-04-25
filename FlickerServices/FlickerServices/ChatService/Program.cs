using ChatService.Repository;
using ChatService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;

namespace ChatService
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
                .WriteTo.File(@"C:\Users\VMUser\flicker\FlickerServices\FlickerServices\ChatService\bin\Logs", rollingInterval: RollingInterval.Day)
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

            builder.Services.AddDbContext<ChatContext>((param) =>
            param.UseSqlServer(builder.Configuration.GetConnectionString("ChatString")));
            /*builder.Services.AddCors();*/
            builder.Services.AddScoped<IChatSer, ChatSer>();
            builder.Services.AddScoped<IChatRepo, ChatRepo>();
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