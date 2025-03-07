using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_psp.Models
{
    public class Jugador
    {
        [BsonId] // Indica que esta es la clave primaria en MongoDB
        [BsonRepresentation(BsonType.ObjectId)] // Permite tratarlo como string
        public string Id { get; set; } = string.Empty; // MongoDB usa Id tipo string

        public string Siglas { get; set; } = string.Empty;
        public int Puntuacion { get; set; }
    }
}
