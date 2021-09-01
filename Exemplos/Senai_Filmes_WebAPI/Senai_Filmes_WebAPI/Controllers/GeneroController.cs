using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Filmes_WebAPI.Domains;
using Senai_Filmes_WebAPI.Interfaces;
using Senai_Filmes_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Controlador responsável pelo end points referentes ao genero
/// </summary>

namespace Senai_Filmes_WebAPI.Controllers
{

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]


    //Define que a rota de uma requisição será no formato domínio/api/nomeController
    //Ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class GeneroController : ControllerBase
    {

        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _GeneroRepository { get; set; }


        /// <summary>
        /// Instancia um objeto _GeneroRepository para que haja referencia do métodos no repositório
        /// </summary>
        public GeneroController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        //IActionResult = Resultado de uma ação
        //Get() = nome genérico
        public IActionResult Get()
        {
            //Devolve Lista de generos
            //Se conecta com o repositório


            //Cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _GeneroRepository.ListarTodos();


            //Retorna os status code 200(OK) com a lista generos no formato JSON
            return Ok(listaGeneros);

        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarId(id);

            if(generoBuscado == null)
            {
                return NotFound("Nenhum gênero encontrado");
            }

            return Ok(generoBuscado);
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {


            //Faz a chamada para o método .Cadastrar();
            _GeneroRepository.Cadastrar(novoGenero);


            //Retorna um status code 201 - created
            return StatusCode(201);

        }


        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarId(id);

            if(generoBuscado ==  null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _GeneroRepository.AtualizarIdUrl(id, generoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        [HttpPut]
        public IActionResult PutBody(GeneroDomain generoAtualizado)
        {
            if (generoAtualizado.nomeGenero == null || generoAtualizado.idGenero == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nome do gênero ou id do gênero não foi informado!"
                    }
                );
            }


            GeneroDomain generoBuscadoo = _GeneroRepository.BuscarId(generoAtualizado.idGenero);

            if (generoBuscadoo != null)
            {
                try
                {
                    _GeneroRepository.AtulizarIdCorpo(generoAtualizado);

                    return NoContent();
                }
                catch (Exception ex)
                {

                    return BadRequest(ex);
                }
            }

            return NotFound(
                new
                {
                    mensagemErro = "Nenhum gênero encontrado!",
                    codErro = true
                }); 
        }



        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="id">id do genero que será deletado</param>
        /// <returns>um status code 2014 - No Contentent</returns>
        /// ex: http://localhost:5000/api/generos/10
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _GeneroRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
