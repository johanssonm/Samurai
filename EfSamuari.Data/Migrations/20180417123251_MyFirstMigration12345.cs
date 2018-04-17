using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class MyFirstMigration12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quote_Samurais_SamuraiID",
                table: "Quote");

            migrationBuilder.DropIndex(
                name: "IX_Quote_SamuraiID",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "SamuraiID",
                table: "Quote");

            migrationBuilder.AddColumn<int>(
                name: "BattleID",
                table: "Samurais",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuoteID",
                table: "Samurais",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_BattleID",
                table: "Samurais",
                column: "BattleID");

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_QuoteID",
                table: "Samurais",
                column: "QuoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Battle_BattleID",
                table: "Samurais",
                column: "BattleID",
                principalTable: "Battle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Quote_QuoteID",
                table: "Samurais",
                column: "QuoteID",
                principalTable: "Quote",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Battle_BattleID",
                table: "Samurais");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Quote_QuoteID",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_BattleID",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_QuoteID",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "BattleID",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "QuoteID",
                table: "Samurais");

            migrationBuilder.AddColumn<int>(
                name: "SamuraiID",
                table: "Quote",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quote_SamuraiID",
                table: "Quote",
                column: "SamuraiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quote_Samurais_SamuraiID",
                table: "Quote",
                column: "SamuraiID",
                principalTable: "Samurais",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
