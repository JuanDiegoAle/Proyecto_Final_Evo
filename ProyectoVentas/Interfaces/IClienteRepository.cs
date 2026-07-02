using ProyectoVentas.Models;
using System.Collections.Generic;

namespace ProyectoVentas.Interfaces
{
    public interface IClienteRepository
    {
        void Guardar(Cliente cliente);
        void Actualizar(Cliente cliente);
        void Eliminar(int id);
        List<Cliente> ObtenerTodos();
    }
}