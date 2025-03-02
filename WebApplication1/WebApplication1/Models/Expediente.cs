using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Expediente
{
    public int IdExpediente { get; set; }

    public int IdPaciente { get; set; }

    public string Diagnostico { get; set; } = null!;

    public string? Tratamiento { get; set; }

    public DateTime? FechaDeCreacion { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
