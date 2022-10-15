using System;
using System.Collections.Generic;

namespace AbonandoAndo.API.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Comprobantes = new HashSet<Comprobante>();
        }

        public int IdCliente { get; set; }
        public long Cuil { get; set; }
        public string Apellidos { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Mail { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
