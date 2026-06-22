namespace SistemWarga
{
    partial class FormDashboardPetugas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnWarga = new System.Windows.Forms.Button();
            this.btnKeluarga = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chartDashboard = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbPilihanChart = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpTahunSurat = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWarga
            // 
            this.btnWarga.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWarga.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnWarga.Location = new System.Drawing.Point(626, 479);
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
            this.btnKeluarga.Location = new System.Drawing.Point(896, 479);
            this.btnKeluarga.Name = "btnKeluarga";
            this.btnKeluarga.Size = new System.Drawing.Size(178, 82);
            this.btnKeluarga.TabIndex = 0;
            this.btnKeluarga.Text = "Kelola Data Kartu Keluarga";
            this.btnKeluarga.UseVisualStyleBackColor = false;
            this.btnKeluarga.Click += new System.EventHandler(this.btnKartuKel_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkGreen;
            this.button3.Location = new System.Drawing.Point(333, 479);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 82);
            this.button3.TabIndex = 0;
            this.button3.Text = "Kelola Surat ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnSurat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Geometr706 BlkCn BT", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 144);
            this.label1.TabIndex = 1;
            this.label1.Text = "DASHBOARD\r\n PETUGAS\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartDashboard
            // 
            chartArea3.Name = "ChartArea1";
            this.chartDashboard.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartDashboard.Legends.Add(legend3);
            this.chartDashboard.Location = new System.Drawing.Point(333, 9);
            this.chartDashboard.Name = "chartDashboard";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartDashboard.Series.Add(series3);
            this.chartDashboard.Size = new System.Drawing.Size(741, 464);
            this.chartDashboard.TabIndex = 2;
            this.chartDashboard.Text = "chart1";
            // 
            // cmbPilihanChart
            // 
            this.cmbPilihanChart.FormattingEnabled = true;
            this.cmbPilihanChart.Location = new System.Drawing.Point(62, 190);
            this.cmbPilihanChart.Name = "cmbPilihanChart";
            this.cmbPilihanChart.Size = new System.Drawing.Size(233, 24);
            this.cmbPilihanChart.TabIndex = 3;
            this.cmbPilihanChart.SelectedIndexChanged += new System.EventHandler(this.cmbPilihanChart_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(114, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Load Chart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLoadChart_Click);
            // 
            // dtpTahunSurat
            // 
            this.dtpTahunSurat.Location = new System.Drawing.Point(62, 220);
            this.dtpTahunSurat.Name = "dtpTahunSurat";
            this.dtpTahunSurat.Size = new System.Drawing.Size(233, 22);
            this.dtpTahunSurat.TabIndex = 5;
            // 
            // FormDashboardPetugas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1086, 571);
            this.Controls.Add(this.dtpTahunSurat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbPilihanChart);
            this.Controls.Add(this.chartDashboard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnKeluarga);
            this.Controls.Add(this.btnWarga);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "FormDashboardPetugas";
            this.Text = "FormDashboardPetugas";
            this.Load += new System.EventHandler(this.FormDashboardPetugas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWarga;
        private System.Windows.Forms.Button btnKeluarga;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDashboard;
        private System.Windows.Forms.ComboBox cmbPilihanChart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpTahunSurat;
    }
}