namespace TurnoAgil.Models{
    public class Turno{
        public int ID { get; set; }
        public int? NIT_Asesor { get; set; }
        public string? Servicio { get; set; }
        public int? NumeroTurno { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaInicioAtencion { get; set; }
        public DateTime FechaFinAtencion { get; set; }
        // public ICollection<Asesor> Asesores {get; set;}= new List<Asesor>();
    }
}