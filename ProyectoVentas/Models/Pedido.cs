using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVentas.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }

        public string Usuario { get; set; }

        public string Cliente { get; set; }

    }
}
