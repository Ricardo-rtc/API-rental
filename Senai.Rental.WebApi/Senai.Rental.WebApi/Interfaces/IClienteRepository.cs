using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IClienteRepository
    {
        List<ClienteDomain> ListarTodos();

        ClienteDomain BuscarPorId(int IdProcurar);

        void Cadastrar(ClienteDomain NovoCliente);

        void Atualizar(ClienteDomain ClienteAtualizado);

        void Deletar(int IdDeletar);

    }
}
