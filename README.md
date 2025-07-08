🧾 SDR Stok Takip Sistemi
SDR Stok Takip Sistemi, küçük ve orta ölçekli işletmelerin stok, satış ve personel işlemlerini kolayca yönetebilmesi için geliştirilmiş güçlü ve kullanıcı dostu bir masaüstü uygulamasıdır.
C# WinForms altyapısıyla hazırlanmış, sade ve verimli arayüzüyle işletmenizin stok takibini zahmetsiz hale getirir.

🚀 Temel Özellikler
📦 Ürün Yönetimi: Ürün ekleme, güncelleme, silme ve stok takibi

🧑‍💼 Personel Takibi: Satış yapan personellerin kayıt ve yönetimi

💰 Satış Modülü: Hızlı satış oluşturma, toplam fiyat hesaplama ve anında stok güncelleme

📄 Fatura Yazdırma: Satış sonrası otomatik fatura çıktısı alma

🔐 Kullanıcı Girişi & Yetkilendirme: Roller ve izinlere göre detaylı kontrol paneli erişimi

⚙️ Veritabanı Ayarları: SQL Server bağlantı bilgilerini program içinden kolayca yapılandırma

💾 Veri Saklama: Ayarlar ve giriş verileri sistemin AppData dizininde güvenli şekilde saklanır

🛠️ Kullanılan Teknolojiler
C# (.NET Framework)

Windows Forms (WinForms)

SQL Server (MSSQL)

Newtonsoft.Json (JSON veri işlemleri için)

Inno Setup (Kurulum Sihirbazı)

📁 Kurulum Adımları
SDR_Kurulum_v1.0.0.exe dosyasını çalıştırarak kurulumu başlatın.

Masaüstünde oluşan kısayol ile uygulamayı açın.

İlk çalıştırmada veritabanı bağlantınızı yapılandırın.

Giriş yaptıktan sonra kontrol panelinden tüm işlemlerinizi gerçekleştirebilirsiniz.

💽 Veritabanı Oluşturma
1. Adım - Veritabanı ve Tablolar(Yıldızların arasındaki kodu direk kopyalayıp yapıştırın)

**************************************************************************************

