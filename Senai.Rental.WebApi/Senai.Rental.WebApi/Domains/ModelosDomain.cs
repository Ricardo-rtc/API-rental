using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ModelosDomain
    {
        public int IdModelo { get; set; }
        public string Descricao { get; set; }
        public int IdMarca { get; set; }
        public MarcasDomain marca { get; set; }
    }
}
