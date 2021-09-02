using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        //Casa
        private string stringConexao = "Data Source = DESKTOP-TUQ4VJR\\SQLEXPRESS; initial catalog= M_Rental; user id=sa; pwd=senai@132";

        public void AtualizarUrl(int idCliente, ClienteDomain cliente)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizar = "UPDATE Cliente SET nomeCliente = @novoNomeCliente, sobrenomeCliente = @novoSobrenomeCliente WHERE idCliente = @idClienteAtualizado";

                using(SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeCliente", cliente.nomeCliente);

                    cmd.Parameters.AddWithValue("@novoSobrenomeCliente", cliente.sobrenomeCliente);

                    cmd.Parameters.AddWithValue("@idClienteAtualizado", idCliente );

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
                    
            }
        }

        public ClienteDomain BuscarId(int idCliente)
        {
           using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarId = "SELECT * FROM Cliente WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader reader;

                using(SqlCommand cmd = new SqlCommand(queryBuscarId, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),

                            nomeCliente = reader["nomeCliente"].ToString(),

                            sobrenomeCliente = reader["sobrenomeCliente"].ToString()
                        };

                        return clienteBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain NovoCliente)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastrar = "INSERT INTO Cliente (nomeCliente, sobrenomeCliente) VALUES (@nomeCliente, @sobrenomeCliente)";

                using(SqlCommand cmd = new SqlCommand(queryCadastrar, con))
                {

                    cmd.Parameters.AddWithValue("@nomeCliente", NovoCliente.nomeCliente);

                    cmd.Parameters.AddWithValue("@sobrenomeCliente", NovoCliente.sobrenomeCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM Cliente WHERE idCliente = @id";

                using(SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
                
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();
            
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryListar = "SELECT idCliente, nomeCliente, SobrenomeCliente FROM Cliente";

                con.Open();

                SqlDataReader reader;


                using (SqlCommand cmd= new SqlCommand(queryListar, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(reader[0]),

                            nomeCliente = reader[1].ToString(),

                            sobrenomeCliente = reader[2].ToString()
                        };


                        listaClientes.Add(cliente);
                    }

                }
                
            }

            return listaClientes;
        }
    }
}
