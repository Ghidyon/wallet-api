using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletApi.Data.Implementations;
using WalletApi.Data.Interfaces;
using WalletApi.Models.Entities;
using WalletApi.Services.Implementations;
using WalletApi.Services.Interfaces;

namespace WalletApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddDbContext<IdentityContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("WalletConnection"),
                        b => b.MigrationsAssembly("WalletApi"));
                });

        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 10;
                options.User.RequireUniqueEmail = true;
            });

            return services;
        }

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerService, LoggerService>();

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork<IdentityContext>>();
            services.AddTransient<IServiceFactory, ServiceFactory>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<ITransactionService, TransactionService>();

            return services;
        }
    }
}
