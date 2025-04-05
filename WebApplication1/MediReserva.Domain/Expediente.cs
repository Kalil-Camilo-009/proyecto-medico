namespace proyecto.Domain
{
    public class Expediente
    {
        public int Id_Expediente { get; set; }
        public int Id_Paciente { get; set; }
        public Paciente Paciente { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public DateTime Fecha_de_Creacion { get; set; }
    }
}
