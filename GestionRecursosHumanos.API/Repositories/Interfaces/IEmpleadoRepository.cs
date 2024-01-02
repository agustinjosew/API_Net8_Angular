using GestionRecursosHumanos.API.Models;

namespace GestionRecursosHumanos.API.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones disponibles para la gestión de empleados en un repositorio.
    /// </summary>
    public interface IEmpleadoRepository
    {
        /// <summary>
        /// Obtiene todos los empleados de manera asincrónica.
        /// </summary>
        /// <returns>Una operación asincrónica que devuelve una colección de empleados.</returns>
        Task<IEnumerable<Empleado>> GetAllAsync();

        /// <summary>
        /// Obtiene un empleado por su identificador de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del empleado que se desea obtener.</param>
        /// <returns>Una operación asincrónica que devuelve el empleado con el identificador especificado.</returns>
        Task<Empleado> GetByIdAsync(string id);

        /// <summary>
        /// Agrega un nuevo empleado de manera asincrónica.
        /// </summary>
        /// <param name="empleado">El empleado que se va a agregar.</param>
        /// <returns>Una operación asincrónica que representa la adición del empleado.</returns>
        Task AddAsync(Empleado empleado);

        /// <summary>
        /// Actualiza un empleado de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del empleado que se desea actualizar.</param>
        /// <param name="empleado">Los datos actualizados del empleado.</param>
        /// <returns>Una operación asincrónica que representa la actualización del empleado.</returns>
        Task UpdateAsync(string id, Empleado empleado);

        /// <summary>
        /// Elimina un empleado por su identificador de manera asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del empleado que se desea eliminar.</param>
        /// <returns>Una operación asincrónica que representa la eliminación del empleado.</returns>
        Task DeleteAsync(string id);
    }

}
