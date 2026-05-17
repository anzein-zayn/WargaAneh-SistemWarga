

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class FormSuratAdmin : Form
    {
        private readonly string connectionString =
            "Data Source=DESKTOP-V6AL6JT\\ZAKYZEIN;Initial Catalog=SistemWarga;Integrated Security=True";

        private BindingSource bindingSource = new BindingSource();
        private DataTable dtSurat = new DataTable();
        private int selectedIdSurat = 0;

        public FormSuratAdmin()
        {
            InitializeComponent();
            dtpTP.MaxDate = DateTime.Today;
            dtpTP.Value = DateTime.Today;
        }

        private void FormSuratAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sistemWargaDataSet5.SuratPengantar' table. You can move, or remove it, as needed.
            this.suratPengantarTableAdapter1.Fill(this.sistemWargaDataSet5.SuratPengantar);

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

            bindingNavigator1.BindingSource = bindingSource;
            bindingSource.PositionChanged += BindingSource_PositionChanged;

            LoadData();

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

                        BindControls();
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
            selectedIdSurat = Convert.ToInt32(row["IdSurat"]);

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
                        }
                    }
                }
                if (dtSurat.Rows.Count == 0) MessageBox.Show("Data tidak ditemukan.");
            }
            catch (Exception ex) { MessageBox.Show("Gagal mencari data: " + ex.Message); }
        }

        // ── INSERT ────────────────────────────────────────────────
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

        // ── DELETE ────────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedIdSurat == 0)
            { MessageBox.Show("Pilih data dari tabel terlebih dahulu."); return; }

            DialogResult confirm = MessageBox.Show("Yakin ingin menghapus surat ini?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteSuratPengantar", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@IdSurat", SqlDbType.Int).Value = selectedIdSurat;

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Data berhasil dihapus.");
                        else
                            MessageBox.Show("Data tidak ditemukan.");
                    }
                }

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
            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            { MessageBox.Show("Status Surat harus dipilih."); cmbStatus.Focus(); return false; }
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
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }
    }
}