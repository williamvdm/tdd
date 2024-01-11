using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tdd.Server.Migrations
{
    /// <inheritdoc />
    public partial class dbServerMigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onderzoeken_Bedrijven_Bedrijfsmail",
                table: "Onderzoeken");

            migrationBuilder.RenameColumn(
                name: "Bedrijfsmail",
                table: "Onderzoeken",
                newName: "BedrijfModelBedrijfsmail");

            migrationBuilder.RenameIndex(
                name: "IX_Onderzoeken_Bedrijfsmail",
                table: "Onderzoeken",
                newName: "IX_Onderzoeken_BedrijfModelBedrijfsmail");

            migrationBuilder.AddColumn<string>(
                name: "BedrijfMail",
                table: "Onderzoeken",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Onderzoeken_Bedrijven_BedrijfModelBedrijfsmail",
                table: "Onderzoeken",
                column: "BedrijfModelBedrijfsmail",
                principalTable: "Bedrijven",
                principalColumn: "Bedrijfsmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onderzoeken_Bedrijven_BedrijfModelBedrijfsmail",
                table: "Onderzoeken");

            migrationBuilder.DropColumn(
                name: "BedrijfMail",
                table: "Onderzoeken");

            migrationBuilder.RenameColumn(
                name: "BedrijfModelBedrijfsmail",
                table: "Onderzoeken",
                newName: "Bedrijfsmail");

            migrationBuilder.RenameIndex(
                name: "IX_Onderzoeken_BedrijfModelBedrijfsmail",
                table: "Onderzoeken",
                newName: "IX_Onderzoeken_Bedrijfsmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Onderzoeken_Bedrijven_Bedrijfsmail",
                table: "Onderzoeken",
                column: "Bedrijfsmail",
                principalTable: "Bedrijven",
                principalColumn: "Bedrijfsmail");
        }
    }
}
