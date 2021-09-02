using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório VeiculoRepository
    /// </summary>
    interface IVeiculoRepository
    {
        /// <summary>
        /// Lista todos os veiculos
        /// </summary>
        /// <returns>uma lista de veiculos</returns>
        List<VeiculoDomain> ListarTodos();



        /// <summary>
        /// Cadastra um novo veiculo
        /// </summary>
        /// <param name="NovoVeiculo">Objeto com os dados que serão cadastrados</param>
        void Cadastrar(VeiculoDomain NovoVeiculo);



        /// <summary>
        ///  Busca um determinado veiculo pelo seu id
        /// </summary>
        /// <param name="idVeiculo">id do veiculo que será buscado</param>
        /// <returns>Retorna um objeto VeiculoDomain que foi buscado</returns>
        VeiculoDomain BuscarId(int idVeiculo);



        /// <summary>
        /// Deleta um veiculo pelo seu id
        /// </summary>
        /// <param name="idVeiculo">id do veiculo que será deletado</param>
        void Deletar(int idVeiculo);



        /// <summary>
        ///  Faz um update/atualiozação de um veiculo através de seu id passado pela Url da requisição
        /// </summary>
        /// <param name="idVeiculo">id do veiculo que será atualizado</param>
        /// <param name="veiculo">objeto VeiculoDomain com os novos dados</param>
        void AtualizarUrl(int idVeiculo, VeiculoDomain veiculo);

    }
}
