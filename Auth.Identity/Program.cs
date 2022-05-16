using Auth.Identity.Data;
using Auth.Identity.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                DataBaseInitializer.Init(scope.ServiceProvider);
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class DataBaseInitializer
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            // var context = serviceProvider.GetService<ApplicationDbContext>();

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser
            {
                UserName="Xaos",
                FirstName="Orkhan",
                LastName="Aliyev"
            };


            var result=userManager.CreateAsync(user,"123456").GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                var res=userManager.AddClaimAsync(user,new Claim(ClaimTypes.Role, "Manager")).GetAwaiter().GetResult();
            }

            //context.Users.Add(user);
            //context.SaveChanges();
        }
    }
}
