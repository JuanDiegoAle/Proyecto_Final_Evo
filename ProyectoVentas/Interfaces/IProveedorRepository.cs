using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoVentas.Models;

namespace ProyectoVentas.Interfaces
{
    public interface IProveedorRepository
    {
        void Registrar(Proveedor proveedor);
        void Eliminar(int id);
        List<Proveedor> ObtenerTodos();
    }
}