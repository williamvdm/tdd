using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tdd.Server.Migrations
{
    /// <inheritdoc />
    public partial class dbMigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    TrackingDataId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingGegevens", x => x.TrackingDataId);
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
                name: "Onderzoeken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Beschrijving = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    BedrijfMail = table.Column<string>(type: "text", nullable: true),
                    Begindatum = table.Column<DateOnly>(type: "date", nullable: false),
                    Einddatum = table.Column<DateOnly>(type: "date", nullable: false),
                    LocatieID = table.Column<int>(type: "integer", nullable: true),
                    BeloningBeschrijving = table.Column<string>(type: "text", nullable: true),
                    Titel = table.Column<string>(type: "text", nullable: false),
                    TrackingGegevensTrackingDataId = table.Column<int>(type: "integer", nullable: true),
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
                        name: "FK_Onderzoeken_Opdrachten_OpdrachtData",
                        column: x => x.OpdrachtData,
                        principalTable: "Opdrachten",
                        principalColumn: "Data");
                    table.ForeignKey(
                        name: "FK_Onderzoeken_TrackingGegevens_TrackingGegevensTrackingDataId",
                        column: x => x.TrackingGegevensTrackingDataId,
                        principalTable: "TrackingGegevens",
                        principalColumn: "TrackingDataId");
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
                    BeschikbaarheidId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Begintijd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Eindtijd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beschikbaarheid", x => x.BeschikbaarheidId);
                    table.ForeignKey(
                        name: "FK_Beschikbaarheid_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vragen",
                columns: table => new
                {
                    VraagID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OnderzoekID = table.Column<Guid>(type: "uuid", nullable: false),
                    Vraag = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    OnderzoekModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vragen", x => x.VraagID);
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
                    Antwoord = table.Column<string>(type: "text", nullable: false),
                    VraagModelVraagID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antwoorden", x => x.AntwoordID);
                    table.ForeignKey(
                        name: "FK_Antwoorden_Vragen_VraagModelVraagID",
                        column: x => x.VraagModelVraagID,
                        principalTable: "Vragen",
                        principalColumn: "VraagID");
                });

            migrationBuilder.CreateTable(
                name: "Beantwoord",
                columns: table => new
                {
                    User = table.Column<Guid>(type: "uuid", nullable: false),
                    OnderzoekId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "FK_Beantwoord_Vragen_VraagID",
                        column: x => x.VraagID,
                        principalTable: "Vragen",
                        principalColumn: "VraagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aandoeningen_UserModelId",
                table: "Aandoeningen",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Antwoorden_VraagModelVraagID",
                table: "Antwoorden",
                column: "VraagModelVraagID");

            migrationBuilder.CreateIndex(
                name: "IX_Beantwoord_OnderzoekId",
                table: "Beantwoord",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_Beantwoord_VraagID",
                table: "Beantwoord",
                column: "VraagID");

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
                name: "IX_Onderzoeken_OpdrachtData",
                table: "Onderzoeken",
                column: "OpdrachtData");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_TrackingGegevensTrackingDataId",
                table: "Onderzoeken",
                column: "TrackingGegevensTrackingDataId");

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
                name: "Beschikbaarheid");

            migrationBuilder.DropTable(
                name: "Contactpersonen");

            migrationBuilder.DropTable(
                name: "Hulpmiddelen");

            migrationBuilder.DropTable(
                name: "Vragen");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "Onderzoeken");

            migrationBuilder.DropTable(
                name: "Verzorgers");

            migrationBuilder.DropTable(
                name: "Bedrijven");

            migrationBuilder.DropTable(
                name: "Opdrachten");

            migrationBuilder.DropTable(
                name: "TrackingGegevens");

            migrationBuilder.DropTable(
                name: "Locaties");
        }
    }
}
