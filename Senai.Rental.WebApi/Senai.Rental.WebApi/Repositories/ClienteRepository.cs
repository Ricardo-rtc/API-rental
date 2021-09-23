using System;
using Senai.Rental.WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void Atualizar(ClienteDomain ClienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public ClienteDomain BuscarPorId(int IdProcurar)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ClienteDomain NovoCliente)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdDeletar)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
