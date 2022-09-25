using System;
using System.Collections.Generic;

namespace AbonandoAndo.API.Models
{
    public partial class Operacion
    {
        //public Operacion()
        //{
        //    Comprobantes = new HashSet<Comprobante>();
        //}

        public int IdOperacion { get; set; }
        public bool Tipo { get; set; }

        //public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
