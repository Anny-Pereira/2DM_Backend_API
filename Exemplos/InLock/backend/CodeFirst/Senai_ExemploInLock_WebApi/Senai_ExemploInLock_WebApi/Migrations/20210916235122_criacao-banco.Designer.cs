﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senai_ExemploInLock_WebApi.Contexts;

namespace Senai_ExemploInLock_WebApi.Migrations
{
    [DbContext(typeof(InLockContext))]
    [Migration("20210916235122_criacao-banco")]
    partial class criacaobanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senai_ExemploInLock_WebApi.Domains.Estudios", b =>
                {
                    b.Property<int>("idEstudio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nomeEstudio")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("idEstudio");

                    b.ToTable("Estudios");

                    b.HasData(
                        new
                        {
                            idEstudio = 1,
                            nomeEstudio = "Blizzard"
                        },
                        new
                        {
                            idEstudio = 2,
                            nomeEstudio = "RockStar Studios"
                        },
                        new
                        {
                            idEstudio = 3,
                            nomeEstudio = "Square Enix"
                        });
                });

            modelBuilder.Entity("Senai_ExemploInLock_WebApi.Domains.Jogos", b =>
                {
                    b.Property<int>("idJogo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dataLancamento")
                        .HasColumnType("DATE");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("idEstudio")
                        .HasColumnType("int");

                    b.Property<string>("nomeJogo")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("valor")
                        .HasColumnType("DECIMAL (10,2)");

                    b.HasKey("idJogo");

                    b.HasIndex("idEstudio");

                    b.ToTable("Jogos");

                    b.HasData(
                        new
                        {
                            idJogo = 1,
                            dataLancamento = new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            descricao = "É um jogo que contém banstante ação...",
                            idEstudio = 1,
                            nomeJogo = "Diablo 3",
                            valor = 99.00m
                        },
                        new
                        {
                            idJogo = 2,
                            dataLancamento = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            descricao = "É um jogo eletrônico de ação e aventura...",
                            idEstudio = 2,
                            nomeJogo = "Read Dead Redemption II",
                            valor = 120.00m
                        });
                });

            modelBuilder.Entity("Senai_ExemploInLock_WebApi.Domains.TiposUsuario", b =>
                {
                    b.Property<int>("idTiposUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("tituloTiposUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("idTiposUsuario");

                    b.ToTable("TiposUsuario");

                    b.HasData(
                        new
                        {
                            idTiposUsuario = 1,
                            tituloTiposUsuario = "Administrador"
                        },
                        new
                        {
                            idTiposUsuario = 4,
                            tituloTiposUsuario = "Cliente"
                        });
                });

            modelBuilder.Entity("Senai_ExemploInLock_WebApi.Domains.Usuarios", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("idTiposUsuario")
                        .HasColumnType("int");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("idUsuario");

                    b.HasIndex("idTiposUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            idUsuario = 1,
                            email = "administrador@admin.com",
                            idTiposUsuario = 2,
                            senha = "admin"
                        },
                        new
                        {
                            idUsuario = 2,
                            email = "cliente@cliente.com",
                            idTiposUsuario = 4,
                            senha = "cliente"
                        });
                });

            modelBuilder.Entity("Senai_ExemploInLock_WebApi.Domains.Jogos", b =>
                {
                    b.HasOne("Senai_ExemploInLock_WebApi.Domains.Estudios", "estudio")
                        .WithMany("jogos")
                        .HasForeignKey("idEstudio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estudio");
                });

            modelBuilder.Entity("Senai_ExemploInLock_WebApi.Domains.Usuarios", b =>
                {
                    b.HasOne("Senai_ExemploInLock_WebApi.Domains.TiposUsuario", "tiposUsuario")
                        .WithMany()
                        .HasForeignKey("idTiposUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tiposUsuario");
                });

            modelBuilder.Entity("Senai_ExemploInLock_WebApi.Domains.Estudios", b =>
                {
                    b.Navigation("jogos");
                });
#pragma warning restore 612, 618
        }
    }
}
