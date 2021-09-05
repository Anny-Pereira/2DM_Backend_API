using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade/tabela Genero
    /// </summary>
    public class GeneroDomain
    {
        public int idGenero { get; set; }


        [Required(ErrorMessage = "O nome do gênero é obrigatório!")]
        public string nomeGenero { get; set; }


    }
}
