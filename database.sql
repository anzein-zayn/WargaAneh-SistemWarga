
CREATE DATABASE SistemWarga;
GO

CREATE TABLE Users (
    IdUser    INT PRIMARY KEY ,
    Username  NVARCHAR(50)  NOT NULL UNIQUE,
    Password  NVARCHAR(255) NOT NULL,
    Role      NVARCHAR(20)  NOT NULL check (Role in ('Admin', 'Petugas'))
);

CREATE TABLE KartuKeluarga (
    IdKK           INT PRIMARY KEY ,
    NoKK           VARCHAR(16)  NOT NULL UNIQUE,
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
    IdKK          INT NOT NULL FOREIGN KEY REFERENCES KartuKeluarga(IdKK),
    StatusKeluarga VARCHAR(50) NOT NULL check (StatusKeluarga in ('Kepala Keluarga','Istri', 'Anak'))
);

CREATE TABLE SuratPengantar (
    IdSurat          INT PRIMARY KEY,
    NIK          varchar (16) FOREIGN KEY REFERENCES Warga(NIK) ON DELETE CASCADE,
    JenisSurat       VARCHAR(100) NOT NULL,
    TanggalPengajuan DATE NOT NULL DEFAULT GETDATE(),
    StatusSurat      VARCHAR(50)  NOT NULL check (StatusSurat in ('Pending','Selesai'))
);

INSERT INTO Users (IdUser, Username , Password, Role)
VALUES
    (1, 'admin',    'admin123',    'Admin'),
    (2,'petugas1', 'petugas123',  'Petugas');

INSERT INTO KartuKeluarga (IdKK, NoKK, KepalaKeluarga, Alamat, RT)
VALUES
    (1, '3371010101010001', 'Budi Santoso',   'Jl. Mawar No. 1', '001'),
    (2, '3371010101010002', 'Siti Rahayu',    'Jl. Melati No. 5', '002');

INSERT INTO Warga ( NIK, Nama, TempatLahir, TanggalLahir, JenisKelamin, IdKK, StatusKeluarga)
VALUES
    ('3371010101010001', 'Budi Santoso',   'Yogyakarta', '1980-01-15', 'L',   1, 'Kepala Keluarga'),
    ('3371010101010002', 'Dewi Santoso',   'Yogyakarta', '1985-06-20', 'P',   1, 'Istri'),
    ('3371010101010003', 'Andi Santoso',   'Yogyakarta', '2005-03-10', 'L',   1, 'Anak'),
    ('3371010101010004', 'Siti Rahayu',    'Solo',       '1975-09-05', 'P',   2, 'Kepala Keluarga');

INSERT INTO SuratPengantar (IdSurat, NIK, JenisSurat, TanggalPengajuan, StatusSurat)
VALUES
    (1,'3371010101010001', 'Surat Keterangan Domisili', '2025-01-10', 'Selesai'),
    (2,'3371010101010003', 'Surat Keterangan Tidak Mampu', '2025-02-15', 'Pending'),
    (3,'3371010101010004', 'Surat Pengantar SKCK', '2025-03-01', 'Selesai');

	