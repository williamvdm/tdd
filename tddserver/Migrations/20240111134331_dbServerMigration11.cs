using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tdd.Server.Migrations
{
    /// <inheritdoc />
    public partial class dbServerMigration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Verzorgers",
                columns: table => new
                {
                    VerzorgerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VerzorgerEmail = table.Column<string>(type: "text", nullable: false),
                    VerzorgerTelefoon = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verzorgers", x => x.VerzorgerId);
                });

            migrationBuilder.CreateTable(
                name: "Bedrijven",
                columns: table => new
                {
                    Bedrijfsmail = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
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
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Voornaam = table.Column<string>(type: "text", nullable: false),
                    Achternaam = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefoon = table.Column<string>(type: "text", nullable: true),
                    ToestemmingBenadering = table.Column<bool>(type: "boolean", nullable: true),
                    VoorkeurBenadering = table.Column<string>(type: "text", nullable: true),
                    Provider = table.Column<string>(type: "text", nullable: false),
                    IsAdult = table.Column<bool>(type: "boolean", nullable: false),
                    IdentityHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    VerzorgerId = table.Column<int>(type: "integer", nullable: true),
                    AdresLocatieID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModel_Locaties_AdresLocatieID",
                        column: x => x.AdresLocatieID,
                        principalTable: "Locaties",
                        principalColumn: "LocatieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserModel_Verzorgers_VerzorgerId",
                        column: x => x.VerzorgerId,
                        principalTable: "Verzorgers",
                        principalColumn: "VerzorgerId");
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
                name: "Aandoeningen",
                columns: table => new
                {
                    AandoeningId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AandoeningNaam = table.Column<string>(type: "text", nullable: false),
                    UserModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aandoeningen", x => x.AandoeningId);
                    table.ForeignKey(
                        name: "FK_Aandoeningen_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Beperkingen",
                columns: table => new
                {
                    BeperkingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeperkingNaam = table.Column<string>(type: "text", nullable: false),
                    UserModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beperkingen", x => x.BeperkingId);
                    table.ForeignKey(
                        name: "FK_Beperkingen_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id");
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
                name: "Onderzoeken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Beschrijving = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    BedrijfMail = table.Column<string>(type: "text", nullable: false),
                    Begindatum = table.Column<DateOnly>(type: "date", nullable: false),
                    Einddatum = table.Column<DateOnly>(type: "date", nullable: false),
                    LocatieID = table.Column<int>(type: "integer", nullable: true),
                    BeloningBeschrijving = table.Column<string>(type: "text", nullable: true),
                    Titel = table.Column<string>(type: "text", nullable: false),
                    OnderzoekSoortTag = table.Column<string>(type: "character varying(128)", nullable: false),
                    TrackingGegevensUserID = table.Column<Guid>(type: "uuid", nullable: true),
                    TrackingGegevensOnderzoekID = table.Column<Guid>(type: "uuid", nullable: true),
                    OpdrachtData = table.Column<string>(type: "text", nullable: true),
                    BedrijfModelBedrijfsmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderzoeken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderzoeken_Bedrijven_BedrijfModelBedrijfsmail",
                        column: x => x.BedrijfModelBedrijfsmail,
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
                    OnderzoekID = table.Column<Guid>(type: "uuid", nullable: false),
                    VraagID = table.Column<Guid>(type: "uuid", nullable: false),
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
                    Onderzoek = table.Column<string>(type: "text", nullable: false),
                    Vraag = table.Column<string>(type: "text", nullable: false),
                    Antwoord = table.Column<string>(type: "text", nullable: false),
                    VraagModelOnderzoekID = table.Column<Guid>(type: "uuid", nullable: true),
                    VraagModelVraagID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antwoorden", x => x.AntwoordID);
                    table.ForeignKey(
                        name: "FK_Antwoorden_Vragen_VraagModelOnderzoekID_VraagModelVraagID",
                        columns: x => new { x.VraagModelOnderzoekID, x.VraagModelVraagID },
                        principalTable: "Vragen",
                        principalColumns: new[] { "OnderzoekID", "VraagID" });
                });

            migrationBuilder.CreateTable(
                name: "Beantwoord",
                columns: table => new
                {
                    User = table.Column<Guid>(type: "uuid", nullable: false),
                    OnderzoekId = table.Column<Guid>(type: "uuid", nullable: false),
                    VraagOnderzoekID = table.Column<Guid>(type: "uuid", nullable: false),
                    VraagID = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "IX_Aandoeningen_UserModelId",
                table: "Aandoeningen",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Antwoorden_VraagModelOnderzoekID_VraagModelVraagID",
                table: "Antwoorden",
                columns: new[] { "VraagModelOnderzoekID", "VraagModelVraagID" });

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
                name: "IX_Beperkingen_UserModelId",
                table: "Beperkingen",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Beschikbaarheid_UserModelId",
                table: "Beschikbaarheid",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactpersonen_BedrijfModelBedrijfsmail",
                table: "Contactpersonen",
                column: "BedrijfModelBedrijfsmail");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_BedrijfModelBedrijfsmail",
                table: "Onderzoeken",
                column: "BedrijfModelBedrijfsmail");

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
                name: "IX_UserModel_AdresLocatieID",
                table: "UserModel",
                column: "AdresLocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_VerzorgerId",
                table: "UserModel",
                column: "VerzorgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vragen_OnderzoekModelId",
                table: "Vragen",
                column: "OnderzoekModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aandoeningen");

            migrationBuilder.DropTable(
                name: "Antwoorden");

            migrationBuilder.DropTable(
                name: "Beantwoord");

            migrationBuilder.DropTable(
                name: "Beperkingen");

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
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "Locaties");

            migrationBuilder.DropTable(
                name: "Verzorgers");
        }
    }
}
