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
            optionsBuilder.UseSqlServer("Server= ; Database= Exemplo_InLockGames_CodeFirst; user ID=sa; pwd=senai@132") ;

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
