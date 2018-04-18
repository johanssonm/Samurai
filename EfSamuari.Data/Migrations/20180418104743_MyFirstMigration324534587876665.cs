using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class MyFirstMigration324534587876665 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SamuraiInfoName",
                table: "Samurais",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SamuraiInfoRealName",
                table: "Samurais",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SamuraiInfo",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    RealName = table.Column<string>(nullable: false),
                    BattleNames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraiInfo", x => new { x.Name, x.RealName });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_SamuraiInfoName_SamuraiInfoRealName",
                table: "Samurais",
                columns: new[] { "SamuraiInfoName", "SamuraiInfoRealName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_SamuraiInfo_SamuraiInfoName_SamuraiInfoRealName",
                table: "Samurais",
                columns: new[] { "SamuraiInfoName", "SamuraiInfoRealName" },
                principalTable: "SamuraiInfo",
                principalColumns: new[] { "Name", "RealName" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_SamuraiInfo_SamuraiInfoName_SamuraiInfoRealName",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "SamuraiInfo");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_SamuraiInfoName_SamuraiInfoRealName",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "SamuraiInfoName",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "SamuraiInfoRealName",
                table: "Samurais");
        }
    }
}
