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
        private string stringConexao = "Data Source =DESKTOP-TUQ4VJR\\SQLEXPRESS; initial catalog= CATALOGO; user id=sa; pwd=senai@132";

        public void AtualizarUrl(int idCliente, ClienteDomain cliente)
        {
            throw new NotImplementedException();
        }

        public ClienteDomain BuscarId(int idCliente)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ClienteDomain NovoCliente)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idCliente)
        {
            throw new NotImplementedException();
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
