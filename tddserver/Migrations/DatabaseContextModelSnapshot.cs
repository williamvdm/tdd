﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tdd.Server.Context;

#nullable disable

namespace tdd.Server.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("AandoeningModel");
                });

            modelBuilder.Entity("tdd.Server.Models.BeperkingModel", b =>
                {
                    b.Property<int>("BeperkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BeperkingId"));

                    b.Property<string>("BeprkingNaam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserModelId")
                        .HasColumnType("uuid");

                    b.HasKey("BeperkingId");

                    b.HasIndex("UserModelId");

                    b.ToTable("BeperkingModel");
                });

            modelBuilder.Entity("tdd.Server.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.Property<char>("Telefoon")
                        .HasMaxLength(10)
                        .HasColumnType("character(10)");

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

                    b.HasIndex("VerzorgerId");

                    b.ToTable("Users");
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

                    b.ToTable("VerzorgerModel");
                });

            modelBuilder.Entity("tdd.Server.Models.AandoeningModel", b =>
                {
                    b.HasOne("tdd.Server.Models.UserModel", null)
                        .WithMany("Aandoening")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("tdd.Server.Models.BeperkingModel", b =>
                {
                    b.HasOne("tdd.Server.Models.UserModel", null)
                        .WithMany("Beperking")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("tdd.Server.Models.UserModel", b =>
                {
                    b.HasOne("tdd.Server.Models.VerzorgerModel", "Verzorger")
                        .WithMany()
                        .HasForeignKey("VerzorgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Verzorger");
                });

            modelBuilder.Entity("tdd.Server.Models.UserModel", b =>
                {
                    b.Navigation("Aandoening");

                    b.Navigation("Beperking");
                });
#pragma warning restore 612, 618
        }
    }
}
