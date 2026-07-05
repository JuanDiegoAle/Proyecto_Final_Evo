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
    }
}
