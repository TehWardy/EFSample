using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class MoreIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BucketUsers_BucketId",
                schema: "Masterdata",
                table: "BucketUsers",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketActiveTransactions_BucketId",
                schema: "Masterdata",
                table: "BucketActiveTransactions",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveTransactions_SourceSystemId",
                schema: "Transactions",
                table: "ActiveTransactions",
                column: "SourceSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BucketUsers_BucketId",
                schema: "Masterdata",
                table: "BucketUsers");

            migrationBuilder.DropIndex(
                name: "IX_BucketActiveTransactions_BucketId",
                schema: "Masterdata",
                table: "BucketActiveTransactions");

            migrationBuilder.DropIndex(
                name: "IX_ActiveTransactions_SourceSystemId",
                schema: "Transactions",
                table: "ActiveTransactions");
        }
    }
}
