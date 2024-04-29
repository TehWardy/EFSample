using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeysForRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "Security",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId",
                schema: "Security",
                table: "UserRoles");
        }
    }
}
