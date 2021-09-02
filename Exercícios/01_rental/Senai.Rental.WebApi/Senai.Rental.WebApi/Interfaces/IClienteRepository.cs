using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ClienteRepository
    /// </summary>
    interface IClienteRepository
    {

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns>uma lista de clientes</returns>
        List<ClienteDomain> ListarTodos();



        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="NovoCliente">Objeto com os dados que serão cadastrados</param>
        void Cadastrar(ClienteDomain NovoCliente);



        /// <summary>
        ///  Busca um determinado cliente pelo seu id
        /// </summary>
        /// <param name="idCliente">id do cliente que será buscado</param>
        /// <returns>Retorna um objeto ClienteDomain que foi buscado</returns>
        ClienteDomain BuscarId(int idCliente);


        /// <summary>
        /// Deleta um cliente pelo seu id
        /// </summary>
        /// <param name="idCliente">id do cliente que será deletado</param>
        void Deletar(int idCliente);



        /// <summary>
        ///  Faz um update/atualiozação de um cliente através de seu id passado pela Url da requisição
        /// </summary>
        /// <param name="idCliente">id do cliente que será atualizado</param>
        /// <param name="cliente">objeto ClienteDomain com os novos dados</param>
        void AtualizarUrl(int idCliente, ClienteDomain cliente);



    }
}
