using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemWarga
{
    public partial class HalamanUtama: Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
        ("Data Source=DESKTOP-V6AL6JT\\ZAKYZEIN;Initial Catalog=SistemWarga;Integrated Security=True");
        public HalamanUtama()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Username dan Password harus diisi!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Gunakan Query Parameter untuk mencegah SQL Injection
                    string query = "SELECT Role FROM Users WHERE Username=@user AND Password=@pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString();
                        MessageBox.Show("Login Berhasil sebagai " + role);

                        // Logika Pengalihan Dashboard
                        if (role == "Admin")
                        {
                            FormDashboardAdmin adminForm = new FormDashboardAdmin();
                            adminForm.Show();
                        }
                        else if (role == "Petugas")
                        {
                            FormDashboardPetugas petugasForm = new FormDashboardPetugas();
                            petugasForm.Show();
                        }

                        this.Hide(); // Sembunyikan form login
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password Salah!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

