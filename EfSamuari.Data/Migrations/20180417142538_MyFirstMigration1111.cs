﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class MyFirstMigration1111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Battlelog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battlelog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Battle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    BattlelogID = table.Column<int>(nullable: true),
                    Brutal = table.Column<bool>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Battle_Battlelog_BattlelogID",
                        column: x => x.BattlelogID,
                        principalTable: "Battlelog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Battle_Battledescription_ID",
                        column: x => x.ID,
                        principalTable: "Battledescription",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Samurais",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hairstyle = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    QuoteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samurais", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Samurais_Quote_QuoteID",
                        column: x => x.QuoteID,
                        principalTable: "Quote",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SamuraiBattle",
                columns: table => new
                {
                    BattleID = table.Column<int>(nullable: false),
                    SamuraiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraiBattle", x => new { x.BattleID, x.SamuraiID });
                    table.ForeignKey(
                        name: "FK_SamuraiBattle_Battle_BattleID",
                        column: x => x.BattleID,
                        principalTable: "Battle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SamuraiBattle_Samurais_SamuraiID",
                        column: x => x.SamuraiID,
                        principalTable: "Samurais",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecretIdentity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SamuraiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SecretIdentity_Samurais_SamuraiID",
                        column: x => x.SamuraiID,
                        principalTable: "Samurais",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battle_BattlelogID",
                table: "Battle",
                column: "BattlelogID",
                unique: true,
                filter: "[BattlelogID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattle_SamuraiID",
                table: "SamuraiBattle",
                column: "SamuraiID");

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_QuoteID",
                table: "Samurais",
                column: "QuoteID");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentity_SamuraiID",
                table: "SecretIdentity",
                column: "SamuraiID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SamuraiBattle");

            migrationBuilder.DropTable(
                name: "SecretIdentity");

            migrationBuilder.DropTable(
                name: "Battle");

            migrationBuilder.DropTable(
                name: "Samurais");

            migrationBuilder.DropTable(
                name: "Battlelog");

            migrationBuilder.DropTable(
                name: "Battledescription");

            migrationBuilder.DropTable(
                name: "Quote");
        }
    }
}