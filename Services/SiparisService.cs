// Services/SiparisService.cs
using sdr.Models;
using sdr.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sdr.Services
{
    public class SiparisService
    {
        private readonly string connectionString = DbConnectionManager.GetConnectionString();

        // Tüm siparişleri (veya kullanıcının siparişlerini) getiren metod
        public DataTable GetSiparislerForCurrentUser()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
SELECT
    S.SiparisID,
    M.Ad + ' ' + M.Soyad AS MusteriAdSoyad,
    U.Username AS PersonelAdi,
    S.SiparisTarihi,
    S.ToplamTutar,
    S.IskontoYuzdesi
FROM
    Siparisler S
INNER JOIN
    Musteriler M ON S.MusteriID = M.MusteriID
INNER JOIN
    Users U ON S.PersonelID = U.UserId";

                // Kullanıcı izinlerine göre filtreleme
                if (!Session.UserPermissions.Contains("allSaleList")) // Varsayılan olarak tüm siparişleri göstermeyen kullanıcılar için
                {
                    query += " WHERE S.PersonelID = @UserId";
                }

                query += " ORDER BY S.SiparisTarihi DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (!Session.UserPermissions.Contains("allSaleList"))
                        cmd.Parameters.AddWithValue("@UserId", Session.UserId);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Belirli bir SiparisID'ye ait tüm detayları (ürünleri) çeken metod
        public Siparis GetSiparisById(int siparisId)
        {
            Siparis siparis = null;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Siparişin genel bilgilerini çek
                string siparisQuery = @"
SELECT
    S.SiparisID,
    S.MusteriID,
    M.Ad + ' ' + M.Soyad AS MusteriAdSoyad,
    M.Unvan AS MusteriUnvan,
    M.Adres AS MusteriAdres,
    M.Telefon AS MusteriTelefon,
    M.Email AS MusteriEmail,
    M.VergiDairesi AS MusteriVergiDairesi,
    M.VergiNo AS MusteriVergiNo,
    S.SiparisTarihi,
    S.ToplamTutar,
    S.IskontoYuzdesi,
    S.PersonelID,
    U.Username AS PersonelAdi,
    S.KdvOrani
FROM
    Siparisler S
INNER JOIN Musteriler M ON S.MusteriID = M.MusteriID
INNER JOIN Users U ON S.PersonelID = U.UserId
WHERE S.SiparisID = @SiparisID";

                using (var cmd = new SqlCommand(siparisQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@SiparisID", siparisId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            siparis = new Siparis
                            {
                                SiparisID = Convert.ToInt32(reader["SiparisID"]),
                                MusteriID = Convert.ToInt32(reader["MusteriID"]),
                                MusteriAdSoyad = reader["MusteriAdSoyad"].ToString(),
                                MusteriUnvan = reader["MusteriUnvan"] == DBNull.Value ? "" : reader["MusteriUnvan"].ToString(),
                                MusteriAdres = reader["MusteriAdres"].ToString(),
                                MusteriTelefon = reader["MusteriTelefon"] == DBNull.Value ? "" : reader["MusteriTelefon"].ToString(),
                                MusteriEmail = reader["MusteriEmail"] == DBNull.Value ? "" : reader["MusteriEmail"].ToString(),
                                MusteriVergiDairesi = reader["MusteriVergiDairesi"] == DBNull.Value ? "" : reader["MusteriVergiDairesi"].ToString(),
                                MusteriVergiNo = reader["MusteriVergiNo"] == DBNull.Value ? "" : reader["MusteriVergiNo"].ToString(),
                                SiparisTarihi = Convert.ToDateTime(reader["SiparisTarihi"]),
                                ToplamTutar = Convert.ToDecimal(reader["ToplamTutar"]),
                                IskontoYuzdesi = Convert.ToDecimal(reader["IskontoYuzdesi"]),
                                PersonelID = Convert.ToInt32(reader["PersonelID"]),
                                PersonelAdi = reader["PersonelAdi"].ToString(),
                                KdvOrani = reader["KdvOrani"] == DBNull.Value ? 20 : Convert.ToDecimal(reader["KdvOrani"])
                            };
                        }
                    }
                }

                if (siparis != null)
                {
                    // Sipariş detaylarını çek
                    string detayQuery = @"
SELECT
    SD.SiparisDetayID,
    SD.UrunID,
    P.UrunAdi,
    SD.Miktar,
    SD.BirimFiyat,
    SD.DetayIskontoYuzdesi,
    SD.DetaySonTutar
FROM
    SiparisDetaylari SD
INNER JOIN Urunler P ON SD.UrunID = P.UrunID
WHERE SD.SiparisID = @SiparisID";

                    using (var cmdDetay = new SqlCommand(detayQuery, conn))
                    {
                        cmdDetay.Parameters.AddWithValue("@SiparisID", siparisId);
                        using (var readerDetay = cmdDetay.ExecuteReader())
                        {
                            while (readerDetay.Read())
                            {
                                siparis.Detaylar.Add(new SiparisDetay
                                {
                                    SiparisDetayID = Convert.ToInt32(readerDetay["SiparisDetayID"]),
                                    SiparisID = siparisId,
                                    UrunID = Convert.ToInt32(readerDetay["UrunID"]),
                                    UrunAdi = readerDetay["UrunAdi"].ToString(),
                                    Miktar = Convert.ToInt32(readerDetay["Miktar"]),
                                    BirimFiyat = Convert.ToDecimal(readerDetay["BirimFiyat"]),
                                    DetayIskontoYuzdesi = Convert.ToDecimal(readerDetay["DetayIskontoYuzdesi"]),
                                    DetaySonTutar = Convert.ToDecimal(readerDetay["DetaySonTutar"])
                                });
                            }
                        }
                    }
                }
            }
            return siparis;
        }

        // Sipariş silme metodu (opsiyonel, isterseniz ekleyebilirsiniz)
        public void DeleteSiparis(int siparisId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Önce detayları sil, sonra ana siparişi sil (Foreign Key kısıtlaması nedeniyle)
                using (var cmdDetay = new SqlCommand("DELETE FROM SiparisDetaylari WHERE SiparisID = @id", conn))
                {
                    cmdDetay.Parameters.AddWithValue("@id", siparisId);
                    cmdDetay.ExecuteNonQuery();
                }
                using (var cmdSiparis = new SqlCommand("DELETE FROM Siparisler WHERE SiparisID = @id", conn))
                {
                    cmdSiparis.Parameters.AddWithValue("@id", siparisId);
                    cmdSiparis.ExecuteNonQuery();
                }
            }
        }

        // Yeni sipariş ekleme (Bu metod genellikle ayrı bir "Yeni Satış" ekranında çağrılır)
        public int AddSiparis(Siparis yeniSiparis)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                int siparisId = -1;

                try
                {
                    // Siparişler tablosuna ekleme
                    string insertSiparisQuery = @"
INSERT INTO Siparisler (MusteriID, SiparisTarihi, ToplamTutar, IskontoYuzdesi, PersonelID, KdvOrani)
OUTPUT INSERTED.SiparisID
VALUES (@MusteriID, @SiparisTarihi, @ToplamTutar, @IskontoYuzdesi, @PersonelID, @KdvOrani)";

                    using (var cmdSiparis = new SqlCommand(insertSiparisQuery, conn, transaction))
                    {
                        cmdSiparis.Parameters.AddWithValue("@MusteriID", yeniSiparis.MusteriID);
                        cmdSiparis.Parameters.AddWithValue("@SiparisTarihi", yeniSiparis.SiparisTarihi);
                        cmdSiparis.Parameters.AddWithValue("@ToplamTutar", yeniSiparis.ToplamTutar);
                        cmdSiparis.Parameters.AddWithValue("@IskontoYuzdesi", yeniSiparis.IskontoYuzdesi);
                        cmdSiparis.Parameters.AddWithValue("@PersonelID", yeniSiparis.PersonelID);
                        cmdSiparis.Parameters.AddWithValue("@KdvOrani", yeniSiparis.KdvOrani);
                        siparisId = (int)cmdSiparis.ExecuteScalar();
                    }

                    // Sipariş detaylarını ekleme
                    string insertDetayQuery = @"
INSERT INTO SiparisDetaylari (SiparisID, UrunID, Miktar, BirimFiyat, DetayIskontoYuzdesi, DetaySonTutar)
VALUES (@SiparisID, @UrunID, @Miktar, @BirimFiyat, @DetayIskontoYuzdesi, @DetaySonTutar)";

                    foreach (var detay in yeniSiparis.Detaylar)
                    {
                        using (var cmdDetay = new SqlCommand(insertDetayQuery, conn, transaction))
                        {
                            cmdDetay.Parameters.AddWithValue("@SiparisID", siparisId);
                            cmdDetay.Parameters.AddWithValue("@UrunID", detay.UrunID);
                            cmdDetay.Parameters.AddWithValue("@Miktar", detay.Miktar);
                            cmdDetay.Parameters.AddWithValue("@BirimFiyat", detay.BirimFiyat);
                            cmdDetay.Parameters.AddWithValue("@DetayIskontoYuzdesi", detay.DetayIskontoYuzdesi);
                            cmdDetay.Parameters.AddWithValue("@DetaySonTutar", detay.DetaySonTutar);
                            cmdDetay.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Sipariş eklenirken hata oluştu: " + ex.Message);
                    siparisId = -1; // Hata durumunda -1 döndür
                }
                return siparisId;
            }
        }
    }
}