using System;
using System.Collections.Generic;

namespace ev1_u1.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string? Tipo { get; set; }

    public string? Disponibilidad { get; set; }

    public string? Precios { get; set; }

    public string? Estado { get; set; }

    public string? Comentarios { get; set; }

    public virtual ICollection<ServiciosCliente> ServiciosClientes { get; set; } = new List<ServiciosCliente>();
}
