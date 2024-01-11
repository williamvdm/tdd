using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tdd.Server.Migrations
{
    /// <inheritdoc />
    public partial class testextdbMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefoon",
                table: "UserModel",
                type: "text",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "Telefoon",
                table: "UserModel",
                type: "character(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
