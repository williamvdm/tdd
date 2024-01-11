﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tdd.Server.Context;

#nullable disable

namespace tdd.Server.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240110190338_testextdbMigration2")]
    partial class testextdbMigration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("tdd.Server.Models.AandoeningModel", b =>
                {
                    b.Property<int>("AandoeningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AandoeningId"));

                    b.Property<string>("AandoeningNaam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserModelId")
                        .HasColumnType("uuid");

                    b.HasKey("AandoeningId");

                    b.HasIndex("UserModelId");

                    b.ToTable("Aandoeningen");
                });

            modelBuilder.Entity("tdd.Server.Models.AntwoordModel", b =>
                {
                    b.Property<int>("AntwoordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AntwoordID"));

                    b.Property<string>("Antwoord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OnderzoekId")
                        .HasColumnType("uuid");

                    b.Property<int>("VraagID")
                        .HasColumnType("integer");

                    b.Property<int>("VraagOnderzoekID")
                        .HasColumnType("integer");

                    b.HasKey("AntwoordID");

                    b.HasIndex("OnderzoekId");

                    b.HasIndex("VraagOnderzoekID", "VraagID");

                    b.ToTable("Antwoorden");
                });

            modelBuilder.Entity("tdd.Server.Models.BeantwoordModel", b =>
                {
                    b.Property<Guid?>("User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Antwoord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OnderzoekId")
                        .HasColumnType("uuid");

                    b.Property<int>("VraagID")
                        .HasColumnType("integer");

                    b.Property<int>("VraagOnderzoekID")
                        .HasColumnType("integer");

                    b.HasKey("User");

                    b.HasIndex("OnderzoekId");

                    b.HasIndex("VraagOnderzoekID", "VraagID");

                    b.ToTable("Beantwoord");
                });

            modelBuilder.Entity("tdd.Server.Models.BedrijfModel", b =>
                {
                    b.Property<string>("Bedrijfsmail")
                        .HasColumnType("text");

                    b.Property<string>("Informatie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LocatieID")
                        .HasColumnType("integer");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Verified")
                        .HasColumnType("boolean");

                    b.HasKey("Bedrijfsmail");

                    b.HasIndex("LocatieID");

                    b.ToTable("Bedrijven");
                });

            modelBuilder.Entity("tdd.Server.Models.BeperkingModel", b =>
                {
                    b.Property<int>("BeperkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BeperkingId"));

                    b.Property<string>("BeperkingNaam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserModelId")
                        .HasColumnType("uuid");

                    b.HasKey("BeperkingId");

                    b.HasIndex("UserModelId");

                    b.ToTable("Beperkingen");
                });

            modelBuilder.Entity("tdd.Server.Models.BeschikbaarheidModel", b =>
                {
                    b.Property<Guid?>("User")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Begintijd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Eindtijd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UserModelId")
                        .HasColumnType("uuid");

                    b.HasKey("User", "Begintijd");

                    b.HasIndex("UserModelId");

                    b.ToTable("Beschikbaarheid");
                });

            modelBuilder.Entity("tdd.Server.Models.ChatModel", b =>
                {
                    b.Property<int>("ChatBerichtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChatBerichtID"));

                    b.Property<string>("Bericht")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OntvangerMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZenderMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ChatBerichtID");

                    b.ToTable("Berichten");
                });

            modelBuilder.Entity("tdd.Server.Models.ContactPersoonModel", b =>
                {
                    b.Property<int>("ContactPersoonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContactPersoonID"));

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BedrijfModelBedrijfsmail")
                        .HasColumnType("text");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ContactPersoonID");

                    b.HasIndex("BedrijfModelBedrijfsmail");

                    b.ToTable("Contactpersonen");
                });

            modelBuilder.Entity("tdd.Server.Models.HulpmiddelModel", b =>
                {
                    b.Property<string>("Hulpmiddel")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Hulpmiddel");

                    b.ToTable("Hulpmiddelen");
                });

            modelBuilder.Entity("tdd.Server.Models.LocatieModel", b =>
                {
                    b.Property<int>("LocatieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LocatieID"));

                    b.Property<int>("Huisnummer")
                        .HasColumnType("integer");

                    b.Property<string>("PlaatsNaam")
                        .HasMaxLength(58)
                        .HasColumnType("character varying(58)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StraatNaam")
                        .HasMaxLength(85)
                        .HasColumnType("character varying(85)");

                    b.HasKey("LocatieID");

                    b.ToTable("Locaties");
                });

            modelBuilder.Entity("tdd.Server.Models.OnderzoekModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bedrijfsmail")
                        .HasColumnType("text");

                    b.Property<DateOnly>("Begindatum")
                        .HasColumnType("date");

                    b.Property<char?>("BeloningBeschrijving")
                        .HasMaxLength(128)
                        .HasColumnType("character(128)");

                    b.Property<string>("Beschrijving")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateOnly>("Einddatum")
                        .HasColumnType("date");

                    b.Property<int?>("LocatieID")
                        .HasColumnType("integer");

                    b.Property<string>("OnderzoekSoortTag")
                        .IsRequired()
                        .HasColumnType("character varying(128)");

                    b.Property<string>("OpdrachtData")
                        .HasColumnType("text");

                    b.Property<char>("Titel")
                        .HasMaxLength(128)
                        .HasColumnType("character(128)");

                    b.Property<Guid?>("TrackingGegevensOnderzoekID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TrackingGegevensUserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Bedrijfsmail");

                    b.HasIndex("LocatieID");

                    b.HasIndex("OnderzoekSoortTag");

                    b.HasIndex("OpdrachtData");

                    b.HasIndex("TrackingGegevensUserID", "TrackingGegevensOnderzoekID");

                    b.ToTable("Onderzoeken");
                });

            modelBuilder.Entity("tdd.Server.Models.OnderzoeksoortModel", b =>
                {
                    b.Property<string>("Tag")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<Guid?>("UserModelId")
                        .HasColumnType("uuid");

                    b.HasKey("Tag");

                    b.HasIndex("UserModelId");

                    b.ToTable("Onderzoeksoorten");
                });

            modelBuilder.Entity("tdd.Server.Models.OpdrachtModel", b =>
                {
                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.HasKey("Data");

                    b.ToTable("Opdrachten");
                });

            modelBuilder.Entity("tdd.Server.Models.TrackingGegevensModel", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OnderzoekID")
                        .HasColumnType("uuid");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID", "OnderzoekID");

                    b.ToTable("TrackingGegevens");
                });

            modelBuilder.Entity("tdd.Server.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AdresLocatieID")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IdentityHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefoon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("ToestemmingBenadering")
                        .HasColumnType("boolean");

                    b.Property<int>("VerzorgerId")
                        .HasColumnType("integer");

                    b.Property<string>("VoorkeurBenadering")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AdresLocatieID");

                    b.HasIndex("VerzorgerId");

                    b.ToTable("UserModel");
                });

            modelBuilder.Entity("tdd.Server.Models.UserRoleMachtigingModel", b =>
                {
                    b.Property<string>("Role")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<int>("Machtigingingen")
                        .HasColumnType("integer");

                    b.HasKey("Role");

                    b.ToTable("UserRoleMachtiging");
                });

            modelBuilder.Entity("tdd.Server.Models.VerzorgerModel", b =>
                {
                    b.Property<int>("VerzorgerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VerzorgerId"));

                    b.Property<string>("VerzorgerEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VerzorgerTelefoon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VerzorgerId");

                    b.ToTable("Verzorgers");
                });

            modelBuilder.Entity("tdd.Server.Models.VraagModel", b =>
                {
                    b.Property<int>("OnderzoekID")
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    b.Property<int>("VraagID")
                        .HasColumnType("integer")
                        .HasColumnOrder(1);

                    b.Property<Guid?>("OnderzoekModelId")
                        .HasColumnType("uuid");

                    b.Property<string>("Vraag")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("OnderzoekID", "VraagID");

                    b.HasIndex("OnderzoekModelId");

                    b.ToTable("Vragen");
                });

            modelBuilder.Entity("tdd.Server.Models.AandoeningModel", b =>
                {
                    b.HasOne("tdd.Server.Models.UserModel", null)
                        .WithMany("Aandoening")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("tdd.Server.Models.AntwoordModel", b =>
                {
                    b.HasOne("tdd.Server.Models.OnderzoekModel", "Onderzoek")
                        .WithMany()
                        .HasForeignKey("OnderzoekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tdd.Server.Models.VraagModel", "Vraag")
                        .WithMany("Antwoorden")
                        .HasForeignKey("VraagOnderzoekID", "VraagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Onderzoek");

                    b.Navigation("Vraag");
                });

            modelBuilder.Entity("tdd.Server.Models.BeantwoordModel", b =>
                {
                    b.HasOne("tdd.Server.Models.OnderzoekModel", "Onderzoek")
                        .WithMany()
                        .HasForeignKey("OnderzoekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tdd.Server.Models.VraagModel", "Vraag")
                        .WithMany()
                        .HasForeignKey("VraagOnderzoekID", "VraagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Onderzoek");

                    b.Navigation("Vraag");
                });

            modelBuilder.Entity("tdd.Server.Models.BedrijfModel", b =>
                {
                    b.HasOne("tdd.Server.Models.LocatieModel", "Locatie")
                        .WithMany()
                        .HasForeignKey("LocatieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locatie");
                });

            modelBuilder.Entity("tdd.Server.Models.BeperkingModel", b =>
                {
                    b.HasOne("tdd.Server.Models.UserModel", null)
                        .WithMany("Beperking")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("tdd.Server.Models.BeschikbaarheidModel", b =>
                {
                    b.HasOne("tdd.Server.Models.UserModel", null)
                        .WithMany("Beschikbaarheid")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("tdd.Server.Models.ContactPersoonModel", b =>
                {
                    b.HasOne("tdd.Server.Models.BedrijfModel", null)
                        .WithMany("contactpersonen")
                        .HasForeignKey("BedrijfModelBedrijfsmail");
                });

            modelBuilder.Entity("tdd.Server.Models.OnderzoekModel", b =>
                {
                    b.HasOne("tdd.Server.Models.BedrijfModel", "Bedrijf")
                        .WithMany("onderzoeken")
                        .HasForeignKey("Bedrijfsmail");

                    b.HasOne("tdd.Server.Models.LocatieModel", "Locatie")
                        .WithMany()
                        .HasForeignKey("LocatieID");

                    b.HasOne("tdd.Server.Models.OnderzoeksoortModel", "OnderzoekSoort")
                        .WithMany()
                        .HasForeignKey("OnderzoekSoortTag")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tdd.Server.Models.OpdrachtModel", "Opdracht")
                        .WithMany()
                        .HasForeignKey("OpdrachtData");

                    b.HasOne("tdd.Server.Models.TrackingGegevensModel", "TrackingGegevens")
                        .WithMany()
                        .HasForeignKey("TrackingGegevensUserID", "TrackingGegevensOnderzoekID");

                    b.Navigation("Bedrijf");

                    b.Navigation("Locatie");

                    b.Navigation("OnderzoekSoort");

                    b.Navigation("Opdracht");

                    b.Navigation("TrackingGegevens");
                });

            modelBuilder.Entity("tdd.Server.Models.OnderzoeksoortModel", b =>
                {
                    b.HasOne("tdd.Server.Models.UserModel", null)
                        .WithMany("Onderzoeksoorten")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("tdd.Server.Models.UserModel", b =>
                {
                    b.HasOne("tdd.Server.Models.LocatieModel", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresLocatieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tdd.Server.Models.VerzorgerModel", "Verzorger")
                        .WithMany()
                        .HasForeignKey("VerzorgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adres");

                    b.Navigation("Verzorger");
                });

            modelBuilder.Entity("tdd.Server.Models.VraagModel", b =>
                {
                    b.HasOne("tdd.Server.Models.OnderzoekModel", null)
                        .WithMany("Vragen")
                        .HasForeignKey("OnderzoekModelId");
                });

            modelBuilder.Entity("tdd.Server.Models.BedrijfModel", b =>
                {
                    b.Navigation("contactpersonen");

                    b.Navigation("onderzoeken");
                });

            modelBuilder.Entity("tdd.Server.Models.OnderzoekModel", b =>
                {
                    b.Navigation("Vragen");
                });

            modelBuilder.Entity("tdd.Server.Models.UserModel", b =>
                {
                    b.Navigation("Aandoening");

                    b.Navigation("Beperking");

                    b.Navigation("Beschikbaarheid");

                    b.Navigation("Onderzoeksoorten");
                });

            modelBuilder.Entity("tdd.Server.Models.VraagModel", b =>
                {
                    b.Navigation("Antwoorden");
                });
#pragma warning restore 612, 618
        }
    }
}