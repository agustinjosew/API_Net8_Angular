using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GestionRecursosHumanos.API.Models
{
    /// <summary>
    /// Clase que representa a un candidato.
    /// </summary>
    public class Candidato
    {
        /// <summary>
        /// Obtiene o establece el identificador del candidato.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del candidato.
        /// </summary>
        [BsonElement("nombre")]
        public required string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del candidato.
        /// </summary>
        [BsonElement("apellido")]
        public required string Apellido { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del candidato.
        /// </summary>
        [BsonElement("email")]
        public required string Email { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del puesto al que aplicó el candidato.
        /// </summary>
        [BsonElement("puestoAplicadoId")]
        public required string PuestoAplicadoId { get; set; }

        /// <summary>
        /// Obtiene o establece el currículum vitae (CV) del candidato.
        /// </summary>
        [BsonElement("cv")]
        public required string Cv { get; set; } // Podría ser una URL al documento del CV

        /// <summary>
        /// Obtiene o establece el estado de la aplicación del candidato.
        /// </summary>
        [BsonElement("estadoAplicacion")]
        public required EstadoAplicacion EstadoAplicacion { get; set; }
    }

}
