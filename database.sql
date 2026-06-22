
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

	ALTER TABLE Warga ADD CONSTRAINT
    CHK_NIK_AngkaSaja
    CHECK (NIK NOT LIKE '%[^0-9]%');

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
    GROUP BY kk.NoKK,  kk.KepalaKeluarga, kk.Alamat, kk.RT;

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

CREATE PROCEDURE sp_CountWarga
	@Total INT OUTPUT
	as
	BEGIN
	SET NOCOUNT ON;
	SELECT @Total = COUNT(*)FROM Warga

END;

CREATE PROCEDURE sp_CountKartuKeluarga
	@Total INT OUTPUT
	as
	BEGIN
	SET NOCOUNT ON;
	SELECT @Total = COUNT(*)FROM KartuKeluarga

END;

CREATE PROCEDURE SP_GetAllWarga
AS
BEGIN
    SET NOCOUNT ON;
    -- Menggunakan VIEW vw_Warga agar data sudah ter-JOIN dengan KartuKeluarga
    SELECT
    NIK,
    Nama,
    JenisKelamin,
    TanggalLahir,
    TempatLahir,
    NoKK,
    StatusKeluarga
FROM vw_Warga
ORDER BY Nama;
END;


CREATE PROCEDURE SP_SearchWarga
    @Keyword NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
		SELECT
		NIK,
		Nama,
		JenisKelamin,
		TanggalLahir,
		TempatLahir,
		NoKK,
		StatusKeluarga
		FROM vw_Warga
		WHERE Nama LIKE '%' + @Keyword + '%'
		   OR NIK LIKE '%' + @Keyword + '%'
		ORDER BY Nama;
	END;


CREATE PROCEDURE SP_InsertWarga
    @NIK            VARCHAR(16),
    @Nama           VARCHAR(100),
    @TempatLahir    VARCHAR(100),
    @TanggalLahir   DATE,
    @JenisKelamin   VARCHAR(20),
    @NoKK           VARCHAR(16),
    @StatusKeluarga VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
	
	 IF NOT EXISTS (
            SELECT 1
            FROM KartuKeluarga
            WHERE NoKK = @NoKK
        )
        BEGIN
            RAISERROR(
            'Nomor KK tidak ditemukan.',
            16,1);
            RETURN;
        END;
    -- Validasi: apakah NIK sudah ada
    IF EXISTS (SELECT 1 FROM Warga WHERE NIK = @NIK)
    BEGIN
        RAISERROR('NIK sudah terdaftar.', 16, 1);
        RETURN;
    END;
	IF LEN(@NIK) <> 16
	BEGIN
		RAISERROR('NIK harus 16 digit.',16,1)
		RETURN;
	END;

	IF @NIK LIKE '%[^0-9]%'
	BEGIN
		RAISERROR('NIK hanya boleh berisi angka.',16,1)
		RETURN;
	END;

	IF @TanggalLahir > GETDATE()
	BEGIN
    RAISERROR('Tanggal lahir tidak boleh melebihi tanggal hari ini.',16,1);
    RETURN;
	END;
 
    INSERT INTO Warga (NIK, Nama, TempatLahir, TanggalLahir, JenisKelamin, NoKK, StatusKeluarga)
    VALUES (@NIK, @Nama, @TempatLahir, @TanggalLahir, @JenisKelamin, @NoKK, @StatusKeluarga);

END;


CREATE PROCEDURE SP_UpdateWarga
    @NIK            VARCHAR(16),
    @Nama           VARCHAR(100),
    @TempatLahir    VARCHAR(100),
    @TanggalLahir   DATE,
    @JenisKelamin   VARCHAR(20),
    @NoKK           VARCHAR(16),
    @StatusKeluarga VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
	IF @TanggalLahir > GETDATE()
	BEGIN
		RAISERROR(
		'Tanggal lahir tidak boleh melebihi tanggal hari ini.',
		16,1);
		RETURN;
	END;
    IF NOT EXISTS (SELECT 1 FROM Warga WHERE NIK = @NIK)
    BEGIN
        RAISERROR('Data Warga dengan NIK tersebut tidak ditemukan.', 16, 1);
        RETURN;
    END;
	IF NOT EXISTS (
    SELECT 1
    FROM KartuKeluarga
    WHERE NoKK = @NoKK
)
	BEGIN
		RAISERROR(
		'Nomor KK tidak ditemukan.',
		16,1)
		RETURN;
	END;

	IF LEN(@NIK) <> 16
	BEGIN
		RAISERROR('NIK harus 16 digit.',16,1);
		RETURN;
	END;

	IF @NIK LIKE '%[^0-9]%'
	BEGIN
		RAISERROR('NIK hanya boleh berisi angka.',16,1);
		RETURN;
	END;
 
    UPDATE Warga
    SET Nama           = @Nama,
        TempatLahir    = @TempatLahir,
        TanggalLahir   = @TanggalLahir,
        JenisKelamin   = @JenisKelamin,
        NoKK           = @NoKK,
        StatusKeluarga = @StatusKeluarga
    WHERE NIK = @NIK;
