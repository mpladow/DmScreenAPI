using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DmScreenAPI.Migrations
{
    public partial class AddedAccountPasswordHashandSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreatureCardAccounts",
                columns: table => new
                {
                    CreatureCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isHostile = table.Column<bool>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    CreatureId = table.Column<int>(nullable: true),
                    CurrentHP = table.Column<int>(nullable: false),
                    MaxHP = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Initiative = table.Column<int>(nullable: true),
                    Strength = table.Column<int>(nullable: true),
                    Dexterity = table.Column<int>(nullable: true),
                    Constitution = table.Column<int>(nullable: true),
                    Wisdom = table.Column<int>(nullable: true),
                    Charisma = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureCardAccounts", x => x.CreatureCardId);
                    table.ForeignKey(
                        name: "FK_CreatureCardAccounts_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "CreatureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreatureCardAccounts_CreatureId",
                table: "CreatureCardAccounts",
                column: "CreatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureCardAccounts");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Accounts");
        }
    }
}
