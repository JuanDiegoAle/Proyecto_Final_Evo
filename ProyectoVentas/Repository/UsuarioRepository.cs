using ProyectoVentas.Interfaces;
using ProyectoVentas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        public void Guardar(Usuario u)
        {
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "INSERT INTO Usuario (Username, Password, Rol) VALUES (@u, @p, @r)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@u", u.Username);
                cmd.Parameters.AddWithValue("@p", u.Password);
                cmd.Parameters.AddWithValue("@r", u.Rol);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "DELETE FROM Usuario WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Username, Password, Rol FROM Usuario", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Usuario
                    {
                        Id = (int)dr["Id"],
                        Username = dr["Username"].ToString(),
                        Password = dr["Password"].ToString(),
                        Rol = dr["Rol"].ToString()
                    });
                }
            }
            return lista;
        }
    }
}