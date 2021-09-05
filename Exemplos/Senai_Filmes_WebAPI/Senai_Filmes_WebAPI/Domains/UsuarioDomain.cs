using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI.Domains
{

    /// <summary>
    /// Classe que representa a entidade usuário
    /// </summary>
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }



        //Define que o campo é obrigatório
        [Required(ErrorMessage ="Informe o e-mail")]
        public string email { get; set; }



        [Required(ErrorMessage = "Informe o e-mail")]
        [StringLength(10, MinimumLength =3, ErrorMessage ="O campo senha precisa conter entre 3 a 10 caracteres.")]
        public string senha { get; set; }
        public string permissao { get; set; }

    }
}
