using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeAPI.Migrations
{
    public partial class ISBN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsISBAdmin",
                table: "Books",
                newName: "ISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "Books",
                newName: "IsISBAdmin");
        }
    }
}
