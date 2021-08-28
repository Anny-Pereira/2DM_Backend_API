using Senai_Filmes_WebAPI.Domains;
using Senai_Filmes_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        //Trocar o nome de servidor quando mudar de máquina

        /// <summary>
        /// String de conexãocom o banco de dados que recebe os parâmetros
        /// Data Source = Nome do Servidor
        /// initial catalog = nome do bando de dados
        /// integrated security= faz a autenticação com o usuário do windows
        /// </summary>
        private string stringConexao = "Data Source =DESKTOP-TUQ4VJR\\SQLEXPRESS; initial catalog= CATALOGO; user id=sa; pwd=senai@132";

        //

        public void AtualizarIdUrl(int idGenero, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtulizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarId(int idGenero)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="NovoGenero">Objeto novoGenero com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain NovoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO GENERO(nomeGenero) VALUES ('" + NovoGenero.nomeGenero + "')";

                con.Open();


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }



        }

        public void Deletar(int IdGenero)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>listaGenero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara instruçlão a ser executada
                string querySelectALL = "SELECT idGenero, nomeGenero FROM Genero";


                //Abre a conexão com o banco de dados
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    //Executa a query
                    rdr = cmd.ExecuteReader();


                    //Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        //Instancia de um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {

                            //Atribui a propriedade idGenero o valor da primeira coluna na tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade nomeGenero o valor da segunda coluna na tabela do banco de dados
                            nomeGenero = rdr[1].ToString()
                        };


                        //Adiciona o objeto genero criado à lista listaGenero
                        listaGenero.Add(genero);
                    }

                   
                }
            }

            return listaGenero;
        }
    }
}
