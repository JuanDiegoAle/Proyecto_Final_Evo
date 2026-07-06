using Microsoft.Office.Interop.Excel;
using ProyectoVentas.Interfaces;
using ProyectoVentas.Models;
using ProyectoVentas.Repository;
using ProyectoVentas.Service;
using ProyectoVentas.Service.Pagos;
using ProyectoVentas.Services;
using ProyectoVentas.UI;
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
        private IPagoService pagoService;
        private IPedidoRepository repo;
        private IProductoRespository productoRepo;
        private IClienteRepository clienteRepo;

        public FormPedido(string rolUsuario, string nombreUsuario,IPedidoRepository repository,IPagoService pagoSrv,IProductoRespository productoRepo)
        {
            InitializeComponent();
            rol = rolUsuario;
            usuario = nombreUsuario;
            this.productoRepo=productoRepo;
        

            repo = repository;
            pagoService = pagoSrv;

            txtCantidad.TextChanged += txtCantidad_TextChanged;

            cmbPago.Items.Add("Yape");
            cmbPago.Items.Add("Tarjeta");

            dgvPedidos.DataSource = repo.ObtenerTodos();

            cmbFiltro.Items.Add("Yape");
            cmbFiltro.Items.Add("Tarjeta");
            cmbFiltro.Items.Add("Todos");

            this.Load += FormPedido_Load;
            comboProducto.SelectedIndexChanged += comboProducto_SelectedIndexChanged;
        }

        private void FormPedido_Load(object sender, EventArgs e)
        {
           
            CargarProductos();

            if (rol == "Vendedor")
            {
                btnEliminar.Enabled = false;
                btnTotal.Enabled = false;
                btnAbrirGrafico.Enabled = false;
                btnExportar.Enabled = false;
                btnEditar.Enabled = false;
                lblTotal.Enabled=false;
            }
        }
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio.Tag == null) return;

            decimal precio = (decimal)txtPrecio.Tag;
            int cantidad;

            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                txtTotal.Text = "";
                return;
            }

            decimal total = precio * cantidad;

            txtTotal.Text = total.ToString("0.00");
        }
        private void CargarProductos()
        {
            var lista = productoRepo.ObtenerTodos();

            comboProducto.DataSource = lista;
            comboProducto.DisplayMember = "Nombre";
            comboProducto.ValueMember = "Id";
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
                MessageBox.Show("Ingrese un monto válido mayor a 0",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
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
                    MetodoPago = metodoPago.Nombre,
                    Cliente = txtCliente.Text,
                    Usuario = usuario
                };

                repo.Actualizar(pedidoEditado);

                MessageBox.Show("Pedido actualizado");

                txtTotal.Tag = null; // limpiar modo edición
                btnProcesar.Text = "Procesar";  
            }
            else // MODO CREAR
            {
                if (string.IsNullOrWhiteSpace(txtCliente.Text))
                {
                    MessageBox.Show("Ingrese el nombre del cliente");
                    return;
                }

                Pedido pedido = new Pedido
                {
                    Cliente = txtCliente.Text, 
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
            FormDashboard grafico=new FormDashboard(repo);

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
            string cliente = dgvPedidos.CurrentRow.Cells["Cliente"].Value.ToString(); 

            txtTotal.Text = total.ToString();
            cmbPago.Text = metodo;
            txtCliente.Text = cliente; 

            txtTotal.Tag = id;

            btnProcesar.Text = "Actualizar";

            MessageBox.Show("Modo edición activado");
        }

        private void comboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboProducto.SelectedItem is Producto p)
            {
                txtPrecio.Text = p.Precio.ToString("0.00");
                txtStock.Text = p.Stock.ToString();

                
                txtPrecio.Tag = p.Precio;

                
                txtCantidad_TextChanged(null, null);
            }
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            IDevolucionRepository repoDev = new DevolucionRepository();

            FormDevolucion form = new FormDevolucion(rol, usuario, repoDev);
            form.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            // Instanciamos el repositorio específico de clientes
            IClienteRepository repoClientes = new Repository.ClienteRepository();

            // Creamos la ventana de clientes pasando el repositorio por el constructor
            FormClientes formularioClientes = new FormClientes(repoClientes);

            // Abrimos la ventana de forma modal y verificamos si se guardó un cliente nuevo
            if (formularioClientes.ShowDialog() == DialogResult.OK)
            {
                // Atrapamos el dato de la variable pública y lo ponemos en la caja de texto
                txtCliente.Text = formularioClientes.ClienteSeleccionado;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Instanciamos el repositorio específico de productos
            IProductoRespository repoProductos = new Repository.ProductoRepository();

            // Creamos la ventana de productos pasando el repositorio por el constructor
            FormProductos formularioProductos = new FormProductos(repoProductos);

            // Abrimos la ventana de forma modal
            formularioProductos.ShowDialog();
            CargarProductos();
        }


    }
}
