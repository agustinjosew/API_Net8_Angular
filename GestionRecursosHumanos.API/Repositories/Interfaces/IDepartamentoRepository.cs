using GestionRecursosHumanos.API.Models;

namespace GestionRecursosHumanos.API.Repositories.Interfaces

{
    /// <summary>
    /// Interfaz que define las operaciones disponibles para la gestión de departamentos en un repositorio.
    /// </summary>
    public interface IDepartamentoRepository
    {
        /// <summary>
        /// Obtiene todos los departamentos de manera asincrónica.
        /// </summary>
        /// <returns>Una operación asincrónica que devuelve una colección de departamentos.</returns>
        Task<IEnumerable<Departamento>> GetAllAsync();

        /// <summary>
        /// Obtiene un departamento por su identificador de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del departamento que se desea obtener.</param>
        /// <returns>Una operación asincrónica que devuelve el departamento con el identificador especificado.</returns>
        Task<Departamento> GetByIdAsync(string id);

        /// <summary>
        /// Agrega un nuevo departamento de manera asincrónica.
        /// </summary>
        /// <param name="departamento">El departamento que se va a agregar.</param>
        /// <returns>Una operación asincrónica que representa la adición del departamento.</returns>
        Task AddAsync(Departamento departamento);

        /// <summary>
        /// Actualiza un departamento de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del departamento que se desea actualizar.</param>
        /// <param name="departamento">Los datos actualizados del departamento.</param>
        /// <returns>Una operación asincrónica que representa la actualización del departamento.</returns>
        Task UpdateAsync(string id, Departamento departamento);

        /// <summary>
        /// Elimina un departamento por su identificador de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del departamento que se desea eliminar.</param>
        /// <returns>Una operación asincrónica que representa la eliminación del departamento.</returns>
        Task DeleteAsync(string id);
    }
}

