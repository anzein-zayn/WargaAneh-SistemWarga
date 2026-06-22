
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormKeluargaPetugas : Form
    {
        private readonly string connectionString =
            "Data Source=192.168.1.11,1433;Initial Catalog=SistemWarga;User ID=sa;Password=12345678;TrustServerCertificate=True;";

        private BindingSource bindingSource = new BindingSource();
        private DataTable dtKK = new DataTable();


        public FormKeluargaPetugas()
        {
            InitializeComponent();
        }

        private void FormKeluargaPetugas_Load(object sender, EventArgs e)
        {
            dgvKartuKeluargaPetugas.AutoGenerateColumns = true;
            dgvKartuKeluargaPetugas.DataSource = bindingSource;
            dgvKartuKeluargaPetugas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKartuKeluargaPetugas.MultiSelect = false;
            dgvKartuKeluargaPetugas.ReadOnly = true;
            dgvKartuKeluargaPetugas.AllowUserToAddRows = false;
            dgvKartuKeluargaPetugas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingNavigator1.BindingSource = bindingSource;
            bindingSource.PositionChanged += BindingSource_PositionChanged;

            LoadData();
            HitungTotal();
        }


        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllKartuKeluarga", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dtKK = new DataTable();
                        da.Fill(dtKK);

                        bindingSource.DataSource = dtKK;
                        dgvKartuKeluargaPetugas.DataSource = bindingSource;

                        BindControls();
                    }
                }
            }
            HitungTotal();
        }


        private void dgvKartuKeluargaPetugas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvKartuKeluargaPetugas.Rows[e.RowIndex];

            txtKepalaKeluarga.Text = row.Cells["KepalaKeluarga"].Value?.ToString() ?? "";
            txtNoKK.Text = row.Cells["NoKK"].Value?.ToString() ?? "";
            txtRT.Text = row.Cells["RT"].Value?.ToString() ?? "";
            txtAlamat.Text = row.Cells["Alamat"].Value?.ToString() ?? "";
        }
        private void HitungTotal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CountKartuKeluarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        lblTotal.Text = "Total KK: " + outputParam.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total: " + ex.Message);
            }
        }

        private void BindControls()
        {
            if (bindingSource.Current == null) return;
            DataRowView row = (DataRowView)bindingSource.Current;

            txtNoKK.Text = row["NoKK"].ToString();
            txtKepalaKeluarga.Text = row["KepalaKeluarga"].ToString();
            txtRT.Text = row["RT"].ToString();
            txtAlamat.Text = row["Alamat"].ToString();

        }

        private void BindingSource_PositionChanged(object sender, EventArgs e)
        {
            BindControls();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoKK.Text))
            {
                MessageBox.Show("Masukkan Nomor KK atau Nama Kepala Keluarga untuk mencari.");
                txtNoKK.Focus();
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_SearchKartuKeluarga", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", txtNoKK.Text.Trim());

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dtKK = new DataTable();
                        da.Fill(dtKK);
                        bindingSource.DataSource = dtKK;
                        dgvKartuKeluargaPetugas.DataSource = bindingSource;
                    }
                }
                if (dtKK.Rows.Count == 0) MessageBox.Show("Data tidak ditemukan.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari data: " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidasiForm()) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertKartuKeluarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NoKK", txtNoKK.Text.Trim());
                        cmd.Parameters.AddWithValue("@KepalaKeluarga", txtKepalaKeluarga.Text.Trim());
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@RT", txtRT.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data KK berhasil ditambahkan.");
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidasiForm()) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateKartuKeluarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NoKK", txtNoKK.Text.Trim());
                        cmd.Parameters.AddWithValue("@KepalaKeluarga", txtKepalaKeluarga.Text.Trim());
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@RT", txtRT.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil diupdate.");
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private bool ValidasiForm()
        {
            if (string.IsNullOrWhiteSpace(txtNoKK.Text))
            {
                MessageBox.Show("Nomor KK harus diisi.");
                txtNoKK.Focus();
                return false;
            }

            if (txtNoKK.Text.Length != 16)
            {
                MessageBox.Show("Nomor KK harus 16 digit.");
                txtNoKK.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKepalaKeluarga.Text))
            {
                MessageBox.Show("Nama Kepala Keluarga harus diisi.");
                txtKepalaKeluarga.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAlamat.Text))
            {
                MessageBox.Show("Alamat harus diisi.");
                txtAlamat.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRT.Text))
            {
                MessageBox.Show("RT harus diisi.");
                txtRT.Focus();
                return false;
            }
            if (txtRT.Text.Length > 3)
            {
                MessageBox.Show("RT maksimal 3 digit.");
                txtRT.Focus();
                return false;
            }
            return true;
        }
        private void ClearForm()
        {
            txtKepalaKeluarga.Clear(); txtNoKK.Clear();
            txtRT.Clear(); txtAlamat.Clear();

            txtNoKK.Focus();
        }

        private void txtNoKK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtNoKK.Text.Length >= 16 &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtKK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtRT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtRT.Text.Length >= 3 &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}