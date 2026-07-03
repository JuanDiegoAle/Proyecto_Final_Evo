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
    public partial class FormClientes : Form
    {
        private IClienteRepository repo;
        public FormClientes(IClienteRepository repository)
        {
            InitializeComponent();
            repo = repository;
            this.Load += FormClientes_Load;
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();

        }

        private void CargarClientes()
        {
            dgvClientes.DataSource=repo.ObtenerTodos();
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
