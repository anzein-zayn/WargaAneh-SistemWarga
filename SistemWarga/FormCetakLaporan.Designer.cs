namespace SistemWarga
{
    partial class FormCetakLaporan
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ListLaporan1 = new SistemWarga.ListLaporan();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.ListLaporan1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1115, 630);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // FormCetakLaporan
            // 
            this.ClientSize = new System.Drawing.Size(1115, 630);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "FormCetakLaporan";
            this.Text = "Cetak Laporan Penduduk";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private ListLaporan ListLaporan1;
    }
}