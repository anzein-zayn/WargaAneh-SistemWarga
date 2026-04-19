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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnWarga
            // 
            this.btnWarga.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWarga.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnWarga.Location = new System.Drawing.Point(35, 233);
            this.btnWarga.Name = "btnWarga";
            this.btnWarga.Size = new System.Drawing.Size(178, 82);
            this.btnWarga.TabIndex = 0;
            this.btnWarga.Text = "Kelola Data Warga";
            this.btnWarga.UseVisualStyleBackColor = true;
            // 
            // btnKeluarga
            // 
            this.btnKeluarga.BackColor = System.Drawing.Color.Transparent;
            this.btnKeluarga.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluarga.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnKeluarga.Location = new System.Drawing.Point(300, 233);
            this.btnKeluarga.Name = "btnKeluarga";
            this.btnKeluarga.Size = new System.Drawing.Size(178, 82);
            this.btnKeluarga.TabIndex = 0;
            this.btnKeluarga.Text = "Kelola Data Kartu Keluarga";
            this.btnKeluarga.UseVisualStyleBackColor = false;
            // 
            // btnSurat
            // 
            this.btnSurat.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSurat.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnSurat.Location = new System.Drawing.Point(35, 402);
            this.btnSurat.Name = "btnSurat";
            this.btnSurat.Size = new System.Drawing.Size(178, 82);
            this.btnSurat.TabIndex = 0;
            this.btnSurat.Text = "Kelola Surat ";
            this.btnSurat.UseVisualStyleBackColor = true;
            // 
            // btnLaporan
            // 
            this.btnLaporan.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaporan.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnLaporan.Location = new System.Drawing.Point(300, 402);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(178, 82);
            this.btnLaporan.TabIndex = 0;
            this.btnLaporan.Text = "Laporan Penduduk";
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Geometr706 BlkCn BT", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(135, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 106);
            this.label1.TabIndex = 1;
            this.label1.Text = "DASHBOARD\r\nADMIN\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(527, 571);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLaporan);
            this.Controls.Add(this.btnSurat);
            this.Controls.Add(this.btnKeluarga);
            this.Controls.Add(this.btnWarga);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FormDashboardAdmin";
            this.Text = "FormDashboardAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWarga;
        private System.Windows.Forms.Button btnKeluarga;
        private System.Windows.Forms.Button btnSurat;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.Label label1;
    }
}