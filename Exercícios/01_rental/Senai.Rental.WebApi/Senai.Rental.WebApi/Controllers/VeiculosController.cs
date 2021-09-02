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
    /// Controller responsável pelos end points de veiculos
    /// </summary>

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {

        private IVeiculoRepository _Veiculorepository { get; set; }

        public VeiculosController()
        {
            _Veiculorepository = new VeiculoRepository();
        }

        //ListarTodos
        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculos = _Veiculorepository.ListarTodos();

            return Ok(listaVeiculos);
        }

        //Cadastrar
        [HttpPost]
        public IActionResult Post(VeiculoDomain NovoVeiculo)
        {
            _Veiculorepository.Cadastrar(NovoVeiculo);

            //201- created
            return StatusCode(201);
        }

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            VeiculoDomain veiculoBuscado = _Veiculorepository.BuscarId(id);

            if (veiculoBuscado == null)
            {
                return NotFound("Nenhum veículo foi encontrado para ser deletado!");
            }

            _Veiculorepository.Deletar(id);

            return StatusCode(204);
        }

        //BuscarId
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            VeiculoDomain veiculoBuscado = _Veiculorepository.BuscarId(id);

            if (veiculoBuscado == null)
            {
                return NotFound("Nenhum veículo foi encontrado!");
            }

            return Ok(veiculoBuscado);
        }


        //AtualizarUrl
        [HttpPut("{id}")]
        public IActionResult Put(int id, VeiculoDomain veiculoAtualizado)
        {
            VeiculoDomain veiculoBuscado = _Veiculorepository.BuscarId(id);

            if (veiculoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "O veículo não foi encontrado!",
                        erro = true
                    });
            }

            try
            {
                _Veiculorepository.AtualizarUrl(id, veiculoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
