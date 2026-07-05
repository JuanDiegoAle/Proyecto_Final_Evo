using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoVentas.Interfaces;
using ProyectoVentas.Models;

namespace ProyectoVentas.UI
{
    public partial class FormUsuarios : Form
    {
        private IUsuarioRepository repo;
        public FormUsuarios(IUsuarioRepository repository)
        {
            InitializeComponent();
            repo = repository;
            this.Load += FormUsuarios_Load;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = repo.ObtenerTodos();
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
