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
            this.cmbLaporan.Location = new System.Drawing.Point(30, 70);
            this.cmbLaporan.Name = "cmbLaporan";
            this.cmbLaporan.Size = new System.Drawing.Size(220, 24);
            this.cmbLaporan.TabIndex = 4;
            // 
            // btnTampil
            // 
            this.btnTampil.Location = new System.Drawing.Point(270, 70);
            this.btnTampil.Name = "btnTampil";
            this.btnTampil.Size = new System.Drawing.Size(100, 25);
            this.btnTampil.TabIndex = 3;
            this.btnTampil.Text = "Tampilkan";
            this.btnTampil.UseVisualStyleBackColor = true;
            this.btnTampil.Click += new System.EventHandler(this.btnTampil_Click);
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(30, 120);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.RowHeadersWidth = 51;
            this.dgvLaporan.Size = new System.Drawing.Size(600, 250);
            this.dgvLaporan.TabIndex = 2;
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblJudul.Location = new System.Drawing.Point(25, 20);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(216, 29);
            this.lblJudul.TabIndex = 1;
            this.lblJudul.Text = "Laporan Penduduk";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(30, 380);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 16);
            this.lblInfo.TabIndex = 0;
            // 
            // FormLaporan
            // 
            this.ClientSize = new System.Drawing.Size(680, 420);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblJudul);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.btnTampil);
            this.Controls.Add(this.cmbLaporan);
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