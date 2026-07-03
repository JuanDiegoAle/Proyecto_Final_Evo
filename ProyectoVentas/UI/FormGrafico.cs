using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ProyectoVentas.Repository;

namespace ProyectoVentas
{
    public partial class FormGrafico : Form
    {
        private PedidoRepository repo = new PedidoRepository();
        public FormGrafico()
        {
            InitializeComponent();
        }

        private void FormGrafico_Load(object sender, EventArgs e)
        {
            MostrarGrafico();
        }

        private void MostrarGrafico()
        {
            chartVentas.Series.Clear();

            Series serie = new Series("Ventas");

            serie.ChartType = SeriesChartType.Pie;

            var datos = repo.ObtenerCantidadPorMetodo();

            foreach (var item in datos)
            {
                DataPoint punto=new DataPoint();

                punto.AxisLabel=item.Key;

                punto.YValues = new double[] { item.Value };

                punto.Label =item.Key+" - " +item.Value + " ventas";

                serie.Points.Add(punto);
            }

            chartVentas.Series.Add(serie);
        }

        private void chartVentas_Click(object sender, EventArgs e)
        {

        }
    }
}
