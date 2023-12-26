using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GestionRecursosHumanos.API.Models
{
    /// <summary>
    /// Clase que representa a un empleado.
    /// </summary>
    public class Empleado
    {
        /// <summary>
        /// Id empleado
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del empleado.
        /// </summary>
        [BsonElement("nombre")]
        public required string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del empleado.
        /// </summary>
        [BsonElement("apellido")]
        public required string Apellido { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del empleado.
        /// </summary>
        [BsonElement("email")]
        public required string Email { get; set; }

        /// <summary>
        /// Obtiene o establece el cargo del empleado.
        /// </summary>
        [BsonElement("cargo")]
        public required string Cargo { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del departamento al que pertenece el empleado.
        /// </summary>
        [BsonElement("departamento")]
        public ObjectId DepartamentoId { get; set; }
    }

}
