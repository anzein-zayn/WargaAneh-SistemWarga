using System;

namespace SistemWarga
{
    public class DataWargaDetail
    {
        public string NIK { get; set; }
        public string Nama { get; set; }
        public string TempatLahir { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string JenisKelamin { get; set; }
        public string NoKK { get; set; }
        public string StatusKeluarga { get; set; }
        public string Judul { get; set; }   // ⬅️ kolom tambahan untuk judul dinamis di report
    }
}