using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbonandoAndo.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public long Cuil { get; set; }
        public string Apellidos { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Mail { get; set; }
    }
}
