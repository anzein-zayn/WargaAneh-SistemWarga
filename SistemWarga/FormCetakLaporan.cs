using System;
using System.Data;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormCetakLaporan : Form
    {
        private DAL dbLogic = new DAL();
        private ListLaporan listWargaLengkap = new ListLaporan();
        private string jenisLaporan;
        private string tipeData;

        public FormCetakLaporan(string jenisLaporan, string tipeData)
        {
            InitializeComponent();

            this.jenisLaporan = jenisLaporan;
            this.tipeData = tipeData;

            try
            {
                // Ambil data dengan filter
                DataTable dtLaporan = dbLogic.GetLaporanWargaFiltered(jenisLaporan, tipeData);

                // Set DataSource ke Crystal Report
                listWargaLengkap.SetDataSource(dtLaporan);

                // Set parameter dengan pengecekan
                SetReportParameters(jenisLaporan, tipeData);

                crystalReportViewer1.ReportSource = listWargaLengkap;
                crystalReportViewer1.Refresh();

                this.Text = $"Cetak Laporan: {jenisLaporan} - {tipeData}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetReportParameters(string jenisLaporan, string tipeData)
        {
            try
            {
                // Cek jumlah parameter yang tersedia
                int paramCount = listWargaLengkap.DataDefinition.ParameterFields.Count;
                // MessageBox.Show($"Jumlah parameter: {paramCount}"); // Untuk debugging

                // Set parameter dengan aman (menggunakan nama parameter, bukan index)
                try
                {
                    listWargaLengkap.SetParameterValue("JudulLaporan", GetJudulLaporan(jenisLaporan, tipeData));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal set parameter JudulLaporan: {ex.Message}");
                }

                try
                {
                    listWargaLengkap.SetParameterValue("JenisLaporan", jenisLaporan);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal set parameter JenisLaporan: {ex.Message}");
                }

                try
                {
                    listWargaLengkap.SetParameterValue("TipeData", tipeData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal set parameter TipeData: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal set parameter report: " + ex.Message);
            }
        }

        private string GetJudulLaporan(string jenisLaporan, string tipeData)
        {
            switch (jenisLaporan)
            {
                case "Jenis Kelamin":
                    return $"LAPORAN WARGA BERDASARKAN JENIS KELAMIN - {tipeData}";
                case "Per RT":
                    return $"LAPORAN WARGA PER RT - RT {tipeData}";
                case "Status Keluarga":
                    return $"LAPORAN WARGA BERDASARKAN STATUS KELUARGA - {tipeData}";
                default:
                    return $"LAPORAN WARGA - {jenisLaporan} - {tipeData}";
            }
        }

        public FormCetakLaporan(string jenisLaporan, string tipeData, DataTable customData)
        {
            InitializeComponent();

            try
            {
                if (customData != null && customData.Rows.Count > 0)
                {
                    listWargaLengkap.SetDataSource(customData);
                }
                else
                {
                    DataTable dtLaporan = dbLogic.GetLaporanWargaFiltered(jenisLaporan, tipeData);
                    listWargaLengkap.SetDataSource(dtLaporan);
                }

                SetReportParameters(jenisLaporan, tipeData);

                crystalReportViewer1.ReportSource = listWargaLengkap;
                crystalReportViewer1.Refresh();

                this.Text = $"Cetak Laporan: {jenisLaporan} - {tipeData}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}