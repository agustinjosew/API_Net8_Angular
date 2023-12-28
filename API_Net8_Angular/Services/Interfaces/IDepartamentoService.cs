using GestionRecursosHumanos.API.DTOs;

namespace GestionRecursosHumanos.API.Services.Interfaces
{
    public interface IDepartamentoService
    {
        /// <summary>
        /// Obtiene todos los departamentos de manera asincrónica.
        /// </summary>
        /// <returns>Una operación asincrónica que devuelve una colección de departamentos.</returns>
        Task<List<DepartamentoDTO>> GetAllDepartamentosAsync();

        /// <summary>
        /// Obtiene un departamento por su identificador de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del departamento que se desea obtener.</param>
        /// <returns>Una operación asincrónica que devuelve el departamento con el identificador especificado.</returns>
        Task<DepartamentoDTO> GetDepartamentosByIdAsync(string id);

        /// <summary>
        /// Agrega un nuevo departamento de manera asincrónica.
        /// </summary>
        /// <param name="departamentoDTO">El departamento que se va a agregar.</param>
        /// <returns>Una operación asincrónica que representa la adición del departamento.</returns>
        Task CreateDepartamentoAsync(DepartamentoDTO departamentoDTO);

        /// <summary>
        /// Actualiza un departamento de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del departamento que se desea actualizar.</param>
        /// <param name="departamentoDTO">Los datos actualizados del departamento.</param>
        /// <returns>Una operación asincrónica que representa la actualización del departamento.</returns>
        Task UpdateDepartamentoAsync(string id, DepartamentoDTO departamentoDTO);

        /// <summary>
        /// Elimina un departamento por su identificador de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del departamento que se desea eliminar.</param>
        /// <returns>Una operación asincrónica que representa la eliminación del departamento.</returns>
        Task DeleteDepartamentoAsync(string id);
    }
}
