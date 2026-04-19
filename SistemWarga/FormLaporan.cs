using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace SistemWarga
{
    public partial class FormLaporan : Form
    {

        private readonly SqlConnection conn;
        private readonly string connectionString =
        ("Data Source=DESKTOP-V6AL6JT\\ZAKYZEIN;Initial Catalog=SistemWarga;Integrated Security=True");

        public FormLaporan()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }
    
    private void btnTampil_Click(object sender, EventArgs e)
        {
            string query = "";

            if (cmbLaporan.Text == "Total Warga & KK")
            {
                query = @"SELECT 
                 (SELECT COUNT(*) FROM Warga) AS TotalWarga,
                 (SELECT COUNT(*) FROM KartuKeluarga) AS TotalKK";
            }
            else if (cmbLaporan.Text == "Jenis Kelamin")
            {
                query = @"SELECT JenisKelamin, COUNT(*) AS Jumlah
                  FROM Warga
                  GROUP BY JenisKelamin";
            }
            else if (cmbLaporan.Text == "Per RT")
            {
                query = @"SELECT KK.RT, COUNT(W.NIK) AS JumlahWarga
                  FROM Warga W
                  JOIN KartuKeluarga KK ON W.IdKK = KK.IdKK
                  GROUP BY KK.RT";
            }

            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvLaporan.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvLaporan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLaporan.Rows[e.RowIndex];

                cmbLaporan.Text = row.Cells["StatusSurat"].Value.ToString();
                
            }
        }
        private void FormLaporan_Load(object sender, EventArgs e)
        {
            cmbLaporan.Items.Clear();
            cmbLaporan.Items.Add("Total Warga & KK");
            cmbLaporan.Items.Add("Jenis Kelamin");
            cmbLaporan.Items.Add("Per RT");
           

            dgvLaporan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLaporan.MultiSelect = false;
            dgvLaporan.ReadOnly = true;
            dgvLaporan.AllowUserToAddRows = false;
            dgvLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvLaporan.CellClick += dgvLaporan_CellClick;
        }
    }
}