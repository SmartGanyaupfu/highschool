using System;
using HighSchool.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HighSchool.API.DbContextFactory
{
    public class RepositoryContextFactory:IDesignTimeDbContextFactory<RepositoryContext>
    {
        // remember to install package ms.efcore.sqlserver & the .Tools
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json").Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite(configuration.GetConnectionString("HSDbDev"), b => b.MigrationsAssembly("HighSchool.API"));
            return new RepositoryContext(builder.Options);

           /* string appsettingsFile = "appsettings.json";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(app.Environment.IsDevelopment() ? "appsettings.Development.json" : appsettingsFile).Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            if (AppBuilder.Environment.IsProduction())
            {
                
                builder.UseSqlServer(configuration.GetConnectionString("HSDbProd"), b => b.MigrationsAssembly("HighSchool.API"));
            }else
            {
                builder.UseSqlite(configuration.GetConnectionString("HSDbDev"), b => b.MigrationsAssembly("HighSchool.API"));
            }
            
            return new RepositoryContext(builder.Options);*/
        }
    }
}

