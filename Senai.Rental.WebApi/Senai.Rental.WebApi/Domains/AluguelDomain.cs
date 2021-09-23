using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomain
    {
        public int IdAluguel  { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ClienteDomain cliente { get; set; }
        public VeiculoDomain veiculo { get; set; }


    }
}
