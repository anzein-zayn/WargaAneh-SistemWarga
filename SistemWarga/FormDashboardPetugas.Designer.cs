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
            this.btnWarga = new System.Windows.Forms.Button();
            this.btnKeluarga = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.btnWarga.Click += new System.EventHandler(this.btnWarga_Click);
            // 
            // btnKeluarga
            // 
            this.btnKeluarga.Location = new System.Drawing.Point(320, 221);
            this.btnKeluarga.Name = "btnKeluarga";
            this.btnKeluarga.Size = new System.Drawing.Size(178, 52);
            this.btnKeluarga.TabIndex = 0;
            this.btnKeluarga.Text = "Kelola Data Kartu Keluarga";
            this.btnKeluarga.UseVisualStyleBackColor = true;
            this.btnKeluarga.Click += new System.EventHandler(this.btnKartuKel_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(320, 286);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 52);
            this.button3.TabIndex = 0;
            this.button3.Text = "Kelola Surat ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnSurat_Click);
            // 
            // FormDashboardPetugas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 571);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnKeluarga);
            this.Controls.Add(this.btnWarga);
            this.Name = "FormDashboardPetugas";
            this.Text = "FormDashboardPetugas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWarga;
        private System.Windows.Forms.Button btnKeluarga;
        private System.Windows.Forms.Button button3;
    }
}