using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
        }

        private void ConnectDatabase()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                MessageBox.Show("Koneksi berhasil!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal: " + ex.Message);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectDatabase();
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
                dgvWarga.Columns.Add("Alamat", "Alamat");
                dgvWarga.Columns.Add("KodeProdi", "ID KK");

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
                    reader["Alamat"].ToString(),
                    reader["KodeProdi"].ToString()

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

                if (txtIdKK.Text == "")
                {
                    MessageBox.Show("IdKK harus diisi");
                    txtIdKK.Focus();
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
                                (IdKK, Nama, Jeniskelamin, TanggalLahir, NIK, TempatLahir, StatusKeluarga)
                                VALUES
                                (@IdKK, @Nama, @JK, @TanggalLahir, @NIK, @TempatLahir, @StatusKeluarga)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdKK", txtIdKK.Text);
                cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@JK", cmbJK.Text);
                cmd.Parameters.AddWithValue("@TanggalLahir", dtpTL.Value.Date);
                cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);
                cmd.Parameters.AddWithValue("@TempatLahir", txtTempatLahir.Text);
                cmd.Parameters.AddWithValue("@StatusKeluarga", cmbSK.Text);
                cmd.Parameters.AddWithValue("@StatusKeluarga", DateTime.Now);

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
                                NIK = @NIK,
                                TempatLahir = @TempatLahir,
                                StatusKeluarga = @StatusKeluarga
                                WHERE IdKK = @IdKK";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdKK", txtIdKK.Text);
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

                txtIdKK.Text = row.Cells["IdKK"].Value.ToString();
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
            txtIdKK.Clear();
            txtNama.Clear();
            cmbJK.SelectedIndex = -1;
            cmbSK.SelectedIndex = -1;
            txtNIK.Clear();
            txtTempatLahir.Clear();
            dtpTL.Value = DateTime.Now;
            txtIdKK.Focus();
        }
        private void FormWarga_Load(object sender, EventArgs e)
        {
            cmbJK.Items.Clear();
            cmbJK.Items.Add("L");
            cmbJK.Items.Add("P");

            dgvWarga.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWarga.MultiSelect = false;
            dgvWarga.ReadOnly = true;
            dgvWarga.AllowUserToAddRows = false;
            dgvWarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvWarga.CellClick += dgvWarga_CellClick;
        }

       
    }
}

