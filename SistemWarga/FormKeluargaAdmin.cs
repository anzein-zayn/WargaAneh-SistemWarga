using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormKeluargaAdmin : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
        ("Data Source=DESKTOP-V6AL6JT\\ZAKYZEIN;Initial Catalog=SistemWarga;Integrated Security=True");

        public FormKeluargaAdmin()
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


                dgvKeluargaAdmin.Rows.Clear();
                dgvKeluargaAdmin.Columns.Clear();

                dgvKeluargaAdmin.Columns.Add("KepalaKeluarga", "Kepala Keluarga");
                dgvKeluargaAdmin.Columns.Add("NoKK", "NoKK");
                dgvKeluargaAdmin.Columns.Add("IdKK", "IdKK");
                dgvKeluargaAdmin.Columns.Add("Alamat", "Alamat");
                dgvKeluargaAdmin.Columns.Add("RT", "RT");
                string query = "SELECT * FROM KartuKeluarga";


                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvKeluargaAdmin.Rows.Add(
                    reader["KepalaKeluarga"].ToString(),
                    reader["NoKK"].ToString(),
                    reader["IdKK"].ToString(),
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

                if (txtIdKK.Text == "")
                {
                    MessageBox.Show("IdKK harus diisi");
                    txtIdKK.Focus();
                    return;
                }

                string query = @"INSERT INTO KartuKeluarga
                                (KepalaKeluarga, NoKK , RT, Alamat, IdKK)
                                VALUES
                               (@KepalaKeluarga, @NoKK ,@RT, @Alamat, @IdKK)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@KepalaKeluarga", txtKepalaKeluarga.Text);
                cmd.Parameters.AddWithValue("@NoKK", txtNoKK.Text);
                cmd.Parameters.AddWithValue("@RT", txtRT.Text);
                cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@IdKK", txtIdKK.Text);


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
                                IdKK = @IdKK
                                WHERE NoKK = @NoKK";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@KepalaKeluarga", txtKepalaKeluarga.Text);
                cmd.Parameters.AddWithValue("@NoKK", txtNoKK.Text);
                cmd.Parameters.AddWithValue("@RT", txtRT.Text);
                cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@IdKK", txtIdKK.Text);

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
                    string query = "DELETE FROM KartuKeluarga WHERE IdKK = @IdKK";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdKK", txtIdKK.Text);

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

        private void dgvKartuKeluargaAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKeluargaAdmin.Rows[e.RowIndex];

                txtKepalaKeluarga.Text = row.Cells["KepalaKeluarga"].Value.ToString();
                txtNoKK.Text = row.Cells["NoKK"].Value.ToString();
                txtRT.Text = row.Cells["RT"].Value.ToString();
                txtAlamat.Text = row.Cells["Alamat"].Value.ToString();
                txtIdKK.Text = row.Cells["IdKK"].Value.ToString();

            }
        }
        private void ClearForm()
        {
            txtKepalaKeluarga.Clear();
            txtNoKK.Clear();
            txtRT.Clear();
            txtAlamat.Clear();
            txtIdKK.Clear();
            txtIdKK.Focus();
        }
        private void FormKeluargaAdmin_Load(object sender, EventArgs e)
        {


            dgvKeluargaAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKeluargaAdmin.MultiSelect = false;
            dgvKeluargaAdmin.ReadOnly = true;
            dgvKeluargaAdmin.AllowUserToAddRows = false;
            dgvKeluargaAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvKeluargaAdmin.CellClick += dgvKartuKeluargaAdmin_CellClick;
        }

    }
}

