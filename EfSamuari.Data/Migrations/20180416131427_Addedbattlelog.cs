using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class Addedbattlelog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BattlelogID",
                table: "Battle",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Battlelog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battlelog", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battle_BattlelogID",
                table: "Battle",
                column: "BattlelogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Battle_Battlelog_BattlelogID",
                table: "Battle",
                column: "BattlelogID",
                principalTable: "Battlelog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battle_Battlelog_BattlelogID",
                table: "Battle");

            migrationBuilder.DropTable(
                name: "Battlelog");

            migrationBuilder.DropIndex(
                name: "IX_Battle_BattlelogID",
                table: "Battle");

            migrationBuilder.DropColumn(
                name: "BattlelogID",
                table: "Battle");
        }
    }
}
