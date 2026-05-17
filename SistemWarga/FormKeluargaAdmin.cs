
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormKeluargaAdmin : Form
    {
        private readonly string connectionString =
            "Data Source=DESKTOP-V6AL6JT\\ZAKYZEIN;Initial Catalog=SistemWarga;Integrated Security=True";

        private BindingSource bindingSource = new BindingSource();
        private DataTable dtKK = new DataTable();


        public FormKeluargaAdmin()
        {
            InitializeComponent();
        }

        private void FormKeluargaAdmin_Load(object sender, EventArgs e)
        {
            dgvKeluargaAdmin.AutoGenerateColumns = true;
            dgvKeluargaAdmin.DataSource = bindingSource;
            dgvKeluargaAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKeluargaAdmin.MultiSelect = false;
            dgvKeluargaAdmin.ReadOnly = true;
            dgvKeluargaAdmin.AllowUserToAddRows = false;
            dgvKeluargaAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
                        dgvKeluargaAdmin.DataSource = bindingSource;

                        BindControls();
                    }
                }
            }
            HitungTotal();
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
            }
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
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchKartuKeluarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Keyword", txtNoKK.Text.Trim());

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtKK = new DataTable();
                            da.Fill(dtKK);
                            bindingSource.DataSource = dtKK;
                            dgvKeluargaAdmin.DataSource = bindingSource;
                        }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteKartuKeluarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@NoKK", SqlDbType.Int).Value = txtNoKK.Text.Trim();

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Data berhasil dihapus.");
                        else
                            MessageBox.Show("Data tidak ditemukan.");
                    }
                }

                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }


        private void ClearForm()
        {
            txtKepalaKeluarga.Clear(); txtNoKK.Clear();
            txtRT.Clear(); txtAlamat.Clear();

            txtNoKK.Focus();
        }

        private void txtNoKK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }
        private void txtKK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        private void txtRT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }


    }
}