namespace proyecto.Domain
{
    public class Medico
    {
        public int Id_Medico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Numero_de_Licencia { get; set; }
        public DateTime Fecha_de_Registro { get; set; }
        public int Id_Usuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
