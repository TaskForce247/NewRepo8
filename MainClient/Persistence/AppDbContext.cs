﻿using MainClient.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainClient.Persistence
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Customer> Customers { get; set; }

        public AppDbContext(DbContextOptions<WaterLogicDbContext> options)
            : base(options)
        {

        }
    }
}
