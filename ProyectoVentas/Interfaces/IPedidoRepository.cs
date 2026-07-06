using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoVentas.Models;

namespace ProyectoVentas.Interfaces
{
    public interface IPedidoRepository
    {
        void Guardar(Pedido pedido);
        void Actualizar(Pedido pedido);
        void Eliminar(int id);
        List<Pedido> ObtenerTodos();

        List<Pedido> FiltarPorMetodo(string metodo);
        decimal ObtenerTotalVendido();

        Dictionary<string, decimal> ObtenerVentasPorVendedor();
        Dictionary<string, int> ObtenerMetodosPagoEstadistica(); 
    }
}
