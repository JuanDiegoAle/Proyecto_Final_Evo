using Microsoft.Office.Interop.Excel;
using ProyectoVentas.Interfaces;
using ProyectoVentas.Models;
using ProyectoVentas.Repository;
using ProyectoVentas.Service;
using ProyectoVentas.Service.Pagos;
using ProyectoVentas.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProyectoVentas.UI
{
    public partial class FormProductos : Form
    {
        private IProductoRespository repo;

        public FormProductos(IProductoRespository repository)
        {
            InitializeComponent();
            repo = repository;
            this.Load += FormProductos_Load;
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = repo.ObtenerTodos();
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Botón rápido para limpiar las cajas
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtNombre.Tag = null; // Limpiamos el ID oculto
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            Producto p = new Producto
            {
                Nombre = txtNombre.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text),
                Stock = Convert.ToInt32(txtStock.Text)
            };

            if (txtNombre.Tag != null) // Si hay un ID oculto, actualiza
            {
                p.Id = (int)txtNombre.Tag;
                repo.Actualizar(p);
                MessageBox.Show("Producto actualizado correctamente.");
            }
            else // Si no hay ID, crea uno nuevo
            {
                repo.Guardar(p);
                MessageBox.Show("Producto registrado con éxito.");
            }

           
            CargarProductos();
            btnLimpiar_Click(null, null);
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtNombre.Tag = null; // Limpiamos el ID oculto
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;
                repo.Eliminar(idSeleccionado);
                MessageBox.Show("Producto Eliminado.");
                btnLimpiar_Click(null, null);
                CargarProductos();
            }
            else { MessageBox.Show("Seleccione toda la fila del producto a eliminar."); }
        }

        private void dgvProductos_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Tag = dgvProductos.Rows[e.RowIndex].Cells["Id"].Value; // Guarda el ID oculto
                txtNombre.Text = dgvProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtPrecio.Text = dgvProductos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                txtStock.Text = dgvProductos.Rows[e.RowIndex].Cells["Stock"].Value.ToString();
            }
        }
    }
}
