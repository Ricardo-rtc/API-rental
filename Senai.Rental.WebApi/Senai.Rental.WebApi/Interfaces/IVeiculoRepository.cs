using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculoRepository
    {
        List<VeiculoDomain> ListarTodos();

        VeiculoDomain BuscarPorId(int IdProcurar);

        void Cadastrar(VeiculoDomain NovoVeiculo);

        void Atualizar(VeiculoDomain VeiculoAtualizado);

        void Deletar(int IdDeletar);


    }
}
