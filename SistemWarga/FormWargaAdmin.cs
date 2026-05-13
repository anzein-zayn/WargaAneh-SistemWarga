using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace SistemWarga
{
    public partial class FormWargaAdmin : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
        ("Data Source=DESKTOP-V6AL6JT\\ZAKYZEIN;Initial Catalog=SistemWarga;Integrated Security=True");
        public FormWargaAdmin()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            dtpTL.MaxDate = DateTime.Today;

            // Opsional: set default value ke hari ini
            dtpTL.Value = DateTime.Today;
        }

        private void AutoConnect()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                this.Text = " Terhubung ✓";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal: " + ex.Message,
                                "Error Koneksi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }


                dgvWarga.Rows.Clear();
                dgvWarga.Columns.Clear();

                dgvWarga.Columns.Add("NIK", "NIK");
                dgvWarga.Columns.Add("Nama", "Nama");
                dgvWarga.Columns.Add("JenisKelamin", "Jenis Kelamin");
                dgvWarga.Columns.Add("TanggalLahir", "Tanggal Lahir");
                dgvWarga.Columns.Add("TempatLahir", "Tempat Lahir");
                dgvWarga.Columns.Add("NoKK", "No KK");
                dgvWarga.Columns.Add("StatusKeluarga", "Status Keluarga");

                string query = "SELECT * FROM Warga";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvWarga.Rows.Add(
                    reader["NIK"].ToString(),
                    reader["Nama"].ToString(),
                    reader["JenisKelamin"].ToString(),
                    Convert.ToDateTime(reader["TanggalLahir"]).ToShortDateString(),
                    reader["TempatLahir"].ToString(),
                    reader["NoKK"].ToString(),
                    reader["StatusKeluarga"].ToString()

                    );
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);

            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                { conn.Open(); }

                if (txtNoKK.Text == "")
                {
                    MessageBox.Show("NoKK harus diisi");
                    txtNoKK.Focus();
                    return;
                }



                if (txtNama.Text == "")
                {
                    MessageBox.Show("Nama harus diisi");
                    txtNama.Focus();
                    return;
                }

                if (cmbJK.Text == "")
                {
                    MessageBox.Show("Jenis Kelamin harus dipilih");
                    cmbJK.Focus();
                    return;
                }

                if (txtTempatLahir.Text == "")
                {
                    MessageBox.Show("Tempat Lahir harus diisi");
                    txtTempatLahir.Focus();
                    return;
                }

                string query = @"INSERT INTO Warga
                                (NoKK, Nama, Jeniskelamin, TanggalLahir, NIK, TempatLahir, StatusKeluarga)
                                VALUES
                                (@NoKK, @Nama, @JK, @TanggalLahir, @NIK, @TempatLahir, @StatusKeluarga)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@NoKK", txtNoKK.Text);
                cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@JK", cmbJK.Text);
                cmd.Parameters.AddWithValue("@TanggalLahir", dtpTL.Value.Date);
                cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);
                cmd.Parameters.AddWithValue("@TempatLahir", txtTempatLahir.Text);
                cmd.Parameters.AddWithValue("@StatusKeluarga", cmbSK.Text);
                

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data Warga berhasil ditambahkan");
                    ClearForm();
                    btnLoad.PerformClick();
                }
                else
                {
                    MessageBox.Show("Data gagal ditambahkan");
                }
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
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = @"UPDATE Warga
                                SET Nama = @Nama,
                                JenisKelamin = @JK,
                                TanggalLahir = @TanggalLahir,
                                TempatLahir = @TempatLahir,
                                StatusKeluarga = @StatusKeluarga
                                WHERE NIK = @NIK";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@NoKK", txtNoKK.Text);
                cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@JK", cmbJK.Text);
                cmd.Parameters.AddWithValue("@TanggalLahir", dtpTL.Value.Date);
                cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);
                cmd.Parameters.AddWithValue("@TempatLahir", txtTempatLahir.Text);
                cmd.Parameters.AddWithValue("@StatusKeluarga", cmbSK.Text);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data berhasil diupdate");
                    ClearForm();
                    btnLoad.PerformClick();
                }

                else
                {
                    MessageBox.Show("Data tidak ditemukan");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                DialogResult resultConfirm = MessageBox.Show(
                    "Yakin ingin menghapus data?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultConfirm == DialogResult.Yes)
                {
                    string query = "DELETE FROM Warga WHERE NIK = @NIK";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus");
                        ClearForm();
                        btnLoad.PerformClick();
                    }

                    else
                    {
                        MessageBox.Show("Data tidak ditemukan");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
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
                dtpTL.Value = Convert.ToDateTime(row.Cells["TanggalLahir"].Value);
                txtNIK.Text = row.Cells["NIK"].Value.ToString();
                txtTempatLahir.Text = row.Cells["TempatLahir"].Value.ToString();
                cmbSK.Text = row.Cells["StatusKeluarga"].Value.ToString();
            }
        }
        private void ClearForm()
        {
            txtNoKK.Clear();
            txtNama.Clear();
            cmbJK.SelectedIndex = -1;
            cmbSK.SelectedIndex = -1;
            txtNIK.Clear();
            txtTempatLahir.Clear();
            dtpTL.Value = DateTime.Now;
            txtNoKK.Focus();
        }
        private void FormWarga_Load(object sender, EventArgs e)
        {
            cmbJK.Items.Clear();
            cmbJK.Items.Add("L");
            cmbJK.Items.Add("P");
            cmbSK.Items.Clear();
            cmbSK.Items.Add("Kepala Keluarga");
            cmbSK.Items.Add("Istri");
            cmbSK.Items.Add("Anak");

            dgvWarga.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWarga.MultiSelect = false;
            dgvWarga.ReadOnly = true;
            dgvWarga.AllowUserToAddRows = false;
            dgvWarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvWarga.CellClick += dgvWarga_CellClick;

            AutoConnect();
        }

        private void txtNoKK_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan angka (0-9) dan backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Blokir karakter selain angka
            }
        }

        // Untuk txtNIK
        private void txtNIK_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan angka (0-9) dan backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtNamaLengkap_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Izinkan: huruf (a-z, A-Z), angka (0-9), backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Blokir karakter lainnya
            }
        }

        private void txtTL_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Izinkan: huruf (a-z, A-Z), angka (0-9), backspace
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Blokir karakter lainnya
            }
        }

        private void cmbJenisKelamin_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset dulu status keluarga
            cmbSK.Items.Clear();

            if (cmbJK.SelectedItem?.ToString() == "P")
            {
                // P: tidak bisa Kepala Keluarga
                cmbSK.Items.Add("Istri");
                cmbSK.Items.Add("Anak");
                cmbSK.Items.Add("Lainnya");
            }
            else if (cmbJK.SelectedItem?.ToString() == "L")
            {
                // L: tidak bisa Istri
                cmbSK.Items.Add("Kepala Keluarga");
                cmbSK.Items.Add("Anak");
                cmbSK.Items.Add("Lainnya");
            }

            cmbSK.SelectedIndex = -1;
        }




    }
}

