using TurnoAgil.Data;

namespace TurnoAgil.Models{
    public class Asesor(){
        public int? ID { get; set; }
        public string? NIT { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Password { get; set; }
        public string? Estado { get; set; }
        public int? Acceso { get; set; }
        
    }
}