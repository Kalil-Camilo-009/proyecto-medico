namespace proyecto.Domain
{
    public class Recordatorio
    {
        public int Id_Recordatorio { get; set; }
        public int Id_Cita { get; set; }
        public Cita Cita { get; set; }
        public string Mensaje { get; set; }
        public DateTime? Fecha_de_Envio { get; set; }
    }
}
