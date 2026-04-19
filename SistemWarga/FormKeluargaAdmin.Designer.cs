namespace SistemWarga
{
    partial class FormKeluargaAdmin
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKepalaKeluarga = new System.Windows.Forms.TextBox();
            this.txtNoKK = new System.Windows.Forms.TextBox();
            this.txtIdKK = new System.Windows.Forms.TextBox();
            this.txtRT = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.dgvKartuKeluargaPetugas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKartuKeluargaPetugas)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(578, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(578, 112);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(578, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Insert";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(578, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Update";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kepala Keluarga";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "No KK";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Id KK";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Alamat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "RT";
            // 
            // txtKepalaKeluarga
            // 
            this.txtKepalaKeluarga.Location = new System.Drawing.Point(143, 54);
            this.txtKepalaKeluarga.Name = "txtKepalaKeluarga";
            this.txtKepalaKeluarga.Size = new System.Drawing.Size(235, 22);
            this.txtKepalaKeluarga.TabIndex = 9;
            // 
            // txtNoKK
            // 
            this.txtNoKK.Location = new System.Drawing.Point(143, 82);
            this.txtNoKK.Name = "txtNoKK";
            this.txtNoKK.Size = new System.Drawing.Size(235, 22);
            this.txtNoKK.TabIndex = 10;
            // 
            // txtIdKK
            // 
            this.txtIdKK.Location = new System.Drawing.Point(143, 131);
            this.txtIdKK.Name = "txtIdKK";
            this.txtIdKK.Size = new System.Drawing.Size(235, 22);
            this.txtIdKK.TabIndex = 11;
            // 
            // txtRT
            // 
            this.txtRT.Location = new System.Drawing.Point(143, 201);
            this.txtRT.Name = "txtRT";
            this.txtRT.Size = new System.Drawing.Size(235, 22);
            this.txtRT.TabIndex = 12;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(143, 168);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(235, 22);
            this.txtAlamat.TabIndex = 13;
            // 
            // dgvKartuKeluargaPetugas
            // 
            this.dgvKartuKeluargaPetugas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKartuKeluargaPetugas.Location = new System.Drawing.Point(79, 266);
            this.dgvKartuKeluargaPetugas.Name = "dgvKartuKeluargaPetugas";
            this.dgvKartuKeluargaPetugas.RowHeadersWidth = 51;
            this.dgvKartuKeluargaPetugas.RowTemplate.Height = 24;
            this.dgvKartuKeluargaPetugas.Size = new System.Drawing.Size(641, 150);
            this.dgvKartuKeluargaPetugas.TabIndex = 14;
            this.dgvKartuKeluargaPetugas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKartuKeluargaPetugas_CellClick);
            // 
            // FormKeluargaPetugas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvKartuKeluargaPetugas);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtRT);
            this.Controls.Add(this.txtIdKK);
            this.Controls.Add(this.txtNoKK);
            this.Controls.Add(this.txtKepalaKeluarga);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.button1);
            this.Name = "FormKeluargaPetugas";
            this.Text = "FormKeluargaPetugas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKartuKeluargaPetugas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKepalaKeluarga;
        private System.Windows.Forms.TextBox txtNoKK;
        private System.Windows.Forms.TextBox txtIdKK;
        private System.Windows.Forms.TextBox txtRT;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.DataGridView dgvKartuKeluargaPetugas;
    }
}