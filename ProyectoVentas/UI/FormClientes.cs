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
        public string ClienteSeleccionado { get; private set; }
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
                // Modo Edición
                c.Id = (int)txtNombre.Tag;
                repo.Actualizar(c);
                MessageBox.Show("Cliente actualizado correctamente");
            }
            else
            {
                // Modo Nuevo
                repo.Guardar(c);
                MessageBox.Show("Cliente registrado correctamente");
            }

            this.ClienteSeleccionado = txtNombre.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificamos si el usuario seleccionó una fila completa
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Pedimos confirmación para evitar borrados accidentales
                DialogResult respuesta = MessageBox.Show("¿Estás seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    int idSeleccionado = (int)dgvClientes.SelectedRows[0].Cells["Id"].Value;
                    repo.Eliminar(idSeleccionado);
                    MessageBox.Show("Cliente eliminado correctamente.");

                    // Refrescamos la tabla y limpiamos
                    CargarClientes();
                    btnLimpiar_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione toda la fila del cliente que desea eliminar.");
            }
        }
    }
}
