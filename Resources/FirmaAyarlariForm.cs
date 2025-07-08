// FirmaAyarlariForm.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using sdr.Models;
using sdr.Services;

namespace sdr
{
    public partial class FirmaAyarlariForm : baseForm
    {
        private FirmaBilgileriModel currentFirmaBilgileri;

        public FirmaAyarlariForm()
        {
            InitializeComponent();

            this.Load += FirmaAyarlariForm_Load;

            btnKaydet.Click += BtnKaydet_Click;
            btnBankaBilgisiEkle.Click += btnBankaBilgisiEkle_Click;
            btnBankaSil.Click += BtnBankaSil_Click;

            SetupDataGridView();
        }

        /// <summary>
        /// DataGridView'in sütunlarını tanımlar, otomatik sütun oluşturmayı kapatır ve düzenlemeyi engeller.
        /// </summary>
        private void SetupDataGridView()
        {
            dgvBankaHesaplari.AutoGenerateColumns = false;
            dgvBankaHesaplari.BorderStyle = BorderStyle.FixedSingle;
            dgvBankaHesaplari.Font = new Font("Segoe UI", 9); // Küçük ve modern font
            dgvBankaHesaplari.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvBankaHesaplari.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvBankaHesaplari.EnableHeadersVisualStyles = false;
            dgvBankaHesaplari.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Sağ üst köşeye yaslamak için dock ve anchor ayarı
            dgvBankaHesaplari.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dgvBankaHesaplari.Location = new Point(this.Width - dgvBankaHesaplari.Width - 30, 20); // Sağ üstte biraz boşluk bırakarak
            dgvBankaHesaplari.Size = new Size(400, 200); // Genişlik ve yükseklik ayarı isteğe bağlı

            // Sütun tanımlamaları
            dgvBankaHesaplari.Columns.Clear(); // Önceki sütunlar varsa temizle
            dgvBankaHesaplari.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "BankaAdi",
                HeaderText = "Banka Adı",
                DataPropertyName = "BankaAdi",
                ReadOnly = true // Bu sütunun düzenlenmesini engelle
            });
            dgvBankaHesaplari.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "IBAN",
                HeaderText = "IBAN",
                DataPropertyName = "IBAN",
                ReadOnly = true // Bu sütunun düzenlenmesini engelle
            });
            dgvBankaHesaplari.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "HesapSahibi",
                HeaderText = "Hesap Sahibi",
                DataPropertyName = "HesapSahibi",
                ReadOnly = true // Bu sütunun düzenlenmesini engelle
            });

            dgvBankaHesaplari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            foreach (DataGridViewColumn col in dgvBankaHesaplari.Columns)
            {
                if (col.Name == "BankaAdi" || col.Name == "HesapSahibi")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                }
                else
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }

            // DataGridView'de satır seçimi modunu ayarla
            dgvBankaHesaplari.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBankaHesaplari.AllowUserToAddRows = false; // Kullanıcının doğrudan DataGridView'e yeni satır eklemesini engelle
            dgvBankaHesaplari.EditMode = DataGridViewEditMode.EditProgrammatically; // Hücrelerin programatik olarak düzenlenmesini sağlar, elle düzenlemeyi engeller
        }

        private void FirmaAyarlariForm_Load(object sender, EventArgs e)
        {
            try
            {
                currentFirmaBilgileri = ConfigService.GetFirmaBilgileri();

                if (currentFirmaBilgileri == null)
                {
                    MessageBox.Show("Firma bilgileri yüklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentFirmaBilgileri = new FirmaBilgileriModel()
                    {
                        BankaHesaplari = new List<BankaHesapBilgisi>()
                    };
                }

                if (currentFirmaBilgileri.BankaHesaplari == null)
                    currentFirmaBilgileri.BankaHesaplari = new List<BankaHesapBilgisi>();

                txtFirmaAdi.Text = currentFirmaBilgileri.FirmaAdi ?? "";
                txtAdres.Text = currentFirmaBilgileri.Adres ?? "";
                txtTelefon.Text = currentFirmaBilgileri.Telefon ?? "";
                txtEmail.Text = currentFirmaBilgileri.Email ?? "";
                txtVergiDairesi.Text = currentFirmaBilgileri.VergiDairesi ?? "";
                txtVergiNo.Text = currentFirmaBilgileri.VergiNo ?? "";

                dgvBankaHesaplari.DataSource = new List<BankaHesapBilgisi>(currentFirmaBilgileri.BankaHesaplari);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firma bilgileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Textbox'lardan güncel bilgileri al ve modele kaydet
                currentFirmaBilgileri.FirmaAdi = txtFirmaAdi.Text;
                currentFirmaBilgileri.Adres = txtAdres.Text;
                currentFirmaBilgileri.Telefon = txtTelefon.Text;
                currentFirmaBilgileri.Email = txtEmail.Text;
                currentFirmaBilgileri.VergiDairesi = txtVergiDairesi.Text;
                currentFirmaBilgileri.VergiNo = txtVergiNo.Text;

                // DataGridView'deki güncel banka hesaplarını al ve modele kaydet
                // DataGridView'in DataSource'u zaten bir List<BankaHesapBilgisi> olduğu için
                // doğrudan bu listeyi kullanabiliriz.
                currentFirmaBilgileri.BankaHesaplari = dgvBankaHesaplari.DataSource as List<BankaHesapBilgisi> ?? new List<BankaHesapBilgisi>();

                // Firma bilgilerini JSON dosyasına serileştirip kaydet
                // Json'ı düzenli (girintili) formatta kaydet
                string appDataFolder = Path.Combine(
       Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
       "SDR Sistemleri"
   );

                if (!Directory.Exists(appDataFolder))
                {
                    Directory.CreateDirectory(appDataFolder);
                }

                string filePath = Path.Combine(appDataFolder, "FirmaBilgileri.json");

                string jsonString = JsonConvert.SerializeObject(currentFirmaBilgileri, Formatting.Indented);
                File.WriteAllText(filePath, jsonString);

                MessageBox.Show("Firma bilgileri başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ConfigService'deki önbelleği temizle ki bir sonraki okumada yeni veriyi alsın
                ConfigService.ClearCache();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firma bilgileri kaydedilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBankaSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Eğer seçili satır varsa
                if (dgvBankaHesaplari.SelectedRows.Count > 0)
                {
                    // DataGridView'in DataSource'unu al
                    List<BankaHesapBilgisi> bankaList = dgvBankaHesaplari.DataSource as List<BankaHesapBilgisi>;
                    if (bankaList == null)
                    {
                        MessageBox.Show("Banka hesapları listesi yüklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Seçili satırın indeksini al
                    int selectedIndex = dgvBankaHesaplari.SelectedRows[0].Index;

                    // Seçili indeks listenin sınırları içindeyse
                    if (selectedIndex >= 0 && selectedIndex < bankaList.Count)
                    {
                        bankaList.RemoveAt(selectedIndex); // Listeden kaldır

                        // DataGridView'i yenilemek için DataSource'u null yapıp tekrar atıyoruz
                        dgvBankaHesaplari.DataSource = null;
                        dgvBankaHesaplari.DataSource = bankaList;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek için bir banka hesabı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Banka hesabı silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBankaHesaplari_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Tıklanan yerin geçerli bir satır olup olmadığını kontrol et
                if (e.RowIndex < 0 || e.RowIndex == dgvBankaHesaplari.NewRowIndex)
                {
                    return;
                }

                // Tıklanan satırı e.RowIndex üzerinden güvenle al.
                DataGridViewRow clickedRow = dgvBankaHesaplari.Rows[e.RowIndex];

                // Hücre değerlerini güvenli bir şekilde al
                string bankaAdi = clickedRow.Cells["BankaAdi"].Value?.ToString();
                string iban = clickedRow.Cells["IBAN"].Value?.ToString();
                string hesapSahibi = clickedRow.Cells["HesapSahibi"].Value?.ToString();

                // Bilgiler varsa MessageBox ile göster
                MessageBox.Show($"Seçilen Banka Adı: {bankaAdi}\nIBAN: {iban}\nHesap Sahibi: {hesapSahibi}", "Banka Detayı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Banka detayı görüntülenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBankaBilgisiEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string bankaAdi = txtBankaAdi.Text?.Trim();
                string iban = txtIBAN.Text?.Trim();
                string hesapSahibi = txtHesapSahibi.Text?.Trim();

                // 1. Boş alan kontrolü (öncelikli olmalı)
                if (string.IsNullOrWhiteSpace(bankaAdi) || string.IsNullOrWhiteSpace(iban) || string.IsNullOrWhiteSpace(hesapSahibi))
                {
                    MessageBox.Show("Lütfen tüm banka bilgisi alanlarını (Banka Adı, IBAN, Hesap Sahibi) eksiksiz doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Mevcut listeyi al
                List<BankaHesapBilgisi> bankaList = dgvBankaHesaplari.DataSource as List<BankaHesapBilgisi> ?? new List<BankaHesapBilgisi>();

                // 3. IBAN tekrar kontrolü
                if (bankaList.Any(b => string.Equals(b.IBAN, iban, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Bu IBAN zaten eklenmiş. Lütfen farklı bir IBAN girin.", "Tekrar Eden IBAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Yeni hesap ekle
                bankaList.Add(new BankaHesapBilgisi
                {
                    BankaAdi = bankaAdi,
                    IBAN = iban,
                    HesapSahibi = hesapSahibi
                });

                // 5. DataGridView yenile
                dgvBankaHesaplari.DataSource = null;
                dgvBankaHesaplari.DataSource = bankaList;

                // 6. Textbox'ları temizle
                txtBankaAdi.Text = "";
                txtIBAN.Text = "";
                txtHesapSahibi.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Banka bilgisi eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        // Bu metotlar artık kullanılmıyor olabilir, ancak tasarımcı tarafından oluşturulduysa bırakılabilir.
        private void dgvBankaHesaplari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bu event genellikle kullanılmaz, CellDoubleClick tercih edilir.
        }

        private void dgvBankaHesaplari_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Bu event genellikle kullanılmaz, CellDoubleClick tercih edilir.
        }

        private void btnBankaBilgisiEkle_Click_1(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {

        }
    }
}