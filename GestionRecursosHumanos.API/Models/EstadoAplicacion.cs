namespace GestionRecursosHumanos.API.Models
{
    /// <summary>
    /// Enumeración que representa el estado de una aplicación.
    /// </summary>
    public enum EstadoAplicacion
    {
        /// <summary>
        /// Estado cuando la aplicación ha sido presentada.
        /// </summary>
        Aplicado,

        /// <summary>
        /// Estado cuando la aplicación se encuentra en proceso de revisión.
        /// </summary>
        EnProceso,

        /// <summary>
        /// Estado cuando la aplicación ha sido aceptada.
        /// </summary>
        Aceptado,

        /// <summary>
        /// Estado cuando la aplicación ha sido rechazada.
        /// </summary>
        Rechazado
    }

}
