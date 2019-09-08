using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DmScreenAPI.Migrations
{
    public partial class AccountResourcesAndAccountCharacterCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreatureCardAccounts_Creatures_CreatureId",
                table: "CreatureCardAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatureCardAccounts",
                table: "CreatureCardAccounts");

            migrationBuilder.RenameTable(
                name: "CreatureCardAccounts",
                newName: "CreatureCards");

            migrationBuilder.RenameIndex(
                name: "IX_CreatureCardAccounts_CreatureId",
                table: "CreatureCards",
                newName: "IX_CreatureCards_CreatureId");

            migrationBuilder.AddColumn<int>(
                name: "AccountResourceId",
                table: "Resources",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountCreatureCardId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountResourceId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountCreatureCardId",
                table: "CreatureCards",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatureCards",
                table: "CreatureCards",
                column: "CreatureCardId");

            migrationBuilder.CreateTable(
                name: "AccountCreatureCards",
                columns: table => new
                {
                    AccountCreatureCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: false),
                    CreatureCardId = table.Column<int>(nullable: false),
                    Sequence = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCreatureCards", x => x.AccountCreatureCardId);
                });

            migrationBuilder.CreateTable(
                name: "AccountResources",
                columns: table => new
                {
                    AccountResourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false),
                    Sequence = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountResources", x => x.AccountResourceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_AccountResourceId",
                table: "Resources",
                column: "AccountResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountCreatureCardId",
                table: "Accounts",
                column: "AccountCreatureCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountResourceId",
                table: "Accounts",
                column: "AccountResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureCards_AccountCreatureCardId",
                table: "CreatureCards",
                column: "AccountCreatureCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountCreatureCards_AccountCreatureCardId",
                table: "Accounts",
                column: "AccountCreatureCardId",
                principalTable: "AccountCreatureCards",
                principalColumn: "AccountCreatureCardId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountResources_AccountResourceId",
                table: "Accounts",
                column: "AccountResourceId",
                principalTable: "AccountResources",
                principalColumn: "AccountResourceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureCards_AccountCreatureCards_AccountCreatureCardId",
                table: "CreatureCards",
                column: "AccountCreatureCardId",
                principalTable: "AccountCreatureCards",
                principalColumn: "AccountCreatureCardId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureCards_Creatures_CreatureId",
                table: "CreatureCards",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "CreatureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_AccountResources_AccountResourceId",
                table: "Resources",
                column: "AccountResourceId",
                principalTable: "AccountResources",
                principalColumn: "AccountResourceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountCreatureCards_AccountCreatureCardId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountResources_AccountResourceId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatureCards_AccountCreatureCards_AccountCreatureCardId",
                table: "CreatureCards");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatureCards_Creatures_CreatureId",
                table: "CreatureCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_AccountResources_AccountResourceId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "AccountCreatureCards");

            migrationBuilder.DropTable(
                name: "AccountResources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_AccountResourceId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountCreatureCardId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountResourceId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatureCards",
                table: "CreatureCards");

            migrationBuilder.DropIndex(
                name: "IX_CreatureCards_AccountCreatureCardId",
                table: "CreatureCards");

            migrationBuilder.DropColumn(
                name: "AccountResourceId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "AccountCreatureCardId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountResourceId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountCreatureCardId",
                table: "CreatureCards");

            migrationBuilder.RenameTable(
                name: "CreatureCards",
                newName: "CreatureCardAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_CreatureCards_CreatureId",
                table: "CreatureCardAccounts",
                newName: "IX_CreatureCardAccounts_CreatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatureCardAccounts",
                table: "CreatureCardAccounts",
                column: "CreatureCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureCardAccounts_Creatures_CreatureId",
                table: "CreatureCardAccounts",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "CreatureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
