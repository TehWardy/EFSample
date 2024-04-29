using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionCSVLines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionCSVLines",
                schema: "Import",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RootBucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceSystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceSeperator = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailureMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditorTransactionRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditorRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedTransactionRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsFundable = table.Column<bool>(type: "bit", nullable: false),
                    IsRaLine = table.Column<bool>(type: "bit", nullable: false),
                    AlsoPayOffer = table.Column<bool>(type: "bit", nullable: false),
                    ProcessingState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ProcessedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCSVLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionCSVLines_Buckets_RootBucketId",
                        column: x => x.RootBucketId,
                        principalSchema: "Masterdata",
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCSVLines_RootBucketId",
                schema: "Import",
                table: "TransactionCSVLines",
                column: "RootBucketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionCSVLines",
                schema: "Import");
        }
    }
}
