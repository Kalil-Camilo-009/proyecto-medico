using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Recordatorio
{
    public int IdRecordatorio { get; set; }

    public int IdCita { get; set; }

    public string? Mensaje { get; set; }

    public DateTime? FechaDeEnvio { get; set; }

    public virtual Cita IdCitaNavigation { get; set; } = null!;
}
