using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Transactions");

            migrationBuilder.EnsureSchema(
                name: "Masterdata");

            migrationBuilder.EnsureSchema(
                name: "Logging");

            migrationBuilder.EnsureSchema(
                name: "Banking");

            migrationBuilder.EnsureSchema(
                name: "Import");

            migrationBuilder.EnsureSchema(
                name: "Finance");

            migrationBuilder.EnsureSchema(
                name: "Payments");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "AuditItemLevels",
                schema: "Logging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditItemLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buckets",
                schema: "Masterdata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buckets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buckets_Buckets_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Masterdata",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InEuropeanUnion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditTypes",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "Masterdata",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTypes",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogEntries",
                schema: "Logging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RemittanceAdviceTypes",
                schema: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemittanceAdviceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Privs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsersArePortalAdmins = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                schema: "Masterdata",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCSVLines",
                schema: "Import",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RootBucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Perspective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressZipOrPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressTownOrCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressPoBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressCountryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlobalTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceSystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceSeperator = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessingState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailureMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCSVLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCSVLines_Buckets_RootBucketId",
                        column: x => x.RootBucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "Masterdata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PoBox = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Line1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipOrPostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TownOrCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StateOrProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Masterdata",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogDataItems",
                schema: "Logging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogEntryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogDataItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogDataItems_LogEntries_LogEntryId",
                        column: x => x.LogEntryId,
                        principalSchema: "Logging",
                        principalTable: "LogEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BucketRoles",
                schema: "Masterdata",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketRoles", x => new { x.BucketId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_BucketRoles_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActiveTransactions",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    DebtorReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebtorVATReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorVATReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FunderReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransactionReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FundingState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FunderExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RelatedTransactionReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OfferValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OfferRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CostOfFunding = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ValueBeforeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValueOfTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FundableValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnpaidValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OfferExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DebtorGeneralLedgerDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreditorGeneralLedgerDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TaxPoint = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AgreedDiscountPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ProposedDiscountPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    OfferAcceptanceDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SourceSystemId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreditorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DebtorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ReceivedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CaptureDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DebtorPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveTransactions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActiveTransactions_Systems_SourceSystemId",
                        column: x => x.SourceSystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BucketSystems",
                schema: "Masterdata",
                columns: table => new
                {
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketSystems", x => new { x.BucketId, x.SystemId });
                    table.ForeignKey(
                        name: "FK_BucketSystems_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketSystems_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundingDetails",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingTypeBucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsSystematic = table.Column<bool>(type: "bit", nullable: false),
                    CurrentLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Limit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunderReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundingDetails_Buckets_FundingTypeBucketId",
                        column: x => x.FundingTypeBucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundingDetails_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FundingDetails_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    SourceSystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DebtorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreditorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DebtorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ReceivedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DebtorPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CaptureDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DebtorGeneralLedgerDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreditorGeneralLedgerDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TaxPoint = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ValueBeforeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValueOfTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FunderExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AgreedDiscountPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    FundingState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FunderName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceTypes_InvoiceTypeId",
                        column: x => x.InvoiceTypeId,
                        principalSchema: "Transactions",
                        principalTable: "InvoiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Systems_SourceSystemId",
                        column: x => x.SourceSystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunderName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FunderState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FunderExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebtorAcceptanceRule = table.Column<bool>(type: "bit", nullable: true),
                    CreditorAcceptanceRule = table.Column<bool>(type: "bit", nullable: true),
                    FunderAcceptanceRule = table.Column<bool>(type: "bit", nullable: true),
                    IssueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EarliestRelatedTaxPoint = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TransactionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FundableValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SourceSystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DebtorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreditorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DebtorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ReceivedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DebtorPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CaptureDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Systems_SourceSystemId",
                        column: x => x.SourceSystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceSystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DebtorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreditorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DebtorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ReceivedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DebtorPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CaptureDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DebtorGeneralLedgerDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreditorGeneralLedgerDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TaxPoint = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ValueBeforeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValueOfTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Systems_SourceSystemId",
                        column: x => x.SourceSystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                schema: "Banking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Masterdata",
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Masterdata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTradingEnabled = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Masterdata",
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Masterdata",
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BucketActiveTransactions",
                schema: "Masterdata",
                columns: table => new
                {
                    ActiveTransactionId = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketActiveTransactions", x => new { x.BucketId, x.ActiveTransactionId });
                    table.ForeignKey(
                        name: "FK_BucketActiveTransactions_ActiveTransactions_ActiveTransactionId",
                        column: x => x.ActiveTransactionId,
                        principalSchema: "Transactions",
                        principalTable: "ActiveTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketActiveTransactions_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BucketInvoices",
                schema: "Masterdata",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketInvoices", x => new { x.BucketId, x.InvoiceId });
                    table.ForeignKey(
                        name: "FK_BucketInvoices_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Transactions",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LinePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxableAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsFundable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Transactions",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceReferences",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceReferences_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Transactions",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceReferences_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BucketOffers",
                schema: "Masterdata",
                columns: table => new
                {
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketOffers", x => new { x.BucketId, x.OfferId });
                    table.ForeignKey(
                        name: "FK_BucketOffers_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalSchema: "Finance",
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferDataItems",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferDataItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferDataItems_Offers_OfferId",
                        column: x => x.OfferId,
                        principalSchema: "Finance",
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferReferences",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferReferences_Offers_OfferId",
                        column: x => x.OfferId,
                        principalSchema: "Finance",
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferReferences_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BucketPurchaseOrders",
                schema: "Masterdata",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketPurchaseOrders", x => new { x.BucketId, x.PurchaseOrderId });
                    table.ForeignKey(
                        name: "FK_BucketPurchaseOrders_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketPurchaseOrders_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalSchema: "Transactions",
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLines",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LinePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxableAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLines_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLines_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalSchema: "Transactions",
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderReferences",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderReferences_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalSchema: "Transactions",
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderReferences_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankBranches",
                schema: "Banking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankBranches_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Masterdata",
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankBranches_Banks_BankId",
                        column: x => x.BankId,
                        principalSchema: "Banking",
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BucketCompanies",
                schema: "Masterdata",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketCompanies", x => new { x.BucketId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_BucketCompanies_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Masterdata",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyReferences",
                schema: "Masterdata",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyReferences_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Masterdata",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyReferences_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BucketUsers",
                schema: "Masterdata",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketUsers", x => new { x.BucketId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BucketUsers_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketUsers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceAuditItems",
                schema: "Logging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AuditItemLevelId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceAuditItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceAuditItems_AuditItemLevels_AuditItemLevelId",
                        column: x => x.AuditItemLevelId,
                        principalSchema: "Logging",
                        principalTable: "AuditItemLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceAuditItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Transactions",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceAuditItems_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfferAuditItems",
                schema: "Logging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AuditItemLevelId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferAuditItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferAuditItems_AuditItemLevels_AuditItemLevelId",
                        column: x => x.AuditItemLevelId,
                        principalSchema: "Logging",
                        principalTable: "AuditItemLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferAuditItems_Offers_OfferId",
                        column: x => x.OfferId,
                        principalSchema: "Finance",
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferAuditItems_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderAuditItems",
                schema: "Logging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AuditItemLevelId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderAuditItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderAuditItems_AuditItemLevels_AuditItemLevelId",
                        column: x => x.AuditItemLevelId,
                        principalSchema: "Logging",
                        principalTable: "AuditItemLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderAuditItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalSchema: "Transactions",
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderAuditItems_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RemittanceAdvices",
                schema: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Effective = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FunderState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemittanceAdviceTypeId = table.Column<int>(type: "int", nullable: false),
                    B2BUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SourceSystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DebtorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreditorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DebtorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ReceivedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DebtorPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CaptureDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemittanceAdvices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemittanceAdvices_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemittanceAdvices_RemittanceAdviceTypes_RemittanceAdviceTypeId",
                        column: x => x.RemittanceAdviceTypeId,
                        principalSchema: "Payments",
                        principalTable: "RemittanceAdviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemittanceAdvices_Systems_SourceSystemId",
                        column: x => x.SourceSystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemittanceAdvices_Users_B2BUserId",
                        column: x => x.B2BUserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Security",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditTypeId = table.Column<int>(type: "int", nullable: false),
                    InvoiceReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SourceSystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DebtorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreditorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DebtorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditorExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ReceivedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DebtorPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CaptureDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DebtorGeneralLedgerDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreditorGeneralLedgerDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TaxPoint = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ValueBeforeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValueOfTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FunderExternalState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AgreedDiscountPaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    FundingState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FunderName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_CreditTypes_CreditTypeId",
                        column: x => x.CreditTypeId,
                        principalSchema: "Transactions",
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Credits_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Credits_InvoiceReferences_InvoiceReferenceId",
                        column: x => x.InvoiceReferenceId,
                        principalSchema: "Transactions",
                        principalTable: "InvoiceReferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Credits_Systems_SourceSystemId",
                        column: x => x.SourceSystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                schema: "Banking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankBranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_BankBranches_BankBranchId",
                        column: x => x.BankBranchId,
                        principalSchema: "Banking",
                        principalTable: "BankBranches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceCompanies",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Perspective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceCompanies_CompanyReferences_CompanyReferenceId",
                        column: x => x.CompanyReferenceId,
                        principalSchema: "Masterdata",
                        principalTable: "CompanyReferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceCompanies_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Transactions",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferCompanies",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Perspective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferCompanies_CompanyReferences_CompanyReferenceId",
                        column: x => x.CompanyReferenceId,
                        principalSchema: "Masterdata",
                        principalTable: "CompanyReferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferCompanies_Offers_OfferId",
                        column: x => x.OfferId,
                        principalSchema: "Finance",
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderCompanies",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Perspective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderCompanies_CompanyReferences_CompanyReferenceId",
                        column: x => x.CompanyReferenceId,
                        principalSchema: "Masterdata",
                        principalTable: "CompanyReferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderCompanies_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalSchema: "Transactions",
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BucketRemittanceAdvices",
                schema: "Masterdata",
                columns: table => new
                {
                    RemittanceAdviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketRemittanceAdvices", x => new { x.BucketId, x.RemittanceAdviceId });
                    table.ForeignKey(
                        name: "FK_BucketRemittanceAdvices_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketRemittanceAdvices_RemittanceAdvices_RemittanceAdviceId",
                        column: x => x.RemittanceAdviceId,
                        principalSchema: "Payments",
                        principalTable: "RemittanceAdvices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RemittanceAdviceAuditItems",
                schema: "Logging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemittanceAdviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AuditItemLevelId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemittanceAdviceAuditItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceAuditItems_AuditItemLevels_AuditItemLevelId",
                        column: x => x.AuditItemLevelId,
                        principalSchema: "Logging",
                        principalTable: "AuditItemLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceAuditItems_RemittanceAdvices_RemittanceAdviceId",
                        column: x => x.RemittanceAdviceId,
                        principalSchema: "Payments",
                        principalTable: "RemittanceAdvices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceAuditItems_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RemittanceAdviceCompanies",
                schema: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    RemittanceAdviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Perspective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemittanceAdviceCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceCompanies_CompanyReferences_CompanyReferenceId",
                        column: x => x.CompanyReferenceId,
                        principalSchema: "Masterdata",
                        principalTable: "CompanyReferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceCompanies_RemittanceAdvices_RemittanceAdviceId",
                        column: x => x.RemittanceAdviceId,
                        principalSchema: "Payments",
                        principalTable: "RemittanceAdvices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RemittanceAdviceReferences",
                schema: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RemittanceAdviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemittanceAdviceReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceReferences_RemittanceAdvices_RemittanceAdviceId",
                        column: x => x.RemittanceAdviceId,
                        principalSchema: "Payments",
                        principalTable: "RemittanceAdvices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceReferences_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BucketCredits",
                schema: "Masterdata",
                columns: table => new
                {
                    CreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketCredits", x => new { x.BucketId, x.CreditId });
                    table.ForeignKey(
                        name: "FK_BucketCredits_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketCredits_Credits_CreditId",
                        column: x => x.CreditId,
                        principalSchema: "Transactions",
                        principalTable: "Credits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditAuditItems",
                schema: "Logging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AuditItemLevelId = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditAuditItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditAuditItems_AuditItemLevels_AuditItemLevelId",
                        column: x => x.AuditItemLevelId,
                        principalSchema: "Logging",
                        principalTable: "AuditItemLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditAuditItems_Credits_CreditId",
                        column: x => x.CreditId,
                        principalSchema: "Transactions",
                        principalTable: "Credits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditAuditItems_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CreditCompanies",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    CreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Perspective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCompanies_CompanyReferences_CompanyReferenceId",
                        column: x => x.CompanyReferenceId,
                        principalSchema: "Masterdata",
                        principalTable: "CompanyReferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditCompanies_Credits_CreditId",
                        column: x => x.CreditId,
                        principalSchema: "Transactions",
                        principalTable: "Credits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditLines",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LinePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxableAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsFundable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditLines_Credits_CreditId",
                        column: x => x.CreditId,
                        principalSchema: "Transactions",
                        principalTable: "Credits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditLines_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditReferences",
                schema: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditReferences_Credits_CreditId",
                        column: x => x.CreditId,
                        principalSchema: "Transactions",
                        principalTable: "Credits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditReferences_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "Masterdata",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BucketBankAccounts",
                schema: "Banking",
                columns: table => new
                {
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketBankAccounts", x => new { x.BucketId, x.BankAccountId });
                    table.ForeignKey(
                        name: "FK_BucketBankAccounts_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalSchema: "Banking",
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketBankAccounts_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payees",
                schema: "Banking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentText = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Masterdata",
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payees_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalSchema: "Banking",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfferLines",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FundableValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CreditReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LinePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxableAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferLines_CreditReferences_CreditReferenceId",
                        column: x => x.CreditReferenceId,
                        principalSchema: "Transactions",
                        principalTable: "CreditReferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferLines_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferLines_InvoiceReferences_InvoiceReferenceId",
                        column: x => x.InvoiceReferenceId,
                        principalSchema: "Transactions",
                        principalTable: "InvoiceReferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferLines_Offers_OfferId",
                        column: x => x.OfferId,
                        principalSchema: "Finance",
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RemittanceAdviceLines",
                schema: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemittanceAdviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CreditReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    OfferReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PurchaseOrderReferenceId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DebtorAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreditorAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LinePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemittanceAdviceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceLines_BankAccounts_CreditorAccountId",
                        column: x => x.CreditorAccountId,
                        principalSchema: "Banking",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceLines_BankAccounts_DebtorAccountId",
                        column: x => x.DebtorAccountId,
                        principalSchema: "Banking",
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceLines_CreditReferences_CreditReferenceId",
                        column: x => x.CreditReferenceId,
                        principalSchema: "Transactions",
                        principalTable: "CreditReferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceLines_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Masterdata",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceLines_InvoiceReferences_InvoiceReferenceId",
                        column: x => x.InvoiceReferenceId,
                        principalSchema: "Transactions",
                        principalTable: "InvoiceReferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceLines_OfferReferences_OfferReferenceId",
                        column: x => x.OfferReferenceId,
                        principalSchema: "Finance",
                        principalTable: "OfferReferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceLines_Offers_OfferId",
                        column: x => x.OfferId,
                        principalSchema: "Finance",
                        principalTable: "Offers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceLines_PurchaseOrderReferences_PurchaseOrderReferenceId",
                        column: x => x.PurchaseOrderReferenceId,
                        principalSchema: "Transactions",
                        principalTable: "PurchaseOrderReferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RemittanceAdviceLines_RemittanceAdvices_RemittanceAdviceId",
                        column: x => x.RemittanceAdviceId,
                        principalSchema: "Payments",
                        principalTable: "RemittanceAdvices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BucketPayees",
                schema: "Masterdata",
                columns: table => new
                {
                    PayeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketPayees", x => new { x.BucketId, x.PayeeId });
                    table.ForeignKey(
                        name: "FK_BucketPayees_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BucketPayees_Payees_PayeeId",
                        column: x => x.PayeeId,
                        principalSchema: "Banking",
                        principalTable: "Payees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPayees",
                schema: "Masterdata",
                columns: table => new
                {
                    PayeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPayees", x => new { x.CompanyId, x.PayeeId });
                    table.ForeignKey(
                        name: "FK_CompanyPayees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Masterdata",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyPayees_Payees_PayeeId",
                        column: x => x.PayeeId,
                        principalSchema: "Banking",
                        principalTable: "Payees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Logging",
                table: "AuditItemLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fatal" },
                    { 2, "Error" },
                    { 3, "Warning" },
                    { 4, "Success" },
                    { 5, "Info" },
                    { 6, "Debug" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Countries",
                columns: new[] { "Id", "InEuropeanUnion", "Name" },
                values: new object[,]
                {
                    { "", false, "UNKNOWN" },
                    { "AD", false, "ANDORRA" },
                    { "AE", false, "UNITED ARAB EMIRATES" },
                    { "AF", false, "AFGHANISTAN" },
                    { "AG", false, "ANTIGUA AND BARBUDA" },
                    { "AI", false, "ANGUILLA" },
                    { "AL", false, "ALBANIA" },
                    { "AM", false, "ARMENIA" },
                    { "AN", false, "NETHERLANDS ANTILLES" },
                    { "AO", false, "ANGOLA" },
                    { "AQ", false, "ANTARCTICA" },
                    { "AR", false, "ARGENTINA" },
                    { "AS", false, "AMERICAN SAMOA" },
                    { "AT", true, "AUSTRIA" },
                    { "AU", false, "AUSTRALIA" },
                    { "AW", false, "ARUBA" },
                    { "AX", false, "ÅLAND ISLANDS" },
                    { "AZ", false, "AZERBAIJAN" },
                    { "BA", false, "BOSNIA AND HERZEGOVINA" },
                    { "BB", false, "BARBADOS" },
                    { "BD", false, "BANGLADESH" },
                    { "BE", false, "BELGIUM" },
                    { "BF", true, "BURKINA FASO" },
                    { "BG", true, "BULGARIA" },
                    { "BH", false, "BAHRAIN" },
                    { "BI", false, "BURUNDI" },
                    { "BJ", false, "BENIN" },
                    { "BM", false, "BERMUDA" },
                    { "BN", false, "BRUNEI DARUSSALAM" },
                    { "BO", false, "BOLIVIA" },
                    { "BR", false, "BRAZIL" },
                    { "BS", false, "BAHAMAS" },
                    { "BT", false, "BHUTAN" },
                    { "BV", false, "BOUVET ISLAND" },
                    { "BW", false, "BOTSWANA" },
                    { "BY", false, "BELARUS" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Countries",
                columns: new[] { "Id", "InEuropeanUnion", "Name" },
                values: new object[,]
                {
                    { "BZ", false, "BELIZE" },
                    { "CA", false, "CANADA" },
                    { "CC", false, "COCOS (KEELING) ISLANDS" },
                    { "CD", false, "CONGO, DEMOCRATIC REPUBLIC OF" },
                    { "CF", false, "CENTRAL AFRICAN REPUBLIC" },
                    { "CG", false, "CONGO" },
                    { "CH", false, "SWITZERLAND" },
                    { "CI", false, "COTE D'IVOIRE" },
                    { "CK", false, "COOK ISLANDS" },
                    { "CL", false, "CHILE" },
                    { "CM", false, "CAMEROON" },
                    { "CN", false, "CHINA" },
                    { "CO", false, "COLOMBIA" },
                    { "CR", false, "COSTA RICA" },
                    { "CS", false, "SERBIA AND MONTENEGRO" },
                    { "CU", false, "CUBA" },
                    { "CV", false, "CAPE VERDE" },
                    { "CX", false, "CHRISTMAS ISLAND" },
                    { "CY", true, "CYPRUS" },
                    { "CZ", true, "CZECH REPUBLIC" },
                    { "DE", true, "GERMANY" },
                    { "DJ", false, "DJIBOUTI" },
                    { "DK", true, "DENMARK" },
                    { "DM", false, "DOMINICA" },
                    { "DO", false, "DOMINICAN REPUBLIC" },
                    { "DZ", false, "ALGERIA" },
                    { "EC", false, "ECUADOR" },
                    { "EE", true, "ESTONIA" },
                    { "EG", false, "EGYPT" },
                    { "EH", false, "WESTERN SAHARA" },
                    { "ER", false, "ERITREA" },
                    { "ES", true, "SPAIN" },
                    { "ET", false, "ETHIOPIA" },
                    { "FI", true, "FINLAND" },
                    { "FJ", false, "FIJI" },
                    { "FK", false, "FALKLAND ISLANDS (MALVINAS)" },
                    { "FM", false, "MICRONESIA, FEDERATED STATES OF" },
                    { "FO", false, "FAROE ISLANDS" },
                    { "FR", true, "FRANCE" },
                    { "GA", false, "GABON" },
                    { "GB", false, "UNITED KINGDOM" },
                    { "GD", false, "GRENADA" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Countries",
                columns: new[] { "Id", "InEuropeanUnion", "Name" },
                values: new object[,]
                {
                    { "GE", false, "GEORGIA" },
                    { "GF", false, "FRENCH GUIANA" },
                    { "GG", false, "GUERNSEY" },
                    { "GH", false, "GHANA" },
                    { "GI", false, "GIBRALTAR" },
                    { "GL", false, "GREENLAND" },
                    { "GM", false, "GAMBIA" },
                    { "GN", false, "GUINEA" },
                    { "GP", false, "GUADELOUPE" },
                    { "GQ", false, "EQUATORIAL GUINEA" },
                    { "GR", true, "GREECE" },
                    { "GS", false, "SOUTH GEORGIA & SOUTH SANDWICH ISLANDS" },
                    { "GT", false, "GUATEMALA" },
                    { "GU", false, "GUAM" },
                    { "GW", false, "GUINEA-BISSAU" },
                    { "GY", false, "GUYANA" },
                    { "HK", false, "HONG KONG" },
                    { "HM", false, "HEARD ISLAND AND MCDONALD ISLANDS" },
                    { "HN", false, "HONDURAS" },
                    { "HR", false, "CROATIA" },
                    { "HT", false, "HAITI" },
                    { "HU", true, "HUNGARY" },
                    { "ID", false, "INDONESIA" },
                    { "IE", true, "IRELAND" },
                    { "IL", false, "ISRAEL" },
                    { "IM", false, "ISLE OF MAN" },
                    { "IN", false, "INDIA" },
                    { "IO", false, "BRITISH INDIAN OCEAN TERRITORY" },
                    { "IQ", false, "IRAQ" },
                    { "IR", false, "IRAN, ISLAMIC REPUBLIC OF" },
                    { "IS", false, "ICELAND" },
                    { "IT", true, "ITALY" },
                    { "JE", false, "JERSEY" },
                    { "JM", false, "JAMAICA" },
                    { "JO", false, "JORDAN" },
                    { "JP", false, "JAPAN" },
                    { "KE", false, "KENYA" },
                    { "KG", false, "KYRGYZSTAN" },
                    { "KH", false, "CAMBODIA" },
                    { "KI", false, "KIRIBATI" },
                    { "KM", false, "COMOROS" },
                    { "KN", false, "SAINT KITTS AND NEVIS" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Countries",
                columns: new[] { "Id", "InEuropeanUnion", "Name" },
                values: new object[,]
                {
                    { "KP", false, "KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF" },
                    { "KR", false, "KOREA, REPUBLIC OF" },
                    { "KW", false, "KUWAIT" },
                    { "KY", false, "CAYMAN ISLANDS" },
                    { "KZ", false, "KAZAKHSTAN" },
                    { "LA", false, "LAO PEOPLE'S DEMOCRATIC REPUBLIC" },
                    { "LB", false, "LEBANON" },
                    { "LC", false, "SAINT LUCIA" },
                    { "LI", false, "LIECHTENSTEIN" },
                    { "LK", false, "SRI LANKA" },
                    { "LR", false, "LIBERIA" },
                    { "LS", false, "LESOTHO" },
                    { "LT", true, "LITHUANIA" },
                    { "LU", true, "LUXEMBOURG" },
                    { "LV", true, "LATVIA" },
                    { "LY", false, "LIBYAN ARAB JAMAHIRIYA" },
                    { "MA", false, "MOROCCO" },
                    { "MC", false, "MONACO" },
                    { "MD", false, "MOLDOVA, REPUBLIC OF" },
                    { "ME", false, "MONTENEGRO" },
                    { "MG", false, "MADAGASCAR" },
                    { "MH", false, "MARSHALL ISLANDS" },
                    { "MK", false, "MACEDONIA,FORMER YUGOSLAV REPUBLIC" },
                    { "ML", false, "MALI" },
                    { "MM", false, "MYANMAR" },
                    { "MN", false, "MONGOLIA" },
                    { "MO", false, "MACAO" },
                    { "MP", false, "NORTHERN MARIANA ISLANDS" },
                    { "MQ", false, "MARTINIQUE" },
                    { "MR", false, "MAURITANIA" },
                    { "MS", false, "MONTSERRAT" },
                    { "MT", true, "MALTA" },
                    { "MU", false, "MAURITIUS" },
                    { "MV", false, "MALDIVES" },
                    { "MW", false, "MALAWI" },
                    { "MX", false, "MEXICO" },
                    { "MY", false, "MALAYSIA" },
                    { "MZ", false, "MOZAMBIQUE" },
                    { "NA", false, "NAMIBIA" },
                    { "NC", false, "NEW CALEDONIA" },
                    { "NE", false, "NIGER" },
                    { "NF", false, "NORFOLK ISLAND" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Countries",
                columns: new[] { "Id", "InEuropeanUnion", "Name" },
                values: new object[,]
                {
                    { "NG", false, "NIGERIA" },
                    { "NI", false, "NICARAGUA" },
                    { "NL", true, "NETHERLANDS" },
                    { "NO", false, "NORWAY" },
                    { "NP", false, "NEPAL" },
                    { "NR", false, "NAURU" },
                    { "NU", false, "NIUE" },
                    { "NZ", false, "NEW ZEALAND" },
                    { "OM", false, "OMAN" },
                    { "PA", false, "PANAMA" },
                    { "PE", false, "PERU" },
                    { "PF", false, "FRENCH POLYNESIA" },
                    { "PG", false, "PAPUA NEW GUINEA" },
                    { "PH", false, "PHILIPPINES" },
                    { "PK", false, "PAKISTAN" },
                    { "PL", true, "POLAND" },
                    { "PM", false, "SAINT PIERRE AND MIQUELON" },
                    { "PN", false, "PITCAIRN" },
                    { "PR", false, "PUERTO RICO" },
                    { "PS", false, "PALESTINIAN TERRITORY, OCCUPIED" },
                    { "PT", true, "PORTUGAL" },
                    { "PW", false, "PALAU" },
                    { "PY", false, "PARAGUAY" },
                    { "QA", false, "QATAR" },
                    { "RE", false, "REUNION" },
                    { "RO", true, "ROMANIA" },
                    { "RS", false, "REPUBLIC OF SERBIA" },
                    { "RU", false, "RUSSIAN FEDERATION" },
                    { "RW", false, "RWANDA" },
                    { "SA", false, "SAUDI ARABIA" },
                    { "SB", false, "SOLOMON ISLANDS" },
                    { "SC", false, "SEYCHELLES" },
                    { "SD", false, "SUDAN" },
                    { "SE", true, "SWEDEN" },
                    { "SG", false, "SINGAPORE" },
                    { "SH", false, "SAINT HELENA" },
                    { "SI", true, "SLOVENIA" },
                    { "SJ", false, "SVALBARD AND JAN MAYEN" },
                    { "SK", true, "SLOVAKIA" },
                    { "SL", false, "SIERRA LEONE" },
                    { "SM", false, "SAN MARINO" },
                    { "SN", false, "SENEGAL" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Countries",
                columns: new[] { "Id", "InEuropeanUnion", "Name" },
                values: new object[,]
                {
                    { "SO", false, "SOMALIA" },
                    { "SR", false, "SURINAME" },
                    { "ST", false, "SAO TOME AND PRINCIPE" },
                    { "SV", false, "EL SALVADOR" },
                    { "SY", false, "SYRIAN ARAB REPUBLIC" },
                    { "SZ", false, "SWAZILAND" },
                    { "TC", false, "TURKS AND CAICOS ISLANDS" },
                    { "TD", false, "CHAD" },
                    { "TF", false, "FRENCH SOUTHERN TERRITORIES" },
                    { "TG", false, "TOGO" },
                    { "TH", false, "THAILAND" },
                    { "TJ", false, "TAJIKISTAN" },
                    { "TK", false, "TOKELAU" },
                    { "TL", false, "TIMOR-LESTE" },
                    { "TM", false, "TURKMENISTAN" },
                    { "TN", false, "TUNISIA" },
                    { "TO", false, "TONGA" },
                    { "TR", false, "TURKEY" },
                    { "TT", false, "TRINIDAD AND TOBAGO" },
                    { "TV", false, "TUVALU" },
                    { "TW", false, "TAIWAN, PROVINCE OF CHINA" },
                    { "TZ", false, "TANZANIA, UNITED REPUBLIC OF" },
                    { "UA", false, "UKRAINE" },
                    { "UG", false, "UGANDA" },
                    { "UM", false, "UNITED STATES MINOR OUTLYING ISLANDS" },
                    { "US", false, "UNITED STATES" },
                    { "UY", false, "URUGUAY" },
                    { "UZ", false, "UZBEKISTAN" },
                    { "VA", false, "HOLY SEE (VATICAN CITY STATE) " },
                    { "VC", false, "SAINT VINCENT AND THE GRENADINES" },
                    { "VE", false, "VENEZUELA" },
                    { "VG", false, "VIRGIN ISLANDS, BRITISH" },
                    { "VI", false, "VIRGIN ISLANDS, U.S." },
                    { "VN", false, "VIET NAM" },
                    { "VU", false, "VANUATU" },
                    { "WF", false, "WALLIS AND FUTUNA" },
                    { "WS", false, "SAMOA" },
                    { "YE", false, "YEMEN" },
                    { "YT", false, "MAYOTTE" },
                    { "ZA", false, "SOUTH AFRICA" },
                    { "ZM", false, "ZAMBIA" },
                    { "ZW", false, "ZIMBABWE" }
                });

            migrationBuilder.InsertData(
                schema: "Transactions",
                table: "CreditTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Credit Note" },
                    { 2, "Replacement" },
                    { 3, "Debit Note" },
                    { 4, "Self Billing Credit" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "AED", "UAEDirham" },
                    { "AFN", "Afghani" },
                    { "ALL", "Lek" },
                    { "AMD", "ArmenianDram" },
                    { "ANG", "NetherlandsAntillianGuilder" },
                    { "AOA", "Kwanza" },
                    { "ARS", "ArgentinePeso" },
                    { "AUD", "AustralianDollar" },
                    { "AWG", "ArubanGuilder" },
                    { "AZN", "AzerbaijanianManat" },
                    { "BAM", "ConvertibleMarks" },
                    { "BBD", "BarbadosDollar" },
                    { "BDT", "Taka" },
                    { "BGN", "BulgarianLev" },
                    { "BHD", "BahrainiDinar" },
                    { "BIF", "BurundiFranc" },
                    { "BMD", "BermudianDollar" },
                    { "BND", "BruneiDollar" },
                    { "BOB", "Boliviano" },
                    { "BRL", "BrazilianReal" },
                    { "BSD", "BahamianDollar" },
                    { "BWP", "Pula" },
                    { "BYR", "BelarussianRuble" },
                    { "BZD", "BelizeDollar" },
                    { "CAD", "CanadianDollar" },
                    { "CDF", "FrancCongolais" },
                    { "CHE", "WIREuro" },
                    { "CHF", "SwissFranc" },
                    { "CHW", "WIRFranc" },
                    { "CLP", "ChileanPeso" },
                    { "CNY", "YuanRenminbi" },
                    { "COP", "ColombianPeso" },
                    { "CRC", "CostaRicanColon" },
                    { "CUP", "CubanPeso" },
                    { "CVE", "CapeVerdeEscudo" },
                    { "CYP", "CyprusPound" },
                    { "CZK", "CzechKoruna" },
                    { "DJF", "DjiboutiFranc" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "DKK", "DanishKrone" },
                    { "DOP", "DominicanPeso" },
                    { "DZD", "AlgerianDinar" },
                    { "EEK", "Kroon" },
                    { "EGP", "EgyptianPound" },
                    { "ERN", "Nakfa" },
                    { "ETB", "EthiopianBirr" },
                    { "EUR", "Euro" },
                    { "FJD", "FijiDollar" },
                    { "FKP", "FalklandIslandsPound" },
                    { "GBP", "PoundSterling" },
                    { "GEL", "Lari" },
                    { "GHC", "Cedi" },
                    { "GIP", "GibraltarPound" },
                    { "GMD", "Dalasi" },
                    { "GNF", "GuineaFranc" },
                    { "GTQ", "Quetzal" },
                    { "GWP", "Guinea-BissauPeso" },
                    { "GYD", "GuyanaDollar" },
                    { "HKD", "HongKongDollar" },
                    { "HNL", "Lempira" },
                    { "HRK", "CroatianKuna" },
                    { "HTG", "Gourde" },
                    { "HUF", "Forint" },
                    { "IDR", "Rupiah" },
                    { "ILS", "NewIsraeliSheqel" },
                    { "INR", "IndianRupee" },
                    { "IQD", "IraqiDinar" },
                    { "IRR", "IranianRial" },
                    { "ISK", "IcelandKrona" },
                    { "JMD", "JamaicanDollar" },
                    { "JOD", "JordanianDinar" },
                    { "JPY", "Yen" },
                    { "KES", "KenyanShilling" },
                    { "KGS", "Som" },
                    { "KHR", "Riel" },
                    { "KMF", "ComoroFranc" },
                    { "KPW", "NorthKoreanWon" },
                    { "KRW", "Won" },
                    { "KWD", "KuwaitiDinar" },
                    { "KYD", "CaymanIslandsDollar" },
                    { "KZT", "Tenge" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "LAK", "Kip" },
                    { "LBP", "LebanesePound" },
                    { "LKR", "SriLankaRupee" },
                    { "LRD", "LiberianDollar" },
                    { "LSL", "Loti" },
                    { "LTL", "LithuanianLitas" },
                    { "LVL", "LatvianLats" },
                    { "LYD", "LibyanDinar" },
                    { "MAD", "MoroccanDirham" },
                    { "MDL", "MoldovanLeu" },
                    { "MGA", "MalagascyAriary" },
                    { "MGF", "MalagascyFranc" },
                    { "MKD", "Denar" },
                    { "MMK", "Kyat" },
                    { "MNT", "Tugrik" },
                    { "MOP", "Pataca" },
                    { "MRO", "Ouguiya" },
                    { "MTL", "MalteseLira" },
                    { "MUR", "MauritiusRupee" },
                    { "MVR", "Rufiyaa" },
                    { "MWK", "Kwacha" },
                    { "MXN", "MexicanPeso" },
                    { "MYR", "MalaysianRinggit" },
                    { "MZN", "Metical" },
                    { "NAD", "NamibianDollar" },
                    { "NGN", "Naira" },
                    { "NIO", "CordobaOro" },
                    { "NOK", "NorwegianKrone" },
                    { "NPR", "NepaleseRupee" },
                    { "NZD", "NewZealandDollar" },
                    { "OMR", "RialOmani" },
                    { "PAB", "Balboa" },
                    { "PEN", "NuevoSol" },
                    { "PGK", "Kina" },
                    { "PHP", "PhilippinePeso" },
                    { "PKR", "PakistanRupee" },
                    { "PLN", "Zloty" },
                    { "PYG", "Guarani" },
                    { "QAR", "QatariRial" },
                    { "ROL", "OldLeu" },
                    { "RON", "NewLeu" },
                    { "RSD", "SerbianDinar" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "RUB", "RussianRuble" },
                    { "RWF", "RwandaFranc" },
                    { "SAR", "SaudiRiyal" },
                    { "SBD", "SolomonIslandsDollar" },
                    { "SCR", "SeychellesRupee" },
                    { "SDD", "SudaneseDinar" },
                    { "SEK", "SwedishKrona" },
                    { "SGD", "SingaporeDollar" },
                    { "SHP", "SaintHelenaPound" },
                    { "SIT", "Tolar" },
                    { "SKK", "SlovakKoruna" },
                    { "SLL", "Leone" },
                    { "SOS", "SomaliShilling" },
                    { "SRD", "SurinamDollar" },
                    { "STD", "Dobra" },
                    { "SVC", "ElSalvadorColon" },
                    { "SYP", "SyrianPound" },
                    { "SZL", "Lilangeni" },
                    { "THB", "Baht" },
                    { "TJS", "Somoni" },
                    { "TMM", "Manat" },
                    { "TND", "TunisianDinar" },
                    { "TOP", "Pa'anga" },
                    { "TRY", "NewTurkishLira" },
                    { "TTD", "TrinidadandTobagoDollar" },
                    { "TWD", "NewTaiwanDollar" },
                    { "TZS", "TanzanianShilling" },
                    { "UAH", "Hryvnia" },
                    { "UGX", "UgandaShilling" },
                    { "USD", "USDollar" },
                    { "USN", "(Nextday)" },
                    { "USS", "(Sameday)" },
                    { "UYU", "PesoUruguayo" },
                    { "UZS", "UzbekistanSum" },
                    { "VEB", "Bolivar" },
                    { "VND", "Dong" },
                    { "VUV", "Vatu" },
                    { "WST", "Tala" },
                    { "XAF", "CFAFrancBEAC" },
                    { "XCD", "EastCaribbeanDollar" },
                    { "XDR", "SDR" },
                    { "XOF", "CFAFrancBCEAO" }
                });

            migrationBuilder.InsertData(
                schema: "Masterdata",
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "XPF", "CFPFranc" },
                    { "YER", "YemeniRial" },
                    { "ZAR", "Rand" },
                    { "ZMK", "Kwacha" },
                    { "ZWD", "ZimbabweDollar" }
                });

            migrationBuilder.InsertData(
                schema: "Transactions",
                table: "InvoiceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sales Invoice" },
                    { 2, "Copy Invoice" },
                    { 3, "Replacement" },
                    { 4, "Self Billing Invoice" },
                    { 5, "Pro Forma Inv" }
                });

            migrationBuilder.InsertData(
                schema: "Payments",
                table: "RemittanceAdviceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Statement" },
                    { 2, "Payer Payment Advice" },
                    { 3, "Payee Payment Advice" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveTransactions_CurrencyId",
                schema: "Transactions",
                table: "ActiveTransactions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveTransactions_SourceSystemId",
                schema: "Transactions",
                table: "ActiveTransactions",
                column: "SourceSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                schema: "Masterdata",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankBranchId",
                schema: "Banking",
                table: "BankAccounts",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranches_AddressId",
                schema: "Banking",
                table: "BankBranches",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranches_BankId",
                schema: "Banking",
                table: "BankBranches",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_AddressId",
                schema: "Banking",
                table: "Banks",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketActiveTransactions_ActiveTransactionId",
                schema: "Masterdata",
                table: "BucketActiveTransactions",
                column: "ActiveTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketBankAccounts_BankAccountId",
                schema: "Banking",
                table: "BucketBankAccounts",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketCompanies_CompanyId",
                schema: "Masterdata",
                table: "BucketCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketCredits_CreditId",
                schema: "Masterdata",
                table: "BucketCredits",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketInvoices_InvoiceId",
                schema: "Masterdata",
                table: "BucketInvoices",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketOffers_OfferId",
                schema: "Masterdata",
                table: "BucketOffers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketPayees_PayeeId",
                schema: "Masterdata",
                table: "BucketPayees",
                column: "PayeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketPurchaseOrders_PurchaseOrderId",
                schema: "Masterdata",
                table: "BucketPurchaseOrders",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketRemittanceAdvices_RemittanceAdviceId",
                schema: "Masterdata",
                table: "BucketRemittanceAdvices",
                column: "RemittanceAdviceId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketRoles_RoleId",
                schema: "Masterdata",
                table: "BucketRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Buckets_ParentId",
                schema: "Masterdata",
                table: "Buckets",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketSystems_SystemId",
                schema: "Masterdata",
                table: "BucketSystems",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketUsers_UserId",
                schema: "Masterdata",
                table: "BucketUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                schema: "Masterdata",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCSVLines_RootBucketId",
                schema: "Import",
                table: "CompanyCSVLines",
                column: "RootBucketId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPayees_PayeeId",
                schema: "Masterdata",
                table: "CompanyPayees",
                column: "PayeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReferences_CompanyId",
                schema: "Masterdata",
                table: "CompanyReferences",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReferences_SystemId",
                schema: "Masterdata",
                table: "CompanyReferences",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditAuditItems_AuditItemLevelId",
                schema: "Logging",
                table: "CreditAuditItems",
                column: "AuditItemLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditAuditItems_CreditId",
                schema: "Logging",
                table: "CreditAuditItems",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditAuditItems_UserId",
                schema: "Logging",
                table: "CreditAuditItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCompanies_CompanyReferenceId",
                schema: "Transactions",
                table: "CreditCompanies",
                column: "CompanyReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCompanies_CreditId",
                schema: "Transactions",
                table: "CreditCompanies",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditLines_CreditId",
                schema: "Transactions",
                table: "CreditLines",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditLines_CurrencyId",
                schema: "Transactions",
                table: "CreditLines",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditReferences_CreditId",
                schema: "Transactions",
                table: "CreditReferences",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditReferences_SystemId",
                schema: "Transactions",
                table: "CreditReferences",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CreditTypeId",
                schema: "Transactions",
                table: "Credits",
                column: "CreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CurrencyId",
                schema: "Transactions",
                table: "Credits",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_InvoiceReferenceId",
                schema: "Transactions",
                table: "Credits",
                column: "InvoiceReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_SourceSystemId",
                schema: "Transactions",
                table: "Credits",
                column: "SourceSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_CurrencyId",
                schema: "Finance",
                table: "FundingDetails",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_FundingTypeBucketId",
                schema: "Finance",
                table: "FundingDetails",
                column: "FundingTypeBucketId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_SystemId",
                schema: "Finance",
                table: "FundingDetails",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAuditItems_AuditItemLevelId",
                schema: "Logging",
                table: "InvoiceAuditItems",
                column: "AuditItemLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAuditItems_InvoiceId",
                schema: "Logging",
                table: "InvoiceAuditItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAuditItems_UserId",
                schema: "Logging",
                table: "InvoiceAuditItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCompanies_CompanyReferenceId",
                schema: "Transactions",
                table: "InvoiceCompanies",
                column: "CompanyReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCompanies_InvoiceId",
                schema: "Transactions",
                table: "InvoiceCompanies",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_CurrencyId",
                schema: "Transactions",
                table: "InvoiceLines",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceId",
                schema: "Transactions",
                table: "InvoiceLines",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReferences_InvoiceId",
                schema: "Transactions",
                table: "InvoiceReferences",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReferences_SystemId",
                schema: "Transactions",
                table: "InvoiceReferences",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CurrencyId",
                schema: "Transactions",
                table: "Invoices",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceTypeId",
                schema: "Transactions",
                table: "Invoices",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SourceSystemId",
                schema: "Transactions",
                table: "Invoices",
                column: "SourceSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_LogDataItems_LogEntryId",
                schema: "Logging",
                table: "LogDataItems",
                column: "LogEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferAuditItems_AuditItemLevelId",
                schema: "Logging",
                table: "OfferAuditItems",
                column: "AuditItemLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferAuditItems_OfferId",
                schema: "Logging",
                table: "OfferAuditItems",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferAuditItems_UserId",
                schema: "Logging",
                table: "OfferAuditItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCompanies_CompanyReferenceId",
                schema: "Finance",
                table: "OfferCompanies",
                column: "CompanyReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCompanies_OfferId",
                schema: "Finance",
                table: "OfferCompanies",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferDataItems_OfferId",
                schema: "Finance",
                table: "OfferDataItems",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferLines_CreditReferenceId",
                schema: "Finance",
                table: "OfferLines",
                column: "CreditReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferLines_CurrencyId",
                schema: "Finance",
                table: "OfferLines",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferLines_InvoiceReferenceId",
                schema: "Finance",
                table: "OfferLines",
                column: "InvoiceReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferLines_OfferId",
                schema: "Finance",
                table: "OfferLines",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferReferences_OfferId",
                schema: "Finance",
                table: "OfferReferences",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferReferences_SystemId",
                schema: "Finance",
                table: "OfferReferences",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CurrencyId",
                schema: "Finance",
                table: "Offers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SourceSystemId",
                schema: "Finance",
                table: "Offers",
                column: "SourceSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Payees_AddressId",
                schema: "Banking",
                table: "Payees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Payees_BankAccountId",
                schema: "Banking",
                table: "Payees",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderAuditItems_AuditItemLevelId",
                schema: "Logging",
                table: "PurchaseOrderAuditItems",
                column: "AuditItemLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderAuditItems_PurchaseOrderId",
                schema: "Logging",
                table: "PurchaseOrderAuditItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderAuditItems_UserId",
                schema: "Logging",
                table: "PurchaseOrderAuditItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderCompanies_CompanyReferenceId",
                schema: "Transactions",
                table: "PurchaseOrderCompanies",
                column: "CompanyReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderCompanies_PurchaseOrderId",
                schema: "Transactions",
                table: "PurchaseOrderCompanies",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_CurrencyId",
                schema: "Transactions",
                table: "PurchaseOrderLines",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_PurchaseOrderId",
                schema: "Transactions",
                table: "PurchaseOrderLines",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderReferences_PurchaseOrderId",
                schema: "Transactions",
                table: "PurchaseOrderReferences",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderReferences_SystemId",
                schema: "Transactions",
                table: "PurchaseOrderReferences",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CurrencyId",
                schema: "Transactions",
                table: "PurchaseOrders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SourceSystemId",
                schema: "Transactions",
                table: "PurchaseOrders",
                column: "SourceSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceAuditItems_AuditItemLevelId",
                schema: "Logging",
                table: "RemittanceAdviceAuditItems",
                column: "AuditItemLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceAuditItems_RemittanceAdviceId",
                schema: "Logging",
                table: "RemittanceAdviceAuditItems",
                column: "RemittanceAdviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceAuditItems_UserId",
                schema: "Logging",
                table: "RemittanceAdviceAuditItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceCompanies_CompanyReferenceId",
                schema: "Payments",
                table: "RemittanceAdviceCompanies",
                column: "CompanyReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceCompanies_RemittanceAdviceId",
                schema: "Payments",
                table: "RemittanceAdviceCompanies",
                column: "RemittanceAdviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceLines_CreditorAccountId",
                schema: "Payments",
                table: "RemittanceAdviceLines",
                column: "CreditorAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceLines_CreditReferenceId",
                schema: "Payments",
                table: "RemittanceAdviceLines",
                column: "CreditReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceLines_CurrencyId",
                schema: "Payments",
                table: "RemittanceAdviceLines",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceLines_DebtorAccountId",
                schema: "Payments",
                table: "RemittanceAdviceLines",
                column: "DebtorAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceLines_InvoiceReferenceId",
                schema: "Payments",
                table: "RemittanceAdviceLines",
                column: "InvoiceReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceLines_OfferId",
                schema: "Payments",
                table: "RemittanceAdviceLines",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceLines_OfferReferenceId",
                schema: "Payments",
                table: "RemittanceAdviceLines",
                column: "OfferReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceLines_PurchaseOrderReferenceId",
                schema: "Payments",
                table: "RemittanceAdviceLines",
                column: "PurchaseOrderReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceLines_RemittanceAdviceId",
                schema: "Payments",
                table: "RemittanceAdviceLines",
                column: "RemittanceAdviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceReferences_RemittanceAdviceId",
                schema: "Payments",
                table: "RemittanceAdviceReferences",
                column: "RemittanceAdviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdviceReferences_SystemId",
                schema: "Payments",
                table: "RemittanceAdviceReferences",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdvices_B2BUserId",
                schema: "Payments",
                table: "RemittanceAdvices",
                column: "B2BUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdvices_CurrencyId",
                schema: "Payments",
                table: "RemittanceAdvices",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdvices_RemittanceAdviceTypeId",
                schema: "Payments",
                table: "RemittanceAdvices",
                column: "RemittanceAdviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RemittanceAdvices_SourceSystemId",
                schema: "Payments",
                table: "RemittanceAdvices",
                column: "SourceSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Security",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                schema: "Security",
                table: "Users",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BucketActiveTransactions",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "BucketBankAccounts",
                schema: "Banking");

            migrationBuilder.DropTable(
                name: "BucketCompanies",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "BucketCredits",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "BucketInvoices",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "BucketOffers",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "BucketPayees",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "BucketPurchaseOrders",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "BucketRemittanceAdvices",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "BucketRoles",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "BucketSystems",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "BucketUsers",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "CompanyCSVLines",
                schema: "Import");

            migrationBuilder.DropTable(
                name: "CompanyPayees",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "CreditAuditItems",
                schema: "Logging");

            migrationBuilder.DropTable(
                name: "CreditCompanies",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "CreditLines",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "FundingDetails",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "InvoiceAuditItems",
                schema: "Logging");

            migrationBuilder.DropTable(
                name: "InvoiceCompanies",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "InvoiceLines",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "LogDataItems",
                schema: "Logging");

            migrationBuilder.DropTable(
                name: "OfferAuditItems",
                schema: "Logging");

            migrationBuilder.DropTable(
                name: "OfferCompanies",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "OfferDataItems",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "OfferLines",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "PurchaseOrderAuditItems",
                schema: "Logging");

            migrationBuilder.DropTable(
                name: "PurchaseOrderCompanies",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "PurchaseOrderLines",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "RemittanceAdviceAuditItems",
                schema: "Logging");

            migrationBuilder.DropTable(
                name: "RemittanceAdviceCompanies",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "RemittanceAdviceLines",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "RemittanceAdviceReferences",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ActiveTransactions",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "Payees",
                schema: "Banking");

            migrationBuilder.DropTable(
                name: "LogEntries",
                schema: "Logging");

            migrationBuilder.DropTable(
                name: "AuditItemLevels",
                schema: "Logging");

            migrationBuilder.DropTable(
                name: "CompanyReferences",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "CreditReferences",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "OfferReferences",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "PurchaseOrderReferences",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "RemittanceAdvices",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "Buckets",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "BankAccounts",
                schema: "Banking");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "Credits",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "Offers",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "PurchaseOrders",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "RemittanceAdviceTypes",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "BankBranches",
                schema: "Banking");

            migrationBuilder.DropTable(
                name: "CreditTypes",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "InvoiceReferences",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "Banks",
                schema: "Banking");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "InvoiceTypes",
                schema: "Transactions");

            migrationBuilder.DropTable(
                name: "Systems",
                schema: "Masterdata");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Masterdata");
        }
    }
}
