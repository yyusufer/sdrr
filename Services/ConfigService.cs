using Newtonsoft.Json;
using sdr.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace sdr.Services
{
    public static class ConfigService
    {
        private static FirmaBilgileriModel _cachedFirmaBilgileri;
        private static readonly string appDataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SDR Sistemleri");
        private static readonly string filePath = Path.Combine(appDataFolder, "FirmaBilgileri.json");

        public static FirmaBilgileriModel GetFirmaBilgileri()
        {
            // Önce önbellek varsa onu dön
            if (_cachedFirmaBilgileri != null)
                return _cachedFirmaBilgileri;

            try
            {
                // Klasör yoksa oluştur
                if (!Directory.Exists(appDataFolder))
                    Directory.CreateDirectory(appDataFolder);

                // Dosya yoksa oluştur ve içine boş bir model yaz
                if (!File.Exists(filePath))
                {
                    _cachedFirmaBilgileri = new FirmaBilgileriModel()
                    {
                        BankaHesaplari = new List<BankaHesapBilgisi>()
                    };
                    SaveFirmaBilgileri(_cachedFirmaBilgileri);
                    return _cachedFirmaBilgileri;
                }

                // Dosyayı oku
                string json = File.ReadAllText(filePath);

                // Eğer dosya boşsa veya geçersizse boş model dön
                if (string.IsNullOrWhiteSpace(json))
                {
                    _cachedFirmaBilgileri = new FirmaBilgileriModel()
                    {
                        BankaHesaplari = new List<BankaHesapBilgisi>()
                    };
                    SaveFirmaBilgileri(_cachedFirmaBilgileri);
                    return _cachedFirmaBilgileri;
                }

                // Deserialize etmeye çalış
                _cachedFirmaBilgileri = JsonConvert.DeserializeObject<FirmaBilgileriModel>(json);

                // Eğer null dönerse boş model yarat ve kaydet
                if (_cachedFirmaBilgileri == null)
                {
                    _cachedFirmaBilgileri = new FirmaBilgileriModel()
                    {
                        BankaHesaplari = new List<BankaHesapBilgisi>()
                    };
                    SaveFirmaBilgileri(_cachedFirmaBilgileri);
                }
            }
            catch
            {
                // Okuma veya parse hatası varsa dosyayı sil ve yeni oluştur
                try
                {
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                catch { /* Silme hatası yoksay */ }

                _cachedFirmaBilgileri = new FirmaBilgileriModel()
                {
                    BankaHesaplari = new List<BankaHesapBilgisi>()
                };
                SaveFirmaBilgileri(_cachedFirmaBilgileri);
            }

            return _cachedFirmaBilgileri;
        }
        public static void SaveFirmaBilgileri(FirmaBilgileriModel firmaBilgileri)
        {
            try
            {
                if (!Directory.Exists(appDataFolder))
                    Directory.CreateDirectory(appDataFolder);

                string json = JsonConvert.SerializeObject(firmaBilgileri, Formatting.Indented);
                File.WriteAllText(filePath, json);

                _cachedFirmaBilgileri = firmaBilgileri; // Önbelleği güncelle
            }
            catch
            {
                // Hata yönetimi yapılabilir
                throw;
            }
        }
        public static void ClearCache()
        {
            _cachedFirmaBilgileri = null;
        }
    }
}
