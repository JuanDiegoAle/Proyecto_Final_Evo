using ProyectoVentas.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoVentas
{
    public partial class FormProveedores : Form
    {
        private IProveedorRepository repo;

        public FormProveedores(IProveedorRepository repository)
        {
            InitializeComponent();
            repo = repository;
            this.Load += FormProveedores_Load;
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            dgvProveedores.DataSource = repo.ObtenerTodos();
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}