using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormDashboardAdmin : Form
    {
        public FormDashboardAdmin()
        {
            InitializeComponent();
        }

        private void btnWarga_Click(object sender, EventArgs e)
        {
            FormWargaAdmin adminWargaP = new FormWargaAdmin();
            adminWargaP.Show();
        }
        private void btnKartuKel_Click(object sender, EventArgs e)
        {
            FormKeluargaAdmin adminWargaP = new FormKeluargaAdmin();
            adminWargaP.Show();
        }
        private void btnSurat_Click(object sender, EventArgs e)
        {
            FormSuratAdmin adminWargaP = new FormSuratAdmin();
            adminWargaP.Show();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FormLaporan adminLaporan = new FormLaporan();
            adminLaporan.Show();
        }

    }
}
