using Microsoft.EntityFrameworkCore.Migrations;

namespace DmScreenAPI.Migrations
{
    public partial class UpdatedEntitieswithFixedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountCreatureCards_AccountCreatureCardId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatureCards_AccountCreatureCards_AccountCreatureCardId",
                table: "CreatureCards");

            migrationBuilder.DropIndex(
                name: "IX_CreatureCards_AccountCreatureCardId",
                table: "CreatureCards");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountCreatureCardId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountCreatureCardId",
                table: "CreatureCards");

            migrationBuilder.DropColumn(
                name: "AccountCreatureCardId",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCreatureCards_AccountId",
                table: "AccountCreatureCards",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCreatureCards_CreatureCardId",
                table: "AccountCreatureCards",
                column: "CreatureCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountCreatureCards_Accounts_AccountId",
                table: "AccountCreatureCards",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountCreatureCards_CreatureCards_CreatureCardId",
                table: "AccountCreatureCards",
                column: "CreatureCardId",
                principalTable: "CreatureCards",
                principalColumn: "CreatureCardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountCreatureCards_Accounts_AccountId",
                table: "AccountCreatureCards");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountCreatureCards_CreatureCards_CreatureCardId",
                table: "AccountCreatureCards");

            migrationBuilder.DropIndex(
                name: "IX_AccountCreatureCards_AccountId",
                table: "AccountCreatureCards");

            migrationBuilder.DropIndex(
                name: "IX_AccountCreatureCards_CreatureCardId",
                table: "AccountCreatureCards");

            migrationBuilder.AddColumn<int>(
                name: "AccountCreatureCardId",
                table: "CreatureCards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountCreatureCardId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreatureCards_AccountCreatureCardId",
                table: "CreatureCards",
                column: "AccountCreatureCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountCreatureCardId",
                table: "Accounts",
                column: "AccountCreatureCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountCreatureCards_AccountCreatureCardId",
                table: "Accounts",
                column: "AccountCreatureCardId",
                principalTable: "AccountCreatureCards",
                principalColumn: "AccountCreatureCardId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureCards_AccountCreatureCards_AccountCreatureCardId",
                table: "CreatureCards",
                column: "AccountCreatureCardId",
                principalTable: "AccountCreatureCards",
                principalColumn: "AccountCreatureCardId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
