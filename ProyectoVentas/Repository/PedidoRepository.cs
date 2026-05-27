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
    public  class PedidoRepository: IPedidoRepository
    {
        private string connectionString = "Server=.;Database=VentasDB;Trusted_Connection=True;";

        public void Guardar(Pedido pedido)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Pedido (Total, MetodoPago, Usuario, Cliente)\r\nVALUES (@Total, @MetodoPago, @Usuario, @Cliente)";
                SqlCommand cmd=new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                cmd.Parameters.AddWithValue("@MetodoPago", pedido.MetodoPago);
                cmd.Parameters.AddWithValue("@Usuario", pedido.Usuario);
                cmd.Parameters.AddWithValue("@Cliente", pedido.Cliente);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Pedido> ObtenerTodos()
        {
            List<Pedido> lista = new List<Pedido>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Pedido";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Pedido
                    {
                        Id = (int)reader["Id"],
                        Total = (decimal)reader["Total"],
                        MetodoPago = reader["MetodoPago"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Cliente = reader["Cliente"].ToString()
                    });
                }
            }
            return lista;
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Pedido WHERE Id=@Id";

                SqlCommand cmd=new SqlCommand(query,conn);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public decimal ObtenerTotalVendido()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT ISNULL(SUM(Total),0) FROM Pedido";

                SqlCommand cmd=new SqlCommand(query,conn); 

                return (decimal)cmd.ExecuteScalar();
            }
        }

        public List<Pedido> FiltarPorMetodo(string metodo)
        {
            List<Pedido> lista=new List<Pedido>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Pedido WHERE MetodoPago=@Metodo";

                SqlCommand cmd=new SqlCommand(query,conn);

                cmd.Parameters.AddWithValue("@Metodo", metodo);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Pedido
                    {
                        Id = (int)reader["Id"],
                        Total = (decimal)reader["Total"],
                        MetodoPago = reader["MetodoPago"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Cliente = reader["Cliente"].ToString()
                    });
                    
                }
            }
            return lista;
        }

        public Dictionary<string, int> ObtenerCantidadPorMetodo()
        {
            Dictionary<string, int> datos= new Dictionary<string, int>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT MetodoPago, COUNT(*) AS Cantidad
                   FROM Pedido
                   GROUP BY MetodoPago";

                SqlCommand cmd=new SqlCommand(query,conn);

                SqlDataReader reader= cmd.ExecuteReader();

                while (reader.Read())
                {
                    string metodo = reader["MetodoPago"].ToString();
                    int cantidad = (int)reader["Cantidad"];

                    datos.Add(metodo, cantidad);   
                }
            }
            return datos;
        }

        public void Actualizar(Pedido pedido)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            UPDATE Pedido
            SET Total = @Total,
                MetodoPago = @MetodoPago,
                Cliente = @Cliente,
                Usuario = @Usuario
            WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                cmd.Parameters.AddWithValue("@MetodoPago", pedido.MetodoPago);
                cmd.Parameters.AddWithValue("@Cliente", pedido.Cliente); 
                cmd.Parameters.AddWithValue("@Usuario", pedido.Usuario);
                cmd.Parameters.AddWithValue("@Id", pedido.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
