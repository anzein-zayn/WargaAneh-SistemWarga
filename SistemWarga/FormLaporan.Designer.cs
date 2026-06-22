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
            this.cmbTipeData = new System.Windows.Forms.ComboBox();
            this.btnTampil = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.cmbJenisLaporan = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTipeData
            // 
            this.cmbTipeData.FormattingEnabled = true;
            this.cmbTipeData.Location = new System.Drawing.Point(343, 169);
            this.cmbTipeData.Name = "cmbTipeData";
            this.cmbTipeData.Size = new System.Drawing.Size(234, 24);
            this.cmbTipeData.TabIndex = 4;
            // 
            // btnTampil
            // 
            this.btnTampil.BackColor = System.Drawing.Color.Transparent;
            this.btnTampil.ForeColor = System.Drawing.Color.DarkRed;
            this.btnTampil.Location = new System.Drawing.Point(583, 160);
            this.btnTampil.Name = "btnTampil";
            this.btnTampil.Size = new System.Drawing.Size(139, 41);
            this.btnTampil.TabIndex = 3;
            this.btnTampil.Text = "Tampilkan";
            this.btnTampil.UseVisualStyleBackColor = false;
            this.btnTampil.Click += new System.EventHandler(this.btnTampil_Click);
            // 
            // btnCetak
            // 
            this.btnCetak.BackColor = System.Drawing.Color.Transparent;
            this.btnCetak.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCetak.Location = new System.Drawing.Point(728, 160);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(139, 41);
            this.btnCetak.TabIndex = 5;
            this.btnCetak.Text = "Cetak Laporan";
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvLaporan.Location = new System.Drawing.Point(12, 232);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.RowHeadersWidth = 51;
            this.dgvLaporan.Size = new System.Drawing.Size(1154, 478);
            this.dgvLaporan.TabIndex = 2;
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.BackColor = System.Drawing.Color.DarkRed;
            this.lblJudul.Font = new System.Drawing.Font("Geometr212 BkCn BT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblJudul.Location = new System.Drawing.Point(313, 9);
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
            this.lblInfo.Size = new System.Drawing.Size(0, 16);
            this.lblInfo.TabIndex = 0;
            // 
            // cmbJenisLaporan
            // 
            this.cmbJenisLaporan.FormattingEnabled = true;
            this.cmbJenisLaporan.Location = new System.Drawing.Point(82, 169);
            this.cmbJenisLaporan.Name = "cmbJenisLaporan";
            this.cmbJenisLaporan.Size = new System.Drawing.Size(234, 24);
            this.cmbJenisLaporan.TabIndex = 4;
            this.cmbJenisLaporan.SelectedIndexChanged += new System.EventHandler(this.cmbJenisLaporan_SelectedIndexChanged);
            // 
            // FormLaporan
            // 
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1178, 722);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblJudul);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.btnTampil);
            this.Controls.Add(this.cmbJenisLaporan);
            this.Controls.Add(this.cmbTipeData);
            this.Font = new System.Drawing.Font("Geometr212 BkCn BT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "FormLaporan";
            this.Text = "Form Laporan";
            this.Load += new System.EventHandler(this.FormLaporan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipeData;
        private System.Windows.Forms.Button btnTampil;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox cmbJenisLaporan;
    }
}