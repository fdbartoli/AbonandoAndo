using System;
using System.Collections.Generic;

namespace AbonandoAndo.api.Models;

public partial class Cuentum
{
    public int? Id { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Cuil { get; set; }

    public decimal? Debe { get; set; }

    public decimal? Haber { get; set; }

    public decimal? Saldo { get; set; }
}
