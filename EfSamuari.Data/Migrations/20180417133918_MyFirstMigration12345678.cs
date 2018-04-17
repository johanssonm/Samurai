using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class MyFirstMigration12345678 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battlelog_Battledescription_BattledescriptionID",
                table: "Battlelog");

            migrationBuilder.DropIndex(
                name: "IX_Battlelog_BattledescriptionID",
                table: "Battlelog");

            migrationBuilder.DropColumn(
                name: "BattledescriptionID",
                table: "Battlelog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BattledescriptionID",
                table: "Battlelog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Battlelog_BattledescriptionID",
                table: "Battlelog",
                column: "BattledescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Battlelog_Battledescription_BattledescriptionID",
                table: "Battlelog",
                column: "BattledescriptionID",
                principalTable: "Battledescription",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
