using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GestionRecursosHumanos.API.Models
{
    /// <summary>
    /// Clase que representa una solicitud de vacaciones.
    /// </summary>
    public class SolicitudVacaciones
    {
        /// <summary>
        /// Obtiene o establece el identificador de la solicitud de vacaciones.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del empleado que hizo la solicitud.
        /// </summary>
        [BsonElement("empleadoId")]
        public required string EmpleadoId { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de inicio de las vacaciones solicitadas.
        /// </summary>
        [BsonElement("fechaInicio")]
        public required DateTime FechaInicio { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de fin de las vacaciones solicitadas.
        /// </summary>
        [BsonElement("fechaFin")]
        public required DateTime FechaFin { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la solicitud de vacaciones.
        /// </summary>
        [BsonElement("estado")]
        public required EstadoVacaciones Estado { get; set; }
    }

}
