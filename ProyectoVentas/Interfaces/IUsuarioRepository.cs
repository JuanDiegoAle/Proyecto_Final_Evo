using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoVentas.Models;



namespace ProyectoVentas.Interfaces
{
    public interface IUsuarioRepository
    {
        bool Login(string username, string password);
        string ObtenerRol(string username);

        void Guardar(Usuario usuario);
        void Eliminar(int id);
        List<Usuario> ObtenerTodos();
    }
}
