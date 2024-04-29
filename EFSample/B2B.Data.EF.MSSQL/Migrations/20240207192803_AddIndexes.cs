using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ActiveTransactions_SourceSystemId",
                schema: "Transactions",
                table: "ActiveTransactions");

            migrationBuilder.DropColumn(
                name: "Data",
                schema: "Masterdata",
                table: "Buckets");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPayees_CompanyId",
                schema: "Masterdata",
                table: "CompanyPayees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketSystems_BucketId",
                schema: "Masterdata",
                table: "BucketSystems",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketRoles_BucketId",
                schema: "Masterdata",
                table: "BucketRoles",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketRemittanceAdvices_BucketId",
                schema: "Masterdata",
                table: "BucketRemittanceAdvices",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketPurchaseOrders_BucketId",
                schema: "Masterdata",
                table: "BucketPurchaseOrders",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketPayees_BucketId",
                schema: "Masterdata",
                table: "BucketPayees",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketOffers_BucketId",
                schema: "Masterdata",
                table: "BucketOffers",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketInvoices_BucketId",
                schema: "Masterdata",
                table: "BucketInvoices",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketCredits_BucketId",
                schema: "Masterdata",
                table: "BucketCredits",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketCompanies_BucketId",
                schema: "Masterdata",
                table: "BucketCompanies",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveTransactions_SourceSystemId_CurrencyId_DebtorState_Value",
                schema: "Transactions",
                table: "ActiveTransactions",
                columns: new[] { "SourceSystemId", "CurrencyId", "DebtorState", "Value" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanyPayees_CompanyId",
                schema: "Masterdata",
                table: "CompanyPayees");

            migrationBuilder.DropIndex(
                name: "IX_BucketSystems_BucketId",
                schema: "Masterdata",
                table: "BucketSystems");

            migrationBuilder.DropIndex(
                name: "IX_BucketRoles_BucketId",
                schema: "Masterdata",
                table: "BucketRoles");

            migrationBuilder.DropIndex(
                name: "IX_BucketRemittanceAdvices_BucketId",
                schema: "Masterdata",
                table: "BucketRemittanceAdvices");

            migrationBuilder.DropIndex(
                name: "IX_BucketPurchaseOrders_BucketId",
                schema: "Masterdata",
                table: "BucketPurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_BucketPayees_BucketId",
                schema: "Masterdata",
                table: "BucketPayees");

            migrationBuilder.DropIndex(
                name: "IX_BucketOffers_BucketId",
                schema: "Masterdata",
                table: "BucketOffers");

            migrationBuilder.DropIndex(
                name: "IX_BucketInvoices_BucketId",
                schema: "Masterdata",
                table: "BucketInvoices");

            migrationBuilder.DropIndex(
                name: "IX_BucketCredits_BucketId",
                schema: "Masterdata",
                table: "BucketCredits");

            migrationBuilder.DropIndex(
                name: "IX_BucketCompanies_BucketId",
                schema: "Masterdata",
                table: "BucketCompanies");

            migrationBuilder.DropIndex(
                name: "IX_ActiveTransactions_SourceSystemId_CurrencyId_DebtorState_Value",
                schema: "Transactions",
                table: "ActiveTransactions");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                schema: "Masterdata",
                table: "Buckets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActiveTransactions_SourceSystemId",
                schema: "Transactions",
                table: "ActiveTransactions",
                column: "SourceSystemId");
        }
    }
}
