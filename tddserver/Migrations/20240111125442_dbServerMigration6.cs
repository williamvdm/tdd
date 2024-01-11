using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tdd.Server.Migrations
{
    /// <inheritdoc />
    public partial class dbServerMigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Antwoorden_Onderzoeken_OnderzoekId",
                table: "Antwoorden");

            migrationBuilder.DropIndex(
                name: "IX_Antwoorden_OnderzoekId",
                table: "Antwoorden");

            migrationBuilder.DropColumn(
                name: "OnderzoekId",
                table: "Antwoorden");

            migrationBuilder.AddColumn<string>(
                name: "Onderzoek",
                table: "Antwoorden",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Onderzoek",
                table: "Antwoorden");

            migrationBuilder.AddColumn<Guid>(
                name: "OnderzoekId",
                table: "Antwoorden",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Antwoorden_OnderzoekId",
                table: "Antwoorden",
                column: "OnderzoekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Antwoorden_Onderzoeken_OnderzoekId",
                table: "Antwoorden",
                column: "OnderzoekId",
                principalTable: "Onderzoeken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
