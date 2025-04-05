namespace proyecto.Domain
{
    public class Cita
    {
        public int Id_Cita { get; set; }
        public int Id_Paciente { get; set; }
        public Paciente Paciente { get; set; }
        public int Id_Medico { get; set; }
        public Medico Medico { get; set; }
        public DateTime Fecha_de_Cita { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
}
