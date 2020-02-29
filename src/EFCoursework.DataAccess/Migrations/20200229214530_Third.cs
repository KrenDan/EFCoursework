using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoursework.DataAccess.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Systems_Icon",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Systems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Systems",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Systems_Icon",
                table: "Systems",
                column: "Icon",
                unique: true,
                filter: "[Icon] IS NOT NULL");
        }
    }
}
