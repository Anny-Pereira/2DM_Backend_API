using Senai_Filmes_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository 
    /// </summary>
    interface IFilmeRepository
    {

        /// <summary>
        /// Retorna todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        List<FilmeDomain> ListarTodos();


        /// <summary>
        /// Busca um filme por id
        /// </summary>
        /// <param name="idFilme">id do filme que será buscado</param>
        /// <returns>Objeto FilmeDomain que foi buscado</returns>
        FilmeDomain BuscarId(int idFilme);


        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="NovoFilme">Objeto NovoFilme com os dados que serão cadastrados</param>
        void Cadastrar(FilmeDomain NovoFilme);


        /// <summary>
        /// Atualiza um filme existente passando seu id pela url da requisição
        /// </summary>
        /// <param name="idFilme">id do filme que será atualizado</param>
        /// <param name="filme">Objeto filme com os novos dados</param>
        void AtualizarIdUrl(int idFilme, FilmeDomain filme);



        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="idFilme">id do filme que será deletado</param>
        void Deletar(int idFilme);
    }
}
