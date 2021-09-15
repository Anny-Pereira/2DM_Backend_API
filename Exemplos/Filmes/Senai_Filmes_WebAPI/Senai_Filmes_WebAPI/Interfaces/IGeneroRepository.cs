using Senai_Filmes_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        ///Estruturas de métodos da Interface
        ////TipoRetorno NomeMetodo (TipoParamentro NomeParametro);
        ///void Listar();


        /// <summary>
        /// Retorna todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero pelo seu id
        /// </summary>
        /// <param name="idGenero">id do genero que será buscado</param>
        /// <returns>Objeto do tipo GeneroDomain que foi buscado</returns>
        GeneroDomain BuscarId(int idGenero);


        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="NovoGenero">Objeto NovoGenero com os dados que serão cadastrados</param>
        void Cadastrar(GeneroDomain NovoGenero);


        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com os novos dados </param>
        void AtulizarIdCorpo(GeneroDomain genero);


        /// <summary>
        /// Atualiza um genero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idGenero">id do genero que será atualizado</param>
        /// <param name="genero">Objeto genero com os novos dados</param>
        void AtualizarIdUrl(int idGenero, GeneroDomain genero);


        /// <summary>
        /// Deleta um genero
        /// </summary>
        /// <param name="IdGenero">id do genero que será deletado</param>
        void Deletar(int IdGenero);
    }
}
