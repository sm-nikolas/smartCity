﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartCityApi.Data;

#nullable disable

namespace SmartCityApi.Migrations
{
    [DbContext(typeof(SmartCityContext))]
    partial class SmartCityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmartCityApi.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Populacao")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cidades", (string)null);
                });

            modelBuilder.Entity("SmartCityApi.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ZonaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ZonaId");

                    b.ToTable("Eventos", (string)null);
                });

            modelBuilder.Entity("SmartCityApi.Models.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ZonaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ZonaId");

                    b.ToTable("Sensores", (string)null);
                });

            modelBuilder.Entity("SmartCityApi.Models.Zona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CidadeId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Zonas", (string)null);
                });

            modelBuilder.Entity("SmartCityApi.Models.Evento", b =>
                {
                    b.HasOne("SmartCityApi.Models.Zona", "Zona")
                        .WithMany("Eventos")
                        .HasForeignKey("ZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("SmartCityApi.Models.Sensor", b =>
                {
                    b.HasOne("SmartCityApi.Models.Zona", "Zona")
                        .WithMany("Sensores")
                        .HasForeignKey("ZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("SmartCityApi.Models.Zona", b =>
                {
                    b.HasOne("SmartCityApi.Models.Cidade", "Cidade")
                        .WithMany("Zonas")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("SmartCityApi.Models.Cidade", b =>
                {
                    b.Navigation("Zonas");
                });

            modelBuilder.Entity("SmartCityApi.Models.Zona", b =>
                {
                    b.Navigation("Eventos");

                    b.Navigation("Sensores");
                });
#pragma warning restore 612, 618
        }
    }
}