END;


CREATE PROCEDURE SP_DeleteWarga
    @NIK VARCHAR(16)
AS
BEGIN
    SET NOCOUNT ON;
 
    IF NOT EXISTS (SELECT 1 FROM Warga WHERE NIK = @NIK)
    BEGIN
        RAISERROR('Data Warga dengan NIK tersebut tidak ditemukan.', 16, 1);
        RETURN;
    END;
 
    DELETE FROM Warga WHERE NIK = @NIK;
END;

---KARTU KELUARGA---

CREATE PROCEDURE SP_GetAllKartuKeluarga
AS
BEGIN
    SET NOCOUNT ON;
    SELECT  NoKK, KepalaKeluarga, Alamat, RT, JumlahAnggota
    FROM vw_KartuKeluarga
    ORDER BY NoKK;
END;
GO
 

CREATE PROCEDURE SP_SearchKartuKeluarga
    @Keyword NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT  NoKK, KepalaKeluarga, Alamat, RT, JumlahAnggota
    FROM vw_KartuKeluarga
    WHERE KepalaKeluarga LIKE '%' + @Keyword + '%'
       OR NoKK LIKE '%' + @Keyword + '%';
END;


 
CREATE PROCEDURE SP_InsertKartuKeluarga
    @NoKK           VARCHAR(16),
    @KepalaKeluarga VARCHAR(100),
    @Alamat         VARCHAR(255),
    @RT             VARCHAR(5)
AS
BEGIN
    SET NOCOUNT ON;
 
    IF EXISTS (SELECT 1 FROM KartuKeluarga WHERE NoKK = @NoKK)
    BEGIN
        RAISERROR('NoKK sudah terdaftar.', 16, 1);
        RETURN;
    END;
	IF LEN(@NoKK) <> 16
	BEGIN
		RAISERROR('Nomor KK harus 16 digit.',16,1)
		RETURN;
	END;

	IF @NoKK LIKE '%[^0-9]%'
	BEGIN
		RAISERROR('Nomor KK hanya boleh berisi angka.',16,1)
		RETURN;
	END;
	IF EXISTS (
    SELECT 1
    FROM KartuKeluarga
    WHERE Alamat = @Alamat
      AND NoKK <> @NoKK
)
	BEGIN
    RAISERROR(
        'Alamat sudah digunakan oleh Kartu Keluarga lain.',
        16,1
    );
    RETURN;
	END;
 
    INSERT INTO KartuKeluarga ( NoKK, KepalaKeluarga, Alamat, RT)
    VALUES (@NoKK, @KepalaKeluarga, @Alamat, @RT);
END;
GO

 
CREATE PROCEDURE SP_UpdateKartuKeluarga
    @NoKK           VARCHAR(16),
    @KepalaKeluarga VARCHAR(100),
    @Alamat         VARCHAR(255),
    @RT             VARCHAR(5)
AS
BEGIN
    SET NOCOUNT ON;
 
    IF NOT EXISTS (SELECT 1 FROM KartuKeluarga WHERE NoKK = @NoKK)
    BEGIN
        RAISERROR('Data KartuKeluarga tidak ditemukan.', 16, 1);
        RETURN;
    END;

	IF LEN(@NoKK) <> 16
	BEGIN
		RAISERROR('Nomor KK harus 16 digit.',16,1);
		RETURN;
	END;

	IF @NoKK LIKE '%[^0-9]%'
	BEGIN
		RAISERROR('Nomor KK hanya boleh berisi angka.',16,1);
		RETURN;
	END;
 
    UPDATE KartuKeluarga
    SET NoKK           = @NoKK,
        KepalaKeluarga = @KepalaKeluarga,
        Alamat         = @Alamat,
        RT             = @RT
    WHERE NoKK = @NoKK;
