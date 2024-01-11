using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tdd.Server.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VerzorgerModel",
                columns: table => new
                {
                    VerzorgerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VerzorgerEmail = table.Column<string>(type: "text", nullable: false),
                    VerzorgerTelefoon = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerzorgerModel", x => x.VerzorgerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Voornaam = table.Column<string>(type: "text", nullable: false),
                    Achternaam = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefoon = table.Column<char>(type: "character(10)", maxLength: 10, nullable: false),
                    ToestemmingBenadering = table.Column<bool>(type: "boolean", nullable: false),
                    VoorkeurBenadering = table.Column<string>(type: "text", nullable: false),
                    Provider = table.Column<string>(type: "text", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdentityHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    VerzorgerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_VerzorgerModel_VerzorgerId",
                        column: x => x.VerzorgerId,
                        principalTable: "VerzorgerModel",
                        principalColumn: "VerzorgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AandoeningModel",
                columns: table => new
                {
                    AandoeningId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AandoeningNaam = table.Column<string>(type: "text", nullable: false),
                    UserModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AandoeningModel", x => x.AandoeningId);
                    table.ForeignKey(
                        name: "FK_AandoeningModel_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BeperkingModel",
                columns: table => new
                {
                    BeperkingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeprkingNaam = table.Column<string>(type: "text", nullable: false),
                    UserModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeperkingModel", x => x.BeperkingId);
                    table.ForeignKey(
                        name: "FK_BeperkingModel_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AandoeningModel_UserModelId",
                table: "AandoeningModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BeperkingModel_UserModelId",
                table: "BeperkingModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VerzorgerId",
                table: "Users",
                column: "VerzorgerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AandoeningModel");

            migrationBuilder.DropTable(
                name: "BeperkingModel");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VerzorgerModel");
        }
    }
}
