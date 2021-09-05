using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ClienteDomain
    {
        public int idCliente { get; set; }


        [Required(ErrorMessage = "O nome do cliente é obrigatório!")]
        public string nomeCliente { get; set; }


        [Required(ErrorMessage = "O sobrenome do cliente é obrigatório!")]
        public string sobrenomeCliente { get; set; }


        [Required(ErrorMessage = "Informa a data de nascimento do cliente.")]
        [DataType(DataType.Date)]

        public DateTime dataNascimento { get; set; }

    }///DataType = tipo de data
    /// Date = só irá mostrar a data sem a hora
}
