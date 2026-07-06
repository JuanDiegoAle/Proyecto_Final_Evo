using System;

namespace ProyectoVentas
{
    partial class FormDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTotalVendidoTitulo = new System.Windows.Forms.Label();
            this.lblTotalVendido = new System.Windows.Forms.Label();
            this.lblMejorVendedorTitulo = new System.Windows.Forms.Label();
            this.lblMejorVendedor = new System.Windows.Forms.Label();
            this.chartVendedores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMetodoPago = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMetodoPago)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(24, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(430, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DASHBOARD DE INDICADORES";
            // 
            // lblTotalVendidoTitulo
            // 
            this.lblTotalVendidoTitulo.AutoSize = true;
            this.lblTotalVendidoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVendidoTitulo.Location = new System.Drawing.Point(30, 80);
            this.lblTotalVendidoTitulo.Name = "lblTotalVendidoTitulo";
            this.lblTotalVendidoTitulo.Size = new System.Drawing.Size(107, 20);
            this.lblTotalVendidoTitulo.TabIndex = 1;
            this.lblTotalVendidoTitulo.Text = "Total Vendido";
            // 
            // lblTotalVendido
            // 
            this.lblTotalVendido.AutoSize = true;
            this.lblTotalVendido.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVendido.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalVendido.Location = new System.Drawing.Point(26, 110);
            this.lblTotalVendido.Name = "lblTotalVendido";
            this.lblTotalVendido.Size = new System.Drawing.Size(126, 37);
            this.lblTotalVendido.TabIndex = 2;
            this.lblTotalVendido.Text = "S/ 0.00";
            // 
            // lblMejorVendedorTitulo
            // 
            this.lblMejorVendedorTitulo.AutoSize = true;
            this.lblMejorVendedorTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMejorVendedorTitulo.Location = new System.Drawing.Point(30, 180);
            this.lblMejorVendedorTitulo.Name = "lblMejorVendedorTitulo";
            this.lblMejorVendedorTitulo.Size = new System.Drawing.Size(122, 20);
            this.lblMejorVendedorTitulo.TabIndex = 3;
            this.lblMejorVendedorTitulo.Text = "Mejor Vendedor";
            // 
            // lblMejorVendedor
            // 
            this.lblMejorVendedor.AutoSize = true;
            this.lblMejorVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMejorVendedor.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblMejorVendedor.Location = new System.Drawing.Point(26, 210);
            this.lblMejorVendedor.Name = "lblMejorVendedor";
            this.lblMejorVendedor.Size = new System.Drawing.Size(355, 37);
            this.lblMejorVendedor.TabIndex = 4;
            this.lblMejorVendedor.Text = "Sin ventas registradas";
            // 
            // chartVendedores
            // 
            chartArea1.Name = "ChartArea1";
            this.chartVendedores.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVendedores.Legends.Add(legend1);
            this.chartVendedores.Location = new System.Drawing.Point(525, 256);
            this.chartVendedores.Name = "chartVendedores";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartVendedores.Series.Add(series1);
            this.chartVendedores.Size = new System.Drawing.Size(300, 300);
            this.chartVendedores.TabIndex = 5;
            this.chartVendedores.Text = "chart1";
            this.chartVendedores.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chartMetodoPago
            // 
            chartArea2.Name = "ChartArea1";
            this.chartMetodoPago.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartMetodoPago.Legends.Add(legend2);
            this.chartMetodoPago.Location = new System.Drawing.Point(81, 256);
            this.chartMetodoPago.Name = "chartMetodoPago";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartMetodoPago.Series.Add(series2);
            this.chartMetodoPago.Size = new System.Drawing.Size(300, 300);
            this.chartMetodoPago.TabIndex = 6;
            this.chartMetodoPago.Text = "chart2";
            this.chartMetodoPago.Click += new System.EventHandler(this.chartMetodoPago_Click_1);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 590);
            this.Controls.Add(this.chartMetodoPago);
            this.Controls.Add(this.chartVendedores);
            this.Controls.Add(this.lblMejorVendedor);
            this.Controls.Add(this.lblMejorVendedorTitulo);
            this.Controls.Add(this.lblTotalVendido);
            this.Controls.Add(this.lblTotalVendidoTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - KPIs";
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMetodoPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void chartMetodoPago_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void chartVendedores_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotalVendidoTitulo;
        private System.Windows.Forms.Label lblTotalVendido;
        private System.Windows.Forms.Label lblMejorVendedorTitulo;
        private System.Windows.Forms.Label lblMejorVendedor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVendedores;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMetodoPago;
    }
}