END;
GO

 
CREATE PROCEDURE SP_DeleteKartuKeluarga
    @NoKK VARCHAR(16)
AS
BEGIN
    SET NOCOUNT ON;
 
    IF NOT EXISTS (SELECT 1 FROM KartuKeluarga WHERE NoKK = @NoKK)
    BEGIN
        RAISERROR('Data KartuKeluarga tidak ditemukan.', 16, 1);
        RETURN;
    END;

	IF EXISTS(
    SELECT 1
    FROM Warga
    WHERE NoKK=@NoKK
)
	BEGIN
    RAISERROR(
    'Kartu Keluarga masih memiliki anggota warga.',
    16,1)
    RETURN;
	END;
 
    DELETE FROM KartuKeluarga WHERE NoKK = @NoKK;
END;
GO

-- SP SURAT PENGANTAR
-- ─────────────────────────────────────────
 
CREATE PROCEDURE SP_GetAllSuratPengantar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdSurat, NIK, Nama, JenisSurat, TanggalPengajuan, StatusSurat
    FROM vw_SuratPengantar
    ORDER BY TanggalPengajuan DESC;
END;
GO

 
CREATE PROCEDURE SP_SearchSuratPengantar
    @Keyword NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdSurat, NIK, Nama, JenisSurat, TanggalPengajuan, StatusSurat
    FROM vw_SuratPengantar
    WHERE NIK       LIKE '%' + @Keyword + '%'
       OR JenisSurat LIKE '%' + @Keyword + '%'
	   OR CAST(IdSurat AS VARCHAR(20))
			LIKE '%' + @Keyword + '%'
       OR Nama       LIKE '%' + @Keyword + '%';
END;
GO

 
CREATE PROCEDURE SP_InsertSuratPengantar
    @NIK              VARCHAR(16),
    @JenisSurat       VARCHAR(100),
    @TanggalPengajuan DATE,
    @StatusSurat      VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
 
    IF NOT EXISTS (SELECT 1 FROM Warga WHERE NIK = @NIK)
    BEGIN
        RAISERROR('NIK tidak ditemukan di tabel Warga.', 16, 1);
        RETURN;
    END;
	DECLARE @IdSurat INT;

	SELECT @IdSurat = ISNULL(MAX(IdSurat),0)+1
	FROM SuratPengantar;
 
    INSERT INTO SuratPengantar (IdSurat, NIK, JenisSurat, TanggalPengajuan, StatusSurat)
    VALUES (@IdSurat, @NIK, @JenisSurat, @TanggalPengajuan, @StatusSurat);
END;
GO

 
CREATE PROCEDURE SP_UpdateSuratPengantar
    @IdSurat          INT,
    @NIK              VARCHAR(16),
    @JenisSurat       VARCHAR(100),
    @TanggalPengajuan DATE,
    @StatusSurat      VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
 
    IF NOT EXISTS (SELECT 1 FROM SuratPengantar WHERE IdSurat = @IdSurat)
    BEGIN
        RAISERROR('Data Surat tidak ditemukan.', 16, 1);
        RETURN;
    END;
	IF NOT EXISTS (
    SELECT 1
    FROM Warga
    WHERE NIK = @NIK
	)
	BEGIN
		RAISERROR(
		'NIK tidak ditemukan.',
		16,1)
		RETURN;
	END;
 
    UPDATE SuratPengantar
    SET NIK              = @NIK,
        JenisSurat       = @JenisSurat,
        TanggalPengajuan = @TanggalPengajuan,
        StatusSurat      = @StatusSurat
    WHERE IdSurat = @IdSurat;
END;
GO

CREATE PROCEDURE SP_DeleteSuratPengantar
    @IdSurat INT
AS
BEGIN
    SET NOCOUNT ON;
 
    IF NOT EXISTS (SELECT 1 FROM SuratPengantar WHERE IdSurat = @IdSurat)
    BEGIN
        RAISERROR('Data Surat tidak ditemukan.', 16, 1);
        RETURN;
    END;
 
    DELETE FROM SuratPengantar WHERE IdSurat = @IdSurat;
