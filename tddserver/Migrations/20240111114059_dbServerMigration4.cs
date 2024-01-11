using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tdd.Server.Migrations
{
    /// <inheritdoc />
    public partial class dbServerMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titel",
                table: "Onderzoeken",
                type: "text",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "BeloningBeschrijving",
                table: "Onderzoeken",
                type: "text",
                nullable: true,
                oldClrType: typeof(char),
                oldType: "character(128)",
                oldMaxLength: 128,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "Titel",
                table: "Onderzoeken",
                type: "character(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<char>(
                name: "BeloningBeschrijving",
                table: "Onderzoeken",
                type: "character(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
