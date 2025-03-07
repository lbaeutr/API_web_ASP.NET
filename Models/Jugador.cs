namespace api_psp.Models
{
    public class Jugador
    {
        public long Id { get; set; }
        public string Siglas { get; set; } = string.Empty; // Máximo 3 caracteres
        public int Puntuacion { get; set; } // Puntuación del jugador
    }
}