END;
GO
 
  --LOGIN---

CREATE PROCEDURE SP_LoginUser
    @Username NVARCHAR(50),
    @Password NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM Users
        WHERE Username=@Username
        AND Password=@Password
    )
    BEGIN
        RAISERROR(
        'Username atau Password salah.',
        16,1);
        RETURN;
    END

    SELECT
        IdUser,
        Username,
        Role
    FROM Users
    WHERE Username=@Username
    AND Password=@Password;
END;
GO

SELECT *
INTO Warga_Backup
FROM Warga;

ALTER TABLE KartuKeluarga
ADD CONSTRAINT CHK_NoKK_AngkaSaja
CHECK (NoKK NOT LIKE '%[^0-9]%');

ALTER TABLE Warga
ADD CONSTRAINT CHK_NIK_16Digit
CHECK (
    LEN(NIK) = 16
    AND NIK NOT LIKE '%[^0-9]%'
);

ALTER TABLE KartuKeluarga
ADD CONSTRAINT CHK_RT_Angka
CHECK (
    RT NOT LIKE '%[^0-9]%'
);


select*from Warga
select*from KartuKeluarga

DELETE FROM SuratPengantar;
DELETE FROM Warga;
DELETE FROM KartuKeluarga;

SELECT *
FROM KartuKeluarga
WHERE NoKK = '3371010101010001';

ALTER TABLE KartuKeluarga
ADD CONSTRAINT UQ_KartuKeluarga_Alamat
UNIQUE(Alamat);
-- ====================================================
-- 1. SP_DeleteWarga
-- ====================================================
ALTER PROCEDURE SP_DeleteWarga
    @NIK VARCHAR(16)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Warga WHERE NIK = @NIK)
    BEGIN
        RAISERROR('Data Warga dengan NIK tersebut tidak ditemukan.', 16, 1);
        RETURN;
    END;

    DELETE FROM Warga WHERE NIK = @NIK;
END;
GO

-- ====================================================
-- 2. SP_DeleteKartuKeluarga
-- ====================================================
ALTER PROCEDURE SP_DeleteKartuKeluarga
    @NoKK VARCHAR(16)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM KartuKeluarga WHERE NoKK = @NoKK)
    BEGIN
        RAISERROR('Data KartuKeluarga tidak ditemukan.', 16, 1);
        RETURN;
    END;

    IF EXISTS (
        SELECT 1
        FROM Warga
        WHERE NoKK = @NoKK
    )
    BEGIN
        RAISERROR(
        'Kartu Keluarga masih memiliki anggota warga.',
        16,1)
        RETURN;
    END;

    DELETE FROM KartuKeluarga WHERE NoKK = @NoKK;
END;
GO

-- ====================================================
-- 3. SP_DeleteSuratPengantar
-- ====================================================
ALTER PROCEDURE SP_DeleteSuratPengantar
    @IdSurat INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM SuratPengantar WHERE IdSurat = @IdSurat)
    BEGIN
        RAISERROR('Data Surat tidak ditemukan.', 16, 1);
        RETURN;
    END;

    DELETE FROM SuratPengantar WHERE IdSurat = @IdSurat;
END;
GO

CREATE PROCEDURE sp_ReportSurat
    @inJenisSurat VARCHAR(100) = NULL,
    @inTahun CHAR(4)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        sp.IdSurat,
        w.Nama,
        w.NIK,
        sp.JenisSurat,
        sp.TanggalPengajuan,
        sp.StatusSurat
    FROM SuratPengantar sp
    INNER JOIN Warga w ON sp.NIK = w.NIK
    WHERE (@inJenisSurat IS NULL OR sp.JenisSurat = @inJenisSurat)
      AND YEAR(sp.TanggalPengajuan) = @inTahun
    ORDER BY sp.TanggalPengajuan DESC;
END;
GO

-- 1. Jumlah Kartu Keluarga per RT
CREATE PROCEDURE sp_DashboardKartuKeluarga
AS
BEGIN
    SET NOCOUNT ON;
    SELECT RT, COUNT(*) AS Jumlah
    FROM KartuKeluarga
    GROUP BY RT
    ORDER BY RT;
