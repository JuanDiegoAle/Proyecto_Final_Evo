using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoVentas.Interfaces;
using ProyectoVentas.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoVentas.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        public void Registrar(Proveedor p)
        {
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "INSERT INTO Proveedor (Ruc, RazonSocial, Telefono, Direccion) VALUES (@ruc, @razon, @tel, @dir)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ruc", p.Ruc);
                cmd.Parameters.AddWithValue("@razon", p.RazonSocial);
                cmd.Parameters.AddWithValue("@tel", p.Telefono);
                cmd.Parameters.AddWithValue("@dir", p.Direccion);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                string query = "DELETE FROM Proveedor WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Proveedor> ObtenerTodos()
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (SqlConnection con = new SqlConnection(ConexionBD.Cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Ruc, RazonSocial, Telefono, Direccion FROM Proveedor", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Proveedor
                    {
                        Id = (int)dr["Id"],
                        Ruc = dr["Ruc"].ToString(),
                        RazonSocial = dr["RazonSocial"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Direccion = dr["Direccion"].ToString()
                    });
                }
            }
            return lista;
        }
    }
}