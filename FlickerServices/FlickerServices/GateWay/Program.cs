using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace GateWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                      .AddJsonFile(@"C:\Users\VMUser\flicker\FlickerServices\FlickerServices\GateWay\ocelot.json")
                                      .Build();
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddOcelot(configuration);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            /*app.MapGet("api/User/Register", () => { });
            app.MapGet("api/Favoutite", () => { });
            app.MapGet("api/user/validate", () => { });*/
            app.UseOcelot();
            app.Run();
        }
    }
}