using Senai_Filmes_WebAPI.Domains;
using Senai_Filmes_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source =DESKTOP-TUQ4VJR\\SQLEXPRESS; initial catalog= CATALOGO; user id=sa; pwd=senai@132";

        public void AtualizarIdUrl(int idFilme, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarId(int idFilme)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain NovoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //string queryInsert = "INSERT INTO Filme(tituloFilme) VALUES ('" + NovoFilme.tituloFilme +"')";

                string queryInsert = "INSERT INTO Filme(tituloFilme) VALUES (@tituloFilme);

                

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@tituloFilme", NovoFilme.tituloFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int idFilme)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idFilme, tituloFilme, ISNULL (Genero.NomeGenero, 'Sem gênero') nomeGenero FROM Filme LEFT JOIN Genero ON FILME.idGenero = GENERO.idGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),

                            tituloFilme = rdr[1].ToString(),

                            genero = new GeneroDomain()

                            {
                                nomeGenero = rdr[2].ToString()
                            }

                        };

                        listaFilme.Add(filme);
                    }
                }
            }


            return listaFilme;

        }
    }

   
}