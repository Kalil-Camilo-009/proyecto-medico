namespace proyecto.Domain
{
    public class Asistente
    {
        public int Id_Asistente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime Fecha_de_Registro { get; set; }
        public int Id_Usuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
