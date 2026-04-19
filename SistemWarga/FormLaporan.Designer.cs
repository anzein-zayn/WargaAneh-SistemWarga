namespace SistemWarga
{
    partial class FormLaporan
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cmbLaporan = new System.Windows.Forms.ComboBox();
            this.btnTampil = new System.Windows.Forms.Button();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLaporan
            // 
            this.cmbLaporan.FormattingEnabled = true;
            this.cmbLaporan.Location = new System.Drawing.Point(47, 128);
            this.cmbLaporan.Name = "cmbLaporan";
            this.cmbLaporan.Size = new System.Drawing.Size(234, 36);
            this.cmbLaporan.TabIndex = 4;
            // 
            // btnTampil
            // 
            this.btnTampil.BackColor = System.Drawing.Color.Transparent;
            this.btnTampil.ForeColor = System.Drawing.Color.DarkRed;
            this.btnTampil.Location = new System.Drawing.Point(317, 125);
            this.btnTampil.Name = "btnTampil";
            this.btnTampil.Size = new System.Drawing.Size(139, 41);
            this.btnTampil.TabIndex = 3;
            this.btnTampil.Text = "Tampilkan";
            this.btnTampil.UseVisualStyleBackColor = false;
            this.btnTampil.Click += new System.EventHandler(this.btnTampil_Click);
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(47, 232);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.RowHeadersWidth = 51;
            this.dgvLaporan.Size = new System.Drawing.Size(600, 234);
            this.dgvLaporan.TabIndex = 2;
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.BackColor = System.Drawing.Color.DarkRed;
            this.lblJudul.Font = new System.Drawing.Font("Geometr212 BkCn BT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblJudul.Location = new System.Drawing.Point(71, 19);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(577, 75);
            this.lblJudul.TabIndex = 1;
            this.lblJudul.Text = "Laporan Penduduk";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(42, 232);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 28);
            this.lblInfo.TabIndex = 0;
            // 
            // FormLaporan
            // 
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(677, 478);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblJudul);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.btnTampil);
            this.Controls.Add(this.cmbLaporan);
            this.Font = new System.Drawing.Font("Geometr212 BkCn BT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.AliceBlue;
            this.Name = "FormLaporan";
            this.Text = "Form Laporan";
            this.Load += new System.EventHandler(this.FormLaporan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLaporan;
        private System.Windows.Forms.Button btnTampil;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblInfo;
    }
}