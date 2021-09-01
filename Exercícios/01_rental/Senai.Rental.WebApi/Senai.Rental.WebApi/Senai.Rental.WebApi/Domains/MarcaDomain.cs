using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class MarcaDomain
    {
        public int idMarca { get; set; }

        public int idModelo { get; set; }

        public string nomeMarca { get; set; }

        public ModeloDomain modelo { get; set; }

    }
}
