using Microsoft.EntityFrameworkCore.Migrations;

namespace DmScreenAPI.Migrations
{
    public partial class AddedIsHostileBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Creatures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Creatures",
                table: "Creatures",
                column: "CreatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Creatures",
                table: "Creatures");

            migrationBuilder.RenameTable(
                name: "Creatures",
                newName: "Characters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "CreatureId");
        }
    }
}
