using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HighSchool.Entities;

namespace HighSchool.Repository
{
    public class RepositoryContext: IdentityDbContext<User>
    {
        //Remember to install MS.Entityframworkcore
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
/*
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PageConfiguration());*/

        }
       // public DbSet<Page>? Pages { get; set; }
       
    }
}

