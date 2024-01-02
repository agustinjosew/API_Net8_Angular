using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GestionRecursosHumanos.API.Models
{
    /// <summary>
    /// Clase que representa un puesto de trabajo.
    /// </summary>
    public class Puesto
    {
        /// <summary>
        /// Obtiene o establece el identificador del puesto.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        /// <summary>
        /// Obtiene o establece el título del puesto.
        /// </summary>
        [BsonElement("titulo")]
        public required string Titulo { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del puesto.
        /// </summary>
        [BsonElement("descripcion")]
        public required string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece una lista de requisitos para el puesto.
        /// </summary>
        [BsonElement("requisitos")]
        public required List<string> Requisitos { get; set; }
    }

}
