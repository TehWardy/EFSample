using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects;
using Microsoft.Extensions.DependencyInjection;

namespace B2B;

public static class B2BConfigurationExtensions
{
    public static void AddEntityFramework(this B2BConfiguration config, IServiceCollection services)
    {
        services.AddPooledDbContextFactory<B2BDbContext>((provider, opt) => provider.GetService<IB2BModelBuildProvider>().Configure(opt), config.MaxDbConnections);
        services.AddTransient<IB2BDbContextFactory, B2BDbContextFactory>();
    }
}