
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLoggic.Core.Models;
using WcfService1;

namespace WaterLoggic.Persistence
{
    public class WaterLogicDbContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Machine> Machines { get; set; }
        public DbSet<MCategory> Categories { get; set; }



        public WaterLogicDbContext(DbContextOptions<WaterLogicDbContext> options)
            : base(options)
        {

        }
    }
}
