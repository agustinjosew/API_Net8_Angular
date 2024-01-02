using GestionRecursosHumanos.API.DTOs;
using GestionRecursosHumanos.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionRecursosHumanos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: /empleados
        [HttpGet]
        public async Task<IActionResult> GetAllEmpleados()
        {
            var empleados = await _empleadoService.GetAllEmpleadosAsync();
            return Ok(empleados);
        }

        // GET: /empleados/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpleadoById(string id)
        {
            var empleado = await _empleadoService.GetEmpleadoByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return Ok(empleado);
        }

        // POST: /empleados
        [HttpPost]
        public async Task<IActionResult> CreateEmpleado([FromBody] EmpleadoDTO empleadoDto)
        {
            await _empleadoService.CreateEmpleadoAsync(empleadoDto);
            return CreatedAtAction(nameof(GetEmpleadoById), new { id = empleadoDto.Id }, empleadoDto);
        }

        // PUT: /empleados/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(string id, [FromBody] EmpleadoDTO empleadoDto)
        {
            await _empleadoService.UpdateEmpleadoAsync(id, empleadoDto);
            return NoContent();
        }

        // DELETE: /empleados/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(string id)
        {
            await _empleadoService.DeleteEmpleadoAsync(id);
            return NoContent();
        }
    }
}
