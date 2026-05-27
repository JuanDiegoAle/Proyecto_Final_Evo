using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVentas.Models
{
    public  class Producto
    {
        public int Id { get; set; }        // Identificador
        public string Nombre { get; set; } // Nombre del producto
        public decimal Precio { get; set; } // Precio
        public int Stock { get; set; }     // Cantidad disponible
    }
}
