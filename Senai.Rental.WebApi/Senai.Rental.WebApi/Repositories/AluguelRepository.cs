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
        private string stringConexao = "Data Source=NOTE0113E3\\SQLEXPRESS; initial catalog=M_Rental; user=sa; pwd=Senai@132";
        public void Atualizar(AluguelDomain AluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao)) 
            { 
                string queryUpdate = "UPDATE Alugueis SET IdVeiculo = @novoVeiculo, IdCliente = @novoCliente, DataInicio = @novaDataR, DataFim = @novaDataD WHERE IdAluguel = @idaluguel;";

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
                string queryselectById = "SELECT IdAluguel, Nome, Sobrenome, Descricao, DataInicio, DataFim FROM Alugueis INNER JOIN Clientes ON Alugueis.IdCliente = Clientes.IdCliente INNER JOIN Veiculos ON Alugueis.IdVeiculo = Veiculos.IdVeiculo INNER JOIN Modelos ON Veiculos.IdModelo = Modelos.IdModelo WHERE IdAluguel = @idaluguel";

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
                            Cliente = new ClienteDomain()
                            {
                                Nome = rdr[1].ToString(),
                                Sobrenome = rdr[2].ToString()
                            },
                            Veiculo = new VeiculoDomain()
                            {
                                Modelo = new ModeloDomain()
                                {
                                    Descricao = rdr[3].ToString()
                                }

                            },
                            DataInicio = Convert.ToDateTime(rdr[4]),
                            DataFim = Convert.ToDateTime(rdr[5])
                        };

                        return aluguelBuscado;
                    }
                };

                return null;
            }
        }

        public void Cadastrar(AluguelDomain NovoAluguel)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Aluguel(IdVeiculo,IdCliente,DataInicio,DataFim) VALUES (@novoVeiculo, @novoCliente, @novaDataR, @novaDataD);";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novoVeiculo", NovoAluguel.IdVeiculo);
                    cmd.Parameters.AddWithValue("@novoCliente", NovoAluguel.IdCliente);
                    cmd.Parameters.AddWithValue("@novaDataR", NovoAluguel.DataInicio);
                    cmd.Parameters.AddWithValue("@novaDataD", NovoAluguel.DataFim);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdDeletar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Aluguel WHERE IdAluguel = @idaluguel;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idaluguel", IdDeletar);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> ListaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdAluguel, Nome, Sobrenome, Descricao,Placa, DataInicio, DataFim FROM Alugueis INNER JOIN Clientes ON Alugueis.IdCliente = Clientes.IdCliente INNER JOIN Veiculos ON Alugueis.IdVeiculo = Veiculos.IdVeiculo INNER JOIN Modelos ON Veiculos.IdModelo = Modelos.IdModelo;";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            IdAluguel = Convert.ToInt32(rdr[0]),
                            Cliente = new ClienteDomain()
                            {
                                Nome = rdr[1].ToString(),
                                Sobrenome = rdr[2].ToString()
                            },
                            Veiculo = new VeiculoDomain()
                            {
                                Modelo = new ModeloDomain()
                                {
                                    Descricao = rdr[3].ToString()
                                },
                                Placa = rdr[4].ToString()
                            },
                            DataInicio = Convert.ToDateTime(rdr[5]),
                            DataFim = Convert.ToDateTime(rdr[6])
                        };
                        ListaAlugueis.Add(aluguel);
                    }
                }
                return ListaAlugueis;
            }
        }
    }
}
