using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreDeUsuario { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string? Rol { get; set; }

    public virtual Asistente? Asistente { get; set; }

    public virtual Medico? Medico { get; set; }
}
