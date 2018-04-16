using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Data.Migrations
{
    public partial class Addedquoteid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Quote_TypeID",
                table: "Samurais");

            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "Samurais",
                newName: "QuoteID");

            migrationBuilder.RenameIndex(
                name: "IX_Samurais_TypeID",
                table: "Samurais",
                newName: "IX_Samurais_QuoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Quote_QuoteID",
                table: "Samurais",
                column: "QuoteID",
                principalTable: "Quote",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Quote_QuoteID",
                table: "Samurais");

            migrationBuilder.RenameColumn(
                name: "QuoteID",
                table: "Samurais",
                newName: "TypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Samurais_QuoteID",
                table: "Samurais",
                newName: "IX_Samurais_TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Quote_TypeID",
                table: "Samurais",
                column: "TypeID",
                principalTable: "Quote",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
