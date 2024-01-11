using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tdd.Server.Migrations
{
    /// <inheritdoc />
    public partial class testextdbMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_Verzorgers_VerzorgerId",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "GeboorteDatum",
                table: "UserModel");

            migrationBuilder.AlterColumn<string>(
                name: "VoorkeurBenadering",
                table: "UserModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "VerzorgerId",
                table: "UserModel",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "ToestemmingBenadering",
                table: "UserModel",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Telefoon",
                table: "UserModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdult",
                table: "UserModel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_UserModel_Verzorgers_VerzorgerId",
                table: "UserModel",
                column: "VerzorgerId",
                principalTable: "Verzorgers",
                principalColumn: "VerzorgerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_Verzorgers_VerzorgerId",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "IsAdult",
                table: "UserModel");

            migrationBuilder.AlterColumn<string>(
                name: "VoorkeurBenadering",
                table: "UserModel",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VerzorgerId",
                table: "UserModel",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ToestemmingBenadering",
                table: "UserModel",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefoon",
                table: "UserModel",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GeboorteDatum",
                table: "UserModel",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_UserModel_Verzorgers_VerzorgerId",
                table: "UserModel",
                column: "VerzorgerId",
                principalTable: "Verzorgers",
                principalColumn: "VerzorgerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
