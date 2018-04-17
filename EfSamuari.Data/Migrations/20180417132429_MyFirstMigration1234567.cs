using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class MyFirstMigration1234567 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BattledescriptionID",
                table: "Battle",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Battle_BattledescriptionID",
                table: "Battle",
                column: "BattledescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Battle_Battledescription_BattledescriptionID",
                table: "Battle",
                column: "BattledescriptionID",
                principalTable: "Battledescription",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battle_Battledescription_BattledescriptionID",
                table: "Battle");

            migrationBuilder.DropIndex(
                name: "IX_Battle_BattledescriptionID",
                table: "Battle");

            migrationBuilder.DropColumn(
                name: "BattledescriptionID",
                table: "Battle");
        }
    }
}
