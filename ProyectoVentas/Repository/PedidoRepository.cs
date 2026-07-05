using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProyectoVentas.Interfaces;
using ProyectoVentas.Models;

namespace ProyectoVentas.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        // ==========================================
        // OPERACIONES CRUD
        // ==========================================

        public void Guardar(Pedido pedido)
        {
            const string query = "INSERT INTO Pedido (Total, MetodoPago, Usuario, Cliente) " +
                                 "VALUES (@Total, @MetodoPago, @Usuario, @Cliente)";

            using (var conn = new SqlConnection(ConexionBD.Cadena))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                cmd.Parameters.AddWithValue("@MetodoPago", pedido.MetodoPago);
                cmd.Parameters.AddWithValue("@Usuario", pedido.Usuario);
                cmd.Parameters.AddWithValue("@Cliente", pedido.Cliente);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Pedido> ObtenerTodos()
        {
            var lista = new List<Pedido>();
            const string query = "SELECT Id, Total, MetodoPago, Usuario, Cliente FROM Pedido";

            using (var conn = new SqlConnection(ConexionBD.Cadena))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearPedido(reader));
                    }
                }
            }
            return lista;
        }

        public List<Pedido> FiltarPorMetodo(string metodo)
        {
            var lista = new List<Pedido>();
            const string query = "SELECT Id, Total, MetodoPago, Usuario, Cliente FROM Pedido WHERE MetodoPago = @Metodo";

            using (var conn = new SqlConnection(ConexionBD.Cadena))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Metodo", metodo);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearPedido(reader));
                    }
                }
            }
            return lista;
        }

        public void Actualizar(Pedido pedido)
        {
            const string query = "UPDATE Pedido SET Total = @Total, MetodoPago = @MetodoPago, " +
                                 "Cliente = @Cliente, Usuario = @Usuario WHERE Id = @Id";

            using (var conn = new SqlConnection(ConexionBD.Cadena))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                cmd.Parameters.AddWithValue("@MetodoPago", pedido.MetodoPago);
                cmd.Parameters.AddWithValue("@Cliente", pedido.Cliente);
                cmd.Parameters.AddWithValue("@Usuario", pedido.Usuario);
                cmd.Parameters.AddWithValue("@Id", pedido.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            const string query = "DELETE FROM Pedido WHERE Id = @Id";

            using (var conn = new SqlConnection(ConexionBD.Cadena))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ==========================================
        // MÉTODOS ESTADÍSTICOS / REPORTES
        // ==========================================

        public decimal ObtenerTotalVendido()
        {
            const string query = "SELECT ISNULL(SUM(Total), 0) FROM Pedido";

            using (var conn = new SqlConnection(ConexionBD.Cadena))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        public Dictionary<string, int> ObtenerCantidadPorMetodo()
        {
            var datos = new Dictionary<string, int>();
            const string query = "SELECT MetodoPago, COUNT(*) AS Cantidad FROM Pedido GROUP BY MetodoPago";

            using (var conn = new SqlConnection(ConexionBD.Cadena))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        datos.Add(reader["MetodoPago"].ToString(), (int)reader["Cantidad"]);
                    }
                }
            }
            return datos;
        }

        public Dictionary<string, decimal> ObtenerVentasPorVendedor()
        {
            var datos = new Dictionary<string, decimal>();
            const string query = "SELECT Usuario, SUM(Total) AS TotalVendido FROM Pedido GROUP BY Usuario";

            using (var conn = new SqlConnection(ConexionBD.Cadena))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        datos.Add(reader["Usuario"].ToString(), (decimal)reader["TotalVendido"]);
                    }
                }
            }
            return datos;
        }

        // ==========================================
        // MÉTODOS AUXILIARES (HELPERS)
        // ==========================================

        private Pedido MapearPedido(SqlDataReader reader)
        {
            return new Pedido
            {
                Id = (int)reader["Id"],
                Total = (decimal)reader["Total"],
                MetodoPago = reader["MetodoPago"].ToString(),
                Usuario = reader["Usuario"].ToString(),
                Cliente = reader["Cliente"].ToString()
            };
        }
    }
}