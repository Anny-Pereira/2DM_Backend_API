using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ModeloDomain
    {
        public int idModelo { get; set; }

        public int idVeiculo { get; set; }

        public string nomeModelo { get; set; }

        public int anoModelo { get; set; }

        public VeiculoDomain veiculo { get; set; }
    }
}
