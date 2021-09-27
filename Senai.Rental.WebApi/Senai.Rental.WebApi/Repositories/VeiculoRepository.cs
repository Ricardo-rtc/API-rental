using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-C8POL51\\SQLEXPRESS; initial catalog=M_Rental; user=sa; pwd=senai@132";
        public void Atualizar(VeiculoDomain VeiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Veiculos SET IdModelo = @idModelo, Placa = @novaPlaca, IdEmpresa = @idEmpresa WHERE IdVeiculo = @IdVeiculo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", VeiculoAtualizado.IdModelo);
                    cmd.Parameters.AddWithValue("@novaPlaca", VeiculoAtualizado.Placa);
                    cmd.Parameters.AddWithValue("@idEmpresa", VeiculoAtualizado.IdEmpresa);
                    cmd.Parameters.AddWithValue("@idVeiculo", VeiculoAtualizado.IdVeiculo);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public VeiculoDomain BuscarPorId(int IdProcurar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdVeiculo, NomeEmpresa, Descricao, NomeMarca, Placa  FROM Veiculos LEFT JOIN Empresas ON Veiculos.IdEmpresa = Empresas.IdEmpresa INNER JOIN Modelos ON Veiculos.IdModelo = Modelos.IdModelo INNER JOIN Marcas ON Modelos.IdMarca = Marcas.IdMarca WHERE IdVeiculo = @idVeiculo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", IdProcurar);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain()
                        {
                            IdVeiculo = Convert.ToInt32(rdr[0]),
                            Empresa = new EmpresaDomain()
                            {
                                NomeEmpresa = rdr[1].ToString()
                            },
                            Modelo = new ModeloDomain()
                            {
                                Descricao = rdr[2].ToString(),
                                Marca = new MarcaDomain()
                                {
                                    Nome = rdr[3].ToString()
                                }
                            },
                            Placa = rdr[4].ToString()
                        };
                        return veiculoBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain NovoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Veiculos(IdEmpresa,IdModelo,Placa) VALUES (@novaEmpresa, @novoModelo, @novaPlaca)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novaEmpresa", NovoVeiculo.IdEmpresa);
                    cmd.Parameters.AddWithValue("@novoModelo", NovoVeiculo.IdModelo);
                    cmd.Parameters.AddWithValue("@novaPlaca", NovoVeiculo.Placa);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdDeletar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Veiculos WHERE IdVeiculo = @idVeiculo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", IdDeletar);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> ListaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdVeiculo, NomeEmpresa, Descricao, NomeMarca, Placa  FROM Veiculos LEFT JOIN Empresas ON Veiculos.IdEmpresa = Empresas.IdEmpresa INNER JOIN Modelos ON Veiculos.IdModelo = Modelos.IdModelo INNER JOIN Marcas ON Modelos.IdMarca = Marcas.IdMarca;";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            IdVeiculo = Convert.ToInt32(rdr[0]),
                            Empresa = new EmpresaDomain()
                            {
                                NomeEmpresa = rdr[1].ToString()
                            },
                            Modelo = new ModeloDomain()
                            {
                                Descricao = rdr[2].ToString(),
                                Marca = new MarcaDomain()
                                {
                                    Nome = rdr[3].ToString()
                                }
                            },
                            Placa = rdr[4].ToString()
                        };
                        ListaVeiculos.Add(veiculo);
                    }
                    return ListaVeiculos;
                }
            }
        }
    }
}
