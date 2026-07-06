using ProyectoVentas.Interfaces;
using ProyectoVentas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVentas.Repository
{
    public  class ProductoRepository :IProductoRespository
    {

        public List<Producto> ObtenerTodos()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(ConexionBD.Cadena))
            {
                conn.Open();

                string query = "SELECT * FROM Producto";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Producto
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Precio = (decimal)reader["Precio"],
                        Stock = (int)reader["Stock"]
                    });
                }
            }

            return lista;
        }
        public void Guardar(Producto p)
        {
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "INSERT INTO Producto (Nombre, Precio, Stock) VALUES (@n, @p, @s)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", p.Nombre);
                cmd.Parameters.AddWithValue("@p", p.Precio);
                cmd.Parameters.AddWithValue("@s", p.Stock);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Producto p)
        {
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "UPDATE Producto SET Nombre=@n, Precio=@p, Stock=@s WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", p.Nombre);
                cmd.Parameters.AddWithValue("@p", p.Precio);
                cmd.Parameters.AddWithValue("@s", p.Stock);
                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "DELETE FROM Producto WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        
    }
}
