using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class MyFirstMigration123456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Battle_BattleID",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_BattleID",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "BattleID",
                table: "Samurais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BattleID",
                table: "Samurais",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_BattleID",
                table: "Samurais",
                column: "BattleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Battle_BattleID",
                table: "Samurais",
                column: "BattleID",
                principalTable: "Battle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
