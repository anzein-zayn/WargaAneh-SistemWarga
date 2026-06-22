

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormSuratPetugas : Form
    {
        private readonly string connectionString =
            "Data Source=192.168.1.11,1433;Initial Catalog=SistemWarga;User ID=sa;Password=12345678;TrustServerCertificate=True;";

        private BindingSource bindingSource = new BindingSource();
        private DataTable dtSurat = new DataTable();
        private int selectedIdSurat = 0;

        public FormSuratPetugas()
        {
            InitializeComponent();
            dtpTP.MaxDate = DateTime.Today;
            dtpTP.Value = DateTime.Today;
        }

        private void FormSuratPetugas_Load(object sender, EventArgs e)
        {

            cmbJS.Items.Clear();
            cmbJS.Items.AddRange(new object[]
            {
                "Surat Keterangan Domisili",
                "Surat Keterangan Tidak Mampu",
                "Surat Pengantar SKCK"
            });

            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[] { "Pending", "Selesai" });

            dgvSurat.AutoGenerateColumns = true;
            dgvSurat.DataSource = bindingSource;
            dgvSurat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSurat.MultiSelect = false;
            dgvSurat.ReadOnly = true;
            dgvSurat.AllowUserToAddRows = false;
            dgvSurat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmbJS.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            txtNIK.MaxLength = 16;
            bindingNavigator1.BindingSource = bindingSource;
            bindingSource.PositionChanged += BindingSource_PositionChanged;



            LoadData();

        }

        private void dgvSurat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvSurat.Rows[e.RowIndex];

            if (row.Cells["IdSurat"].Value != DBNull.Value)
                selectedIdSurat = Convert.ToInt32(row.Cells["IdSurat"].Value);

            cmbStatus.Text = row.Cells["StatusSurat"].Value?.ToString() ?? "";
            cmbJS.Text = row.Cells["JenisSurat"].Value?.ToString() ?? "";

            if (row.Cells["TanggalPengajuan"].Value != DBNull.Value)
                dtpTP.Value = Convert.ToDateTime(row.Cells["TanggalPengajuan"].Value);

            txtNIK.Text = row.Cells["NIK"].Value?.ToString() ?? "";
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllSuratPengantar", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dtSurat = new DataTable();
                        da.Fill(dtSurat);

                        bindingSource.DataSource = dtSurat;
                        dgvSurat.DataSource = bindingSource;
                        if (dtSurat.Rows.Count > 0)
                        {
                            BindControls();
                        }
                        cmbJS.DropDownStyle = ComboBoxStyle.DropDownList;
                        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                }
            }

        }



        private void BindControls()
        {
            if (bindingSource.Current == null) return;
            DataRowView row = (DataRowView)bindingSource.Current;

            txtIdSurat.Text = row["IdSurat"].ToString();
            txtNIK.Text = row["NIK"].ToString();
            cmbJS.Text = row["JenisSurat"].ToString();
            cmbStatus.Text = row["StatusSurat"].ToString();
            if (row["IdSurat"] != DBNull.Value)
            {
                selectedIdSurat = Convert.ToInt32(row["IdSurat"]);
            }

            if (row["TanggalPengajuan"] != DBNull.Value)
                dtpTP.Value = Convert.ToDateTime(row["TanggalPengajuan"]);
        }

        private void BindingSource_PositionChanged(object sender, EventArgs e) => BindControls();

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdSurat.Text))
            {
                MessageBox.Show("Masukkan ID Surat terlebih dahulu.");
                txtIdSurat.Focus();
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchSuratPengantar", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Keyword", txtIdSurat.Text.Trim());

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtSurat = new DataTable();
                            da.Fill(dtSurat);
                            bindingSource.DataSource = dtSurat;
                            dgvSurat.DataSource = bindingSource;
                            if (dtSurat.Rows.Count > 0)
                            {
                                bindingSource.Position = 0;
                                BindControls();
                            }
                        }
                    }
                }
                if (dtSurat.Rows.Count == 0) MessageBox.Show("Data tidak ditemukan.");
            }
            catch (Exception ex) { MessageBox.Show("Gagal mencari data: " + ex.Message); }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidasiForm()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertSuratPengantar", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NIK", txtNIK.Text.Trim());
                        cmd.Parameters.AddWithValue("@JenisSurat", cmbJS.Text);
                        cmd.Parameters.AddWithValue("@TanggalPengajuan", dtpTP.Value.Date);
                        cmd.Parameters.AddWithValue("@StatusSurat", cmbStatus.Text);




                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data Surat berhasil ditambahkan.");
                ClearForm(); LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // ── UPDATE ────────────────────────────────────────────────
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedIdSurat == 0)
            { MessageBox.Show("Pilih data dari tabel terlebih dahulu."); return; }
            if (!ValidasiForm()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateSuratPengantar", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdSurat", selectedIdSurat);
                        cmd.Parameters.AddWithValue("@NIK", txtNIK.Text.Trim());
                        cmd.Parameters.AddWithValue("@JenisSurat", cmbJS.Text);
                        cmd.Parameters.AddWithValue("@TanggalPengajuan", dtpTP.Value.Date);
                        cmd.Parameters.AddWithValue("@StatusSurat", cmbStatus.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil diupdate.");
                ClearForm(); LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Terjadi kesalahan: " + ex.Message); }
        }

        private bool ValidasiForm()
        {
            if (string.IsNullOrWhiteSpace(txtNIK.Text))
            { MessageBox.Show("NIK harus diisi."); txtNIK.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(cmbJS.Text))
            { MessageBox.Show("Jenis Surat harus dipilih."); cmbJS.Focus(); return false; }
            if (txtNIK.Text.Length != 16)
            {
                MessageBox.Show("NIK harus 16 digit.");
                txtNIK.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            { MessageBox.Show("Status Surat harus dipilih."); cmbStatus.Focus(); return false; }
            if (!long.TryParse(txtNIK.Text, out _))
            {
                MessageBox.Show("NIK hanya boleh berisi angka.");
                txtNIK.Focus();
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtIdSurat.Clear(); txtNIK.Clear();
            cmbJS.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            dtpTP.Value = DateTime.Today;
            selectedIdSurat = 0;
            txtNIK.Focus();
        }

        private void txtIDSurat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
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

    }
}