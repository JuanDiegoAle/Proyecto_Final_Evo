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
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Usuario y contraseña son obligatorios");
                return;
            }
            Usuario u = new Usuario
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Rol = string.IsNullOrWhiteSpace(txtRol.Text) ? "Vendedor" : txtRol.Text

            };
            repo.Guardar(u);
            MessageBox.Show("Usuario registrado con exito.");
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtRol.Text = "";
            CargarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)dgvUsuarios.SelectedRows[0].Cells["Id"].Value;
                repo.Eliminar(idSeleccionado);
                MessageBox.Show("Usuario eliminado correctamente");
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Por favor,seleccione toda la fila del usuario a eliminar");
            }
        }
    }
}
