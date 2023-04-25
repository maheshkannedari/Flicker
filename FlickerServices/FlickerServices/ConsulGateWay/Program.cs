using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Consul;

namespace ConsulGateWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
             .AddJsonFile("ConsulOcelot.json")
             .Build();

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddOcelot(Configuration).AddConsul();
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.UseOcelot();
            app.Run();
        }
    }
}