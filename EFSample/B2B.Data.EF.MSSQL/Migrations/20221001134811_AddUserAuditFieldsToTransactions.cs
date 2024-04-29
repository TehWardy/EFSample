using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.EF.Migrations
{
    public partial class AddUserAuditFieldsToTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Payments",
                table: "RemittanceAdvices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Payments",
                table: "RemittanceAdvices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Transactions",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Transactions",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Finance",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Finance",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Transactions",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Transactions",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Transactions",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Transactions",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Payments",
                table: "RemittanceAdvices");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Payments",
                table: "RemittanceAdvices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Transactions",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Transactions",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Finance",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Finance",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Transactions",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Transactions",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Transactions",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Transactions",
                table: "Credits");
        }
    }
}
