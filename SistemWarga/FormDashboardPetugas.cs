using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemWarga
{
    public partial class FormDashboardPetugas: Form
    {
        private DAL dbLogic = new DAL();

        public FormDashboardPetugas()
        {
            InitializeComponent();
        }

        private void FormDashboardPetugas_Load(object sender, EventArgs e)
        {
            // Setup ComboBox pilihan chart
            cmbPilihanChart.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPilihanChart.Items.Clear();
            cmbPilihanChart.Items.AddRange(new object[]
            {
                "Jumlah Kartu Keluarga per RT",
                "Jumlah Warga per Jenis Kelamin",
                "Jumlah Surat per Jenis Surat",
                "Jumlah Surat per Status"
            });
            cmbPilihanChart.SelectedIndex = 0;

            // Setup DateTimePicker tahun (hanya relevan untuk pilihan Surat)
            dtpTahunSurat.Format = DateTimePickerFormat.Custom;
            dtpTahunSurat.CustomFormat = "yyyy";
            dtpTahunSurat.ShowUpDown = true;
            dtpTahunSurat.MinDate = new DateTime(2000, 1, 1);
            dtpTahunSurat.MaxDate = DateTime.Now;

            ToggleTahunPicker();
            LoadChart();
        }

        private void cmbPilihanChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleTahunPicker();
        }

        // DateTimePicker tahun hanya muncul/aktif kalau pilihan terkait Surat
        private void ToggleTahunPicker()
        {
            bool isSurat = cmbPilihanChart.SelectedItem != null &&
                           cmbPilihanChart.SelectedItem.ToString().Contains("Surat");
            dtpTahunSurat.Enabled = isSurat;
        }

        private void btnLoadChart_Click(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void LoadChart()
        {
            chartDashboard.Series.Clear();
            chartDashboard.Titles.Clear();
            chartDashboard.ChartAreas.Clear();
            chartDashboard.Legends.Clear();

            ChartArea ca = new ChartArea("MainArea");
            ca.BackColor = Color.Transparent;
            chartDashboard.ChartAreas.Add(ca);

            Legend legend = new Legend("MainLegend");
            chartDashboard.Legends.Add(legend);

            try
            {
                string pilihan = cmbPilihanChart.SelectedItem.ToString();
                DataTable dt;
                string kolomLabel, kolomJumlah, judul;
                SeriesChartType tipeChart;

                switch (pilihan)
                {
                    case "Jumlah Kartu Keluarga per RT":
                        dt = dbLogic.GetDashboardKartuKeluarga();
                        kolomLabel = "RT";
                        kolomJumlah = "Jumlah";
                        judul = "Jumlah Kartu Keluarga per RT";
                        tipeChart = SeriesChartType.Column;
                        ca.AxisX.Title = "RT";
                        ca.AxisY.Title = "Jumlah KK";
                        break;

                    case "Jumlah Warga per Jenis Kelamin":
                        dt = dbLogic.GetDashboardWargaGender();
                        kolomLabel = "JenisKelamin";
                        kolomJumlah = "Jumlah";
                        judul = "Jumlah Warga per Jenis Kelamin";
                        tipeChart = SeriesChartType.Pie;
                        break;

                    case "Jumlah Surat per Jenis Surat":
                        dt = dbLogic.GetDashboardSuratJenis(dtpTahunSurat.Value.Year);
                        kolomLabel = "JenisSurat";
                        kolomJumlah = "Jumlah";
                        judul = $"Jumlah Surat per Jenis Surat Tahun {dtpTahunSurat.Value.Year}";
                        tipeChart = SeriesChartType.Column;
                        ca.AxisX.Title = "Jenis Surat";
                        ca.AxisY.Title = "Jumlah";
                        ca.AxisX.LabelStyle.Angle = -25;
                        break;

                    case "Jumlah Surat per Status":
                        dt = dbLogic.GetDashboardSuratStatus(dtpTahunSurat.Value.Year);
                        kolomLabel = "StatusSurat";
                        kolomJumlah = "Jumlah";
                        judul = $"Jumlah Surat per Status Tahun {dtpTahunSurat.Value.Year}";
                        tipeChart = SeriesChartType.Pie;
                        break;

                    default:
                        return;
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk ditampilkan.");
                    return;
                }

                Series s = new Series("Series1");
                s.ChartType = tipeChart;
                s.IsValueShownAsLabel = true;
                if (tipeChart == SeriesChartType.Pie)
                    s.Label = "#VALX: #VAL";

                foreach (DataRow row in dt.Rows)
                {
                    string label = row[kolomLabel].ToString();
                    int jumlah = Convert.ToInt32(row[kolomJumlah]);
                    s.Points.AddXY(label, jumlah);
                }

                chartDashboard.Series.Add(s);

                Title title = new Title(judul, Docking.Top,
                    new Font("Arial", 12, FontStyle.Bold), Color.DarkBlue);
                chartDashboard.Titles.Add(title);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load chart: " + ex.Message);
            }
        }

        // ── Tombol menu navigasi yang sudah ada ──
        private void btnWarga_Click(object sender, EventArgs e)
        {
            FormWargaPetugas formWarga = new FormWargaPetugas();
            formWarga.Show();
        }

        private void btnKartuKel_Click(object sender, EventArgs e)
        {
            FormKeluargaPetugas formKeluarga = new FormKeluargaPetugas();
            formKeluarga.Show();
        }

        private void btnSurat_Click(object sender, EventArgs e)
        {
            FormSuratPetugas formSurat = new FormSuratPetugas();
            formSurat.Show();
        }

       
    }
}