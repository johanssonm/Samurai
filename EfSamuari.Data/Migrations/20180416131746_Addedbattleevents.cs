using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class Addedbattleevents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Battlelog");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Battlelog");

            migrationBuilder.AddColumn<int>(
                name: "BattledescriptionID",
                table: "Battlelog",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Battledescription",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battledescription", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battlelog_Battledescription_BattledescriptionID",
                table: "Battlelog");

            migrationBuilder.DropTable(
                name: "Battledescription");

            migrationBuilder.DropIndex(
                name: "IX_Battlelog_BattledescriptionID",
                table: "Battlelog");

            migrationBuilder.DropColumn(
                name: "BattledescriptionID",
                table: "Battlelog");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Battlelog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Battlelog",
                nullable: true);
        }
    }
}
