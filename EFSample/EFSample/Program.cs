using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Setup A simpler replacement for my Web App host ...
var builer = new HostBuilder();

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

builer.ConfigureLogging(logBuilder => logBuilder.AddConsole());

builer.ConfigureServices(services =>
{
    services.AddSingleton<IB2BModelBuildProvider>(
        new B2BMSSQLModelBuildProvider(
            config.GetConnectionString("B2B"),
            logSQL: true));

    services.AddDbContextFactory<B2BDbContext>((provider, opt) => provider.GetRequiredService<IB2BModelBuildProvider>().Configure(opt));
    services.AddTransient<IB2BDbContextFactory, B2BDbContextFactory>();
});

IHost host = builer.Build();


// Whats consumed from my controller in my web app ...
var factory = host.Services.GetRequiredService<IB2BDbContextFactory>();
using var context = factory.CreateDbContext();
context.Migrate();


// Execute The problem Query (and log to console output) ...
string[] systems = ["SystemA"];
var results = context.RemittanceAdvices
    .Where(t => systems.Contains(t.SourceSystemId))
    .ToArray();