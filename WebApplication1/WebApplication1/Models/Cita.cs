using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Cita
{
    public int IdCita { get; set; }

    public int IdPaciente { get; set; }

    public int IdMedico { get; set; }

    public DateTime FechaDeCita { get; set; }

    public string? Estado { get; set; }

    public string? Observaciones { get; set; }

    public virtual Medico IdMedicoNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual ICollection<Recordatorio> Recordatorios { get; set; } = new List<Recordatorio>();
}
