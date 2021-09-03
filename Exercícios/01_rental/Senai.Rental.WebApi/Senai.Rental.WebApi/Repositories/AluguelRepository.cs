using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {

        //Casa
        private string stringConexao = "Data Source = DESKTOP-TUQ4VJR\\SQLEXPRESS; initial catalog= M_Rental; user id=sa; pwd=senai@132";



        public void AtualizarUrl(int idAluguel, AluguelDomain NovoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizar = "UPDATE Aluguel SET idVeiculo = @idVeiculo, idCliente = @idCliente, dataAluguel = @dataAluguel, dataDevolucao = @dataDevolucao WHERE idAluguel = @idAluguelAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", NovoAluguel.idVeiculo);

                    cmd.Parameters.AddWithValue("@idCliente", NovoAluguel.idCliente);
                    
                    cmd.Parameters.AddWithValue("@dataAluguel", NovoAluguel.dataAluguel);
                    
                    cmd.Parameters.AddWithValue("@dataDevolucao", NovoAluguel.dataDevolucao);

                    cmd.Parameters.AddWithValue("@idAluguelAtualizado", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public AluguelDomain BuscarId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarId = "SELECT idAluguel, Aluguel.idVeiculo, nomeModelo, nomeCliente, sobrenomeCliente, DataAluguel, DataDevolucao FROM Aluguel INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(queryBuscarId, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"]),

                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),

                            veiculo = new VeiculoDomain()
                            {
                                modelo = new ModeloDomain()
                                {
                                    nomeModelo = reader["nomeModelo"].ToString()
                                }
                            },

                            cliente = new ClienteDomain()
                            {
                                nomeCliente = reader["nomeCliente"].ToString(),
                                sobrenomeCliente = reader["sobrenomeCliente"].ToString()
                            },

                            dataAluguel = Convert.ToDateTime(reader["dataAluguel"]),

                            dataDevolucao = Convert.ToDateTime(reader["dataDevolucao"])
                         

                        };

                        return aluguelBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain NovoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastrar = "INSERT INTO Aluguel (idVeiculo, idCliente, dataAluguel, dataDevolucao) VALUES (@IdVeiculo, @IdCliente, @dataAluguel, @dataDevolucao)";

                using (SqlCommand cmd = new SqlCommand(queryCadastrar, con))
                {

                    cmd.Parameters.AddWithValue("@idVeiculo", NovoAluguel.idVeiculo);

                    cmd.Parameters.AddWithValue("@idCliente", NovoAluguel.idCliente);

                    cmd.Parameters.AddWithValue("@dataAluguel", NovoAluguel.dataAluguel);

                    cmd.Parameters.AddWithValue("@dataDevolucao", NovoAluguel.dataDevolucao);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM Aluguel WHERE idAluguel = @id";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@id", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryListar = "SELECT idAluguel, Aluguel.idVeiculo, nomeModelo, nomeCliente, sobrenomeCliente, DataAluguel, DataDevolucao FROM Aluguel INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(queryListar, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(reader[0]),

                            idVeiculo = Convert.ToInt32(reader[1]),


                            veiculo = new VeiculoDomain()
                            {
                                modelo = new ModeloDomain()
                                {
                                    nomeModelo = reader[2].ToString()
                                }
                            },

                            cliente = new ClienteDomain()
                            {
                                nomeCliente = reader[3].ToString(),
                                sobrenomeCliente = reader[4].ToString()
                            },

                            dataAluguel = Convert.ToDateTime(reader[5]),

                            dataDevolucao = Convert.ToDateTime(reader[6]),

                            

                        };

                        listaAlugueis.Add(aluguel);
                    }
                }

            }

            return listaAlugueis;
        }
    }
}
