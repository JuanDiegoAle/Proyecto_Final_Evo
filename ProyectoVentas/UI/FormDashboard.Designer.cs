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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTotalVendidoTitulo = new System.Windows.Forms.Label();
            this.lblTotalVendido = new System.Windows.Forms.Label();
            this.lblMejorVendedorTitulo = new System.Windows.Forms.Label();
            this.lblMejorVendedor = new System.Windows.Forms.Label();
            this.chartMetodoPago = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVendedores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartMetodoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedores)).BeginInit();
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
            // chartMetodoPago
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMetodoPago.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMetodoPago.Legends.Add(legend1);
            this.chartMetodoPago.Location = new System.Drawing.Point(30, 270);
            this.chartMetodoPago.Name = "chartMetodoPago";
            this.chartMetodoPago.Size = new System.Drawing.Size(380, 220);
            this.chartMetodoPago.TabIndex = 5;
            this.chartMetodoPago.Text = "chartMetodoPago";
            this.chartMetodoPago.Click += new System.EventHandler(this.chartMetodoPago_Click);
            // 
            // chartVendedores
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVendedores.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVendedores.Legends.Add(legend2);
            this.chartVendedores.Location = new System.Drawing.Point(430, 270);
            this.chartVendedores.Name = "chartVendedores";
            this.chartVendedores.Size = new System.Drawing.Size(380, 220);
            this.chartVendedores.TabIndex = 6;
            this.chartVendedores.Text = "chartVendedores";
            this.chartVendedores.Click += new System.EventHandler(this.chartVendedores_Click);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 510);
            this.Controls.Add(this.chartVendedores);
            this.Controls.Add(this.chartMetodoPago);
            this.Controls.Add(this.lblMejorVendedor);
            this.Controls.Add(this.lblMejorVendedorTitulo);
            this.Controls.Add(this.lblTotalVendido);
            this.Controls.Add(this.lblTotalVendidoTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - KPIs";
            ((System.ComponentModel.ISupportInitialize)(this.chartMetodoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotalVendidoTitulo;
        private System.Windows.Forms.Label lblTotalVendido;
        private System.Windows.Forms.Label lblMejorVendedorTitulo;
        private System.Windows.Forms.Label lblMejorVendedor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMetodoPago;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVendedores;
    }
}
