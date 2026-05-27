using ProyectoVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVentas.Interfaces
{
    public  interface IDevolucionRepository
    {
        void Guardar(Devolucion d);
        List<Devolucion> ObtenerTodos();
        void Actualizar(Devolucion d);
        void Eliminar(int id);
    }
}
