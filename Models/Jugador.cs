namespace api_psp.Models
{
    public class Jugador
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Equipo { get; set; } = string.Empty;
    }
}
