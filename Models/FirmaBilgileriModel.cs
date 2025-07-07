// Models/FirmaBilgileriModel.cs
using System.Collections.Generic;

namespace sdr.Models // <--- Bu ad alanı (namespace) çok önemli!
{
    public class FirmaBilgileriModel
    {
        public string FirmaAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public List<BankaHesapBilgisi> BankaHesaplari { get; set; } = new List<BankaHesapBilgisi>();
    }

    public class BankaHesapBilgisi
    {
        public string BankaAdi { get; set; }
        public string IBAN { get; set; }
        public string HesapSahibi { get; set; }
    }
}