namespace GestionRecursosHumanos.API.DTOs
{
    /// <summary>
    /// DTO que representa un departamento.
    /// </summary>
    public class DepartamentoDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador del departamento.
        /// </summary>
        public required string Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del departamento.
        /// </summary>
        public required string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del departamento.
        /// </summary>
        public required string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece la ubicación del departamento.
        /// </summary>
        public required string Ubicacion { get; set; }
    }
}
