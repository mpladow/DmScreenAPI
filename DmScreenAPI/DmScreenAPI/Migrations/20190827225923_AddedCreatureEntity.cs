using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DmScreenAPI.Migrations
{
    public partial class AddedCreatureEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CreatureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: true),
                    CR = table.Column<int>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Initiative = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Constitution = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false),
                    Charisma = table.Column<int>(nullable: false),
                    PPerception = table.Column<int>(nullable: false),
                    PInsight = table.Column<int>(nullable: false),
                    PInvestigation = table.Column<int>(nullable: false),
                    AC = table.Column<int>(nullable: false),
                    InitiativeBonus = table.Column<int>(nullable: true),
                    StrengthBonus = table.Column<int>(nullable: true),
                    DexterityBonus = table.Column<int>(nullable: true),
                    ConstitutionBonus = table.Column<int>(nullable: true),
                    WisdomBonus = table.Column<int>(nullable: true),
                    CharismaBonus = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Speed = table.Column<int>(nullable: false),
                    ProficiencyBonus = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CreatureId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
