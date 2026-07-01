using ProyectoVentas.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoVentas.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
    

        public bool Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.Cadena))
            {
                conn.Open();

                string query = @"
                SELECT COUNT(*)
                FROM Usuario
                WHERE Username = @Username
                AND Password = @Password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

        public string ObtenerRol(string username)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.Cadena))
            {
                conn.Open();

                string query = @"
                SELECT Rol
                FROM Usuario
                WHERE Username = @Username";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                object result = cmd.ExecuteScalar();

                return result != null ? result.ToString() : "";
            }
        }
    }

}
