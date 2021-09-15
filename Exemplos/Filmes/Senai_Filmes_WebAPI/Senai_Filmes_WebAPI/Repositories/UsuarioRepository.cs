using Senai_Filmes_WebAPI.Domains;
using Senai_Filmes_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI.Repositories
{

  
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source =DESKTOP-TUQ4VJR\\SQLEXPRESS; initial catalog= CATALOGO; user id=sa; pwd=senai@132";

        public UsuarioDomain BuscarEmailSenha(string email, string senha)
        {
            //Define a conexão con passando a string de conexão
           using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT * FROM Usuario
                                       WHERE email = @email AND senha = @senha";


                //Define o comando cmd passando a query e a conexão
                using(SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.Parameters.AddWithValue("@senha", senha);


                    //Abre a conexão com o bando de dados
                    con.Open();


                    //Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();


                    //Caso os dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        //Cria um objeto do tipo UsuarioDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            //Atribui às propriedades os valores das colunas do banco de dados
                            
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),

                            email = rdr["email"].ToString(),

                            senha = rdr["senha"].ToString(),

                            permissao = rdr["permissao"].ToString()

                        };


                        //Retorna o usuário buscado
                        return usuarioBuscado;
                    }

                    //Caso não encontre um email e senha correspondente, retorna null
                    return null;
                }
            }

        }
    }
}
