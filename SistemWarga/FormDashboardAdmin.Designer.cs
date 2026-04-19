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
            this.btnWarga = new System.Windows.Forms.Button();
            this.btnKeluarga = new System.Windows.Forms.Button();
            this.btnSurat = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWarga
            // 
            this.btnWarga.Location = new System.Drawing.Point(320, 154);
            this.btnWarga.Name = "btnWarga";
            this.btnWarga.Size = new System.Drawing.Size(178, 52);
            this.btnWarga.TabIndex = 0;
            this.btnWarga.Text = "Kelola Data Warga";
            this.btnWarga.UseVisualStyleBackColor = true;
            // 
            // btnKeluarga
            // 
            this.btnKeluarga.Location = new System.Drawing.Point(320, 221);
            this.btnKeluarga.Name = "btnKeluarga";
            this.btnKeluarga.Size = new System.Drawing.Size(178, 52);
            this.btnKeluarga.TabIndex = 0;
            this.btnKeluarga.Text = "Kelola Data Kartu Keluarga";
            this.btnKeluarga.UseVisualStyleBackColor = true;
            // 
            // btnSurat
            // 
            this.btnSurat.Location = new System.Drawing.Point(320, 286);
            this.btnSurat.Name = "btnSurat";
            this.btnSurat.Size = new System.Drawing.Size(178, 52);
            this.btnSurat.TabIndex = 0;
            this.btnSurat.Text = "Kelola Surat ";
            this.btnSurat.UseVisualStyleBackColor = true;
            // 
            // btnLaporan
            // 
            this.btnLaporan.Location = new System.Drawing.Point(320, 355);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(178, 52);
            this.btnLaporan.TabIndex = 0;
            this.btnLaporan.Text = "Laporan Penduduk";
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // FormDashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 571);
            this.Controls.Add(this.btnLaporan);
            this.Controls.Add(this.btnSurat);
            this.Controls.Add(this.btnKeluarga);
            this.Controls.Add(this.btnWarga);
            this.Name = "FormDashboardAdmin";
            this.Text = "FormDashboardAdmin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWarga;
        private System.Windows.Forms.Button btnKeluarga;
        private System.Windows.Forms.Button btnSurat;
        private System.Windows.Forms.Button btnLaporan;
    }
}