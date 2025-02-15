﻿using System;
using DeliBot.Data;
using DeliBot.Data.GuessGame;
using DeliBot.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DeliBot.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            provider.GetRequiredService<Bot>().RunAsync().GetAwaiter().GetResult();

        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<DeliBotContext>(options =>
                    {
                        options.UseLazyLoadingProxies();
                        options.UseMySql(context.Configuration.GetConnectionString("Default"),
                            new MariaDbServerVersion(new Version(10, 3, 21)), 
                            b => b.MigrationsAssembly("DeliBot.Console"));
                    });
                    services.AddTransient<Bot>();
                    services.AddTransient<IGuessService, GuessService>();
                });
    }
}