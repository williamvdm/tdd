using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tdd.Server.Migrations
{
    /// <inheritdoc />
    public partial class testMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AandoeningModel_Users_UserModelId",
                table: "AandoeningModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BeperkingModel_Users_UserModelId",
                table: "BeperkingModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_VerzorgerModel_VerzorgerId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VerzorgerModel",
                table: "VerzorgerModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeperkingModel",
                table: "BeperkingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AandoeningModel",
                table: "AandoeningModel");

            migrationBuilder.RenameTable(
                name: "VerzorgerModel",
                newName: "Verzorgers");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserModel");

            migrationBuilder.RenameTable(
                name: "BeperkingModel",
                newName: "Beperkingen");

            migrationBuilder.RenameTable(
                name: "AandoeningModel",
                newName: "Aandoeningen");

            migrationBuilder.RenameIndex(
                name: "IX_Users_VerzorgerId",
                table: "UserModel",
                newName: "IX_UserModel_VerzorgerId");

            migrationBuilder.RenameColumn(
                name: "BeprkingNaam",
                table: "Beperkingen",
                newName: "BeperkingNaam");

            migrationBuilder.RenameIndex(
                name: "IX_BeperkingModel_UserModelId",
                table: "Beperkingen",
                newName: "IX_Beperkingen_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_AandoeningModel_UserModelId",
                table: "Aandoeningen",
                newName: "IX_Aandoeningen_UserModelId");

            migrationBuilder.AddColumn<int>(
                name: "AdresLocatieID",
                table: "UserModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verzorgers",
                table: "Verzorgers",
                column: "VerzorgerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserModel",
                table: "UserModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beperkingen",
                table: "Beperkingen",
                column: "BeperkingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aandoeningen",
                table: "Aandoeningen",
                column: "AandoeningId");

            migrationBuilder.CreateTable(
                name: "Berichten",
                columns: table => new
                {
                    ChatBerichtID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ZenderMail = table.Column<string>(type: "text", nullable: false),
                    OntvangerMail = table.Column<string>(type: "text", nullable: false),
                    Bericht = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Berichten", x => x.ChatBerichtID);
                });

            migrationBuilder.CreateTable(
                name: "Beschikbaarheid",
                columns: table => new
                {
                    User = table.Column<Guid>(type: "uuid", nullable: false),
                    Begintijd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Eindtijd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beschikbaarheid", x => new { x.User, x.Begintijd });
                    table.ForeignKey(
                        name: "FK_Beschikbaarheid_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hulpmiddelen",
                columns: table => new
                {
                    Hulpmiddel = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hulpmiddelen", x => x.Hulpmiddel);
                });

            migrationBuilder.CreateTable(
                name: "Locaties",
                columns: table => new
                {
                    LocatieID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostCode = table.Column<string>(type: "text", nullable: false),
                    PlaatsNaam = table.Column<string>(type: "character varying(58)", maxLength: 58, nullable: true),
                    StraatNaam = table.Column<string>(type: "character varying(85)", maxLength: 85, nullable: true),
                    Huisnummer = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locaties", x => x.LocatieID);
                });

            migrationBuilder.CreateTable(
                name: "Onderzoeksoorten",
                columns: table => new
                {
                    Tag = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    UserModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderzoeksoorten", x => x.Tag);
                    table.ForeignKey(
                        name: "FK_Onderzoeksoorten_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Opdrachten",
                columns: table => new
                {
                    Data = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opdrachten", x => x.Data);
                });

            migrationBuilder.CreateTable(
                name: "TrackingGegevens",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    OnderzoekID = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingGegevens", x => new { x.UserID, x.OnderzoekID });
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMachtiging",
                columns: table => new
                {
                    Role = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Machtigingingen = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMachtiging", x => x.Role);
                });

            migrationBuilder.CreateTable(
                name: "Bedrijven",
                columns: table => new
                {
                    Bedrijfsmail = table.Column<string>(type: "text", nullable: false),
                    Informatie = table.Column<string>(type: "text", nullable: false),
                    LocatieID = table.Column<int>(type: "integer", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    Verified = table.Column<bool>(type: "boolean", nullable: false),
                    Provider = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrijven", x => x.Bedrijfsmail);
                    table.ForeignKey(
                        name: "FK_Bedrijven_Locaties_LocatieID",
                        column: x => x.LocatieID,
                        principalTable: "Locaties",
                        principalColumn: "LocatieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contactpersonen",
                columns: table => new
                {
                    ContactPersoonID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Voornaam = table.Column<string>(type: "text", nullable: false),
                    Achternaam = table.Column<string>(type: "text", nullable: false),
                    BedrijfModelBedrijfsmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactpersonen", x => x.ContactPersoonID);
                    table.ForeignKey(
                        name: "FK_Contactpersonen_Bedrijven_BedrijfModelBedrijfsmail",
                        column: x => x.BedrijfModelBedrijfsmail,
                        principalTable: "Bedrijven",
                        principalColumn: "Bedrijfsmail");
                });

            migrationBuilder.CreateTable(
                name: "Onderzoeken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Beschrijving = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Bedrijfsmail = table.Column<string>(type: "text", nullable: true),
                    Begindatum = table.Column<DateOnly>(type: "date", nullable: false),
                    Einddatum = table.Column<DateOnly>(type: "date", nullable: false),
                    LocatieID = table.Column<int>(type: "integer", nullable: true),
                    BeloningBeschrijving = table.Column<char>(type: "character(128)", maxLength: 128, nullable: true),
                    Titel = table.Column<char>(type: "character(128)", maxLength: 128, nullable: false),
                    OnderzoekSoortTag = table.Column<string>(type: "character varying(128)", nullable: false),
                    TrackingGegevensUserID = table.Column<Guid>(type: "uuid", nullable: true),
                    TrackingGegevensOnderzoekID = table.Column<Guid>(type: "uuid", nullable: true),
                    OpdrachtData = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderzoeken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderzoeken_Bedrijven_Bedrijfsmail",
                        column: x => x.Bedrijfsmail,
                        principalTable: "Bedrijven",
                        principalColumn: "Bedrijfsmail");
                    table.ForeignKey(
                        name: "FK_Onderzoeken_Locaties_LocatieID",
                        column: x => x.LocatieID,
                        principalTable: "Locaties",
                        principalColumn: "LocatieID");
                    table.ForeignKey(
                        name: "FK_Onderzoeken_Onderzoeksoorten_OnderzoekSoortTag",
                        column: x => x.OnderzoekSoortTag,
                        principalTable: "Onderzoeksoorten",
                        principalColumn: "Tag",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Onderzoeken_Opdrachten_OpdrachtData",
                        column: x => x.OpdrachtData,
                        principalTable: "Opdrachten",
                        principalColumn: "Data");
                    table.ForeignKey(
                        name: "FK_Onderzoeken_TrackingGegevens_TrackingGegevensUserID_Trackin~",
                        columns: x => new { x.TrackingGegevensUserID, x.TrackingGegevensOnderzoekID },
                        principalTable: "TrackingGegevens",
                        principalColumns: new[] { "UserID", "OnderzoekID" });
                });

            migrationBuilder.CreateTable(
                name: "Vragen",
                columns: table => new
                {
                    OnderzoekID = table.Column<int>(type: "integer", nullable: false),
                    VraagID = table.Column<int>(type: "integer", nullable: false),
                    Vraag = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    OnderzoekModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vragen", x => new { x.OnderzoekID, x.VraagID });
                    table.ForeignKey(
                        name: "FK_Vragen_Onderzoeken_OnderzoekModelId",
                        column: x => x.OnderzoekModelId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Antwoorden",
                columns: table => new
                {
                    AntwoordID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OnderzoekId = table.Column<Guid>(type: "uuid", nullable: false),
                    VraagOnderzoekID = table.Column<int>(type: "integer", nullable: false),
                    VraagID = table.Column<int>(type: "integer", nullable: false),
                    Antwoord = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antwoorden", x => x.AntwoordID);
                    table.ForeignKey(
                        name: "FK_Antwoorden_Onderzoeken_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Antwoorden_Vragen_VraagOnderzoekID_VraagID",
                        columns: x => new { x.VraagOnderzoekID, x.VraagID },
                        principalTable: "Vragen",
                        principalColumns: new[] { "OnderzoekID", "VraagID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beantwoord",
                columns: table => new
                {
                    User = table.Column<Guid>(type: "uuid", nullable: false),
                    OnderzoekId = table.Column<Guid>(type: "uuid", nullable: false),
                    VraagOnderzoekID = table.Column<int>(type: "integer", nullable: false),
                    VraagID = table.Column<int>(type: "integer", nullable: false),
                    Antwoord = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beantwoord", x => x.User);
                    table.ForeignKey(
                        name: "FK_Beantwoord_Onderzoeken_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beantwoord_Vragen_VraagOnderzoekID_VraagID",
                        columns: x => new { x.VraagOnderzoekID, x.VraagID },
                        principalTable: "Vragen",
                        principalColumns: new[] { "OnderzoekID", "VraagID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_AdresLocatieID",
                table: "UserModel",
                column: "AdresLocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Antwoorden_OnderzoekId",
                table: "Antwoorden",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_Antwoorden_VraagOnderzoekID_VraagID",
                table: "Antwoorden",
                columns: new[] { "VraagOnderzoekID", "VraagID" });

            migrationBuilder.CreateIndex(
                name: "IX_Beantwoord_OnderzoekId",
                table: "Beantwoord",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_Beantwoord_VraagOnderzoekID_VraagID",
                table: "Beantwoord",
                columns: new[] { "VraagOnderzoekID", "VraagID" });

            migrationBuilder.CreateIndex(
                name: "IX_Bedrijven_LocatieID",
                table: "Bedrijven",
                column: "LocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Beschikbaarheid_UserModelId",
                table: "Beschikbaarheid",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactpersonen_BedrijfModelBedrijfsmail",
                table: "Contactpersonen",
                column: "BedrijfModelBedrijfsmail");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_Bedrijfsmail",
                table: "Onderzoeken",
                column: "Bedrijfsmail");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_LocatieID",
                table: "Onderzoeken",
                column: "LocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_OnderzoekSoortTag",
                table: "Onderzoeken",
                column: "OnderzoekSoortTag");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_OpdrachtData",
                table: "Onderzoeken",
                column: "OpdrachtData");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_TrackingGegevensUserID_TrackingGegevensOnderzoe~",
                table: "Onderzoeken",
                columns: new[] { "TrackingGegevensUserID", "TrackingGegevensOnderzoekID" });

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeksoorten_UserModelId",
                table: "Onderzoeksoorten",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vragen_OnderzoekModelId",
                table: "Vragen",
                column: "OnderzoekModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aandoeningen_UserModel_UserModelId",
                table: "Aandoeningen",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beperkingen_UserModel_UserModelId",
                table: "Beperkingen",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserModel_Locaties_AdresLocatieID",
                table: "UserModel",
                column: "AdresLocatieID",
                principalTable: "Locaties",
                principalColumn: "LocatieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserModel_Verzorgers_VerzorgerId",
                table: "UserModel",
                column: "VerzorgerId",
                principalTable: "Verzorgers",
                principalColumn: "VerzorgerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aandoeningen_UserModel_UserModelId",
                table: "Aandoeningen");

            migrationBuilder.DropForeignKey(
                name: "FK_Beperkingen_UserModel_UserModelId",
                table: "Beperkingen");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_Locaties_AdresLocatieID",
                table: "UserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_Verzorgers_VerzorgerId",
                table: "UserModel");

            migrationBuilder.DropTable(
                name: "Antwoorden");

            migrationBuilder.DropTable(
                name: "Beantwoord");

            migrationBuilder.DropTable(
                name: "Berichten");

            migrationBuilder.DropTable(
                name: "Beschikbaarheid");

            migrationBuilder.DropTable(
                name: "Contactpersonen");

            migrationBuilder.DropTable(
                name: "Hulpmiddelen");

            migrationBuilder.DropTable(
                name: "UserRoleMachtiging");

            migrationBuilder.DropTable(
                name: "Vragen");

            migrationBuilder.DropTable(
                name: "Onderzoeken");

            migrationBuilder.DropTable(
                name: "Bedrijven");

            migrationBuilder.DropTable(
                name: "Onderzoeksoorten");

            migrationBuilder.DropTable(
                name: "Opdrachten");

            migrationBuilder.DropTable(
                name: "TrackingGegevens");

            migrationBuilder.DropTable(
                name: "Locaties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Verzorgers",
                table: "Verzorgers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserModel",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_UserModel_AdresLocatieID",
                table: "UserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beperkingen",
                table: "Beperkingen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aandoeningen",
                table: "Aandoeningen");

            migrationBuilder.DropColumn(
                name: "AdresLocatieID",
                table: "UserModel");

            migrationBuilder.RenameTable(
                name: "Verzorgers",
                newName: "VerzorgerModel");

            migrationBuilder.RenameTable(
                name: "UserModel",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Beperkingen",
                newName: "BeperkingModel");

            migrationBuilder.RenameTable(
                name: "Aandoeningen",
                newName: "AandoeningModel");

            migrationBuilder.RenameIndex(
                name: "IX_UserModel_VerzorgerId",
                table: "Users",
                newName: "IX_Users_VerzorgerId");

            migrationBuilder.RenameColumn(
                name: "BeperkingNaam",
                table: "BeperkingModel",
                newName: "BeprkingNaam");

            migrationBuilder.RenameIndex(
                name: "IX_Beperkingen_UserModelId",
                table: "BeperkingModel",
                newName: "IX_BeperkingModel_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Aandoeningen_UserModelId",
                table: "AandoeningModel",
                newName: "IX_AandoeningModel_UserModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VerzorgerModel",
                table: "VerzorgerModel",
                column: "VerzorgerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeperkingModel",
                table: "BeperkingModel",
                column: "BeperkingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AandoeningModel",
                table: "AandoeningModel",
                column: "AandoeningId");

            migrationBuilder.AddForeignKey(
                name: "FK_AandoeningModel_Users_UserModelId",
                table: "AandoeningModel",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BeperkingModel_Users_UserModelId",
                table: "BeperkingModel",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_VerzorgerModel_VerzorgerId",
                table: "Users",
                column: "VerzorgerId",
                principalTable: "VerzorgerModel",
                principalColumn: "VerzorgerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
