using ExcelDataReader;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace SistemWarga
{
    public partial class FormWargaPetugas : Form
    {
        static string connectionString = "Data Source=192.168.1.11,1433;Initial Catalog=SistemWarga;User ID=sa;Password=12345678;TrustServerCertificate=True;";

        private BindingSource bindingSource = new BindingSource();
        private DataTable dtWarga = new DataTable();
        private DataTable dtPreviewImport;

        public FormWargaPetugas()
        {
            InitializeComponent();
            dtpTL.MaxDate = DateTime.Today;

            // Opsional: set default value ke hari ini
            dtpTL.Value = DateTime.Today;
        }

        private void HitungTotal()

        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CountWarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        lblTotal.Text = "Total Warga: " + outputParam.Value.ToString();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total: " + ex.Message);

            }
        }

        private void LoadWarga()
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllWarga", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dtWarga = new DataTable();
                        da.Fill(dtWarga);


                        bindingSource.DataSource = dtWarga;
                        dgvWarga.DataSource = bindingSource;

                        if (dtWarga.Rows.Count > 0)
                        {
                            BindControls();
                        }
                    }
                }
            }
            HitungTotal();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadWarga();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNIK.Text))
            {
                MessageBox.Show("Masukkan NIK atau ID yang dicari.");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchWarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Keyword", txtNIK.Text.Trim());

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtWarga = new DataTable();
                            da.Fill(dtWarga);
                            bindingSource.DataSource = dtWarga;
                            dgvWarga.DataSource = bindingSource;
                        }
                    }
                }

                if (dtWarga.Rows.Count == 0)
                    MessageBox.Show("Data tidak ditemukan.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari data: " + ex.Message);
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidasiForm()) return;

            string jenisKelamin = cmbJK.SelectedItem?.ToString();
            string statusKeluarga = cmbSK.SelectedItem?.ToString();

            if (jenisKelamin == "P" && statusKeluarga == "Kepala Keluarga")
            {
                MessageBox.Show("P tidak boleh menjadi Kepala Keluarga!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (jenisKelamin == "L" && statusKeluarga == "Istri")
            {
                MessageBox.Show("L tidak boleh memilih status Istri!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertWarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NoKK", txtNoKK.Text.Trim());

                        cmd.Parameters.AddWithValue("@NIK", txtNIK.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@TempatLahir", txtTempatLahir.Text.Trim());
                        cmd.Parameters.AddWithValue("@TanggalLahir", dtpTL.Value.Date);
                        cmd.Parameters.AddWithValue("@JenisKelamin", cmbJK.Text);
                        cmd.Parameters.AddWithValue("@StatusKeluarga", cmbSK.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data Warga berhasil ditambahkan.");
                ClearForm();
                LoadWarga();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string jenisKelamin = cmbJK.SelectedItem?.ToString();
            string statusKeluarga = cmbSK.SelectedItem?.ToString();
            if (!ValidasiForm())
                return;

            if (jenisKelamin == "P" && statusKeluarga == "Kepala Keluarga")
            {
                MessageBox.Show("P tidak boleh menjadi Kepala Keluarga!",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (jenisKelamin == "L" && statusKeluarga == "Istri")
            {
                MessageBox.Show("L tidak boleh memilih status Istri!",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateWarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NoKK", txtNoKK.Text.Trim());
                        cmd.Parameters.AddWithValue("@NIK", txtNIK.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@TempatLahir", txtTempatLahir.Text.Trim());
                        cmd.Parameters.AddWithValue("@TanggalLahir", dtpTL.Value.Date);
                        cmd.Parameters.AddWithValue("@JenisKelamin", cmbJK.Text);
                        cmd.Parameters.AddWithValue("@StatusKeluarga", cmbSK.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil diupdate.");
                ClearForm();
                LoadWarga();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNIK.Text))
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Yakin ingin menghapus data warga ini?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteWarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Mengikuti pola modul: Add dengan SqlDbType
                        cmd.Parameters.Add("@NIK", SqlDbType.VarChar, 16).Value = txtNIK.Text.Trim();

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Data berhasil dihapus.");
                        else
                            MessageBox.Show("Data tidak ditemukan.");
                    }
                }

                ClearForm();
                LoadWarga();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void BindingSource_PositionChanged(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
        {
            if (bindingSource.Current == null) return;
            DataRowView row = (DataRowView)bindingSource.Current;

            txtNIK.Text = row["NIK"].ToString();
            txtNama.Text = row["Nama"].ToString();
            cmbJK.Text = row["JenisKelamin"].ToString();
            txtTempatLahir.Text = row["TempatLahir"].ToString();
            txtNoKK.Text = row["NoKK"].ToString();
            cmbSK.Text = row["StatusKeluarga"].ToString();

            if (row["TanggalLahir"] != DBNull.Value)
                dtpTL.Value = Convert.ToDateTime(row["TanggalLahir"]);
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                    IF OBJECT_ID('dbo.Warga_Backup') IS NOT NULL
                    BEGIN
                    DELETE FROM dbo.SuratPengantar;
                    DELETE FROM dbo.Warga;

                    INSERT INTO dbo.Warga
                    SELECT * FROM dbo.Warga_Backup;
                    END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil direset");
                LoadWarga();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset gagal: " + ex.Message);
            }
        }
        private void dgvWarga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvWarga.Rows[e.RowIndex];

                txtNoKK.Text = row.Cells["NoKK"].Value.ToString();
                txtNama.Text = row.Cells["Nama"].Value.ToString();
                cmbJK.Text = row.Cells["JenisKelamin"].Value.ToString();

                cmbSK.Items.Clear();
                if (cmbJK.Text == "P")
                    cmbSK.Items.AddRange(new object[] { "Istri", "Anak" });
                else
                    cmbSK.Items.AddRange(new object[] { "Kepala Keluarga", "Anak" });

                cmbSK.Text = row.Cells["StatusKeluarga"].Value.ToString();

                if (row.Cells["TanggalLahir"].Value != DBNull.Value)
                    dtpTL.Value = Convert.ToDateTime(row.Cells["TanggalLahir"].Value);

                txtNIK.Text = row.Cells["NIK"].Value.ToString();
                txtTempatLahir.Text = row.Cells["TempatLahir"].Value.ToString();
                // blok duplikat dihapus
            }
        }
        private void cmbJK_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSK.Items.Clear();
            if (cmbJK.SelectedItem?.ToString() == "P")
                cmbSK.Items.AddRange(new object[] { "Istri", "Anak" });
            else if (cmbJK.SelectedItem?.ToString() == "L")
                cmbSK.Items.AddRange(new object[] { "Kepala Keluarga", "Anak" });
            cmbSK.SelectedIndex = -1;
        }
        private void ClearForm()
        {
            txtNIK.Clear();
            txtNama.Clear();
            txtTempatLahir.Clear();
            txtNoKK.Clear();
            cmbJK.SelectedIndex = -1;
            cmbSK.SelectedIndex = -1;
            dtpTL.Value = DateTime.Today;
            txtNoKK.Focus();
        }



        private void FormWarga_Load(object sender, EventArgs e)
        {

            cmbJK.Items.Clear();
            cmbJK.Items.AddRange(new object[] { "L", "P" });

            cmbSK.Items.Clear();
            cmbSK.Items.AddRange(new object[] { "Kepala Keluarga", "Istri", "Anak" });

            dgvWarga.AutoGenerateColumns = true;
            dgvWarga.DataSource = bindingSource;
            dgvWarga.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWarga.MultiSelect = false;
            dgvWarga.ReadOnly = true;
            dgvWarga.AllowUserToAddRows = false;
            dgvWarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingNavigator1.BindingSource = bindingSource;

            bindingSource.PositionChanged += BindingSource_PositionChanged;
            cmbJK.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSK.DropDownStyle = ComboBoxStyle.DropDownList;

            txtNIK.MaxLength = 16;
            txtNoKK.MaxLength = 16;

            LoadWarga();
            HitungTotal();
        }

        private void txtNoKK_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) &&
                 e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (txtNoKK.Text.Length >= 16 &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void txtNamaLengkap_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTL_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    string query =
                        "UPDATE Warga SET Nama='HACKED' WHERE NIK='" +
                        txtNIK.Text + "'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show(result + " baris terupdate");
                    }
                }
                LoadWarga();

            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtNIK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtNIK.Text.Length >= 16 &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool ValidasiForm()
        {
            if (string.IsNullOrWhiteSpace(txtNoKK.Text))
            {
                MessageBox.Show("No KK harus diisi.");
                return false;
            }

            if (txtNoKK.Text.Length != 16)
            {
                MessageBox.Show("No KK harus 16 digit.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNIK.Text))
            {
                MessageBox.Show("NIK harus diisi.");
                return false;
            }

            if (txtNIK.Text.Length != 16)
            {
                MessageBox.Show("NIK harus 16 digit.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Nama harus diisi.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTempatLahir.Text))
            {
                MessageBox.Show("Tempat lahir harus diisi.");
                return false;
            }

            if (cmbJK.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih jenis kelamin.");
                return false;
            }

            if (cmbSK.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih status keluarga.");
                return false;
            }

            return true;
        }
        

        private void btnImportDb_Click(object sender, EventArgs e)
        {
            if (dtPreviewImport == null || dtPreviewImport.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diimport.");
                return;
            }

            int sukses = 0, gagal = 0;
            StringBuilder errorLog = new StringBuilder();

            foreach (DataRow row in dtPreviewImport.Rows)
            {
                try
                {
                    string nik = row["NIK"].ToString().Trim();
                    string nama = row["Nama"].ToString().Trim();
                    string tempatLahir = row["TempatLahir"].ToString().Trim();
                    string noKK = row["NoKK"].ToString().Trim();
                    string jenisKelamin = row["JenisKelamin"].ToString().Trim();
                    string statusKeluarga = row["StatusKeluarga"].ToString().Trim();

                    if (string.IsNullOrEmpty(nik) || string.IsNullOrEmpty(nama))
                    { gagal++; errorLog.AppendLine($"Baris dilewati: NIK/Nama kosong"); continue; }

                    if (!DateTime.TryParse(row["TanggalLahir"].ToString(), out DateTime tglLahir))
                    { gagal++; errorLog.AppendLine($"NIK {nik}: format tanggal salah"); continue; }

                    // Validasi bisnis SAMA seperti yang sudah kita terapkan di btnInsert manual
                    if (jenisKelamin == "P" && statusKeluarga == "Kepala Keluarga")
                    { gagal++; errorLog.AppendLine($"NIK {nik}: P tidak boleh Kepala Keluarga"); continue; }
                    if (jenisKelamin == "L" && statusKeluarga == "Istri")
                    { gagal++; errorLog.AppendLine($"NIK {nik}: L tidak boleh Istri"); continue; }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("sp_InsertWarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NIK", nik);
                        cmd.Parameters.AddWithValue("@Nama", nama);
                        cmd.Parameters.AddWithValue("@TempatLahir", tempatLahir);
                        cmd.Parameters.AddWithValue("@TanggalLahir", tglLahir);
                        cmd.Parameters.AddWithValue("@JenisKelamin", jenisKelamin);
                        cmd.Parameters.AddWithValue("@NoKK", noKK);
                        cmd.Parameters.AddWithValue("@StatusKeluarga", statusKeluarga);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    sukses++;
                }
                catch (Exception ex)
                {
                    gagal++;
                    errorLog.AppendLine($"Error: {ex.Message}");
                }
            }

            MessageBox.Show($"Import selesai.\nSukses: {sukses}\nGagal: {gagal}\n\n{errorLog}");
            dgvWarga.Enabled = true;
            btnTambah.Enabled = true;
            btnUpdate.Enabled = true;
            LoadWarga();
        }


        private void btnImpExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        dtPreviewImport = result.Tables[0];
                        dgvWarga.DataSource = dtPreviewImport;
                        dgvWarga.Enabled = false; // preview only, belum bisa diedit

                        // Nonaktifkan tombol lain sementara, sama seperti pola modul
                        btnTambah.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnImpDB.Enabled = true;
                    }
                }
            }
        }
    }
}


