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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(txtRuc.Text) || string.IsNullOrWhiteSpace(txtRazonSocial.Text))
                {
                    MessageBox.Show("El RUC y la Razón Social son obligatorios.");
                    return;
                }

                Proveedor p = new Proveedor
                {
                    Ruc = txtRuc.Text,
                    RazonSocial = txtRazonSocial.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                repo.Registrar(p);
                MessageBox.Show("Proveedor registrado correctamente.");

                txtRuc.Text = ""; txtRazonSocial.Text = ""; txtTelefono.Text = ""; txtDireccion.Text = "";
                CargarProveedores();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {
                if (dgvProveedores.SelectedRows.Count > 0)
                {
                    int idSeleccionado = (int)dgvProveedores.SelectedRows[0].Cells["Id"].Value;
                    repo.Eliminar(idSeleccionado);
                    MessageBox.Show("Proveedor eliminado.");
                    CargarProveedores();
                }
                else
                {
                    MessageBox.Show("Seleccione toda la fila del proveedor a eliminar.");
                }
            }
        }
    }
}