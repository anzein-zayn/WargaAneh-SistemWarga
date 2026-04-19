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
    public partial class FormDashboardPetugas: Form
    {
        public FormDashboardPetugas()
        {
            InitializeComponent();
        }

        private void btnWarga_Click(object sender, EventArgs e)
        {
            FormWargaPetugas adminWargaP = new FormWargaPetugas();
            adminWargaP.Show();
        }
        private void btnKartuKel_Click(object sender, EventArgs e)
        {
            FormKeluargaPetugas adminWargaP = new FormKeluargaPetugas();
            adminWargaP.Show();
        }
        private void btnSurat_Click(object sender, EventArgs e)
        {
            FormSuratPetugas adminWargaP = new FormSuratPetugas();
            adminWargaP.Show();
        }
        
    }
}
