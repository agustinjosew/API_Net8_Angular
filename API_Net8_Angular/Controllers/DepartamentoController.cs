using GestionRecursosHumanos.API.DTOs;
using GestionRecursosHumanos.API.Models;
using GestionRecursosHumanos.API.Services;
using GestionRecursosHumanos.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionRecursosHumanos.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;
        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        // GET: /departamentos
        [HttpGet]
        public async Task<IActionResult> GetAllDepartamentos()
        {
            var departamentos = await _departamentoService.GetAllDepartamentosAsync();
            return Ok(departamentos);
        }

        // GET: /departamentos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartamentoById(string id)
        {
            var departamento= await _departamentoService.GetDepartamentosByIdAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return Ok(departamento);
        }

        // POST: /departamentos
        [HttpPost]
        public async Task<IActionResult> CreateDepartamento([FromBody] DepartamentoDTO departamentoDTO)
        {
            await _departamentoService.CreateDepartamentoAsync(departamentoDTO);
            return CreatedAtAction(nameof(GetDepartamentoById), new { id = departamentoDTO.Id }, departamentoDTO);
        }

        // PUT: /departamentos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDépartamento(string id, [FromBody] DepartamentoDTO departamentoDTO)
        {
            await _departamentoService.UpdateDepartamentoAsync(id, departamentoDTO);
            return NoContent();
        }

        // DELETE: /departamentos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(string id)
        {
            await _departamentoService.DeleteDepartamentoAsync(id);
            return NoContent();
        }
    }
}
