using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Identity_cms.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Identity_cms
{
    public class Program
    {
        public const string AdministratorRights = "Administrator";
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();//Fetches the actual instantiated object (runtime) of the ApplicationDbContext class.
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();//userManager is provided by the identity framework
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>(); //same for roleManager provieded by identiyframework

                if (!roleManager.RoleExistsAsync(Program.AdministratorRights).Result) //Does the rolemanager know about the admin role?
                {
                    var result = roleManager.CreateAsync(new IdentityRole(Program.AdministratorRights)).Result; //if not, create the admin role
                }

                string adminUserName = "meftaful2010@gmail.com";
                IdentityUser adminUser = userManager.FindByNameAsync(adminUserName).Result; //Searches for the admin user
                if (adminUser == null) //did not exist in the database, so let's create 
                {
                    var result = userManager.CreateAsync(new IdentityUser(adminUserName), "password").Result; //Create a user that we'll give admin rights. The admin user has the extremely secure password: password
                    IdentityUser admin = userManager.FindByNameAsync(adminUserName).Result; //fetch the user we just created
                    var roleResult = userManager.AddToRoleAsync(admin, Program.AdministratorRights).Result; //give admin rights to it
                }
                else
                {
                    var hasRole = userManager.IsInRoleAsync(adminUser, Program.AdministratorRights).Result; //not needed here, but leaving it as an example
                }

            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
