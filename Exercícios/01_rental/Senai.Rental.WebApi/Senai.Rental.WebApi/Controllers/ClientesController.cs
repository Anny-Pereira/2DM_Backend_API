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
    /// Controller responsável pelos end points de clientes
    /// </summary>

    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }



        ///ListarTodos()
        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaClientes = _ClienteRepository.ListarTodos();

            return Ok(listaClientes);
        }

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarId(id);

            if (clienteBuscado == null)
            {
                return NotFound("Nenhum cliente foi encontrado para ser deletado!");
            }

            _ClienteRepository.Deletar(id);

            return StatusCode(204);
        }


        //Cadastrar
        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _ClienteRepository.Cadastrar(novoCliente);


            ///201 - created
            return StatusCode(201);
        }


        //BuscarId
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarId(id);

            if (clienteBuscado == null)
            {
                return NotFound("Nenhum cliente foi encontrado!");
            }

            return Ok(clienteBuscado);

        }

        //AtualizarUrl
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClienteDomain ClienteAtualizado)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarId(id);

            if (clienteBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "O cliente não foi encontrado!",
                        erro= true
                    });
            }

            try
            {
                _ClienteRepository.AtualizarUrl(id, ClienteAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


    }
}
