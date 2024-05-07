using System;
using System.Collections.Generic;

namespace ev1_u1.Models;

public partial class ServiciosCliente
{
    public int ServiciosIdServicio { get; set; }

    public int ClientesIdCliente { get; set; }

    public string? Inicio { get; set; }

    public string? Termino { get; set; }

    public string? Observaciones { get; set; }

    public string? Tecnico { get; set; }

    public string? NProceso { get; set; }

    public virtual Cliente ClientesIdClienteNavigation { get; set; } = null!;

    public virtual Servicio ServiciosIdServicioNavigation { get; set; } = null!;
}
