using System;
using System.Collections.Generic;

namespace AbonandoAndo.API.Models
{
    public partial class Concepto
    {
        public Concepto()
        {
            Comprobantes = new HashSet<Comprobante>();
        }

        public int IdConcepto { get; set; }
        public string Concepto1 { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Importe { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
