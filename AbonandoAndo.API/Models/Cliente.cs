using System;
using System.Collections.Generic;

namespace AbonandoAndo.Api.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Cuil { get; set; }

    public string? Apellidos { get; set; }

    public string? Nombres { get; set; }

    public string? Domicilio { get; set; }

    public string? Telefono { get; set; }

    public string? Mail { get; set; }

    public virtual ICollection<Egreso> Egresos { get; } = new List<Egreso>();

    public virtual ICollection<Ingreso> Ingresos { get; } = new List<Ingreso>();
}
