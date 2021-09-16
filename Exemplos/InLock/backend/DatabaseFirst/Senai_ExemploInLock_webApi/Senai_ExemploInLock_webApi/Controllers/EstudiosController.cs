using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_ExemploInLock_webApi.Domains;
using Senai_ExemploInLock_webApi.Interfaces;
using Senai_ExemploInLock_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ExemploInLock_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _estudioRepository para referenciar as implementações feitas no repositório Estudiorepository
        /// </summary>
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }


        //ListarTodos
        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>uma lista de estudios com status code 200</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_estudioRepository.Listar());
        }


        //BuscarId
        /// <summary>
        /// Busca um estúdio através do seu id
        /// </summary>
        /// <param name="idestudio">id do estúdio que será buscado</param>
        /// <returns>um estúdio encontrado com status code 200</returns>
        [HttpGet("{idEstudio}")]
        public IActionResult BuscarId(int idEstudio)
        {
            return Ok(_estudioRepository.BuscarId(idEstudio));
        }


        //Cadastrar
        /// <summary>
        /// Cadastra um estudio
        /// </summary>
        /// <param name="novoEstudio">objeto novoEstudio com as novas informações</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Estudio novoEstudio)
        {
            //Chama o método Cadastrar enviando as informações de cadastro
            _estudioRepository.Cadastrar(novoEstudio);

            //retorna um status code
            return StatusCode(201);
        }



        //Atualizar
        /// <summary>
        /// atualiza um estudio existente
        /// </summary>
        /// <param name="idEstudio">id do estudio que será atualizado</param>
        /// <param name="estudioAtualizado">objeto com as novas informações</param>
        /// <returns></returns>
        [HttpPut("{idEstudio}")]
        public IActionResult Atualizar(int idEstudio, Estudio estudioAtualizado)
        {
            //Chama o método .Atualizar() enviando as novas informações
            _estudioRepository.Atualizar(idEstudio, estudioAtualizado);


            //Retorna um status code
            return StatusCode(204);
        }


        //Deletar
        /// <summary>
        /// Deleta um estudio existente
        /// </summary>
        /// <param name="idEstudio">id do estudio que será deletado</param>
        /// <returns>retorna um status code 204 - No Contente</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            //Chama o método .Deletar enviando o id do estudio como parametro
            _estudioRepository.Deletar(id);


            //Retorna um status code
            return StatusCode(204);
        }

        //ListarJogos
        [HttpGet("jogos")]
        public IActionResult ListarJogos()
        {
            return Ok(_estudioRepository.ListarJogos());
        }
    }
}
