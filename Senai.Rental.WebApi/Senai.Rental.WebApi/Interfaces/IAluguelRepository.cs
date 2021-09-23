using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        List<AluguelDomain> ListarTodos();

        AluguelDomain BuscarPorId(int IdProcurar);

        void Cadastrar(AluguelDomain NovoAluguel);

        void Atualizar(AluguelDomain AluguelAtualizado);

        void Deletar(int IdDeletar);
    }
}
