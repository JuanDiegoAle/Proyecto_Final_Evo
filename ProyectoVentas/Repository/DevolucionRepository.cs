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
    public class DevolucionRepository:IDevolucionRepository
    {
        private string connectionString = "Server=.;Database=VentasDB;Trusted_Connection=True;";

        public void Guardar(Devolucion d)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Devolucion (PedidoId, Motivo, Fecha, Usuario) VALUES (@p, @m, @f, @u)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@p", d.PedidoId);
                cmd.Parameters.AddWithValue("@m", d.Motivo);
                cmd.Parameters.AddWithValue("@f", d.Fecha);
                cmd.Parameters.AddWithValue("@u", d.Usuario);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Devolucion> ObtenerTodos()
        {
            List<Devolucion> lista = new List<Devolucion>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Devolucion";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Devolucion
                    {
                        Id = (int)dr["Id"],
                        PedidoId = (int)dr["PedidoId"],
                        Motivo = dr["Motivo"].ToString(),
                        Fecha = (DateTime)dr["Fecha"],
                        Usuario = dr["Usuario"].ToString()
                    });
                }
            }

            return lista;
        }

        public void Actualizar(Devolucion d)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Devolucion SET PedidoId=@p, Motivo=@m WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@p", d.PedidoId);
                cmd.Parameters.AddWithValue("@m", d.Motivo);
                cmd.Parameters.AddWithValue("@id", d.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Devolucion WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
