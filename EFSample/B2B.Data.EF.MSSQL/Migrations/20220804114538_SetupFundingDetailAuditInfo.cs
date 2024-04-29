using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.EF.Migrations
{
    public partial class SetupFundingDetailAuditInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Finance",
                table: "FundingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "Finance",
                table: "FundingDetails",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastUpdated",
                schema: "Finance",
                table: "FundingDetails",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "Finance",
                table: "FundingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.Sql("UPDATE [Finance].[FundingDetails] SET CreatedBy='system',LastUpdatedBy='system',CreatedOn=GETDATE(),LastUpdated=GETDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Finance",
                table: "FundingDetails");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "Finance",
                table: "FundingDetails");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                schema: "Finance",
                table: "FundingDetails");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "Finance",
                table: "FundingDetails");
        }
    }
}
