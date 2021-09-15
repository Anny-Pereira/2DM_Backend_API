using Senai_ExemploInLock_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ExemploInLock_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns></returns>
        List<Estudio> Listar();


        /// <summary>
        /// Busca um estúdio através do seu id
        /// </summary>
        /// <param name="id">id do estudio que será buscado</param>
        /// <returns>Retorna um objeto estudio encontrado</returns>
        Estudio BuscarId(int id);


        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio com as informações</param>
        void Cadastrar(Estudio novoEstudio);


        /// <summary>
        /// Atualiza os dados de um estúdio existente
        /// </summary>
        /// <param name="idEstudio">id do estudio que será atualizado</param>
        /// <param name="estudioAtualizado">objeto estudioAtualizado com as novas informações </param>
        void Atualizar(int idEstudio, Estudio estudioAtualizado);


        /// <summary>
        /// Deleta um estudio existente pelo seu id
        /// </summary>
        /// <param name="idEstudio">id do estudio que será deletado</param>
        void Deletar(int idEstudio);



        /// <summary>
        /// Lista todos os estúdios com a lista de jogos
        /// </summary>
        /// <returns>Uma lista de estúdios com seus respectivos jogos</returns>
        List<Estudio> ListarJogos();
    }
}
