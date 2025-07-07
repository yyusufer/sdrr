// Services/ConfigService.cs
using Newtonsoft.Json;
using sdr.Models; // <--- Bu satırın var olduğundan ve doğru olduğundan emin olun!
using System;
using System.IO;
using System.Windows.Forms;

namespace sdr.Services
{
    public static class ConfigService
    {
        private static FirmaBilgileriModel _firmaBilgileri;
        private static readonly string basePath = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string filePath = Path.Combine(basePath, "FirmaBilgileri.json");
        public static FirmaBilgileriModel GetFirmaBilgileri()
        {
            if (_firmaBilgileri == null)
            {
               
                if (File.Exists(filePath))
                {
                    try
                    {
                        string jsonString = File.ReadAllText(filePath);
                        _firmaBilgileri = JsonConvert.DeserializeObject<FirmaBilgileriModel>(jsonString);
                    }
                    catch (JsonException ex)
                    {
                        MessageBox.Show($"Firma bilgileri JSON dosyasını okurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _firmaBilgileri = new FirmaBilgileriModel();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Firma bilgileri dosyasına erişirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _firmaBilgileri = new FirmaBilgileriModel();
                    }
                }
                else
                {
                    MessageBox.Show($"FirmaBilgileri.json dosyası bulunamadı: {filePath}. Yeni bir dosya oluşturulacak.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _firmaBilgileri = new FirmaBilgileriModel(); // Dosya yoksa boş model döndür
                    // Boş bir JSON dosyası oluşturabiliriz başlangıçta
                    try
                    {
                        string emptyJson = JsonConvert.SerializeObject(_firmaBilgileri, Formatting.Indented);
                        File.WriteAllText(filePath, emptyJson);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Boş FirmaBilgileri.json dosyası oluşturulurken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return _firmaBilgileri;
        }
        
        /// <summary>
        /// Firma bilgileri önbelleğini temizler.
        /// </summary>
        public static void ClearCache()
        {
            _firmaBilgileri = null;
        }
    }
}