namespace SistemWarga
{
    partial class FormSuratAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSuratAdmin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdSurat = new System.Windows.Forms.TextBox();
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.dtpTP = new System.Windows.Forms.DateTimePicker();
            this.cmbJS = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvSurat = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.sistemWargaDataSet4 = new SistemWarga.SistemWargaDataSet4();
            this.suratPengantarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suratPengantarTableAdapter = new SistemWarga.SistemWargaDataSet4TableAdapters.SuratPengantarTableAdapter();
            this.suratPengantarBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.suratPengantarBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.suratPengantarBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.suratPengantarBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.sistemWargaDataSet5 = new SistemWarga.SistemWargaDataSet5();
            this.suratPengantarBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.suratPengantarTableAdapter1 = new SistemWarga.SistemWargaDataSet5TableAdapters.SuratPengantarTableAdapter();
            this.suratPengantarBindingSource6 = new System.Windows.Forms.BindingSource(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sistemWargaDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemWargaDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource6)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Surat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "NIK";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(33, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tanggal Pengajuan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Leelawadee", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(373, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Jenis Surat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SeaShell;
            this.label5.Location = new System.Drawing.Point(373, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Status";
            // 
            // txtIdSurat
            // 
            this.txtIdSurat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suratPengantarBindingSource5, "IdSurat", true));
            this.txtIdSurat.Location = new System.Drawing.Point(36, 240);
            this.txtIdSurat.Name = "txtIdSurat";
            this.txtIdSurat.Size = new System.Drawing.Size(200, 22);
            this.txtIdSurat.TabIndex = 1;
            this.txtIdSurat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDSurat_KeyPress);
            // 
            // txtNIK
            // 
            this.txtNIK.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suratPengantarBindingSource5, "NIK", true));
            this.txtNIK.Location = new System.Drawing.Point(36, 284);
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.Size = new System.Drawing.Size(200, 22);
            this.txtNIK.TabIndex = 1;
            this.txtNIK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNIK_KeyPress);
            // 
            // dtpTP
            // 
            this.dtpTP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suratPengantarBindingSource5, "TanggalPengajuan", true));
            this.dtpTP.Location = new System.Drawing.Point(36, 334);
            this.dtpTP.Name = "dtpTP";
            this.dtpTP.Size = new System.Drawing.Size(200, 22);
            this.dtpTP.TabIndex = 2;
            // 
            // cmbJS
            // 
            this.cmbJS.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suratPengantarBindingSource6, "JenisSurat", true));
            this.cmbJS.FormattingEnabled = true;
            this.cmbJS.Location = new System.Drawing.Point(376, 282);
            this.cmbJS.Name = "cmbJS";
            this.cmbJS.Size = new System.Drawing.Size(212, 24);
            this.cmbJS.TabIndex = 3;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suratPengantarBindingSource6, "StatusSurat", true));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(376, 238);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(212, 24);
            this.cmbStatus.TabIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnLoad.Font = new System.Drawing.Font("Geometr706 BlkCn BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.Azure;
            this.btnLoad.Location = new System.Drawing.Point(410, 366);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 37);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnInsert.Font = new System.Drawing.Font("Geometr706 BlkCn BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.Color.Azure;
            this.btnInsert.Location = new System.Drawing.Point(513, 315);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 41);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnUpdate.Font = new System.Drawing.Font("Geometr706 BlkCn BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Azure;
            this.btnUpdate.Location = new System.Drawing.Point(513, 366);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 37);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvSurat
            // 
            this.dgvSurat.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSurat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurat.Location = new System.Drawing.Point(36, 427);
            this.dgvSurat.Name = "dgvSurat";
            this.dgvSurat.RowHeadersWidth = 51;
            this.dgvSurat.RowTemplate.Height = 24;
            this.dgvSurat.Size = new System.Drawing.Size(552, 188);
            this.dgvSurat.TabIndex = 5;
            this.dgvSurat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSurat_CellClick);
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Geometr212 BkCn BT", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkOrange;
            this.label6.Location = new System.Drawing.Point(104, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(418, 46);
            this.label6.TabIndex = 6;
            this.label6.Text = "PENGAJUAN SURAT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(246, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(643, 27);
            this.bindingNavigator1.TabIndex = 8;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // sistemWargaDataSet4
            // 
            this.sistemWargaDataSet4.DataSetName = "SistemWargaDataSet4";
            this.sistemWargaDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // suratPengantarBindingSource
            // 
            this.suratPengantarBindingSource.DataMember = "SuratPengantar";
            this.suratPengantarBindingSource.DataSource = this.sistemWargaDataSet4;
            // 
            // suratPengantarTableAdapter
            // 
            this.suratPengantarTableAdapter.ClearBeforeFill = true;
            // 
            // suratPengantarBindingSource1
            // 
            this.suratPengantarBindingSource1.DataMember = "SuratPengantar";
            this.suratPengantarBindingSource1.DataSource = this.sistemWargaDataSet4;
            // 
            // suratPengantarBindingSource2
            // 
            this.suratPengantarBindingSource2.DataMember = "SuratPengantar";
            this.suratPengantarBindingSource2.DataSource = this.sistemWargaDataSet4;
            // 
            // suratPengantarBindingSource3
            // 
            this.suratPengantarBindingSource3.DataMember = "SuratPengantar";
            this.suratPengantarBindingSource3.DataSource = this.sistemWargaDataSet4;
            // 
            // suratPengantarBindingSource4
            // 
            this.suratPengantarBindingSource4.DataMember = "SuratPengantar";
            this.suratPengantarBindingSource4.DataSource = this.sistemWargaDataSet4;
            // 
            // sistemWargaDataSet5
            // 
            this.sistemWargaDataSet5.DataSetName = "SistemWargaDataSet5";
            this.sistemWargaDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // suratPengantarBindingSource5
            // 
            this.suratPengantarBindingSource5.DataMember = "SuratPengantar";
            this.suratPengantarBindingSource5.DataSource = this.sistemWargaDataSet5;
            // 
            // suratPengantarTableAdapter1
            // 
            this.suratPengantarTableAdapter1.ClearBeforeFill = true;
            // 
            // suratPengantarBindingSource6
            // 
            this.suratPengantarBindingSource6.DataMember = "SuratPengantar";
            this.suratPengantarBindingSource6.DataSource = this.sistemWargaDataSet5;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnSearch.Font = new System.Drawing.Font("Geometr706 BlkCn BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Azure;
            this.btnSearch.Location = new System.Drawing.Point(410, 315);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 41);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FormSuratAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(643, 627);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvSurat);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbJS);
            this.Controls.Add(this.dtpTP);
            this.Controls.Add(this.txtNIK);
            this.Controls.Add(this.txtIdSurat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormSuratAdmin";
            this.Text = "FormSurat";
            this.Load += new System.EventHandler(this.FormSuratAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sistemWargaDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemWargaDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suratPengantarBindingSource6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdSurat;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.DateTimePicker dtpTP;
        private System.Windows.Forms.ComboBox cmbJS;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvSurat;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private SistemWargaDataSet4 sistemWargaDataSet4;
        private System.Windows.Forms.BindingSource suratPengantarBindingSource;
        private SistemWargaDataSet4TableAdapters.SuratPengantarTableAdapter suratPengantarTableAdapter;
        private System.Windows.Forms.BindingSource suratPengantarBindingSource1;
        private System.Windows.Forms.BindingSource suratPengantarBindingSource2;
        private System.Windows.Forms.BindingSource suratPengantarBindingSource4;
        private System.Windows.Forms.BindingSource suratPengantarBindingSource3;
        private SistemWargaDataSet5 sistemWargaDataSet5;
        private System.Windows.Forms.BindingSource suratPengantarBindingSource5;
        private SistemWargaDataSet5TableAdapters.SuratPengantarTableAdapter suratPengantarTableAdapter1;
        private System.Windows.Forms.BindingSource suratPengantarBindingSource6;
        private System.Windows.Forms.Button btnSearch;
    }
}