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

    }
}