CREATE DATABASE sdr;
USE [sdr]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 8.07.2025 13:33:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[MusteriID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[Adres] [nvarchar](255) NULL,
	[Unvan] [nvarchar](100) NULL,
	[Telefon] [nvarchar](20) NULL,
	[EklenmeTarihi] [datetime] NOT NULL,
	[EkleyenPersonelID] [int] NULL,
	[Email] [nvarchar](255) NULL,
	[VergiDairesi] [nvarchar](100) NULL,
	[VergiNo] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MusteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Permissions]    Script Date: 8.07.2025 13:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[PermissionId] [int] IDENTITY(1,1) NOT NULL,
	[PermissionName] [varchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[PermissionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissions]    Script Date: 8.07.2025 13:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissions](
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8.07.2025 13:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satislar]    Script Date: 8.07.2025 13:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satislar](
	[SatisID] [int] IDENTITY(1,1) NOT NULL,
	[MusteriID] [int] NOT NULL,
	[PersonelID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[Miktar] [int] NOT NULL,
	[Tutar] [decimal](18, 2) NOT NULL,
	[SatisTarihi] [datetime] NOT NULL,
	[IskontoYuzdesi] [decimal](5, 2) NOT NULL,
	[SonTutar] [decimal](18, 2) NOT NULL,
	[KdvOrani] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[SatisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiparisDetaylari]    Script Date: 8.07.2025 13:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiparisDetaylari](
	[SiparisDetayID] [int] IDENTITY(1,1) NOT NULL,
	[SiparisID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[Miktar] [int] NOT NULL,
	[BirimFiyat] [decimal](18, 2) NOT NULL,
	[DetayIskontoYuzdesi] [decimal](5, 2) NULL,
	[DetaySonTutar] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[SiparisDetayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparisler]    Script Date: 8.07.2025 13:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparisler](
	[SiparisID] [int] IDENTITY(1,1) NOT NULL,
	[MusteriID] [int] NOT NULL,
	[SiparisTarihi] [datetime] NULL,
	[ToplamTutar] [decimal](18, 2) NULL,
	[IskontoYuzdesi] [decimal](5, 2) NULL,
	[PersonelID] [int] NULL,
	[KdvOrani] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[SiparisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 8.07.2025 13:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [nvarchar](100) NOT NULL,
	[UrunAdedi] [int] NOT NULL,
	[UrunOzelligi] [nvarchar](255) NULL,
	[UrunAlisFiyati] [decimal](18, 2) NOT NULL,
	[UrunSatisFiyati] [decimal](18, 2) NOT NULL,
	[EklenmeTarihi] [datetime] NOT NULL,
	[EkleyenPersonelID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8.07.2025 13:33:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[PasswordHash] [varchar](255) NOT NULL,
	[RoleId] [int] NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Musteriler] ADD  DEFAULT (getdate()) FOR [EklenmeTarihi]
GO
ALTER TABLE [dbo].[Satislar] ADD  DEFAULT (getdate()) FOR [SatisTarihi]
GO
ALTER TABLE [dbo].[Satislar] ADD  DEFAULT ((0)) FOR [IskontoYuzdesi]
GO
ALTER TABLE [dbo].[Satislar] ADD  DEFAULT ((0)) FOR [SonTutar]
GO
ALTER TABLE [dbo].[SiparisDetaylari] ADD  DEFAULT ((0)) FOR [DetayIskontoYuzdesi]
GO
ALTER TABLE [dbo].[Siparisler] ADD  DEFAULT (getdate()) FOR [SiparisTarihi]
GO
ALTER TABLE [dbo].[Siparisler] ADD  DEFAULT ((0)) FOR [IskontoYuzdesi]
GO
ALTER TABLE [dbo].[Siparisler] ADD  DEFAULT ((20)) FOR [KdvOrani]
GO
ALTER TABLE [dbo].[Urunler] ADD  DEFAULT (getdate()) FOR [EklenmeTarihi]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([PermissionId])
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Satislar]  WITH CHECK ADD FOREIGN KEY([MusteriID])
REFERENCES [dbo].[Musteriler] ([MusteriID])
GO
ALTER TABLE [dbo].[Satislar]  WITH CHECK ADD FOREIGN KEY([PersonelID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Satislar]  WITH CHECK ADD FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([UrunID])
GO
ALTER TABLE [dbo].[SiparisDetaylari]  WITH CHECK ADD FOREIGN KEY([SiparisID])
REFERENCES [dbo].[Siparisler] ([SiparisID])
GO
ALTER TABLE [dbo].[SiparisDetaylari]  WITH CHECK ADD FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([UrunID])
GO
ALTER TABLE [dbo].[Siparisler]  WITH CHECK ADD FOREIGN KEY([MusteriID])
REFERENCES [dbo].[Musteriler] ([MusteriID])
GO
ALTER TABLE [dbo].[Siparisler]  WITH CHECK ADD FOREIGN KEY([PersonelID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO


**************************************************************************************


2. Adım - Rolleri Oluşturma
**************************************************************************************
INSERT INTO Roles (RoleName, Description) VALUES ('Admin', 'Full access to all system features');
INSERT INTO Users (Username, PasswordHash, RoleId) VALUES ('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1);
**************************************************************************************
3. Adım - Yönetici Kullanıcı Oluşturma
**************************************************************************************
INSERT INTO Users (Username, PasswordHash, RoleId) VALUES ('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1);
5. Adım - İzinleri Ekleyin
**************************************************************************************
INSERT INTO Permissions (PermissionName, Description) VALUES ('settings', 'Settings Menu');
INSERT INTO Permissions (PermissionName, Description) VALUES ('createSale', 'Create New Sale Menu');
INSERT INTO Permissions (PermissionName, Description) VALUES ('customers', 'Customers List Menu');
INSERT INTO Permissions (PermissionName, Description) VALUES ('personel_list', 'Personel List Menu');
INSERT INTO Permissions (PermissionName, Description) VALUES ('sales', 'Sales Menu');
INSERT INTO Permissions (PermissionName, Description) VALUES ('allSaleList', 'Show All Sale');
INSERT INTO Permissions (PermissionName, Description) VALUES ('stock', 'Stock Entry');
INSERT INTO Permissions (PermissionName, Description) VALUES ('sales_LockButton', 'Lock Button on Sales');
**************************************************************************************
6. Adım - Roller ile İzinleri Eşleştirin
INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (1, 1);
INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (1, 2);
INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (1, 3);
INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (1, 4);
INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (1, 5);
INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (1, 6);
INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (1, 7)
INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (1, 8);
7. Adım - Örnek Müşteri Kaydı
sql
Kopyala
Düzenle
INSERT INTO Musteriler (Ad, Soyad, Adres, Unvan, Telefon, EklenmeTarihi, EkleyenPersonelID)
OUTPUT INSERTED.MusteriID
VALUES ('Müşteri', ' ', NULL, NULL, '11111111111', SYSDATETIME(), 1);

🔐 Geliştirici Notu
Sistem tamamen genişletilebilir ve özelleştirilebilir yapıda tasarlanmıştır.

İlerleyen sürümlerde fatura tasarımı, e-posta bildirimleri, Excel aktarımları gibi modüller eklenecektir.

Programın çoğunluğu İngilizce, bazı bölümleri Türkçe'dir; ilerleyen sürümlerde tamamen İngilizce olması planlanmaktadır.

Varsayılan yönetici bilgileri:

Kullanıcı adı: admin

Şifre: admin (SHA256 ile hashlenmiş şekilde saklanır)

Yeni izinler eklediğinizde ilgili roller için düzenleme yapmayı unutmayın.

📬 İletişim
Herhangi bir soru, öneri veya destek talebi için bana GitHub üzerinden ulaşabilirsiniz:
✉️ E-posta: yyusuf.er@hotmail.com