END;
GO

-- 2. Jumlah Warga per Jenis Kelamin
CREATE PROCEDURE sp_DashboardWargaGender
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        CASE JenisKelamin WHEN 'L' THEN 'Laki-laki' WHEN 'P' THEN 'Perempuan' END AS JenisKelamin,
        COUNT(*) AS Jumlah
    FROM Warga
    GROUP BY JenisKelamin;
END;
GO

-- 3. Jumlah Surat per Jenis Surat
CREATE PROCEDURE sp_DashboardSuratJenis
    @inTahun CHAR(4)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT JenisSurat, COUNT(*) AS Jumlah
    FROM SuratPengantar
    WHERE YEAR(TanggalPengajuan) = @inTahun
    GROUP BY JenisSurat;
END;
GO

-- 4. Jumlah Surat per Status
CREATE PROCEDURE sp_DashboardSuratStatus
    @inTahun CHAR(4)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT StatusSurat, COUNT(*) AS Jumlah
    FROM SuratPengantar
    WHERE YEAR(TanggalPengajuan) = @inTahun
    GROUP BY StatusSurat;
END;
GO

-- ============================================
-- SP Laporan Total Warga & KK
-- ============================================
CREATE PROCEDURE sp_LaporanTotal
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 'Total Warga' AS Kategori, COUNT(*) AS Jumlah FROM Warga
    UNION ALL
    SELECT 'Total Kartu Keluarga' AS Kategori, COUNT(*) AS Jumlah FROM KartuKeluarga;
END;
GO

-- ============================================
-- SP Laporan per Jenis Kelamin
-- ============================================
CREATE PROCEDURE sp_LaporanJenisKelamin
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        CASE JenisKelamin WHEN 'L' THEN 'Laki-laki' WHEN 'P' THEN 'Perempuan' END AS Kategori,
        COUNT(*) AS Jumlah
    FROM Warga
    GROUP BY JenisKelamin;
END;
GO

-- ============================================
-- SP Laporan per RT
-- ============================================
CREATE PROCEDURE sp_LaporanPerRT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        'RT ' + KK.RT AS Kategori,
        COUNT(W.NIK) AS Jumlah
    FROM KartuKeluarga KK
    LEFT JOIN Warga W ON W.NoKK = KK.NoKK
    GROUP BY KK.RT
    ORDER BY KK.RT;
END;
GO

CREATE TABLE LogAktivitas (
    IdLog INT IDENTITY PRIMARY KEY,
    NamaTabel VARCHAR(50),
    Aksi VARCHAR(10),
    NIK VARCHAR(16),
    WaktuAksi DATETIME DEFAULT GETDATE(),
    Keterangan VARCHAR(255)
);
GO

CREATE TRIGGER trg_AuditWarga
ON Warga
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO LogAktivitas (NamaTabel, Aksi, NIK, Keterangan)
        SELECT 'Warga', 'INSERT', NIK, 'Data warga baru ditambahkan: ' + Nama
        FROM inserted;
    END

    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO LogAktivitas (NamaTabel, Aksi, NIK, Keterangan)
        SELECT 'Warga', 'UPDATE', NIK, 'Data warga diubah: ' + Nama
        FROM inserted;
    END

    IF NOT EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO LogAktivitas (NamaTabel, Aksi, NIK, Keterangan)
        SELECT 'Warga', 'DELETE', NIK, 'Data warga dihapus: ' + Nama
        FROM deleted;
    END
END;
GO

