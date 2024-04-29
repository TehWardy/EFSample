using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;
using B2BSystem = B2B.Objects.Entities.Masterdata.System;

namespace B2B.Data.EF
{
    public partial class B2BMSSQLModelBuildProvider
    {
        private static void ConfigureMasterdata(ModelBuilder modelBuilder)
        {
            ConfigureMasterdataModel(modelBuilder);
        }

        public static void ConfigureMasterdataModel(ModelBuilder modelBuilder)
        {
            ConfigureMasterdataTables(modelBuilder);
            ConfigureMasterdataColumns(modelBuilder);
            ConfigureMasterdataForeignKeys(modelBuilder);
            ConfigureMasterdataIndexes(modelBuilder);
        }

        private static void ConfigureMasterdataIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BucketUser>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<BucketActiveTransaction>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<BucketCompany>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<BucketCredit>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<BucketInvoice>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<BucketOffer>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<BucketPayee>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<BucketPurchaseOrder>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<BucketRemittanceAdvice>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<BucketRole>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<BucketSystem>().HasIndex(i => i.BucketId);
            modelBuilder.Entity<CompanyPayee>().HasIndex(i => i.CompanyId);
        }

        private static void ConfigureMasterdataTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .ToTable("Addresses", "Masterdata");

            modelBuilder.Entity<Bucket>()
                .ToTable("Buckets", "Masterdata");

            modelBuilder.Entity<BucketActiveTransaction>()
                .ToTable("BucketActiveTransactions", "Masterdata");

            modelBuilder.Entity<BucketCompany>()
                .ToTable("BucketCompanies", "Masterdata");

            modelBuilder.Entity<BucketInvoice>()
                .ToTable("BucketInvoices", "Masterdata");

            modelBuilder.Entity<BucketCredit>()
                .ToTable("BucketCredits", "Masterdata");

            modelBuilder.Entity<BucketOffer>()
                .ToTable("BucketOffers", "Masterdata");

            modelBuilder.Entity<BucketPayee>()
                .ToTable("BucketPayees", "Masterdata");

            modelBuilder.Entity<BucketPurchaseOrder>()
                .ToTable("BucketPurchaseOrders", "Masterdata");

            modelBuilder.Entity<BucketRemittanceAdvice>()
                .ToTable("BucketRemittanceAdvices", "Masterdata");

            modelBuilder.Entity<BucketRole>()
                .ToTable("BucketRoles", "Masterdata");

            modelBuilder.Entity<BucketSystem>()
                .ToTable("BucketSystems", "Masterdata");

            modelBuilder.Entity<BucketUser>()
                .ToTable("BucketUsers", "Masterdata");

            modelBuilder.Entity<Company>()
                .ToTable("Companies", "Masterdata");

            modelBuilder.Entity<CompanyPayee>()
                .ToTable("CompanyPayees", "Masterdata");

            modelBuilder.Entity<CompanyReference>()
                .ToTable("CompanyReferences", "Masterdata");

            modelBuilder.Entity<Country>()
                .ToTable("Countries", "Masterdata");

            modelBuilder.Entity<Currency>()
                .ToTable("Currencies", "Masterdata");

