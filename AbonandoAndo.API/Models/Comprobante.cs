using System;
using System.Collections.Generic;

namespace AbonandoAndo.API.Models
{
    public partial class Comprobante
    {
        public int IdComprobante { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdCliente { get; set; }
        public int? IdOperacion { get; set; }
        public int? IdConcepto { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Concepto? IdConceptoNavigation { get; set; }
        public virtual Operacion? IdOperacionNavigation { get; set; }
    }
}
