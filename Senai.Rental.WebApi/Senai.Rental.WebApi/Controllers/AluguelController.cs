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
    public class AluguelController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AluguelController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<AluguelDomain> ListaAlugueis = _AluguelRepository.ListarTodos();

                return Ok(ListaAlugueis);
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(id);

                if (aluguelBuscado != null)
                {
                    return Ok(aluguelBuscado);
                }

                return NotFound("Aluguel não encontrado!");
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpPost]
        public IActionResult Post(AluguelDomain NovoAluguel)
        {
            try
            {
                _AluguelRepository.Cadastrar(NovoAluguel);
                return StatusCode(201);
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpDelete("{IdDeletar}")]
        public IActionResult Delete (int IdDeletar)
        {
            try
            {
                _AluguelRepository.Deletar(IdDeletar);
                return StatusCode(204);
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Put(AluguelDomain AluguelAtualizar)
        {
            AluguelDomain AluguelBuscado = _AluguelRepository.BuscarPorId(AluguelAtualizar.IdAluguel);

            if(AluguelBuscado != null)
            {
                try
                {
                    _AluguelRepository.Atualizar(AluguelAtualizar);
                    return NoContent();
                }
                catch(Exception erro)
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
