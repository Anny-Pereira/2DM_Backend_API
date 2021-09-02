using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório AluguelRepository
    /// </summary>
    interface IAluguelRepository
    {
        /// <summary>
        /// Lista todos os alugueis
        /// </summary>
        /// <returns>uma lista de aluguéis</returns>
        List<AluguelDomain> ListarTodos();



        /// <summary>
        /// Cadastra um novo aluguel
        /// </summary>
        /// <param name="NovoAluguel">Objeto com os dados que serão cadastrados</param>
        void Cadastrar(AluguelDomain NovoAluguel);



        /// <summary>
        ///  Busca um determinado aluguel pelo seu id
        /// </summary>
        /// <param name="idAluguel">id do aluguel que será buscado</param>
        /// <returns>Retorna um objeto AluguelDomain que foi buscado</returns>
        AluguelDomain BuscarId(int idAluguel);



        /// <summary>
        /// Deleta um aluguel pelo seu id
        /// </summary>
        /// <param name="idAluguel">id do aluguel que será deletado</param>
        void Deletar(int idAluguel);



        /// <summary>
        ///  Faz um update/atualiozação de um aluguel através de seu id passado pela Url da requisição
        /// </summary>
        /// <param name="idAluguel">id do aluguel que será atualizado</param>
        /// <param name="aluguel">objeto AluguelDomain com os novos dados</param>
        void AtualizarUrl(int idAluguel, AluguelDomain aluguel);

    }
}
