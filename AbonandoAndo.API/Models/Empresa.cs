using System;
using System.Collections.Generic;

namespace AbonandoAndo.API.Models
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public string RazonSocial { get; set; } = null!;
        public string? Domicilio { get; set; }
        public string Actividad { get; set; } = null!;
    }
}
