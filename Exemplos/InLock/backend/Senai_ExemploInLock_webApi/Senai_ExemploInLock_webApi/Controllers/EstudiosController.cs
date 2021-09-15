using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
