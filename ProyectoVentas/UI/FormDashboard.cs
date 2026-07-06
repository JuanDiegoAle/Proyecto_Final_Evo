using ProyectoVentas.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoVentas
{
    public partial class FormDashboard : Form
    {
        private IPedidoRepository repo;

        public FormDashboard(IPedidoRepository repository)
        {
            InitializeComponent();
            repo = repository;
            this.Load += FormDashboard_Load;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            CargarKPIs();
        }

        private void CargarKPIs()
        {
            decimal total = repo.ObtenerTotalVendido();
            lblTotalVendido.Text = "S/ " + total.ToString("0.00");

            var ventasPorVendedor = repo.ObtenerVentasPorVendedor();
            if (ventasPorVendedor.Count > 0)
            {
                var mejorVendedor = ventasPorVendedor.OrderByDescending(v => v.Value).First();
                lblMejorVendedor.Text = mejorVendedor.Key + " (S/ " + mejorVendedor.Value.ToString("0.00") + ")";
            }
            else
            {
                lblMejorVendedor.Text = "Sin ventas registradas";
            }
        }
    }
}
