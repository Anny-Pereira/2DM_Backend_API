using Microsoft.EntityFrameworkCore;
using Senai_ExemploInLock_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ExemploInLock_WebApi.Contexts
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto
    /// Faz a comunicação entre a API e o Banco de Dados 
    /// </summary>
    public class InLockContext : DbContext
    {
        //Define as enidades do banco de dados
        public DbSet<TiposUsuario> TiposUsuario  { get; set; }
        public DbSet<Estudios> Estudios  { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Jogos> Jogos { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Coloca a string de conexão
            optionsBuilder.UseSqlServer("Server=DESKTOP-TUQ4VJR\\SQLEXPRESS ; Database= Exemplo_InLockGames_CodeFirst; user ID=sa; pwd=senai@132") ;

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define as entidade já com dados.

            //Not NULL
            //modelBuilder.Entity<TiposUsuario>(entity =>
            //{
            //    entity.HasIndex(u => u.titulo).IsUnique();
            //}
            //);


            modelBuilder.Entity<TiposUsuario>().HasData(

                new TiposUsuario
                {
                    //não necessariamente precisa declarar o id
                    idTiposUsuario = 1,
                    tituloTiposUsuario = "Administrador"
                },

                new TiposUsuario
                {
                    idTiposUsuario = 2,
                    tituloTiposUsuario = "Cliente"
                }
                );

            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {
                    idUsuario = 1,
                    email= "administrador@admin.com",
                    senha = "admin",
                    idTiposUsuario = 1
                },

                 new Usuarios
                 {
                     idUsuario = 2,
                     email = "cliente@cliente.com",
                     senha = "cliente",
                     idTiposUsuario = 2
                 }
                );

            modelBuilder.Entity<Estudios>().HasData(
                new Estudios
                {
                    idEstudio = 1,
                    nomeEstudio = "Blizzard"
                },
                new Estudios
                {
                    idEstudio = 2,
                    nomeEstudio = "RockStar Studios"
                },
                new Estudios
                {
                    idEstudio = 3,
                    nomeEstudio = "Square Enix"
                }
                );

            modelBuilder.Entity<Jogos>().HasData(
                new Jogos
                {
                    idJogo = 1,
                    nomeJogo= "Diablo 3",
                    dataLancamento = Convert.ToDateTime("15/05/2021"),
                    descricao = "É um jogo que contém banstante ação...",
                    valor = Convert.ToDecimal("99,00"),
                    idEstudio = 1
                },
                new Jogos
                {
                idJogo = 2,
                    nomeJogo = "Read Dead Redemption II",
                    dataLancamento = Convert.ToDateTime("26/10/2018"),
                    descricao = "É um jogo eletrônico de ação e aventura...",
                    valor = Convert.ToDecimal("120,00"),
                    idEstudio = 2 
                }
                );

            base.OnModelCreating(modelBuilder);

        }
    }
}
