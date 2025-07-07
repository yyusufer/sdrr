// Models/Siparis.cs
using System;
using System.Collections.Generic; // Detayları tutmak için

namespace sdr.Models
{
    public class Siparis
    {
        public int SiparisID { get; set; }
        public int MusteriID { get; set; }
        public string MusteriAdSoyad { get; set; } // Join ile gelecek
        public string MusteriUnvan { get; set; } // Join ile gelecek
        public string MusteriAdres { get; set; } // Join ile gelecek
        public string MusteriTelefon { get; set; } // Join ile gelecek
        public string MusteriEmail { get; set; } // Join ile gelecek
        public string MusteriVergiDairesi { get; set; } // Join ile gelecek
        public string MusteriVergiNo { get; set; } // Join ile gelecek
        public DateTime SiparisTarihi { get; set; }
        public decimal ToplamTutar { get; set; } // Tüm detayların KDV ve indirim sonrası toplamı
        public decimal IskontoYuzdesi { get; set; }
        public int PersonelID { get; set; }
        public string PersonelAdi { get; set; } // Join ile gelecek
        public decimal KdvOrani { get; set; } // Fatura bazında KDV oranı (genellikle sabit ama değişebilir)

        // Bu siparişe ait ürün detaylarını tutmak için bir liste
        public List<SiparisDetay> Detaylar { get; set; } = new List<SiparisDetay>();
    }

    public class SiparisDetay
    {
        public int SiparisDetayID { get; set; }
        public int SiparisID { get; set; } // Hangi siparişin detayı olduğunu belirtir
        public int UrunID { get; set; }
        public string UrunAdi { get; set; } // Join ile gelecek
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal DetayIskontoYuzdesi { get; set; } // Bu detaya özel indirim
        public decimal DetaySonTutar { get; set; } // Bu satırın iskonto sonrası tutarı (Miktar * BirimFiyat * (1 - DetayIskontoYuzdesi/100))
    }
}