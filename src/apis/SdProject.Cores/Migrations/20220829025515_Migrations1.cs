using Microsoft.EntityFrameworkCore.Migrations;

namespace SdProject.Core.Migrations
{
    public partial class Migrations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HaveRead",
                table: "UserBookEntities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HaveRead",
                table: "UserBookEntities");
        }
    }
}
