using System;

namespace ProyectoVentas.Repository
{
    public static class ConexionBD
    {
        // Centralizamos la cadena de conexión aquí para no repetir en varios lugares
        public static string Cadena { get; } = "Server=.;Database=VentasDB;Trusted_Connection=True;";
    }
}