using MongoDB.Bson.Serialization.Attributes;

namespace GestionRecursosHumanos.API.Models
{
    /// <summary>
    /// Clase que representa una dirección.
    /// </summary>
    public class Direccion
    {
        /// <summary>
        /// Obtiene o establece el nombre de la calle de la dirección.
        /// </summary>
        [BsonElement("calle")]
        public required string Calle { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la ciudad de la dirección.
        /// </summary>
        [BsonElement("ciudad")]
        public required string Ciudad { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estado o provincia de la dirección.
        /// </summary>
        [BsonElement("estado")]
        public required string Estado { get; set; }

        /// <summary>
        /// Obtiene o establece el código postal de la dirección.
        /// </summary>
        [BsonElement("codigoPostal")]
        public required string CodigoPostal { get; set; }
    }

}
