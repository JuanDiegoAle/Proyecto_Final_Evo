using ProyectoVentas.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            CargarGraficos();
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

        private void CargarGraficos()
        {
            chartMetodoPago.Series.Clear();
            var seriePastel = chartMetodoPago.Series.Add("Pagos");
            seriePastel.ChartType = SeriesChartType.Pie;
            seriePastel.IsValueShownAsLabel = true;

            var datosPago = repo.ObtenerMetodosPagoEstadistica();
            foreach (var item in datosPago)
            {
                seriePastel.Points.AddXY(item.Key, item.Value);
            }

            chartVendedores.Series.Clear();
            var serieBarras = chartVendedores.Series.Add("Ventas Totales");
            serieBarras.ChartType = SeriesChartType.Column;
            serieBarras.IsValueShownAsLabel = true;

            var datosVendedor = repo.ObtenerVentasPorVendedor();
            foreach (var item in datosVendedor)
            {
                serieBarras.Points.AddXY(item.Key, item.Value);
            }
        }
    }
}
