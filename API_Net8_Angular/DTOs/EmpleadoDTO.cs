namespace GestionRecursosHumanos.API.DTOs
{
    /// <summary>
    /// DTO (Data Transfer Object) que representa a un empleado.
    /// </summary>
    public class EmpleadoDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador del empleado.
        /// </summary>
        public required string Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del empleado.
        /// </summary>
        public required string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del empleado.
        /// </summary>
        public required string Apellido { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del empleado.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtiene o establece el cargo del empleado.
        /// </summary>
        public required string Cargo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del departamento al que pertenece el empleado.
        /// </summary>
        public required string DepartamentoId { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del puesto del empleado.
        /// </summary>
        public required string PuestoId { get; set; }

    }
}

