using B2B.Data.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace B2B.Data.EF
{
    public partial class B2BMSSQLModelBuildProvider(string connectionString, bool logSQL) : IB2BModelBuildProvider
    {
        public void MigrateDatabase(DatabaseFacade database) =>
            database.Migrate();

        public void Create(ModelBuilder modelBuilder)
        {
            ConfigureAuditingModel(modelBuilder);
            ConfigureBankingModel(modelBuilder);
            ConfigureFinancingModel(modelBuilder);
            ConfigureSecurity(modelBuilder);
            ConfigureMasterdata(modelBuilder);
            ConfigureTransactions(modelBuilder);
            ConfigurePayments(modelBuilder);
            ConfigureImports(modelBuilder);
            ConfigureAuditing(modelBuilder);

            var cascadingRelationships = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var relationship in cascadingRelationships)
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        public void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString,
                builder =>
                {
                    builder.MigrationsAssembly("B2B.Data.EF.MSSQL");
                    builder.EnableRetryOnFailure(2);
                    builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });

            if (logSQL)
                optionsBuilder.LogTo((message) =>
                {
                    if (message.Contains("Executing") || message.Contains("transaction"))
                        System.Diagnostics.Debug.WriteLine(message);
                });
        }
    }
}