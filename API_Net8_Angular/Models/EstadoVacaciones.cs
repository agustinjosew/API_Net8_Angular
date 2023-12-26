namespace GestionRecursosHumanos.API.Models
{
    /// <summary>
    /// Enumeración que representa el estado de una solicitud de vacaciones.
    /// </summary>
    public enum EstadoVacaciones
    {
        /// <summary>
        /// Estado cuando la solicitud de vacaciones está pendiente de revisión.
        /// </summary>
        Pendiente,

        /// <summary>
        /// Estado cuando la solicitud de vacaciones ha sido aprobada.
        /// </summary>
        Aprobado,

        /// <summary>
        /// Estado cuando la solicitud de vacaciones ha sido rechazada.
        /// </summary>
        Rechazado
    }

}
