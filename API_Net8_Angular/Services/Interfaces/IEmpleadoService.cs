using GestionRecursosHumanos.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionRecursosHumanos.API.Services.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones disponibles para el servicio de gestión de empleados.
    /// </summary>
    public interface IEmpleadoService
    {
        /// <summary>
        /// Obtiene todos los empleados de manera asincrónica.
        /// </summary>
        /// <returns>Una operación asincrónica que devuelve una lista de objetos EmpleadoDTO.</returns>
        Task<List<EmpleadoDTO>> GetAllEmpleadosAsync();

        /// <summary>
        /// Obtiene un empleado por su identificador de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del empleado que se desea obtener.</param>
        /// <returns>Una operación asincrónica que devuelve un objeto EmpleadoDTO con el identificador especificado.</returns>
        Task<EmpleadoDTO> GetEmpleadoByIdAsync(string id);

        /// <summary>
        /// Crea un nuevo empleado de manera asincrónica.
        /// </summary>
        /// <param name="empleadoDto">El objeto EmpleadoDTO que representa al nuevo empleado.</param>
        /// <returns>Una operación asincrónica que representa la creación del empleado.</returns>
        Task CreateEmpleadoAsync(EmpleadoDTO empleadoDto);

        /// <summary>
        /// Actualiza un empleado de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del empleado que se desea actualizar.</param>
        /// <param name="empleadoDto">El objeto EmpleadoDTO con los datos actualizados del empleado.</param>
        /// <returns>Una operación asincrónica que representa la actualización del empleado.</returns>
        Task UpdateEmpleadoAsync(string id, EmpleadoDTO empleadoDto);

        /// <summary>
        /// Elimina un empleado por su identificador de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del empleado que se desea eliminar.</param>
        /// <returns>Una operación asincrónica que representa la eliminación del empleado.</returns>
        Task DeleteEmpleadoAsync(string id);
    }
}

