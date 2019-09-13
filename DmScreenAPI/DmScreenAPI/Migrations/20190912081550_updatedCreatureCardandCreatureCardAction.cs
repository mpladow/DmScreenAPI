using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DmScreenAPI.Migrations
{
    public partial class updatedCreatureCardandCreatureCardAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreatureCards_Creatures_CreatureId",
                table: "CreatureCards");

            migrationBuilder.DropTable(
                name: "Cheatsheets");

            migrationBuilder.DropTable(
                name: "Creatures");

            migrationBuilder.DropIndex(
                name: "IX_CreatureCards_CreatureId",
                table: "CreatureCards");

            migrationBuilder.RenameColumn(
                name: "CreatureId",
                table: "CreatureCards",
                newName: "Intelligence");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "CreatureCards",
                newName: "PPerception");

            migrationBuilder.AddColumn<bool>(
                name: "BlueIndicatorOn",
                table: "CreatureCards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GreenIndicatorOn",
                table: "CreatureCards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PInsight",
                table: "CreatureCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PInvestigation",
                table: "CreatureCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "RedIndicatorOn",
                table: "CreatureCards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CreatureAction",
                columns: table => new
                {
                    CreatureActionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatureCardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureAction", x => x.CreatureActionId);
                    table.ForeignKey(
                        name: "FK_CreatureAction_CreatureCards_CreatureCardId",
                        column: x => x.CreatureCardId,
                        principalTable: "CreatureCards",
                        principalColumn: "CreatureCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreatureCardActions",
                columns: table => new
                {
                    CreatureCardActionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatureCardId = table.Column<int>(nullable: false),
                    CreatureActionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureCardActions", x => x.CreatureCardActionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreatureAction_CreatureCardId",
                table: "CreatureAction",
                column: "CreatureCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureAction");

            migrationBuilder.DropTable(
                name: "CreatureCardActions");

            migrationBuilder.DropColumn(
                name: "BlueIndicatorOn",
                table: "CreatureCards");

            migrationBuilder.DropColumn(
                name: "GreenIndicatorOn",
                table: "CreatureCards");

            migrationBuilder.DropColumn(
                name: "PInsight",
                table: "CreatureCards");

            migrationBuilder.DropColumn(
                name: "PInvestigation",
                table: "CreatureCards");

            migrationBuilder.DropColumn(
                name: "RedIndicatorOn",
                table: "CreatureCards");

            migrationBuilder.RenameColumn(
                name: "PPerception",
                table: "CreatureCards",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "Intelligence",
                table: "CreatureCards",
                newName: "CreatureId");

            migrationBuilder.CreateTable(
                name: "Cheatsheets",
                columns: table => new
                {
                    Cheatsheetid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Html = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheatsheets", x => x.Cheatsheetid);
                });

            migrationBuilder.CreateTable(
                name: "Creatures",
                columns: table => new
                {
                    CreatureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AC = table.Column<int>(nullable: false),
                    CR = table.Column<int>(nullable: true),
                    Charisma = table.Column<int>(nullable: false),
                    CharismaBonus = table.Column<int>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Constitution = table.Column<int>(nullable: false),
                    ConstitutionBonus = table.Column<int>(nullable: true),
                    Dexterity = table.Column<int>(nullable: false),
                    DexterityBonus = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Initiative = table.Column<int>(nullable: false),
                    InitiativeBonus = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PInsight = table.Column<int>(nullable: false),
                    PInvestigation = table.Column<int>(nullable: false),
                    PPerception = table.Column<int>(nullable: false),
                    ProficiencyBonus = table.Column<int>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Speed = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    StrengthBonus = table.Column<int>(nullable: true),
                    Wisdom = table.Column<int>(nullable: false),
                    WisdomBonus = table.Column<int>(nullable: true),
                    isHostile = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creatures", x => x.CreatureId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreatureCards_CreatureId",
                table: "CreatureCards",
                column: "CreatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureCards_Creatures_CreatureId",
                table: "CreatureCards",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "CreatureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
