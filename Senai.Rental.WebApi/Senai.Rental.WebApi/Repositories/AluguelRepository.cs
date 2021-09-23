using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        public void Atualizar(AluguelDomain AluguelAtualizado)
        {
            throw new NotImplementedException();
        }

        public AluguelDomain BuscarPorId(int IdProcurar)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(AluguelDomain NovoAluguel)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdDeletar)
        {
            throw new NotImplementedException();
        }

        public List<AluguelDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
