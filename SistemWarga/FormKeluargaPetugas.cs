using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormKeluargaPetugas: Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
        ("Data Source=DESKTOP-V6AL6JT\\ZAKYZEIN;Initial Catalog=SistemWarga;Integrated Security=True");

        public FormKeluargaPetugas()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
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


                dgvKartuKeluargaPetugas.Rows.Clear();
                dgvKartuKeluargaPetugas.Columns.Clear();

                dgvKartuKeluargaPetugas.Columns.Add("KepalaKeluarga", "Kepala Keluarga");
                dgvKartuKeluargaPetugas.Columns.Add("NoKK", "NoKK");
                dgvKartuKeluargaPetugas.Columns.Add("Alamat", "Alamat");
                dgvKartuKeluargaPetugas.Columns.Add("RT", "RT");
                string query = "SELECT * FROM KartuKeluarga";


                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                dgvKartuKeluargaPetugas.Rows.Add(
                reader["KepalaKeluarga"].ToString(),
                reader["NoKK"].ToString(),
                reader["Alamat"].ToString(),
                reader["RT"].ToString()



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

                if (txtKepalaKeluarga.Text == "")
                {
                    MessageBox.Show("KepalaKeluarga harus diisi");
                    txtKepalaKeluarga.Focus();
                    return;
                }



                if (txtNoKK.Text == "")
                {
                    MessageBox.Show("NoKK harus diisi");
                    txtNoKK.Focus();
                    return;
                }

                if (txtRT.Text == "")
                {
                    MessageBox.Show("RT harus diisi");
                    txtRT.Focus();
                    return;
                }

                if (txtAlamat.Text == "")
                {
                    MessageBox.Show("Alamat harus diisi");
                    txtAlamat.Focus();
                    return;
                }

                string query = @"INSERT INTO KartuKeluarga
                                (KepalaKeluarga, NoKK , RT, Alamat)
                                VALUES
                               (@KepalaKeluarga, @NoKK ,@RT, @Alamat)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@KepalaKeluarga",txtKepalaKeluarga.Text);
                cmd.Parameters.AddWithValue("@NoKK", txtNoKK.Text);
                cmd.Parameters.AddWithValue("@RT", txtRT.Text);
                cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text);
         

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
                string query = @"UPDATE KartuKeluarga
                                SET KepalaKeluarga = @KepalaKeluarga,
                                NoKK = @NoKK,
                                RT = @RT,
                                Alamat = @Alamat,
                                WHERE NoKK = @NoKK";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@KepalaKeluarga", txtKepalaKeluarga.Text);
                cmd.Parameters.AddWithValue("@NoKK", txtNoKK.Text);
                cmd.Parameters.AddWithValue("@RT", txtRT.Text);
                cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text);

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

        private void dgvKartuKeluargaPetugas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKartuKeluargaPetugas.Rows[e.RowIndex];

                txtKepalaKeluarga.Text = row.Cells["KepalaKeluarga"].Value.ToString();
                txtNoKK.Text = row.Cells["NoKK"].Value.ToString();
                txtRT.Text = row.Cells["RT"].Value.ToString();
                txtAlamat.Text = row.Cells["Alamat"].Value.ToString();

            
            }
        }
        private void ClearForm()
        {
            txtKepalaKeluarga.Clear();
            txtNoKK.Clear();
            txtRT.Clear();
            txtAlamat.Clear();
            txtNoKK.Focus();
        }
        private void FormWargaPetugas_Load(object sender, EventArgs e)
        {
            

            dgvKartuKeluargaPetugas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKartuKeluargaPetugas.MultiSelect = false;
            dgvKartuKeluargaPetugas.ReadOnly = true;
            dgvKartuKeluargaPetugas.AllowUserToAddRows = false;
            dgvKartuKeluargaPetugas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvKartuKeluargaPetugas.CellClick += dgvKartuKeluargaPetugas_CellClick;

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
        private void txtKK_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan angka (0-9) dan backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void txtRT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan angka (0-9) dan backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }



    }
}

