
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using WaterLoggic.Persistence;

namespace WaterLoggic.Persistence
{
    public static class DbInitializer
    {
        public static void SeedDatabase(
            WaterLogicDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            System.Console.WriteLine("Seeding... - Start");

            var categories = new List<MCategory>
            {
                new MCategory { Name = "Vanilla Machines"},
                new MCategory { Name = "Chocolate Machines" },
                new MCategory { Name = "Fruit Machines"},
                new MCategory { Name = "dd"}
            };

            var machines = new List<Machine>
            {
                new Machine
                {
                    Name ="Strawberry Machine",
                    Price = 48.00M,
                    ShortDescription ="Yammy Sweet & Testy",
                    LongDescription ="Icing carrot machine jelly-o cheesemachine. tootsie roll oat machine pie chocolate bar cookie dragée brownie. Lollipop cotton candy machine bear claw oat machine.dragée gummies.",
                    Category = categories[0],
                    ImageUrl ="/img/vanilla-machine2.jpg",
                  
                },
                new Machine
                {
                    Name ="Dark Chocolate Machine",
                    Price =45.50M,
                    ShortDescription ="Yammy! Dark Chocolate Flavour",
                    LongDescription ="Icing carrot machine jelly-o cheesemachine. tootsie roll oat machine pie chocolate bar cookie dragée brownie. Lollipop cotton candy machine bear claw oat machine.dragée gummies.",
                    Category = categories[1],
                    ImageUrl ="/img/chocolate-machine4.jpg",
                  
                },
                new Machine
                {
                    Name ="Special Chocolate Machine",
                    Price = 30.50M,
                    ShortDescription ="Taste Our Spejhal Chocolates",
                    LongDescription ="Icing carrot machine jelly-o cheesemachine. tootsie roll oat machine pie chocolate bar cookie dragée brownie. Lollipop cotton candy machine bear claw oat machine.dragée gummies.",
                    Category = categories[1],
                    ImageUrl ="/img/chocolate-machine3.jpg",
                    
                },
                new Machine
                {
                    Name ="Red Velvet Machine",
                    Price=35.00M,
                    ShortDescription ="Our Special Machine",
                    LongDescription ="Icing carrot machine jelly-o cheesemachine. tootsie roll oat machine pie chocolate bar cookie dragée brownie. Lollipop cotton candy machine bear claw oat machine.dragée gummies.",
                    Category = categories[0],
                    ImageUrl ="/img/vanilla-machine4.jpg",
                 
                },
                new Machine
                {
                    Name ="Mixed Fruit Machine",
                    Price = 30.50M,
                    ShortDescription ="Fruity & Testy",
                    LongDescription ="Icing carrot machine jelly-o cheesemachine. tootsie roll oat machine pie chocolate bar cookie dragée brownie. Lollipop cotton candy machine bear claw oat machine.caramels.",
                    Category = categories[2],
                    ImageUrl ="/img/fruit-machine.jpg",
                  
                }

            };

            if (!context.Categories.Any() && !context.Machines.Any())
            {
                context.Categories.AddRange(categories);
                context.Machines.AddRange(machines);
                context.SaveChanges();
            }


            IdentityUser usr = null;
            string userEmail = configuration["Admin:Email"] ?? "admin@admin.com";
            string userName = configuration["Admin:Username"] ?? "admin";
            string password = configuration["Admin:Password"] ?? "Passw@rd!123";

            if (!context.Users.Any())
            {
                usr = new IdentityUser
                {
                    Email = userEmail,
                    UserName = userName
                };
                userManager.CreateAsync(usr, password);
            }

            if (!context.UserRoles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("Admin"));

            }
            if (usr == null)
            {
                usr = userManager.FindByEmailAsync(userEmail).Result;
            }
            if (!userManager.IsInRoleAsync(usr, "Admin").Result)
            {
                userManager.AddToRoleAsync(usr, "Admin");
            }

            context.SaveChanges();

            System.Console.WriteLine("Seeding... - End");
        }

    }
}