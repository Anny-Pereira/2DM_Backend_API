using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos end points de alugueis
    /// </summary>

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }


        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        //ListarTodos
        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAlugueis = _AluguelRepository.ListarTodos();

            return Ok(listaAlugueis);
        }


        //Cadastrar
        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _AluguelRepository.Cadastrar(novoAluguel);

            //201 - created
            return StatusCode(201);
        }


        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarId(id);

            if (aluguelBuscado == null)
            {
                return NotFound("Nenhum registro de aluguel foi encontrado para ser deletado!");
            }

            _AluguelRepository.Deletar(id);

            return StatusCode(204);
        }


        //AtualizarUrl
        [HttpPut("{id}")]
        public IActionResult Put(int id, AluguelDomain aluguelAtualizado)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarId(id);

            if (aluguelBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "O registro de aluguel não foi encontrado!",
                        erro = true
                    });
            }

            try
            {
                _AluguelRepository.AtualizarUrl(id, aluguelAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        //BuscarId
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarId(id);

            if (aluguelBuscado == null)
            {
                return NotFound("Nenhum registro de aluguel foi encontrado!");
            }

            return Ok(aluguelBuscado);
        }


    }
}
