using System;
using System.Collections.Generic;

namespace AbonandoAndo.Api.Models;

public partial class Egreso
{
    public int Id { get; set; }

    public decimal? Monto { get; set; }

    public string? Fecha { get; set; }

    public string? Detalle { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
}
