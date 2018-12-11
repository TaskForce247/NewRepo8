using CakeShop.Persistence;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MService;
using WaterLoggic.Persistence;

namespace CakeShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MachineRepositoryClient client = new MachineRepositoryClient();
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                
                var context = scope.ServiceProvider.GetRequiredService<WaterLogicDbContext>();
                var usermanger = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var env = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                //DbInitializer.SeedDatabase(context, usermanger, roleManager, env);

            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();
    }
}
