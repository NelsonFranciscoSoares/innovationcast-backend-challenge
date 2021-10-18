﻿// <auto-generated />
using System;
using Backend.Challenge.Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Challenge.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DiscussaoDBContext))]
    partial class DiscussaoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Backend.Challenge.Domain.Entities.ComentarioEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTimeOffset>("DataEdicao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataInsercao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataPublicacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EntidadeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.HasKey("Id");

                    b.HasIndex("EntidadeId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Backend.Challenge.Domain.Entities.EntidadeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DataEdicao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataInsercao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UtilizadorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Entidades");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a2167a9-2714-4cb7-8556-212cd9ebba7b"),
                            DataEdicao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DataInsercao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UtilizadorId = new Guid("184a9890-e15d-43eb-989e-87db80eac0bd")
                        },
                        new
                        {
                            Id = new Guid("8d2f019a-03e3-44da-a372-ffa1f8370623"),
                            DataEdicao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DataInsercao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UtilizadorId = new Guid("11a4a979-05b1-45ff-b875-5852abf5da75")
                        });
                });

            modelBuilder.Entity("Backend.Challenge.Domain.Entities.UtilizadorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DataEdicao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataInsercao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Utilizadores");

                    b.HasData(
                        new
                        {
                            Id = new Guid("184a9890-e15d-43eb-989e-87db80eac0bd"),
                            DataEdicao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DataInsercao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "teste01@gmail.com",
                            Username = "Teste01"
                        },
                        new
                        {
                            Id = new Guid("11a4a979-05b1-45ff-b875-5852abf5da75"),
                            DataEdicao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DataInsercao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "teste02@gmail.com",
                            Username = "Teste02"
                        });
                });

            modelBuilder.Entity("Backend.Challenge.Domain.Entities.ComentarioEntity", b =>
                {
                    b.HasOne("Backend.Challenge.Domain.Entities.EntidadeEntity", "Entidade")
                        .WithMany("Comentarios")
                        .HasForeignKey("EntidadeId")
                        .IsRequired();

                    b.Navigation("Entidade");
                });

            modelBuilder.Entity("Backend.Challenge.Domain.Entities.EntidadeEntity", b =>
                {
                    b.HasOne("Backend.Challenge.Domain.Entities.UtilizadorEntity", "Utilizador")
                        .WithMany("Entidades")
                        .HasForeignKey("UtilizadorId")
                        .IsRequired();

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("Backend.Challenge.Domain.Entities.EntidadeEntity", b =>
                {
                    b.Navigation("Comentarios");
                });

            modelBuilder.Entity("Backend.Challenge.Domain.Entities.UtilizadorEntity", b =>
                {
                    b.Navigation("Entidades");
                });
#pragma warning restore 612, 618
        }
    }
}