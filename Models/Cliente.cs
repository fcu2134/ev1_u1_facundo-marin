using System;
using System.Collections.Generic;

namespace ev1_u1.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Rut { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? ServicioATomar { get; set; }

    public virtual ICollection<ServiciosCliente> ServiciosClientes { get; set; } = new List<ServiciosCliente>();
}
