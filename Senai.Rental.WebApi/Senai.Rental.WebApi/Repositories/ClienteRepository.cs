using System;
using Senai.Rental.WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;
using System.Data.SqlClient;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string stringConexao = "Data Source=DESKTOP-C8POL51\\SQLEXPRESS; initial catalog=M_Rental; user=sa; pwd=senai@132";
        public void Atualizar(ClienteDomain ClienteAtualizado)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Clientes SET Nome = @novoNome, Sobrenome = @novoSobrenome, CPF = @novoCPF WHERE IdCliente = @Id;";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryUpdate,con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", ClienteAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@novoSobrenome", ClienteAtualizado.Sobrenome);
                    cmd.Parameters.AddWithValue("@novoCPF", ClienteAtualizado.CPF);
                    cmd.Parameters.AddWithValue("@Id", ClienteAtualizado.IdCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int IdProcurar)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdCliente, Nome, Sobrenome, CPF FROM Cliente WHERE IdClinte = @idCliente;";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", IdProcurar);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain()
                        {
                            IdCliente = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            CPF = rdr[3].ToString()
                        };
                        return clienteBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain NovoCliente)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Clientes(Nome, Sobrenome, CPF) VALUES (@novoNome, @novoSobrenome, @novoCPF";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", NovoCliente.Nome);
                    cmd.Parameters.AddWithValue("@novoSobrenome", NovoCliente.Sobrenome);
                    cmd.Parameters.AddWithValue("@novoCPF", NovoCliente.CPF);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int IdDeletar)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Clientes WHERE IdCliente = @idCliente";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", IdDeletar);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> ListaClientes = new List<ClienteDomain>();

            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdCliente, Nome, Sobrenome, CPF FROM Clientes";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            IdCliente = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            CPF = rdr[3].ToString()
                        };

                        ListaClientes.Add(cliente);

                    }
                }
            }
            return ListaClientes;
        }
    }
}
