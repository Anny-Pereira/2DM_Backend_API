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


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain filmeBusacdo = _FilmeRepository.BuscarId(id);

            if (filmeBusacdo == null)
            {
                return NotFound("Nenhum filme encontrado!");
            }

            return Ok(filmeBusacdo);
        }


        [HttpPut("{id}")]
        public IActionResult PutBody(int id, FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _FilmeRepository.BuscarId(id);

            if (filmeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Filme não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _FilmeRepository.AtualizarIdUrl(id, filmeAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _FilmeRepository.Deletar(id);

            return NoContent();
        }
    }
}
