using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Medico
{
    public int IdMedico { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Especialidad { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? NumeroDeLicencia { get; set; }

    public DateTime? FechaDeRegistro { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
