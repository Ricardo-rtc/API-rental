using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private IClienteRepository _ClienteRepository { get; set; }

        public ClienteController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ClienteDomain> ListaClientes = _ClienteRepository.ListarTodos();

                return Ok(ListaClientes);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(id);

                if (ClienteBuscado != null)
                {
                    return Ok(ClienteBuscado);
                }

                return NotFound("Aluguel não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpPost]
        public IActionResult Post(ClienteDomain NovoCliente)
        {
            try
            {
                _ClienteRepository.Cadastrar(NovoCliente);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpDelete("{IdDeletar}")]
        public IActionResult Delete(int IdDeletar)
        {
            try
            {
                _ClienteRepository.Deletar(IdDeletar);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteDomain ClienteAtualizar)
        {
            ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(ClienteAtualizar.IdCliente);

            if (ClienteBuscado != null)
            {
                try
                {
                    _ClienteRepository.Atualizar(ClienteAtualizar);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound(new
            {
                mensagem = "Aluguel não encontrado",
                Coderro = true
            });
        }
    }
}

