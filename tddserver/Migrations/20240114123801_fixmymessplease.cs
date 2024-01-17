using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tdd.Server.Migrations
{
    /// <inheritdoc />
    public partial class fixmymessplease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnderzoekModelUserModel",
                columns: table => new
                {
                    DeelnemersId = table.Column<Guid>(type: "uuid", nullable: false),
                    OnderzoekenId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderzoekModelUserModel", x => new { x.DeelnemersId, x.OnderzoekenId });
                    table.ForeignKey(
                        name: "FK_OnderzoekModelUserModel_Onderzoeken_OnderzoekenId",
                        column: x => x.OnderzoekenId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnderzoekModelUserModel_UserModel_DeelnemersId",
                        column: x => x.DeelnemersId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekModelUserModel_OnderzoekenId",
                table: "OnderzoekModelUserModel",
                column: "OnderzoekenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnderzoekModelUserModel");
        }
    }
}
