namespace SistemWarga
{
    partial class FormDashboardAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnWarga = new System.Windows.Forms.Button();
            this.btnKeluarga = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chartDashboard = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbPilihanChart = new System.Windows.Forms.ComboBox();
            this.dtpTahunSurat = new System.Windows.Forms.DateTimePicker();
            this.btnSurat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWarga
            // 
            this.btnWarga.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWarga.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnWarga.Location = new System.Drawing.Point(809, 447);
            this.btnWarga.Name = "btnWarga";
            this.btnWarga.Size = new System.Drawing.Size(178, 82);
            this.btnWarga.TabIndex = 0;
            this.btnWarga.Text = "Kelola Data Warga";
            this.btnWarga.UseVisualStyleBackColor = true;
            this.btnWarga.Click += new System.EventHandler(this.btnWarga_Click);
            // 
            // btnKeluarga
            // 
            this.btnKeluarga.BackColor = System.Drawing.Color.Transparent;
            this.btnKeluarga.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluarga.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnKeluarga.Location = new System.Drawing.Point(563, 447);
            this.btnKeluarga.Name = "btnKeluarga";
            this.btnKeluarga.Size = new System.Drawing.Size(178, 82);
            this.btnKeluarga.TabIndex = 0;
            this.btnKeluarga.Text = "Kelola Data Kartu Keluarga";
            this.btnKeluarga.UseVisualStyleBackColor = false;
            this.btnKeluarga.Click += new System.EventHandler(this.btnKartuKel_Click);
            // 
            // btnLaporan
            // 
            this.btnLaporan.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaporan.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnLaporan.Location = new System.Drawing.Point(321, 447);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(178, 82);
            this.btnLaporan.TabIndex = 0;
            this.btnLaporan.Text = "Laporan";
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Geometr706 BlkCn BT", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(38, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 104);
            this.label1.TabIndex = 1;
            this.label1.Text = "DASHBOARD\r\nADMIN\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartDashboard
            // 
            chartArea2.Name = "ChartArea1";
            this.chartDashboard.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDashboard.Legends.Add(legend2);
            this.chartDashboard.Location = new System.Drawing.Point(296, 34);
            this.chartDashboard.Name = "chartDashboard";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDashboard.Series.Add(series2);
            this.chartDashboard.Size = new System.Drawing.Size(691, 396);
            this.chartDashboard.TabIndex = 2;
            this.chartDashboard.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load Chart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLoadChart_Click);
            // 
            // cmbPilihanChart
            // 
            this.cmbPilihanChart.FormattingEnabled = true;
            this.cmbPilihanChart.Location = new System.Drawing.Point(47, 151);
            this.cmbPilihanChart.Name = "cmbPilihanChart";
            this.cmbPilihanChart.Size = new System.Drawing.Size(200, 24);
            this.cmbPilihanChart.TabIndex = 4;
            this.cmbPilihanChart.SelectedIndexChanged += new System.EventHandler(this.cmbPilihanChart_SelectedIndexChanged);
            // 
            // dtpTahunSurat
            // 
            this.dtpTahunSurat.Location = new System.Drawing.Point(47, 191);
            this.dtpTahunSurat.Name = "dtpTahunSurat";
            this.dtpTahunSurat.Size = new System.Drawing.Size(200, 22);
            this.dtpTahunSurat.TabIndex = 5;
            // 
            // btnSurat
            // 
            this.btnSurat.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSurat.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnSurat.Location = new System.Drawing.Point(86, 447);
            this.btnSurat.Name = "btnSurat";
            this.btnSurat.Size = new System.Drawing.Size(178, 82);
            this.btnSurat.TabIndex = 0;
            this.btnSurat.Text = "Kelola Surat ";
            this.btnSurat.UseVisualStyleBackColor = true;
            this.btnSurat.Click += new System.EventHandler(this.btnSurat_Click);
            // 
            // FormDashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1050, 571);
            this.Controls.Add(this.dtpTahunSurat);
            this.Controls.Add(this.cmbPilihanChart);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chartDashboard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSurat);
            this.Controls.Add(this.btnLaporan);
            this.Controls.Add(this.btnKeluarga);
            this.Controls.Add(this.btnWarga);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FormDashboardAdmin";
            this.Text = "FormDashboardAdmin";
            this.Load += new System.EventHandler(this.FormDashboardAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWarga;
        private System.Windows.Forms.Button btnKeluarga;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDashboard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbPilihanChart;
        private System.Windows.Forms.DateTimePicker dtpTahunSurat;
        private System.Windows.Forms.Button btnSurat;
    }
}