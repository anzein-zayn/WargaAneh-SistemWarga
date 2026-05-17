using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace SistemWarga
{
    public partial class FormWargaPetugas: Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
        ("Data Source=DESKTOP-V6AL6JT\\ZAKYZEIN;Initial Catalog=SistemWarga;Integrated Security=True");
        private BindingSource bindingSource = new BindingSource();
        private DataTable dtWarga = new DataTable();
        public FormWargaPetugas()
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

                        BindControls();
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

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertWarga", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

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
        private void cmbJenisKelamin_SelectedIndexChanged(object sender, EventArgs e)
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
            // TODO: This line of code loads data into the 'sistemWargaDataSet5.Warga' table. You can move, or remove it, as needed.
            this.wargaTableAdapter.Fill(this.sistemWargaDataSet5.Warga);

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

            LoadWarga();
            HitungTotal();
        }

        private void txtNoKK_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan angka (0-9) dan backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
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





    }
}

