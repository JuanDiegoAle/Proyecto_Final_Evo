using ProyectoVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVentas.Interfaces
{
    public interface IProductoRespository
    {
        void Guardar (Producto producto);
        void Actualizar (Producto producto);
        void Eliminar (int id);
        List<Producto> ObtenerTodos();
    }
}
