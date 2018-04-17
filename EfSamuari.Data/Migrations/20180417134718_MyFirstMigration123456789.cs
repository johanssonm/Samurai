using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class MyFirstMigration123456789 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatteBattledescriptionID",
                table: "Battlelog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Battlelog_BatteBattledescriptionID",
                table: "Battlelog",
                column: "BatteBattledescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Battlelog_Battledescription_BatteBattledescriptionID",
                table: "Battlelog",
                column: "BatteBattledescriptionID",
                principalTable: "Battledescription",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battlelog_Battledescription_BatteBattledescriptionID",
                table: "Battlelog");

            migrationBuilder.DropIndex(
                name: "IX_Battlelog_BatteBattledescriptionID",
                table: "Battlelog");

            migrationBuilder.DropColumn(
                name: "BatteBattledescriptionID",
                table: "Battlelog");
        }
    }
}
