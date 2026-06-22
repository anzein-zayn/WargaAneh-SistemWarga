using System;
using System.Data;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormLaporan : Form
    {
        private DAL dbLogic = new DAL();
        private DataTable dtLaporan;

        public FormLaporan()
        {
            InitializeComponent();
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            // Setup ComboBox Jenis Laporan
            cmbJenisLaporan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJenisLaporan.Items.Clear();
            cmbJenisLaporan.Items.AddRange(new object[]
            {
                "Jenis Kelamin",
                "Per RT",
                "Status Keluarga"
            });
            cmbJenisLaporan.SelectedIndex = 0;

            // Setup ComboBox Tipe Data
            cmbTipeData.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipeData.Items.Clear();
            cmbTipeData.Items.AddRange(new object[]
            {
                "L",
                "P"
            });
            cmbTipeData.SelectedIndex = 0;

            // Setup DataGridView
            dgvLaporan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLaporan.MultiSelect = false;
            dgvLaporan.ReadOnly = true;
            dgvLaporan.AllowUserToAddRows = false;
            dgvLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnCetak.Enabled = false;

            // Tampilkan data default
            TampilkanData();
        }

        private void cmbJenisLaporan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update ComboBox Tipe Data sesuai dengan Jenis Laporan yang dipilih
            cmbTipeData.Items.Clear();

            string selectedJenis = cmbJenisLaporan.SelectedItem?.ToString();

            switch (selectedJenis)
            {
                case "Jenis Kelamin":
                    cmbTipeData.Items.AddRange(new object[] { "L", "P" });
                    break;
                case "Per RT":
                    // Ambil daftar RT dari database atau isi manual
                    // Contoh: cmbTipeData.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
                    // Untuk sementara kita isi dengan beberapa contoh
                    cmbTipeData.Items.AddRange(new object[] { "001","002" });
                    break;
                case "Status Keluarga":
                    cmbTipeData.Items.AddRange(new object[] { "Kepala Keluarga", "Istri", "Anak" });
                    break;
                default:
                    cmbTipeData.Items.AddRange(new object[] { "L", "P" });
                    break;
            }

            if (cmbTipeData.Items.Count > 0)
                cmbTipeData.SelectedIndex = 0;

            // Tampilkan data setelah perubahan
            TampilkanData();
        }

        private void btnTampil_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void TampilkanData()
        {
            if (cmbJenisLaporan.SelectedItem == null || cmbTipeData.SelectedItem == null)
            {
                MessageBox.Show("Pilih jenis laporan dan tipe data terlebih dahulu.");
                return;
            }

            try
            {
                string jenisLaporan = cmbJenisLaporan.SelectedItem.ToString();
                string tipeData = cmbTipeData.SelectedItem.ToString();

                // Panggil method baru untuk mendapatkan data dengan filter
                dtLaporan = dbLogic.GetLaporanWargaFiltered(jenisLaporan, tipeData);
                dgvLaporan.DataSource = dtLaporan;

                // Sembunyikan kolom "Judul" dari tampilan grid
                if (dgvLaporan.Columns.Contains("Judul"))
                    dgvLaporan.Columns["Judul"].Visible = false;

                btnCetak.Enabled = dtLaporan.Rows.Count > 0;

                if (dtLaporan.Rows.Count == 0)
                    MessageBox.Show($"Data tidak ditemukan untuk {jenisLaporan} - {tipeData}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnCetak_Click(object sender, EventArgs e)
        {
            if (dtLaporan == null || dtLaporan.Rows.Count == 0)
            {
                MessageBox.Show("Tampilkan data terlebih dahulu sebelum mencetak.");
                return;
            }

            string jenisLaporan = cmbJenisLaporan.SelectedItem.ToString();
            string tipeData = cmbTipeData.SelectedItem.ToString();

            // Kirim data yang sudah difilter ke form cetak
            FormCetakLaporan frmCetak = new FormCetakLaporan(jenisLaporan, tipeData, dtLaporan);
            frmCetak.Show();
        }
    }
}