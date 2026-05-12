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

namespace ProyectoVentas
{
    public partial class FormPedido : Form
    {
        private string rol;
        private string usuario;
        private PagoService pagoService=new PagoService();
        private PedidoRepository repo=new PedidoRepository();

        public FormPedido(string rolUsuario, string nombreUsuario)
        {
            InitializeComponent();
            rol = rolUsuario;
            usuario = nombreUsuario;

            cmbPago.Items.Add("Yape");
            cmbPago.Items.Add("Tarjeta");

            dgvPedidos.DataSource = repo.ObtenerTodos();

            cmbFiltro.Items.Add("Yape");
            cmbFiltro.Items.Add("Tarjeta");
            cmbFiltro.Items.Add("Todos");
        }

        private void FormPedido_Load(object sender, EventArgs e)
        {
            if (rol == "vendedor")
            {
                btnEliminar.Visible = false;
                btnTotal.Visible = false;
                btnAbrirGrafico.Visible = false;
                btnExportar.Visible = false;
                btnEditar.Visible = false;
                lblTotal.Visible=false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotal.Text))
            {
                MessageBox.Show("Ingrese un Monto");
                return;
            }

            decimal total;
            if (!decimal.TryParse(txtTotal.Text, out total))
            {
                MessageBox.Show("Monto Invalido");
                return;
            }

            if (total <= 0)
            {
                MessageBox.Show("El monto no puede ser negativo o cero");
                return;
            }

            IPago metodoPago;
            switch (cmbPago.Text)
            {
                case "Yape":
                    metodoPago = new PagoYape();
                    break;
                case "Tarjeta":
                    metodoPago = new PagoTarjeta();
                    break;
                default:
                    MessageBox.Show("Seleccione un Método de Pago");
                    return;
            }

            bool exito = pagoService.Procesar(metodoPago, total);

            if (!exito) return;


            if (txtTotal.Tag != null) // MODO EDITAR
            {
                int id = (int)txtTotal.Tag;

                Pedido pedidoEditado = new Pedido
                {
                    Id = id,
                    Total = total,
                    MetodoPago = metodoPago.Nombre
                };

                repo.Actualizar(pedidoEditado);

                MessageBox.Show("Pedido actualizado");

                txtTotal.Tag = null; // limpiar modo edición
            }
            else // MODO CREAR
            {
                Pedido pedido = new Pedido
                {
                    Total = total,
                    MetodoPago = metodoPago.Nombre,
                    Usuario = usuario
                };

                repo.Guardar(pedido);

                MessageBox.Show("Pedido guardado correctamente");
            }

           
            txtTotal.Text = "";
            cmbPago.SelectedIndex = -1;
            dgvPedidos.DataSource = repo.ObtenerTodos();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvPedidos.DataSource = repo.ObtenerTodos();
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pedido");
                return;
            }

            int id = (int)dgvPedidos.CurrentRow.Cells["Id"].Value;

            DialogResult resultado = MessageBox.Show(
                "¿Desea eliminar este pedido?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning

            );
            
            if ( resultado == DialogResult.Yes )
            {
                repo.Eliminar( id );
                MessageBox.Show("Pedido Eliminado");
                dgvPedidos.DataSource=repo.ObtenerTodos();
            
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            decimal total = repo.ObtenerTotalVendido();
            lblTotal.Text = "Total Vendido: S/ " + total;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFiltro.Text))
            {
                MessageBox.Show("Seleccione un Filtro");
                return;
            }

            if (cmbFiltro.Text == "Todos")
            {
                dgvPedidos.DataSource= repo.ObtenerTodos();
            }
            else
            {
                dgvPedidos.DataSource = repo.FiltarPorMetodo(cmbFiltro.Text);
            }
            

            dgvPedidos.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAbrirGrafico_Click(object sender, EventArgs e)
        {
            FormGrafico grafico=new FormGrafico();

            grafico.ShowDialog();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Excel.Application excel= new Excel.Application();

            Excel.Workbook workbook = excel.Workbooks.Add();

            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dgvPedidos.Columns[i].HeaderText;
            }

            for (int i = 0; i < dgvPedidos.Rows.Count; i++)
            {
                for (int j = 0; j < dgvPedidos.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgvPedidos.Rows[i].Cells[j].Value?.ToString();
                }
            }
            worksheet.Columns.AutoFit();
            excel.Visible = true;

            MessageBox.Show("Exportacion completada");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pedido");
                return;
            }

            int id = (int)dgvPedidos.CurrentRow.Cells["Id"].Value;
            decimal total = (decimal)dgvPedidos.CurrentRow.Cells["Total"].Value;
            string metodo = dgvPedidos.CurrentRow.Cells["MetodoPago"].Value.ToString();

            txtTotal.Text = total.ToString();
            cmbPago.Text = metodo;

            txtTotal.Tag = id;

            btnProcesar.Text = "Actualizar"; 

            MessageBox.Show("Modo edición activado");
        }
    }
}
