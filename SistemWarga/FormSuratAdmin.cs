using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormSuratAdmin : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
        ("Data Source=DESKTOP-V6AL6JT\\ZAKYZEIN;Initial Catalog=SistemWarga;Integrated Security=True");
        public FormSuratAdmin()
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


                dgvSurat.Rows.Clear();
                dgvSurat.Columns.Clear();

                dgvSurat.Columns.Add("IdSurat", "IdSurat");
                dgvSurat.Columns.Add("StatusSurat", "StatusSurat");
                dgvSurat.Columns.Add("JenisSurat", "JenisSurat");
                dgvSurat.Columns.Add("TanggalPengajuan", "TanggalPengajuan");
                dgvSurat.Columns.Add("NIK", "NIK");
                string query = "SELECT * FROM SuratPengantar";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvSurat.Rows.Add(
                    reader["IdSurat"].ToString(),
                    reader["StatusSurat"].ToString(),
                    reader["JenisSurat"].ToString(),
                    Convert.ToDateTime(reader["TanggalPengajuan"]).ToShortDateString(),
                    reader["NIK"].ToString()

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

                if (txtIdSurat.Text == "")
                {
                    MessageBox.Show("Id Surat harus diisi");
                    txtIdSurat.Focus();
                    return;
                }



                if (cmbStatus.Text == null)
                {
                    MessageBox.Show("Jenis Surat harus diisi");
                    return;
                }

                if (cmbJS.Text == null)
                {
                    MessageBox.Show("Jenis Kelamin harus dipilih");
                    return;
                }

                string query = @"INSERT INTO SuratPengantar
                                (IdSurat, JenisSurat, TanggalPengajuan, StatusSurat, NIK)
                                VALUES
                                (@IdSurat, @JenisSurat, @TanggalPengajuan, @StatusSurat, @NIK)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdSurat", txtIdSurat.Text);
                cmd.Parameters.AddWithValue("@StatusSurat", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@JenisSurat", cmbJS.Text);
                cmd.Parameters.AddWithValue("@TanggalPengajuan", dtpTP.Value.Date);
                cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);


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
                string query = @"UPDATE SuratPengantar
                                SET JenisSurat = @JenisSurat,
                                TanggalPengajuan = @TanggalPengajuan,
                                StatusSurat = @StatusSurat,
                                NIK = @NIK
                                WHERE IdSurat = @IdSurat";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdSurat", txtIdSurat.Text);
                cmd.Parameters.AddWithValue("@StatusSurat", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@JenisSurat", cmbJS.Text);
                cmd.Parameters.AddWithValue("@TanggalPengajuan", dtpTP.Value.Date);
                cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);


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
                    string query = "DELETE FROM SuratPengantar WHERE IdSurat = @IdSurat";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdSurat", txtIdSurat.Text);

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



        private void dgvSurat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSurat.Rows[e.RowIndex];

                txtIdSurat.Text = row.Cells["IdSurat"].Value.ToString();
                cmbStatus.Text = row.Cells["StatusSurat"].Value.ToString();
                cmbJS.Text = row.Cells["JenisSurat"].Value.ToString();
                dtpTP.Value = Convert.ToDateTime(row.Cells["TanggalPengajuan"].Value);
                txtNIK.Text = row.Cells["NIK"].Value.ToString();
            }
        }
        private void ClearForm()
        {
            txtIdSurat.Clear();
            cmbStatus.SelectedIndex = -1;
            cmbJS.SelectedIndex = -1;
            txtNIK.Clear();
            dtpTP.Value = DateTime.Now;
            txtNIK.Clear();
        }
        private void FormSuratAdmin_Load(object sender, EventArgs e)
        {
            cmbJS.Items.Clear();
            cmbJS.Items.Add("Surat Keterangan Domisili");
            cmbJS.Items.Add("Surat Keterangan Tidak Mampu");
            cmbJS.Items.Add("Surat Pengantar SKCK");
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Selesai");
            cmbStatus.Items.Add("DiTunda");

            dgvSurat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSurat.MultiSelect = false;
            dgvSurat.ReadOnly = true;
            dgvSurat.AllowUserToAddRows = false;
            dgvSurat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvSurat.CellClick += dgvSurat_CellClick;
        }
    }
}
