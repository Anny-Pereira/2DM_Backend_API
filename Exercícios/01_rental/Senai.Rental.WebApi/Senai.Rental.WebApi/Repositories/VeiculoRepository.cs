using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {

        //Casa
        private string stringConexao = "Data Source = DESKTOP-TUQ4VJR\\SQLEXPRESS; initial catalog= M_Rental; user id=sa; pwd=senai@132";

        public void AtualizarUrl(int idVeiculo, VeiculoDomain NovoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizar = "UPDATE Veiculo SET idModelo = @idModelo, placa = @placa WHERE idVeiculo = @idVeiculoAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", NovoVeiculo.idModelo );

                    cmd.Parameters.AddWithValue("@placa", NovoVeiculo.placa );

                    cmd.Parameters.AddWithValue("@idVeiculoAtualizado", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public VeiculoDomain BuscarId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarId = "SELECT idVeiculo, idEmpresa , placa, nomeModelo FROM Veiculo LEFT JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo   WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(queryBuscarId, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),

                            idEmpresa = Convert.ToInt32(reader["idEmpresa"]),

                            placa = reader["placa"].ToString(),

                            modelo = new ModeloDomain()
                            {
                                nomeModelo = reader["nomeModelo"].ToString()
                            }
                        };

                        return veiculoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain NovoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastrar = "INSERT INTO Veiculo (IdEmpresa, IdModelo, placa) VALUES (@idEmpresa, @idModelo, @placa)";

                using (SqlCommand cmd = new SqlCommand(queryCadastrar, con))
                {

                    cmd.Parameters.AddWithValue("@idEmpresa", NovoVeiculo.idEmpresa);

                    cmd.Parameters.AddWithValue("@idModelo", NovoVeiculo.idModelo);

                    cmd.Parameters.AddWithValue("@placa", NovoVeiculo.placa);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM Veiculo WHERE idVeiculo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@id", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryListar = "SELECT idVeiculo, placa, veiculo.idModelo, nomeModelo FROM Veiculo LEFT JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo";

                con.Open();

                SqlDataReader reader;

                using(SqlCommand cmd = new SqlCommand(queryListar, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(reader[0]),

                            placa = reader[1].ToString(),

                            idModelo = Convert.ToInt32(reader[2]),

                            modelo = new ModeloDomain()
                            {

                                nomeModelo = reader["nomeModelo"].ToString()
                            }
                           
                        };

                        listaVeiculos.Add(veiculo);
                    }
                }

            }

            return listaVeiculos;
        }
    }
}
