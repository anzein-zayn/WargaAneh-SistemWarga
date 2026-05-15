
CREATE DATABASE SistemWarga;
GO

CREATE TABLE Users (
    IdUser    INT PRIMARY KEY ,
    Username  NVARCHAR(50)  NOT NULL UNIQUE,
    Password  NVARCHAR(255) NOT NULL,
    Role      NVARCHAR(20)  NOT NULL check (Role in ('Admin', 'Petugas'))
);

CREATE TABLE KartuKeluarga (
    NoKK           varchar (16)PRIMARY KEY  NOT NULL ,
    KepalaKeluarga VARCHAR(100) NOT NULL,
    Alamat         VARCHAR(255) NOT NULL,
    RT             VARCHAR(5)   NOT NULL
);

CREATE TABLE Warga (
    NIK           varchar (16)PRIMARY KEY  NOT NULL ,
    Nama          VARCHAR(100) NOT NULL,
    TempatLahir   VARCHAR(100) NOT NULL,
    TanggalLahir  DATE NOT NULL,
    JenisKelamin  VARCHAR(20)  NOT NULL check (JenisKelamin in ('L','P')),
    NoKK         varchar(16) NOT NULL REFERENCES KartuKeluarga(NoKK),
    StatusKeluarga VARCHAR(50) NOT NULL check (StatusKeluarga in ('Kepala Keluarga','Istri', 'Anak'))
);

CREATE TABLE SuratPengantar (
    IdSurat          INT PRIMARY KEY,
    NIK          varchar (16)  REFERENCES Warga(NIK) ON DELETE CASCADE,
    JenisSurat       VARCHAR(100) NOT NULL,
    TanggalPengajuan DATE NOT NULL DEFAULT GETDATE(),
    StatusSurat      VARCHAR(50)  NOT NULL check (StatusSurat in ('Pending','Selesai'))
);

INSERT INTO Users (IdUser, Username , Password, Role)
VALUES
    (1, 'admin',    'admin123',    'Admin'),
    (2,'petugas1', 'petugas123',  'Petugas');

INSERT INTO KartuKeluarga (NoKK, KepalaKeluarga, Alamat, RT)
VALUES
    ('3371010101010001', 'Budi Santoso',   'Jl. Mawar No. 1', '001'),
    ('3371010101010002', 'Siti Rahayu',    'Jl. Melati No. 5', '002');

INSERT INTO Warga ( NIK, Nama, TempatLahir, TanggalLahir, JenisKelamin, NoKK, StatusKeluarga)
VALUES
    ('3371010101010001', 'Budi Santoso',   'Yogyakarta', '1980-01-15', 'L',  '3371010101010001', 'Kepala Keluarga'),
    ('3371010101010002', 'Dewi Santoso',   'Yogyakarta', '1985-06-20', 'P',  '3371010101010001', 'Istri'),
    ('3371010101010003', 'Andi Santoso',   'Yogyakarta', '2005-03-10', 'L',   '3371010101010001', 'Anak'),
    ('3371010101010004', 'Siti Rahayu',    'Solo',       '1975-09-05', 'P',   '3371010101010002', 'Kepala Keluarga');

INSERT INTO SuratPengantar (IdSurat, NIK, JenisSurat, TanggalPengajuan, StatusSurat)
VALUES
    (1,'3371010101010001', 'Surat Keterangan Domisili', '2025-01-10', 'Selesai'),
    (2,'3371010101010003', 'Surat Keterangan Tidak Mampu', '2025-02-15', 'Pending'),
    (3,'3371010101010004', 'Surat Pengantar SKCK', '2025-03-01', 'Selesai');

CREATE VIEW vw_Warga AS
    SELECT
        w.NIK,
        w.Nama,
        w.JenisKelamin,
        w.TanggalLahir,
        w.TempatLahir,
        kk.NoKK,
        w.StatusKeluarga
    FROM Warga w
    INNER JOIN KartuKeluarga kk ON w.NoKK = kk.NoKK;


CREATE VIEW vw_KartuKeluarga AS
    SELECT
        kk.NoKK,
        kk.KepalaKeluarga,
        kk.Alamat,
        kk.RT,
        COUNT(w.NIK) AS JumlahAnggota
    FROM KartuKeluarga kk
    LEFT JOIN Warga w ON kk.NoKK = w.NoKK
    GROUP BY kk.NoKK, kk.NoKK, kk.KepalaKeluarga, kk.Alamat, kk.RT;

CREATE VIEW vw_SuratPengantar AS
SELECT
    sp.IdSurat,
    sp.NIK,
    w.Nama,
    sp.JenisSurat,
    sp.TanggalPengajuan,
    sp.StatusSurat
FROM SuratPengantar sp
INNER JOIN Warga w ON sp.NIK = w.NIK;


---WARGA---

CREATE PROCEDURE SP_GetAllWarga
AS
BEGIN
    SET NOCOUNT ON;
    -- Menggunakan VIEW vw_Warga agar data sudah ter-JOIN dengan KartuKeluarga
    SELECT NIK, Nama, JenisKelamin, TanggalLahir, TempatLahir, NoKK, NoKK, StatusKeluarga
    FROM vw_Warga
    ORDER BY Nama;
END;


CREATE PROCEDURE SP_SearchWarga
    @Keyword NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT NIK, Nama, JenisKelamin, TanggalLahir, TempatLahir, NoKK, NoKK, StatusKeluarga
    FROM vw_Warga
    WHERE Nama LIKE '%' + @Keyword + '%'
       OR NIK  LIKE '%' + @Keyword + '%'
    ORDER BY Nama;
END;


CREATE PROCEDURE SP_InsertWarga
    @NIK            VARCHAR(16),
    @Nama           VARCHAR(100),
    @TempatLahir    VARCHAR(100),
    @TanggalLahir   DATE,
    @JenisKelamin   VARCHAR(20),
    @NoKK           INT,
    @StatusKeluarga VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
 
    -- Validasi: apakah NoKK ada di tabel KartuKeluarga
    IF NOT EXISTS (SELECT 1 FROM KartuKeluarga WHERE NoKK = @NoKK)
    BEGIN
        RAISERROR('NoKK tidak ditemukan di tabel KartuKeluarga.', 16, 1);
        RETURN;
    END
 
    -- Validasi: apakah NIK sudah ada
    IF EXISTS (SELECT 1 FROM Warga WHERE NIK = @NIK)
    BEGIN
        RAISERROR('NIK sudah terdaftar.', 16, 1);
        RETURN;
    END
 
    INSERT INTO Warga (NIK, Nama, TempatLahir, TanggalLahir, JenisKelamin, NoKK, StatusKeluarga)
    VALUES (@NIK, @Nama, @TempatLahir, @TanggalLahir, @JenisKelamin, @NoKK, @StatusKeluarga);
END;