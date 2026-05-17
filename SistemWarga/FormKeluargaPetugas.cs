
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormKeluargaPetugas : Form
    {
        private readonly string connectionString =
            "Data Source=DESKTOP-V6AL6JT\\ZAKYZEIN;Initial Catalog=SistemWarga;Integrated Security=True";

        private BindingSource bindingSource = new BindingSource();
        private DataTable dtKK = new DataTable();


        public FormKeluargaPetugas()
        {
            InitializeComponent();
        }

        private void FormKeluargaAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sistemWargaDataSet5.KartuKeluarga' table. You can move, or remove it, as needed.
            this.kartuKeluargaTableAdapter.Fill(this.sistemWargaDataSet5.KartuKeluarga);
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKartuKeluargaPetugas.Rows[e.RowIndex];

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
                            dgvKartuKeluargaPetugas.DataSource = bindingSource;
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

        private void txtKepalaKeluarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }
        private void txtRT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }


    }
}