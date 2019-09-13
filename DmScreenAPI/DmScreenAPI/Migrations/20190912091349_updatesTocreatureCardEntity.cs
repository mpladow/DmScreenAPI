using Microsoft.EntityFrameworkCore.Migrations;

namespace DmScreenAPI.Migrations
{
    public partial class updatesTocreatureCardEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Initiative",
                table: "CreatureCards",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AC",
                table: "CreatureCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CreatureCards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AC",
                table: "CreatureCards");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CreatureCards");

            migrationBuilder.AlterColumn<int>(
                name: "Initiative",
                table: "CreatureCards",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
