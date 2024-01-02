using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GestionRecursosHumanos.API.Models
{
    /// <summary>
    /// Clase que representa un departamento.
    /// </summary>
    public class Departamento
    {
        /// <summary>
        /// Obtiene o establece el identificador del departamento.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del departamento.
        /// </summary>
        [BsonElement("nombre")]
        public required string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del departamento.
        /// </summary>
        [BsonElement("descripcion")]
        public required string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece la ubicación del departamento.
        /// </summary>
        [BsonElement("ubicacion")]
        public required string Ubicacion { get; set; }
    }
}
