using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MyOrganizer.Models;

namespace MyOrganizer.Data
{

        public class ApplicationDbContext : IdentityDbContext<AppUser>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            { }

            public DbSet<AppUser> AppUsers { get; set; }
            public DbSet<MyTask> Tasks { get; set; }
            public DbSet<Category> Categories { get; set; }

        }
}
