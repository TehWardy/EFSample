using B2B.Objects.Entities.Payments;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF
{
    public partial class B2BMSSQLModelBuildProvider
    {
        private static void ConfigurePaymentsModel(ModelBuilder modelBuilder)
        {
            ConfigurePaymentsTables(modelBuilder);
            ConfigurePaymentsColumns(modelBuilder);
            ConfigurePaymentsForeignKeys(modelBuilder);
        }

        private static void ConfigurePaymentsTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RemittanceAdvice>()
                .ToTable("RemittanceAdvices", "Payments");

            modelBuilder.Entity<RemittanceAdviceCompany>()
                .ToTable("RemittanceAdviceCompanies", "Payments");

            modelBuilder.Entity<RemittanceAdviceLine>()
                .ToTable("RemittanceAdviceLines", "Payments");

            modelBuilder.Entity<RemittanceAdviceReference>()
                .ToTable("RemittanceAdviceReferences", "Payments");

            modelBuilder.Entity<RemittanceAdviceType>()
                .ToTable("RemittanceAdviceTypes", "Payments");
        }

        private static void ConfigurePaymentsColumns(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RemittanceAdvice>()
                .HasKey(ra => ra.Id);

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.SourceSystemId)
                .IsRequired();

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.CurrencyId)
                .IsRequired();

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.DebtorState)
                .HasMaxLength(50);

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.CreditorState)
                .HasMaxLength(50);

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.Comment)
                .HasMaxLength(500);

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.Number)
                .HasMaxLength(50);

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.DebtorName)
                .HasMaxLength(200);

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.CreditorName)
                .HasMaxLength(200);

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.DebtorExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.CreditorExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<RemittanceAdvice>()
                .Property(ra => ra.Value)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<RemittanceAdviceCompany>()
                .HasKey(rac => rac.Id);

            modelBuilder.Entity<RemittanceAdviceCompany>()
                .Property(rac => rac.Id)
                .HasMaxLength(110);

            modelBuilder.Entity<RemittanceAdviceCompany>()
                .Property(rac => rac.CompanyReferenceId)
                .IsRequired();

            modelBuilder.Entity<RemittanceAdviceLine>()
                .HasKey(ral => ral.Id);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .Property(ral => ral.CurrencyId)
                .IsRequired();

            modelBuilder.Entity<RemittanceAdviceLine>()
                .Property(ral => ral.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .Property(ral => ral.LinePrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<RemittanceAdviceLine>()
                .Property(ral => ral.PaymentReference)
                .HasMaxLength(100);

            modelBuilder.Entity<RemittanceAdviceReference>()
                .HasKey(rar => rar.Id);

            modelBuilder.Entity<RemittanceAdviceReference>()
                .Property(rar => rar.Id)
                .HasMaxLength(100);

            modelBuilder.Entity<RemittanceAdviceReference>()
                .Property(rar => rar.SystemId)
                .IsRequired();

            modelBuilder.Entity<RemittanceAdviceReference>()
                .Property(rar => rar.Value)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<RemittanceAdviceType>()
                .HasKey(rar => rar.Id);

            modelBuilder.Entity<RemittanceAdviceType>()
                .Property(rar => rar.Name)
                .IsRequired()
                .HasMaxLength(32);

        }

        private static void ConfigurePaymentsForeignKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RemittanceAdvice>()
                .HasOne(ra => ra.SourceSystem)
                .WithMany(s => s.RemittanceAdvices)
                .HasForeignKey(ra => ra.SourceSystemId);

            modelBuilder.Entity<RemittanceAdvice>()
                .HasOne(ra => ra.Currency)
                .WithMany(c => c.RemittenceAdvices)
                .HasForeignKey(ra => ra.CurrencyId);

            modelBuilder.Entity<RemittanceAdvice>()
                .HasOne(ra => ra.RemittanceAdviceType)
                .WithMany(rat => rat.RemittanceAdvices)
                .HasForeignKey(ra => ra.RemittanceAdviceTypeId);

            modelBuilder.Entity<RemittanceAdvice>()
                .HasMany(ra => ra.AuditTrail)
                .WithOne(raat => raat.RemittanceAdvice)
                .HasForeignKey(raat => raat.RemittanceAdviceId);

            modelBuilder.Entity<RemittanceAdvice>()
                .HasMany(ra => ra.Lines)
                .WithOne(ral => ral.RemittanceAdvice)
                .HasForeignKey(ral => ral.RemittanceAdviceId);

            modelBuilder.Entity<RemittanceAdvice>()
                .HasMany(ra => ra.References)
                .WithOne(rar => rar.RemittanceAdvice)
                .HasForeignKey(rar => rar.RemittanceAdviceId);

            modelBuilder.Entity<RemittanceAdvice>()
                .HasMany(ra => ra.Companies)
                .WithOne(rac => rac.RemittanceAdvice)
                .HasForeignKey(rac => rac.RemittanceAdviceId);

            modelBuilder.Entity<RemittanceAdvice>()
                .HasMany(ra => ra.Buckets)
                .WithOne(rab => rab.RemittanceAdvice)
                .HasForeignKey(rab => rab.RemittanceAdviceId);

            modelBuilder.Entity<RemittanceAdviceCompany>()
                .HasOne(rac => rac.RemittanceAdvice)
                .WithMany(ra => ra.Companies)
                .HasForeignKey(rac => rac.RemittanceAdviceId);

            modelBuilder.Entity<RemittanceAdviceCompany>()
                .HasOne(rac => rac.CompanyReference)
                .WithMany(cr => cr.RemittanceAdviceReferences)
                .HasForeignKey(rac => rac.CompanyReferenceId);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .HasOne(ral => ral.Currency)
                .WithMany(c => c.RemittanceAdviceLines)
                .HasForeignKey(ral => ral.CurrencyId);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .HasOne(ral => ral.Offer)
                .WithMany(o => o.RemittanceAdviceLines)
                .HasForeignKey(ral => ral.OfferId);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .HasOne(ral => ral.DebtorAccount)
                .WithMany(da => da.DebtorPayments)
                .HasForeignKey(ral => ral.DebtorAccountId);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .HasOne(ral => ral.CreditorAccount)
                .WithMany(ca => ca.CreditorPayments)
                .HasForeignKey(ral => ral.CreditorAccountId);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .HasOne(ral => ral.RemittanceAdvice)
                .WithMany(ra => ra.Lines)
                .HasForeignKey(ral => ral.RemittanceAdviceId);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .HasOne(ral => ral.InvoiceReference)
                .WithMany(ir => ir.RemittanceAdviceLines)
                .HasForeignKey(ral => ral.InvoiceReferenceId);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .HasOne(ral => ral.CreditReference)
                .WithMany(cr => cr.RemittanceAdviceLines)
                .HasForeignKey(ral => ral.CreditReferenceId);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .HasOne(ral => ral.PurchaseOrderReference)
                .WithMany(por => por.RemittanceAdviceLines)
                .HasForeignKey(ral => ral.PurchaseOrderReferenceId);

            modelBuilder.Entity<RemittanceAdviceLine>()
                .HasOne(ral => ral.OfferReference)
                .WithMany(or => or.RemittanceAdviceLines)
                .HasForeignKey(ral => ral.OfferReferenceId);

            modelBuilder.Entity<RemittanceAdviceReference>()
                .HasOne(rar => rar.System)
                .WithMany(s => s.RemittanceAdviceReferences)
                .HasForeignKey(rar => rar.SystemId);

            modelBuilder.Entity<RemittanceAdviceReference>()
                .HasOne(rar => rar.RemittanceAdvice)
                .WithMany(ra => ra.References)
                .HasForeignKey(rar => rar.RemittanceAdviceId);

            modelBuilder.Entity<RemittanceAdviceType>()
                .HasMany(rat => rat.RemittanceAdvices)
                .WithOne(ra => ra.RemittanceAdviceType)
                .HasForeignKey(ra => ra.RemittanceAdviceTypeId);
        }

        private void ConfigurePayments(ModelBuilder modelBuilder)
        {
            ConfigurePaymentsModel(modelBuilder);
        }
    }
}