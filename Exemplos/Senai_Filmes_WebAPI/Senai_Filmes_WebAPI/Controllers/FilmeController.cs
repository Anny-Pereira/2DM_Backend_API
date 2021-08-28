using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Filmes_WebAPI.Domains;
using Senai_Filmes_WebAPI.Interfaces;
using Senai_Filmes_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI.Controllers
{
    [Produces ("application/json")]


    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _FilmeRepository { get; set; }


        public FilmeController()
        {
            _FilmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FilmeDomain> listaFilme = _FilmeRepository.ListarTodos();

            return Ok(listaFilme);
   
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain NovoFilme)
        {
            _FilmeRepository.Cadastrar(NovoFilme);

            return StatusCode(201);

        }
    }
}
