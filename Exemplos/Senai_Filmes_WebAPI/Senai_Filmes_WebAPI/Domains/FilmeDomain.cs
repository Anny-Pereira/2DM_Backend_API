using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI.Domains
{
    /// <summary>
    ///  Classe que representa a entidade/tabela Filme
    /// </summary>
    public class FilmeDomain
    {

        public int idFilme { get; set; }

        public int idGenero { get; set; }

        [Required(ErrorMessage = "O título do filme é obrigatório!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O título do filme deve conter de 2 a 50 caracteres.")]
        //[RegularExpression("", ErrorMessage= "Não é permitido número no título")]
        public string tituloFilme { get; set; }



        public  GeneroDomain genero { get; set; }
    }
}