CREATE TRIGGER trg_ValidasiStatusKeluarga
ON Warga
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted
        WHERE (JenisKelamin = 'P' AND StatusKeluarga = 'Kepala Keluarga')
           OR (JenisKelamin = 'L' AND StatusKeluarga = 'Istri')
    )
    BEGIN
        RAISERROR('Kombinasi JenisKelamin dan StatusKeluarga tidak valid.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

CREATE TRIGGER trg_AuditSurat
ON SuratPengantar
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO LogAktivitas (NamaTabel, Aksi, NIK, Keterangan)
        SELECT 'SuratPengantar', 'INSERT', NIK, 'Pengajuan surat baru: ' + JenisSurat
        FROM inserted;
    END

    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO LogAktivitas (NamaTabel, Aksi, NIK, Keterangan)
        SELECT 'SuratPengantar', 'UPDATE', NIK, 'Surat diubah: ' + JenisSurat
        FROM inserted;
    END

    IF NOT EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO LogAktivitas (NamaTabel, Aksi, NIK, Keterangan)
        SELECT 'SuratPengantar', 'DELETE', NIK, 'Surat dihapus: ' + JenisSurat
        FROM deleted;
    END
END;
GO
CREATE PROCEDURE sp_LaporanWargaFiltered
    @JenisLaporan NVARCHAR(50),
    @TipeData NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @JenisLaporan = 'Jenis Kelamin'
    BEGIN
        SELECT 
            NIK,
            Nama,
            TempatLahir,
            CONVERT(VARCHAR, TanggalLahir, 101) AS TanggalLahir,
            JenisKelamin,
            NoKK,
            StatusKeluarga
        FROM Warga
        WHERE JenisKelamin = @TipeData
        ORDER BY Nama
    END
    ELSE IF @JenisLaporan = 'Per RT'
    BEGIN
        SELECT 
            w.NIK,
            w.Nama,
            w.TempatLahir,
            CONVERT(VARCHAR, w.TanggalLahir, 101) AS TanggalLahir,
            w.JenisKelamin,
            w.NoKK,
            w.StatusKeluarga,
            kk.RT
        FROM Warga w
        INNER JOIN KartuKeluarga kk ON w.NoKK = kk.NoKK
        WHERE kk.RT = @TipeData
        ORDER BY w.Nama
    END
    ELSE IF @JenisLaporan = 'Status Keluarga'
    BEGIN
        SELECT 
            NIK,
            Nama,
            TempatLahir,
            CONVERT(VARCHAR, TanggalLahir, 101) AS TanggalLahir,
            JenisKelamin,
            NoKK,
            StatusKeluarga
        FROM Warga
        WHERE StatusKeluarga = @TipeData
        ORDER BY Nama
    END
END
CREATE TRIGGER trg_ValidasiKepalaKeluarga
ON Warga
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Cek apakah ada NoKK yang memiliki lebih dari 1 Kepala Keluarga
    IF EXISTS (
        SELECT NoKK, COUNT(*) AS JumlahKepala
        FROM (
            SELECT NoKK FROM inserted
            UNION ALL
            SELECT NoKK FROM deleted
        ) AS SemuaData
        WHERE EXISTS (
            SELECT 1 
            FROM Warga w 
            WHERE w.NoKK = SemuaData.NoKK 
              AND w.StatusKeluarga = 'Kepala Keluarga'
        )
        GROUP BY NoKK
        HAVING COUNT(*) > 1
    )
    BEGIN
        RAISERROR('Satu NoKK hanya boleh memiliki satu Kepala Keluarga.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Cek data KartuKeluarga dengan RT 002
SELECT * FROM KartuKeluarga WHERE RT = '002';

-- Cek data Warga yang terhubung dengan RT 002
SELECT 
    w.NIK,
    w.Nama,
    w.JenisKelamin,
    w.NoKK,
    kk.RT
FROM Warga w
INNER JOIN KartuKeluarga kk ON w.NoKK = kk.NoKK
WHERE kk.RT = '002';
-- Test SP dengan RT 002
EXEC sp_LaporanWargaFiltered 'Per RT', '002';

-- Lihat semua RT yang ada
SELECT DISTINCT RT FROM KartuKeluarga;

-- Test SP dengan RT 002
EXEC sp_LaporanWargaFiltered 'Per RT', '002';

-- Cek struktur tabel
SELECT COLUMN_NAME, DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'KartuKeluarga' 
AND COLUMN_NAME = 'RT';


-- Lihat semua RT yang ada di KartuKeluarga
SELECT DISTINCT RT FROM KartuKeluarga;

-- Lihat detail KartuKeluarga
SELECT NoKK, KepalaKeluarga, Alamat, RT FROM KartuKeluarga;

-- Lihat Warga beserta RT-nya
SELECT 
    w.NIK,
    w.Nama,
    w.NoKK,
    kk.RT
FROM Warga w
INNER JOIN KartuKeluarga kk ON w.NoKK = kk.NoKK;