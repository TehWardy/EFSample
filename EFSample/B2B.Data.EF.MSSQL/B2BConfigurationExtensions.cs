using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects;
using Microsoft.Extensions.DependencyInjection;

namespace B2B;

public static class MSSQLB2BConfigurationExtensions
{
    public static void AddSQLServerModelProvider(
        this B2BConfiguration config,
        IServiceCollection services,
        string connectionString) =>
            services.AddSingleton<IB2BModelBuildProvider>(
                new B2BMSSQLModelBuildProvider(connectionString, config.LogSQL));
}