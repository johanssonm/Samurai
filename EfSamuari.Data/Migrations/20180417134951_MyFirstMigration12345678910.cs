using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class MyFirstMigration12345678910 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battlelog_Battledescription_BatteBattledescriptionID",
                table: "Battlelog");

            migrationBuilder.RenameColumn(
                name: "BatteBattledescriptionID",
                table: "Battlelog",
                newName: "BattledescriptionID");

            migrationBuilder.RenameIndex(
                name: "IX_Battlelog_BatteBattledescriptionID",
                table: "Battlelog",
                newName: "IX_Battlelog_BattledescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Battlelog_Battledescription_BattledescriptionID",
                table: "Battlelog",
                column: "BattledescriptionID",
                principalTable: "Battledescription",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battlelog_Battledescription_BattledescriptionID",
                table: "Battlelog");

            migrationBuilder.RenameColumn(
                name: "BattledescriptionID",
                table: "Battlelog",
                newName: "BatteBattledescriptionID");

            migrationBuilder.RenameIndex(
                name: "IX_Battlelog_BattledescriptionID",
                table: "Battlelog",
                newName: "IX_Battlelog_BatteBattledescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Battlelog_Battledescription_BatteBattledescriptionID",
                table: "Battlelog",
                column: "BatteBattledescriptionID",
                principalTable: "Battledescription",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
