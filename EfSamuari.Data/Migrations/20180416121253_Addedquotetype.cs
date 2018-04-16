using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class Addedquotetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Samurais",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_TypeID",
                table: "Samurais",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Quote_TypeID",
                table: "Samurais",
                column: "TypeID",
                principalTable: "Quote",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Quote_TypeID",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_TypeID",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Samurais");
        }
    }
}