            modelBuilder.Entity<B2BSystem>()
                .ToTable("Systems", "Masterdata");
        }

        private static void ConfigureMasterdataColumns(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Address>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Address>()
                .Property(a => a.PoBox)
                .HasMaxLength(10);

            modelBuilder.Entity<Address>()
                .Property(a => a.Line1)
                .HasMaxLength(200);

            modelBuilder.Entity<Address>()
                .Property(a => a.Line2)
                .HasMaxLength(200);

            modelBuilder.Entity<Address>()
                .Property(a => a.ZipOrPostalCode)
                .HasMaxLength(20);

            modelBuilder.Entity<Address>()
                .Property(a => a.TownOrCity)
                .HasMaxLength(100);

            modelBuilder.Entity<Address>()
                .Property(a => a.StateOrProvince)
                .HasMaxLength(100);

            modelBuilder.Entity<Address>()
                .Property(a => a.CountryId)
                .IsRequired();

            modelBuilder.Entity<Bucket>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Bucket>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Bucket>()
                .Property(b => b.Key)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Bucket>()
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Bucket>()
                .Property(b => b.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<BucketCompany>()
                .HasKey(i => new { i.BucketId, i.CompanyId });

            modelBuilder.Entity<BucketActiveTransaction>()
                .HasKey(i => new { i.BucketId, i.ActiveTransactionId });

            modelBuilder.Entity<BucketInvoice>()
                .HasKey(i => new { i.BucketId, i.InvoiceId });

            modelBuilder.Entity<BucketPurchaseOrder>()
                .HasKey(i => new { i.BucketId, i.PurchaseOrderId });

            modelBuilder.Entity<BucketCredit>()
                .HasKey(i => new { i.BucketId, i.CreditId });

            modelBuilder.Entity<BucketOffer>()
                .HasKey(i => new { i.BucketId, i.OfferId });

            modelBuilder.Entity<BucketPayee>()
                .HasKey(i => new { i.BucketId, i.PayeeId });

            modelBuilder.Entity<BucketRemittanceAdvice>()
                .HasKey(i => new { i.BucketId, i.RemittanceAdviceId });

            modelBuilder.Entity<BucketRole>()
                .HasKey(i => new { i.BucketId, i.RoleId });

            modelBuilder.Entity<BucketSystem>()
                .HasKey(i => new { i.BucketId, i.SystemId });

            modelBuilder.Entity<BucketUser>()
                .HasKey(i => new { i.BucketId, i.UserId });

            modelBuilder.Entity<CompanyPayee>()
                .HasKey(i => new { i.CompanyId, i.PayeeId });

            modelBuilder.Entity<Company>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Company>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Company>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Company>()
                .Property(c => c.WebsiteUrl)
                .HasMaxLength(500);

            modelBuilder.Entity<Company>()
                .Property(c => c.CreatedBy)
                .HasMaxLength(100);

            modelBuilder.Entity<Company>()
                .Property(c => c.LastUpdatedBy)
                .HasMaxLength(100);

            modelBuilder.Entity<CompanyReference>()
                .HasKey(cr => cr.Id);

            modelBuilder.Entity<CompanyReference>()
                .Property(cr => cr.Id)
                .HasMaxLength(100);

            modelBuilder.Entity<CompanyReference>()
                .Property(cr => cr.Value)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<CompanyReference>()
                .Property(cr => cr.SystemId)
                .IsRequired();

            modelBuilder.Entity<Country>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Country>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Currency>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Currency>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Currency>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<B2BSystem>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<B2BSystem>()
                .Property(s => s.Id)
                .HasMaxLength(50);

            modelBuilder.Entity<B2BSystem>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<B2BSystem>().
                Property(s => s.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<B2BSystem>()
                .Property(s => s.Description)
                .IsRequired();

            modelBuilder.Entity<B2BSystem>()
                .Property(s => s.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<B2BSystem>()
                .Property(s => s.CreatedBy)
                .HasMaxLength(100);

            modelBuilder.Entity<B2BSystem>()
                .Property(s => s.LastUpdatedBy)
                .HasMaxLength(100);
        }

        private static void ConfigureMasterdataForeignKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CountryId);

            modelBuilder.Entity<Address>()
                .HasMany(a => a.Banks)
                .WithOne(b => b.Address)
                .HasForeignKey(b => b.AddressId);

            modelBuilder.Entity<Address>()
                .HasMany(a => a.BankBranches)
                .WithOne(bb => bb.Address)
                .HasForeignKey(bb => bb.AddressId);

            modelBuilder.Entity<Address>()
                .HasMany(a => a.Companies)
                .WithOne(c => c.Address)
                .HasForeignKey(c => c.AddressId);

            modelBuilder.Entity<Address>()
                .HasMany(a => a.Payees)
                .WithOne(p => p.Address)
                .HasForeignKey(p => p.AddressId);

            modelBuilder.Entity<Bucket>()
                .HasOne(b => b.Parent)
                .WithMany(b => b.Buckets)
                .HasForeignKey(b => b.ParentId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.Systems)
                .WithOne(bs => bs.Bucket)
                .HasForeignKey(bs => bs.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.Companies)
                .WithOne(bc => bc.Bucket)
                .HasForeignKey(bc => bc.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.Roles)
                .WithOne(br => br.Bucket)
                .HasForeignKey(br => br.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.BankAccounts)
                .WithOne(baa => baa.Bucket)
                .HasForeignKey(baa => baa.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.Payees)
                .WithOne(bp => bp.Bucket)
                .HasForeignKey(bp => bp.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.Users)
                .WithOne(bu => bu.Bucket)
                .HasForeignKey(bu => bu.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.Invoices)
                .WithOne(bi => bi.Bucket)
                .HasForeignKey(bi => bi.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.RemittanceAdvices)
                .WithOne(bra => bra.Bucket)
                .HasForeignKey(bra => bra.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.Offers)
                .WithOne(bo => bo.Bucket)
                .HasForeignKey(bo => bo.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.PurchaseOrders)
                .WithOne(bpo => bpo.Bucket)
                .HasForeignKey(bpo => bpo.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.Credits)
                .WithOne(bc => bc.Bucket)
                .HasForeignKey(bc => bc.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.ActiveTransactions)
                .WithOne(bat => bat.Bucket)
                .HasForeignKey(bat => bat.BucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.Buckets)
                .WithOne(b => b.Parent)
                .HasForeignKey(b => b.ParentId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.FundingDetails)
                .WithOne(fd => fd.FundingTypeBucket)
                .HasForeignKey(fd => fd.FundingTypeBucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.CompanyCSVLines)
                .WithOne(ccsvl => ccsvl.RootBucket)
                .HasForeignKey(cssvl => cssvl.RootBucketId);

            modelBuilder.Entity<Bucket>()
                .HasMany(b => b.TransactionCSVLines)
                .WithOne(tcsvl => tcsvl.RootBucket)
                .HasForeignKey(tcsvl => tcsvl.RootBucketId);

            modelBuilder.Entity<BucketActiveTransaction>()
                .HasOne(bat => bat.Bucket)
                .WithMany(b => b.ActiveTransactions)
                .HasForeignKey(bat => bat.BucketId);

            modelBuilder.Entity<BucketActiveTransaction>()
                .HasOne(bat => bat.ActiveTransaction)
                .WithMany(a => a.Buckets)
                .HasForeignKey(bat => bat.ActiveTransactionId);

            modelBuilder.Entity<BucketCompany>()
                .HasOne(bc => bc.Bucket)
                .WithMany(b => b.Companies)
                .HasForeignKey(bc => bc.BucketId);

            modelBuilder.Entity<BucketCompany>()
                .HasOne(bc => bc.Company)
                .WithMany(c => c.Buckets)
                .HasForeignKey(bc => bc.CompanyId);

            modelBuilder.Entity<BucketCredit>()
                .HasOne(bc => bc.Bucket)
                .WithMany(b => b.Credits)
                .HasForeignKey(bc => bc.BucketId);

            modelBuilder.Entity<BucketCredit>()
                .HasOne(bc => bc.Credit)
                .WithMany(c => c.Buckets)
                .HasForeignKey(bc => bc.CreditId);

            modelBuilder.Entity<BucketInvoice>()
                .HasOne(bi => bi.Bucket)
                .WithMany(b => b.Invoices)
                .HasForeignKey(bi => bi.BucketId);

            modelBuilder.Entity<BucketInvoice>()
                .HasOne(bi => bi.Invoice)
                .WithMany(i => i.Buckets)
                .HasForeignKey(bi => bi.InvoiceId);

            modelBuilder.Entity<BucketOffer>()
                .HasOne(bo => bo.Bucket)
                .WithMany(b => b.Offers)
                .HasForeignKey(bo => bo.BucketId);

            modelBuilder.Entity<BucketOffer>()
                .HasOne(bo => bo.Offer)
                .WithMany(o => o.Buckets)
                .HasForeignKey(bo => bo.OfferId);

            modelBuilder.Entity<BucketPayee>()
                .HasOne(bp => bp.Bucket)
                .WithMany(b => b.Payees)
                .HasForeignKey(bp => bp.BucketId);

            modelBuilder.Entity<BucketPayee>()
                .HasOne(bp => bp.Payee)
                .WithMany(p => p.Buckets)
                .HasForeignKey(bp => bp.PayeeId);

            modelBuilder.Entity<BucketPurchaseOrder>()
                .HasOne(bpo => bpo.Bucket)
                .WithMany(b => b.PurchaseOrders)
                .HasForeignKey(bpo => bpo.BucketId);

            modelBuilder.Entity<BucketPurchaseOrder>()
                .HasOne(bpo => bpo.PurchaseOrder)
                .WithMany(po => po.Buckets)
                .HasForeignKey(bpo => bpo.PurchaseOrderId);

            modelBuilder.Entity<BucketRemittanceAdvice>()
                .HasOne(bra => bra.Bucket)
                .WithMany(b => b.RemittanceAdvices)
                .HasForeignKey(bra => bra.BucketId);

            modelBuilder.Entity<BucketRemittanceAdvice>()
                .HasOne(bra => bra.RemittanceAdvice)
                .WithMany(ra => ra.Buckets)
                .HasForeignKey(bra => bra.RemittanceAdviceId);

            modelBuilder.Entity<BucketRole>()
                .HasOne(br => br.Bucket)
                .WithMany(b => b.Roles)
                .HasForeignKey(br => br.BucketId);

            modelBuilder.Entity<BucketRole>()
                .HasOne(br => br.Role)
                .WithMany(r => r.Buckets)
                .HasForeignKey(br => br.RoleId);

            modelBuilder.Entity<BucketSystem>()
                .HasOne(bs => bs.Bucket)
                .WithMany(b => b.Systems)
                .HasForeignKey(bs => bs.BucketId);

            modelBuilder.Entity<BucketSystem>()
                .HasOne(bs => bs.System)
                .WithMany(s => s.Buckets)
                .HasForeignKey(bs => bs.SystemId);

            modelBuilder.Entity<BucketUser>()
                .HasOne(bu => bu.Bucket)
                .WithMany(b => b.Users)
                .HasForeignKey(bu => bu.BucketId);

            modelBuilder.Entity<BucketUser>()
                .HasOne(bu => bu.User)
                .WithMany(u => u.Buckets)
                .HasForeignKey(bu => bu.UserId);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.Address)
                .WithMany(a => a.Companies)
                .HasForeignKey(c => c.AddressId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.References)
                .WithOne(cr => cr.Company)
                .HasForeignKey(cr => cr.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Buckets)
                .WithOne(bc => bc.Company)
                .HasForeignKey(bc => bc.CompanyId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Payees)
                .WithOne(cp => cp.Company)
                .HasForeignKey(cp => cp.CompanyId);

            modelBuilder.Entity<CompanyPayee>()
                .HasOne(cp => cp.Company)
                .WithMany(c => c.Payees)
                .HasForeignKey(cp => cp.CompanyId);

            modelBuilder.Entity<CompanyPayee>()
                .HasOne(cp => cp.Payee)
                .WithMany(p => p.Companies)
                .HasForeignKey(cp => cp.PayeeId);

            modelBuilder.Entity<CompanyReference>()
                .HasOne(cr => cr.System)
                .WithMany(s => s.CompanyReferences)
                .HasForeignKey(cr => cr.SystemId);

            modelBuilder.Entity<CompanyReference>()
                .HasOne(cr => cr.Company)
                .WithMany(c => c.References)
                .HasForeignKey(cr => cr.CompanyId);

            modelBuilder.Entity<CompanyReference>()
                .HasMany(cr => cr.InvoiceReferences)
                .WithOne(ic => ic.CompanyReference)
                .HasForeignKey(ic => ic.CompanyReferenceId);

            modelBuilder.Entity<CompanyReference>()
                .HasMany(cr => cr.CreditReferences)
                .WithOne(cc => cc.CompanyReference)
                .HasForeignKey(cc => cc.CompanyReferenceId);

            modelBuilder.Entity<CompanyReference>()
                .HasMany(cr => cr.PurchaseOrderReferences)
                .WithOne(poc => poc.CompanyReference)
                .HasForeignKey(poc => poc.CompanyReferenceId);

            modelBuilder.Entity<CompanyReference>()
                .HasMany(cr => cr.RemittanceAdviceReferences)
                .WithOne(rac => rac.CompanyReference)
                .HasForeignKey(rac => rac.CompanyReferenceId);

            modelBuilder.Entity<CompanyReference>()
                .HasMany(cr => cr.OfferReferences)
                .WithOne(oc => oc.CompanyReference)
                .HasForeignKey(oc => oc.CompanyReferenceId);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Addresses)
                .WithOne(a => a.Country)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.RemittenceAdvices)
                .WithOne(ra => ra.Currency)
                .HasForeignKey(ra => ra.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.Invoices)
                .WithOne(i => i.Currency)
                .HasForeignKey(i => i.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.Credits)
                .WithOne(c => c.Currency)
                .HasForeignKey(c => c.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.Offers)
                .WithOne(o => o.Currency)
                .HasForeignKey(o => o.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.PurchaseOrders)
                .WithOne(po => po.Currency);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.FundingDetails)
                .WithOne(fd => fd.Currency)
                .HasForeignKey(fd => fd.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.OfferLines)
                .WithOne(ol => ol.Currency)
                .HasForeignKey(c => c.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.PurchaseOrderLines)
                .WithOne(pol => pol.Currency)
                .HasForeignKey(pol => pol.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.CreditLines)
                .WithOne(cl => cl.Currency)
                .HasForeignKey(cl => cl.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.InvoiceLines)
                .WithOne(il => il.Currency)
                .HasForeignKey(il => il.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.RemittanceAdviceLines)
                .WithOne(ral => ral.Currency)
                .HasForeignKey(ral => ral.CurrencyId);

            modelBuilder.Entity<Currency>()
                .HasMany(c => c.ActiveTransactions)
                .WithOne(at => at.Currency)
                .HasForeignKey(at => at.CurrencyId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.Buckets)
                .WithOne(s => s.System)
                .HasForeignKey(s => s.SystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.CompanyReferences)
                .WithOne(s => s.System)
                .HasForeignKey(s => s.SystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.InvoiceReferences)
                .WithOne(s => s.System)
                .HasForeignKey(s => s.SystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.CreditReferences)
                .WithOne(s => s.System)
                .HasForeignKey(s => s.SystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.OfferReferences)
                .WithOne(s => s.System)
                .HasForeignKey(s => s.SystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.PurchaseOrderReferences)
                .WithOne(s => s.System)
                .HasForeignKey(s => s.SystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.RemittanceAdviceReferences)
                .WithOne(s => s.System)
                .HasForeignKey(s => s.SystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.FundingDetails)
                .WithOne(s => s.System)
                .HasForeignKey(s => s.SystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.Offers)
                .WithOne(o => o.SourceSystem)
                .HasForeignKey(o => o.SourceSystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.Invoices)
                .WithOne(i => i.SourceSystem)
                .HasForeignKey(i => i.SourceSystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.Credits)
                .WithOne(c => c.SourceSystem)
                .HasForeignKey(c => c.SourceSystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.PurchaseOrders)
                .WithOne(po => po.SourceSystem)
                .HasForeignKey(s => s.SourceSystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.RemittanceAdvices)
                .WithOne(ra => ra.SourceSystem)
                .HasForeignKey(s => s.SourceSystemId);

            modelBuilder.Entity<B2BSystem>()
                .HasMany(s => s.ActiveTransactions)
                .WithOne(at => at.SourceSystem)
                .HasForeignKey(at => at.SourceSystemId);
        }
    }
}