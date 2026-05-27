using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVentas.Models
{
    public class Devolucion
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
    }
}
