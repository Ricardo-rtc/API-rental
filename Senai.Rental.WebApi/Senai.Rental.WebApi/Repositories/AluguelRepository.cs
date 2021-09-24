using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = "Data Source=DESKTOP-C8POL51\\SQLEXPRESS; initial catalog=M_Rental; user=sa; pwd=senai@132";
        public void Atualizar(AluguelDomain AluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao)) 
            { 
                string queryUpdate = "UPDATE Aluguel SET IdVeiculo = @novoVeiculo, IdCliente = @novoCliente, DataInicio = @novaDataR, DataFim = @novaDataD WHERE IdAluguel = @idaluguel;";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryUpdate,con))
                {
                    cmd.Parameters.AddWithValue("@novoVeiculo", AluguelAtualizado.IdVeiculo);
                    cmd.Parameters.AddWithValue("@novoCliente", AluguelAtualizado.IdCliente);
                    cmd.Parameters.AddWithValue("@novoDataR", AluguelAtualizado.DataInicio);
                    cmd.Parameters.AddWithValue("@novoDataD", AluguelAtualizado.DataFim);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public AluguelDomain BuscarPorId(int IdProcurar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryselectById = "SELECT IdAluguel, Nome, Sobrenome, NomeModelo, DataInicio, DataFim FROM Aluguel INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo WHERE IdAluguel = @idaluguel;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryselectById, con))
                {
                    cmd.Parameters.AddWithValue("@idaluguel", IdProcurar);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain()
                        {
                            IdAluguel = Convert.ToInt32(rdr[0]),
                            ClienteDomain = new ClienteDomain()
                            {
                                Nome = rdr[1].ToString(),
                                Sobrenome = rdr[2].ToString()
                            },
                            VeiculoDomain = new VeiculoDomain()
                            {
                                ModeloDomain = new ModeloDomain()
                                {
                                    NomeModelo = rdr[3].ToString()
                                }
                                
                            },
                            DataInicio = Convert.ToDateTime(rdr[4]),
                            DataFim = Convert.ToDateTime(rdr[5])
                        };

                        return aluguelBuscado;
                    }
                }

                return null;
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
