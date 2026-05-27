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
    public partial class FormDevolucion : Form
    {
        string rol;
        string usuario;
        IDevolucionRepository repo;
        public FormDevolucion(string rolUsuario,string nombreUsuario,IDevolucionRepository repository)
        {
            InitializeComponent();

            rol = rolUsuario;
            usuario = nombreUsuario;
            repo = repository;

            this.Load += FormDevolucion_Load;
        }

        private void FormDevolucion_Load(object sender, EventArgs e)
        {
            dgvDevoluciones.DataSource = repo.ObtenerTodos();

            if (rol == "vendedor")
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int pedidoId;

            if (!int.TryParse(txtPedidoId.Text, out pedidoId))
            {
                MessageBox.Show("Pedido inválido");
                return;
            }

            if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                MessageBox.Show("Ingrese motivo");
                return;
            }

            if (txtMotivo.Tag != null)
            {
                int id = (int)txtMotivo.Tag;

                Devolucion d = new Devolucion
                {
                    Id = id,
                    PedidoId = pedidoId,
                    Motivo = txtMotivo.Text,
                    Fecha = DateTime.Now,
                    Usuario = usuario
                };

                repo.Actualizar(d);

                txtMotivo.Tag = null;

                MessageBox.Show("Actualizado");
            }
            else 
            {
                Devolucion d = new Devolucion
                {
                    PedidoId = pedidoId,
                    Motivo = txtMotivo.Text,
                    Fecha = DateTime.Now,
                    Usuario = usuario
                };

                repo.Guardar(d);

                MessageBox.Show("Registrado");
            }

            dgvDevoluciones.DataSource = repo.ObtenerTodos();

            txtPedidoId.Text = "";
            txtMotivo.Text = "";


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(rol == "vendedor")
    {
                MessageBox.Show("No tienes permiso para editar");
                return;
            }

            if (dgvDevoluciones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una devolución");
                return;
            }

            int id = (int)dgvDevoluciones.CurrentRow.Cells["Id"].Value;
            int pedidoId = (int)dgvDevoluciones.CurrentRow.Cells["PedidoId"].Value;
            string motivo = dgvDevoluciones.CurrentRow.Cells["Motivo"].Value.ToString();

            txtPedidoId.Text = pedidoId.ToString();
            txtMotivo.Text = motivo;

            txtMotivo.Tag = id;

            btnRegistrar.Text = "Actualizar";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (rol == "vendedor")
            {
                MessageBox.Show("No tienes permiso para eliminar");
                return;
            }

            if (dgvDevoluciones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una devolución");
                return;
            }

            int id = (int)dgvDevoluciones.CurrentRow.Cells["Id"].Value;

            repo.Eliminar(id);

            dgvDevoluciones.DataSource = repo.ObtenerTodos();

            MessageBox.Show("Eliminado");
        }
    }
}
