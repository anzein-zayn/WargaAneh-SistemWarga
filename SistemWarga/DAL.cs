using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemWarga
{
    public class DAL
    {
        public static string GetConnectionString()
        {
            string connectionString = "Data Source=192.168.1.11,1433;Initial Catalog=SistemWarga;User ID=sa;Password=12345678;TrustServerCertificate=True;";
            return connectionString;

        }

        // Field ini sebenarnya tidak terpakai di method lain — boleh dihapus
        // atau dibiarkan kalau memang dipakai di tempat lain (cek juga ya)

        public DataTable GetDashboardKartuKeluarga()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand("sp_DashboardKartuKeluarga", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetDashboardWargaGender()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand("sp_DashboardWargaGender", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetDashboardSuratJenis(int tahun)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand("sp_DashboardSuratJenis", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inTahun", tahun.ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetDashboardSuratStatus(int tahun)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand("sp_DashboardSuratStatus", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inTahun", tahun.ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetReportSurat(string jenisSurat, int tahun)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand("sp_ReportSurat", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inJenisSurat",
                    jenisSurat == "Semua" ? (object)DBNull.Value : jenisSurat);
                cmd.Parameters.AddWithValue("@inTahun", tahun.ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetLaporanWarga(string jenisFilter)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand("sp_LaporanWarga", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JenisFilter", jenisFilter);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string judul;
                switch (jenisFilter)
                {
                    case "Jenis Kelamin":
                        judul = "LAPORAN WARGA PER JENIS KELAMIN";
                        break;
                    case "Per RT":
                        judul = "LAPORAN WARGA PER RT";
                        break;
                    default:
                        judul = "LAPORAN WARGA SESUAI STATUS KELUARGA";
                        break;
                }

                dt.Columns.Add("Judul", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    row["Judul"] = judul;
                }

                return dt;
            }
        }

        public DataTable GetLaporanWargaFiltered(string jenisLaporan, string tipeData)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand("sp_LaporanWargaFiltered", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JenisLaporan", jenisLaporan);
                cmd.Parameters.AddWithValue("@TipeData", tipeData);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public static string GetLocalIPAddress()
        {
            string localIP = string.Empty;
            try
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting local IP address: " + ex.Message);
            }
            return localIP;
        }
    }
}