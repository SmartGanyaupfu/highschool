using System;
using HighSchool.Contracts;
using HighSchool.EmailService;
using HighSchool.LoggerService;
using HighSchool.Repository;
using HighSchool.Shared.Configs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.API.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services) =>
              services.AddCors(options =>
              {
                  options.AddPolicy("CorsPolicy", builder =>
                   builder.WithOrigins("http://localhost:50837", "http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader().WithExposedHeaders("X-Pagination"));
              });

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();

        // public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration cofiguration)
        {
         

            services.AddDbContext<RepositoryContext>(opts =>
         opts.UseSqlite(cofiguration.GetConnectionString("HSDbDev"))); // add the nuget package
        }
        
        /*public static void ConfigureSqlServerContext(this IServiceCollection services,
       IConfiguration cofiguration) =>
        services.AddDbContext<RepositoryContext>(opts =>
        opts.UseSqlServer(cofiguration.GetConnectionString("HSDbProd"))); // add the nuget package */

        /* public static void ConfigureIdentity(this IServiceCollection services)
         {
             var builder = services.AddIdentity<User, IdentityRole>(o =>
             {
                 o.Password.RequireDigit = true;
                 o.Password.RequireLowercase = false;
                 o.Password.RequireUppercase = false;
                 o.Password.RequireNonAlphanumeric = false;
                 o.Password.RequiredLength = 10;
                 o.User.RequireUniqueEmail = true;
             }).AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();

         }*/

        public static void ConfigureEmailService(this IServiceCollection services) => services.AddScoped<IEmailSender, EmailSender>();
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureEmail(this IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration
       .GetSection("EmailConfiguration")
       .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

        }

        //configuring jwt
        //installl Microsoft.AspNetCore.Authentication.JwtBearer  for ths to work.
       /* public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");
            var secretK = configuration.GetSection("SecretKey").Value;

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretK))
                };
            });
        }*/
    }
}

