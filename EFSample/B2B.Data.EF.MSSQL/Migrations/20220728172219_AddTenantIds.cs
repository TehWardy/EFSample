using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.EF.Migrations
{
    public partial class AddTenantIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "Masterdata",
                table: "Buckets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                schema: "Masterdata",
                table: "Buckets");
        }
    }
}
