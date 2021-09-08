using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Filmes_WebAPI.Domains;
using Senai_Filmes_WebAPI.Interfaces;
using Senai_Filmes_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarEmailSenha(login.email, login.senha);

            if (usuarioBuscado != null)
            {
                //return Ok(usuarioBuscado);

                //Define os dados que serão fornecidos no token - payload

                var claims = new[]
                {

                    ///Baixar Pacote e ctrl + .
                    new Claim(JwtRegistoredClaimNames.Email, usuarioBuscado.email),  //"email" : "saulo@email.com"

                    new Claim(JwtRegistoredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),

                    new Claim(ClaimTypes.Role, usuarioBuscado.permissao),

                    new Claim("Claim Personalizada", "Valor teste")
                };

                //Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

                //Define as credencias do token - signature
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                var meuToken = new JwtSecurityToken(
                        issuer: "Filmes.WebApi",                 //Define o emissor do token

                        audience: "Filmes.WebApi",              //Define o destinatário do token                    );

                        claims: minhasClaims,                    //Dados definidos acima

                        expires: DateTime.Now.AddMinutes(30)     //Define o tempo de expiração

                        signingCredentials: creds                //Define creedencias do token

                        );

                return Ok(new
                {
                    token = new JwrSecurityTokenHandler().WriteToken(meuToken)
                });
            }

            return NotFound("Email ou senha inválidos!");
        }

    }
}
