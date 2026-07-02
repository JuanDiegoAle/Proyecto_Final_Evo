using ProyectoVentas.Interfaces;
using ProyectoVentas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoVentas.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public void Guardar(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "INSERT INTO Cliente (Nombre, DNI, Telefono) VALUES (@n, @d, @t)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", cliente.Nombre);
                cmd.Parameters.AddWithValue("@d", string.IsNullOrEmpty(cliente.DNI) ? (object)DBNull.Value : cliente.DNI);
                cmd.Parameters.AddWithValue("@t", string.IsNullOrEmpty(cliente.Telefono) ? (object)DBNull.Value : cliente.Telefono);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "UPDATE Cliente SET Nombre=@n, DNI=@d, Telefono=@t WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", cliente.Nombre);
                cmd.Parameters.AddWithValue("@d", string.IsNullOrEmpty(cliente.DNI) ? (object)DBNull.Value : cliente.DNI);
                cmd.Parameters.AddWithValue("@t", string.IsNullOrEmpty(cliente.Telefono) ? (object)DBNull.Value : cliente.Telefono);
                cmd.Parameters.AddWithValue("@id", cliente.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "DELETE FROM Cliente WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "SELECT * FROM Cliente";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Cliente
                    {
                        Id = (int)dr["Id"],
                        Nombre = dr["Nombre"].ToString(),
                        DNI = dr["DNI"] != DBNull.Value ? dr["DNI"].ToString() : "",
                        Telefono = dr["Telefono"] != DBNull.Value ? dr["Telefono"].ToString() : ""
                    });
                }
            }
            return lista;
        }
    }
}