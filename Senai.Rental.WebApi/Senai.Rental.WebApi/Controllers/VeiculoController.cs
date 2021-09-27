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
    public class VeiculoController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculoController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<VeiculoDomain> ListaVeiculos = _VeiculoRepository.ListarTodos();

                return Ok(ListaVeiculos);
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
                VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarPorId(id);

                if (VeiculoBuscado != null)
                {
                    return Ok(VeiculoBuscado);
                }

                return NotFound("Veiculo não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [HttpPost]
        public IActionResult Post(VeiculoDomain NovoVeiculo)
        { 
            try
            {
            _VeiculoRepository.Cadastrar(NovoVeiculo);
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
                _VeiculoRepository.Deletar(IdDeletar);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Put(VeiculoDomain VeiculoAtualizar)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarPorId(VeiculoAtualizar.IdVeiculo);

            if (VeiculoBuscado != null)
            {
                try
                {
                    _VeiculoRepository.Atualizar(VeiculoAtualizar);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound(new
            {
                mensagem = "Veiculo não encontrado",
                Coderro = true
            });
        }
    }
}

