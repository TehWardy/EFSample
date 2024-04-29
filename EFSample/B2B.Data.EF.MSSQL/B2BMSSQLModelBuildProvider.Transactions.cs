using B2B.Objects.Entities;
using B2B.Objects.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF
{
    public partial class B2BMSSQLModelBuildProvider
    {
        private static void ConfigureTransactions(ModelBuilder modelBuilder)
        {
            ConfigureTransactionsTables(modelBuilder);
            ConfigureTransactionsColumns(modelBuilder);
            ConfigureTransactionsForeignKeys(modelBuilder);
            ConfigureTransactionCSVLineIndexes(modelBuilder);
        }

        private static void ConfigureTransactionCSVLineIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveTransaction>().HasIndex(i => i.SourceSystemId);

            modelBuilder.Entity<ActiveTransaction>()
                .HasIndex(i => new { i.SourceSystemId, i.CurrencyId, i.DebtorState, i.Value });
        }

        private static void ConfigureTransactionsTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCompany>()
                .ToTable("CreditCompanies", "Transactions");

            modelBuilder.Entity<InvoiceCompany>()
                .ToTable("InvoiceCompanies", "Transactions");

            modelBuilder.Entity<PurchaseOrderCompany>()
                .ToTable("PurchaseOrderCompanies", "Transactions");

            modelBuilder.Entity<CreditLine>()
                .ToTable("CreditLines", "Transactions");

            modelBuilder.Entity<InvoiceLine>()
                .ToTable("InvoiceLines", "Transactions");

            modelBuilder.Entity<PurchaseOrderLine>()
                .ToTable("PurchaseOrderLines", "Transactions");

            modelBuilder.Entity<CreditReference>()
                .ToTable("CreditReferences", "Transactions");

            modelBuilder.Entity<InvoiceReference>()
                .ToTable("InvoiceReferences", "Transactions");

            modelBuilder.Entity<PurchaseOrderReference>()
                .ToTable("PurchaseOrderReferences", "Transactions");

            modelBuilder.Entity<ActiveTransaction>()
                .ToTable("ActiveTransactions", "Transactions");

            modelBuilder.Entity<Credit>()
                .ToTable("Credits", "Transactions");

            modelBuilder.Entity<CreditType>()
                .ToTable("CreditTypes", "Transactions");

            modelBuilder.Entity<Invoice>()
                .ToTable("Invoices", "Transactions");

            modelBuilder.Entity<InvoiceType>()
                .ToTable("InvoiceTypes", "Transactions");

            modelBuilder.Entity<PurchaseOrder>()
                .ToTable("PurchaseOrders", "Transactions");
        }

        private static void ConfigureTransactionsColumns(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCompany>()
                .HasKey(cc => cc.Id);

            modelBuilder.Entity<CreditCompany>()
                .Property(cc => cc.Id)
                .HasMaxLength(110);

            modelBuilder.Entity<CreditCompany>()
                .Property(cc => cc.CompanyReferenceId)
                .IsRequired();

            modelBuilder.Entity<InvoiceCompany>()
                .HasKey(ic => ic.Id);

            modelBuilder.Entity<InvoiceCompany>()
                .Property(ic => ic.Id)
                .HasMaxLength(110);

            modelBuilder.Entity<InvoiceCompany>()
                .Property(ic => ic.CompanyReferenceId)
                .IsRequired();

            modelBuilder.Entity<PurchaseOrderCompany>()
                .HasKey(poc => poc.Id);

            modelBuilder.Entity<PurchaseOrderCompany>()
                .Property(poc => poc.Id)
                .HasMaxLength(110);

            modelBuilder.Entity<PurchaseOrderCompany>()
                .Property(poc => poc.CompanyReferenceId)
                .IsRequired();

            modelBuilder.Entity<CreditLine>()
                .HasKey(cl => cl.Id);

            modelBuilder.Entity<CreditLine>()
                .Property(cl => cl.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<CreditLine>()
                .Property(cl => cl.ProductCode)
                .HasMaxLength(50);

            modelBuilder.Entity<CreditLine>()
                .Property(cl => cl.LinePrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CreditLine>()
                .Property(cl => cl.UnitPrice)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<CreditLine>()
                .Property(cl => cl.Quantity)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CreditLine>()
                .Property(cl => cl.TaxRate)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<CreditLine>()
                .Property(cl => cl.TaxFee)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CreditLine>()
                .Property(cl => cl.TaxableAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CreditLine>()
                .Property(cl => cl.TaxAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CreditLine>()
                .Property(cl => cl.CurrencyId)
                .IsRequired();

            modelBuilder.Entity<InvoiceLine>()
                .HasKey(il => il.Id);

            modelBuilder.Entity<InvoiceLine>()
                .Property(il => il.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<InvoiceLine>()
                .Property(il => il.ProductCode)
                .HasMaxLength(50);

            modelBuilder.Entity<InvoiceLine>()
                .Property(il => il.LinePrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<InvoiceLine>()
                .Property(il => il.UnitPrice)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<InvoiceLine>()
                .Property(il => il.Quantity)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<InvoiceLine>()
                .Property(il => il.TaxRate)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<InvoiceLine>()
                .Property(il => il.TaxFee)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<InvoiceLine>()
                .Property(il => il.TaxableAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<InvoiceLine>()
                .Property(il => il.TaxAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<InvoiceLine>()
                .Property(il => il.CurrencyId)
                .IsRequired();

            modelBuilder.Entity<PurchaseOrderLine>()
                .HasKey(pol => pol.Id);

            modelBuilder.Entity<PurchaseOrderLine>()
                .Property(pol => pol.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<PurchaseOrderLine>()
                .Property(pol => pol.ProductCode)
                .HasMaxLength(50);

            modelBuilder.Entity<PurchaseOrderLine>()
                .Property(pol => pol.LinePrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrderLine>()
                .Property(pol => pol.UnitPrice)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<PurchaseOrderLine>()
                .Property(pol => pol.Quantity)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrderLine>()
                .Property(pol => pol.TaxRate)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<PurchaseOrderLine>()
                .Property(pol => pol.TaxFee)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrderLine>()
                .Property(pol => pol.TaxableAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrderLine>()
                .Property(pol => pol.TaxAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrderLine>()
                .Property(pol => pol.CurrencyId)
                .IsRequired();

            modelBuilder.Entity<CreditReference>()
                .HasKey(cr => cr.Id);

            modelBuilder.Entity<CreditReference>()
                .Property(cr => cr.Id)
                .HasMaxLength(100);

            modelBuilder.Entity<CreditReference>()
                .Property(cr => cr.Value)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<CreditReference>()
                .Property(cr => cr.SystemId)
                .IsRequired();

            modelBuilder.Entity<InvoiceReference>()
                .HasKey(ir => ir.Id);

            modelBuilder.Entity<InvoiceReference>()
                .Property(ir => ir.Id)
                .HasMaxLength(100);

            modelBuilder.Entity<InvoiceReference>()
                .Property(ir => ir.Value)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<InvoiceReference>()
                .Property(ir => ir.SystemId)
                .IsRequired();

            modelBuilder.Entity<PurchaseOrderReference>()
                .HasKey(por => por.Id);

            modelBuilder.Entity<PurchaseOrderReference>()
                .Property(por => por.Id)
                .HasMaxLength(100);

            modelBuilder.Entity<PurchaseOrderReference>()
                .Property(por => por.Value)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<PurchaseOrderReference>()
                .Property(por => por.SystemId)
                .IsRequired();

            modelBuilder.Entity<ActiveTransaction>()
                .HasKey(at => at.Id);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.Id)
                .HasMaxLength(100);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.TransactionType)
                .IsRequired();

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.DebtorReference)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.DebtorVATReference)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.CreditorReference)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.CreditorVATReference)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.FunderReference)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.TransactionReference)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.DebtorName)
                .HasMaxLength(200);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.DebtorExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.DebtorState)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.CreditorName)
                .HasMaxLength(200);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.CreditorExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.CreditorState)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.FundingState)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.FunderExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.RelatedTransactionReference)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.Comment)
                .HasMaxLength(500);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.Number)
                .HasMaxLength(50);

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.OfferValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.OfferRate)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.CostOfFunding)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.Value)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.ValueBeforeTax)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.ValueOfTax)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.FundableValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ActiveTransaction>()
                .Property(at => at.UnpaidValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Credit>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Credit>()
                .Property(c => c.DebtorName)
                .HasMaxLength(200);

            modelBuilder.Entity<Credit>()
               .Property(c => c.DebtorState)
               .HasMaxLength(50);

            modelBuilder.Entity<Credit>()
               .Property(c => c.DebtorExternalState)
               .HasMaxLength(50);

            modelBuilder.Entity<Credit>()
                .Property(c => c.CreditorName)
                .HasMaxLength(200);

            modelBuilder.Entity<Credit>()
               .Property(c => c.CreditorState)
               .HasMaxLength(50);

            modelBuilder.Entity<Credit>()
               .Property(c => c.CreditorExternalState)
               .HasMaxLength(50);

            modelBuilder.Entity<Credit>()
                .Property(c => c.FunderName)
                .HasMaxLength(200);

            modelBuilder.Entity<Credit>()
                .Property(c => c.FundingState)
                .HasMaxLength(50);

            modelBuilder.Entity<Credit>()
                .Property(c => c.FunderExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<Credit>()
                .Property(c => c.Comment)
                .HasMaxLength(500);

            modelBuilder.Entity<Credit>()
                .Property(c => c.Number)
                .HasMaxLength(50);

            modelBuilder.Entity<Credit>()
                .Property(c => c.Value)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Credit>()
                .Property(c => c.ValueBeforeTax)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Credit>()
                .Property(c => c.ValueOfTax)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Credit>()
                .Property(c => c.CurrencyId)
                .IsRequired();

            modelBuilder.Entity<Credit>()
                .Property(c => c.SourceSystemId)
                .IsRequired();

            modelBuilder.Entity<CreditType>()
                .HasKey(ct => ct.Id);

            modelBuilder.Entity<CreditType>()
                .Property(ct => ct.Name)
                .HasMaxLength(32);

            modelBuilder.Entity<Invoice>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.DebtorName)
                .HasMaxLength(200);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.DebtorState)
                .HasMaxLength(50);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.DebtorExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.CreditorName)
                .HasMaxLength(200);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.CreditorState)
                .HasMaxLength(50);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.CreditorExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.FunderName)
                .HasMaxLength(200);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.FundingState)
                .HasMaxLength(50);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.FunderExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Comment)
                .HasMaxLength(500);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Number)
                .HasMaxLength(50);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.ValueBeforeTax)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.ValueOfTax)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Value)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.SourceSystemId)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.CurrencyId)
                .IsRequired();

            modelBuilder.Entity<InvoiceType>()
                .HasKey(it => it.Id);

            modelBuilder.Entity<InvoiceType>()
                .Property(it => it.Name)
                .HasMaxLength(32);

            modelBuilder.Entity<PurchaseOrder>()
                .HasKey(po => po.Id);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.DebtorName)
                .HasMaxLength(200);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.DebtorState)
                .HasMaxLength(50);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.DebtorExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.CreditorName)
                .HasMaxLength(200);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.CreditorState)
                .HasMaxLength(50);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.CreditorExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.Comment)
                .HasMaxLength(500);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.Number)
                .HasMaxLength(50);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.ValueBeforeTax)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.ValueOfTax)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.Value)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.SourceSystemId)
                .IsRequired();

            modelBuilder.Entity<PurchaseOrder>()
                .Property(po => po.CurrencyId)
                .IsRequired();
        }

        private static void ConfigureTransactionsForeignKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCompany>()
                .HasOne(cc => cc.CompanyReference)
                .WithMany(cr => cr.CreditReferences)
                .HasForeignKey(cc => cc.CompanyReferenceId);

            modelBuilder.Entity<CreditCompany>()
                .HasOne(cc => cc.Credit)
                .WithMany(c => c.Companies)
                .HasForeignKey(cc => cc.CreditId);

            modelBuilder.Entity<InvoiceCompany>()
                .HasOne(ic => ic.CompanyReference)
                .WithMany(cr => cr.InvoiceReferences)
                .HasForeignKey(ic => ic.CompanyReferenceId);

            modelBuilder.Entity<InvoiceCompany>()
                .HasOne(ic => ic.Invoice)
                .WithMany(i => i.Companies)
                .HasForeignKey(ic => ic.InvoiceId);

            modelBuilder.Entity<PurchaseOrderCompany>()
                .HasOne(poc => poc.CompanyReference)
                .WithMany(cr => cr.PurchaseOrderReferences)
                .HasForeignKey(poc => poc.CompanyReferenceId);

            modelBuilder.Entity<PurchaseOrderCompany>()
                .HasOne(poc => poc.PurchaseOrder)
                .WithMany(cr => cr.Companies)
                .HasForeignKey(poc => poc.PurchaseOrderId);

            modelBuilder.Entity<CreditLine>()
                .HasOne(cl => cl.Currency)
                .WithMany(c => c.CreditLines)
                .HasForeignKey(cl => cl.CurrencyId);

            modelBuilder.Entity<CreditLine>()
                .HasOne(cl => cl.Credit)
                .WithMany(c => c.Lines)
                .HasForeignKey(cl => cl.CreditId);

            modelBuilder.Entity<InvoiceLine>()
                .HasOne(il => il.Currency)
                .WithMany(c => c.InvoiceLines)
                .HasForeignKey(il => il.CurrencyId);

            modelBuilder.Entity<InvoiceLine>()
                .HasOne(il => il.Invoice)
                .WithMany(i => i.Lines)
                .HasForeignKey(il => il.InvoiceId);

            modelBuilder.Entity<PurchaseOrderLine>()
                .HasOne(pol => pol.Currency)
                .WithMany(c => c.PurchaseOrderLines)
                .HasForeignKey(pol => pol.CurrencyId);

            modelBuilder.Entity<PurchaseOrderLine>()
                .HasOne(pol => pol.PurchaseOrder)
                .WithMany(po => po.Lines)
                .HasForeignKey(pol => pol.PurchaseOrderId);

            modelBuilder.Entity<CreditReference>()
                .HasOne(cr => cr.System)
                .WithMany(s => s.CreditReferences)
                .HasForeignKey(cr => cr.SystemId);

            modelBuilder.Entity<CreditReference>()
                .HasOne(cr => cr.Credit)
                .WithMany(c => c.References)
                .HasForeignKey(cr => cr.CreditId);

            modelBuilder.Entity<CreditReference>()
                .HasMany(cr => cr.OfferLines)
                .WithOne(ol => ol.CreditReference)
                .HasForeignKey(ol => ol.CreditReferenceId);

            modelBuilder.Entity<CreditReference>()
                .HasMany(cr => cr.RemittanceAdviceLines)
                .WithOne(ral => ral.CreditReference)
                .HasForeignKey(ral => ral.CreditReferenceId);

            modelBuilder.Entity<InvoiceReference>()
                .HasOne(ir => ir.System)
                .WithMany(s => s.InvoiceReferences)
                .HasForeignKey(ir => ir.SystemId);

            modelBuilder.Entity<InvoiceReference>()
                .HasOne(ir => ir.Invoice)
                .WithMany(i => i.References)
                .HasForeignKey(ir => ir.InvoiceId);

            modelBuilder.Entity<InvoiceReference>()
                .HasMany(ir => ir.Credits)
                .WithOne(c => c.InvoiceReference)
                .HasForeignKey(c => c.InvoiceReferenceId);

            modelBuilder.Entity<InvoiceReference>()
                .HasMany(ir => ir.OfferLines)
                .WithOne(ol => ol.InvoiceReference)
                .HasForeignKey(ol => ol.InvoiceReferenceId);

            modelBuilder.Entity<InvoiceReference>()
                .HasMany(ir => ir.RemittanceAdviceLines)
                .WithOne(ral => ral.InvoiceReference)
                .HasForeignKey(ral => ral.InvoiceReferenceId);

            modelBuilder.Entity<PurchaseOrderReference>()
                .HasOne(por => por.System)
                .WithMany(s => s.PurchaseOrderReferences)
                .HasForeignKey(por => por.SystemId);

            modelBuilder.Entity<PurchaseOrderReference>()
                .HasOne(por => por.PurchaseOrder)
                .WithMany(po => po.References)
                .HasForeignKey(por => por.PurchaseOrderId);

            modelBuilder.Entity<PurchaseOrderReference>()
                .HasMany(por => por.RemittanceAdviceLines)
                .WithOne(ral => ral.PurchaseOrderReference)
                .HasForeignKey(ral => ral.PurchaseOrderReferenceId);

            modelBuilder.Entity<ActiveTransaction>()
                .HasOne(at => at.SourceSystem)
                .WithMany(s => s.ActiveTransactions)
                .HasForeignKey(at => at.SourceSystemId);

            modelBuilder.Entity<ActiveTransaction>()
                .HasOne(at => at.Currency)
                .WithMany(c => c.ActiveTransactions)
                .HasForeignKey(at => at.CurrencyId);

            modelBuilder.Entity<ActiveTransaction>()
                .HasMany(at => at.Buckets)
                .WithOne(bat => bat.ActiveTransaction)
                .HasForeignKey(bat => bat.ActiveTransactionId);

            modelBuilder.Entity<Credit>()
                .HasOne(c => c.Currency)
                .WithMany(c => c.Credits)
                .HasForeignKey(c => c.CurrencyId);

            modelBuilder.Entity<Credit>()
                .HasOne(c => c.SourceSystem)
                .WithMany(s => s.Credits)
                .HasForeignKey(c => c.SourceSystemId);

            modelBuilder.Entity<Credit>()
                .HasOne(c => c.CreditType)
                .WithMany(ct => ct.Credits)
                .HasForeignKey(c => c.CreditTypeId);

            modelBuilder.Entity<Credit>()
                .HasOne(c => c.InvoiceReference)
                .WithMany(ir => ir.Credits)
                .HasForeignKey(c => c.InvoiceReferenceId);

            modelBuilder.Entity<Credit>()
                .HasMany(c => c.AuditTrail)
                .WithOne(cai => cai.Credit)
                .HasForeignKey(cai => cai.CreditId);

            modelBuilder.Entity<Credit>()
                .HasMany(c => c.Lines)
                .WithOne(cl => cl.Credit)
                .HasForeignKey(cl => cl.CreditId);

            modelBuilder.Entity<Credit>()
                .HasMany(c => c.References)
                .WithOne(cr => cr.Credit)
                .HasForeignKey(cr => cr.CreditId);

            modelBuilder.Entity<Credit>()
                .HasMany(c => c.Companies)
                .WithOne(cc => cc.Credit)
                .HasForeignKey(cc => cc.CreditId);

            modelBuilder.Entity<Credit>()
                .HasMany(c => c.Buckets)
                .WithOne(bc => bc.Credit)
                .HasForeignKey(bc => bc.CreditId);

            modelBuilder.Entity<CreditType>()
                .HasMany(ct => ct.Credits)
                .WithOne(c => c.CreditType)
                .HasForeignKey(c => c.CreditTypeId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.SourceSystem)
                .WithMany(s => s.Invoices)
                .HasForeignKey(i => i.SourceSystemId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Currency)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CurrencyId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.InvoiceType)
                .WithMany(it => it.Invoices)
                .HasForeignKey(i => i.InvoiceTypeId);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.AuditTrail)
                .WithOne(iai => iai.Invoice)
                .HasForeignKey(iai => iai.InvoiceId);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.Lines)
                .WithOne(il => il.Invoice)
                .HasForeignKey(il => il.InvoiceId);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.References)
                .WithOne(ir => ir.Invoice)
                .HasForeignKey(ir => ir.InvoiceId);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.Companies)
                .WithOne(ic => ic.Invoice)
                .HasForeignKey(ic => ic.InvoiceId);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.Buckets)
                .WithOne(bi => bi.Invoice)
                .HasForeignKey(bi => bi.InvoiceId);

            modelBuilder.Entity<InvoiceType>()
                .HasMany(it => it.Invoices)
                .WithOne(i => i.InvoiceType)
                .HasForeignKey(i => i.InvoiceTypeId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.SourceSystem)
                .WithMany(s => s.PurchaseOrders)
                .HasForeignKey(po => po.SourceSystemId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(po => po.Currency)
                .WithMany(c => c.PurchaseOrders)
                .HasForeignKey(po => po.CurrencyId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(po => po.AuditTrail)
                .WithOne(poai => poai.PurchaseOrder)
                .HasForeignKey(poai => poai.PurchaseOrderId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(po => po.Lines)
                .WithOne(pol => pol.PurchaseOrder)
                .HasForeignKey(pol => pol.PurchaseOrderId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(po => po.References)
                .WithOne(ir => ir.PurchaseOrder)
                .HasForeignKey(poc => poc.PurchaseOrderId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(po => po.Companies)
                .WithOne(ic => ic.PurchaseOrder)
                .HasForeignKey(poc => poc.PurchaseOrderId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(po => po.Buckets)
                .WithOne(bi => bi.PurchaseOrder)
                .HasForeignKey(bpo => bpo.PurchaseOrderId);
        }
    }
}