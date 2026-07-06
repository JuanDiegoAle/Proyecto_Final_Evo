using ProyectoVentas.Interfaces;
using ProyectoVentas.Models;
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text="";
            txtDni.Text="";
            txtTelefono.Text="";
            // Usaremos la propiedad Tag del txtNombre para guardar el ID del cliente ocultamente cuando queramos editar
            txtNombre.Tag = null;
            btnGuardar.Text = "Guardar";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del cliente es obligatorio.");
                return;
            }

           
            Cliente c = new Cliente
            {
                Nombre = txtNombre.Text,
                DNI = txtDni.Text,
                Telefono = txtTelefono.Text
            };

            
            if (txtNombre.Tag != null)
            {
               
                c.Id = (int)txtNombre.Tag;
                repo.Actualizar(c);
                MessageBox.Show("Cliente actualizado correctamente");
            }
            else
            {
                
                repo.Guardar(c);
                MessageBox.Show("Cliente registrado correctamente");
            }

            
            CargarClientes();
            btnLimpiar_Click(null, null);
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                
                txtNombre.Tag = dgvClientes.Rows[e.RowIndex].Cells["Id"].Value;

                
                txtNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDni.Text = dgvClientes.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                txtTelefono.Text = dgvClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();

                
                btnGuardar.Text = "Actualizar";
            }
        }
    }
}
