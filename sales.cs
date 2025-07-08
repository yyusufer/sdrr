// sales.cs (sadece değişen kısımlar)
using ReaLTaiizor.Controls;
using ReaLTaiizor.Extension;
using sdr.Helpers;
using sdr.Models; // Yeni modelleri dahil et
using sdr.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace sdr
{
    public partial class sales : baseForm
    {
        private bool deleteEnabled = false;
        private LostButton btnPrint = new LostButton();
        private PrintDocument printDocument = new PrintDocument();
        private int selectedSiparisId = -1; // faturaSatisId yerine selectedSiparisId kullanacağız
        private SiparisService siparisService = new SiparisService(); // Yeni servis örneği

        public sales()
        {
            InitializeComponent();
            dataGridView1.SizeChanged += (s, e) => PositionLockButton();
            this.Resize += (s, e) => PositionControls();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        // Eski GetSalesForCurrentUser metodunu kaldırın veya adını değiştirin.
        // Artık SiparisService üzerinden GetSiparislerForCurrentUser() metodunu kullanacağız.

        // Eski DeleteSale metodunu kaldırın.
        // Artık SiparisService üzerinden DeleteSiparis() metodunu kullanacağız.

        private void sales_Load(object sender, EventArgs e)
        {
            var dt = siparisService.GetSiparislerForCurrentUser(); // SiparisService kullan
            dataGridView1.DataSource = dt;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            gorsel();
            PositionLockButton();
            RecalculateLayout();
            deleteEnabled = false;
            LockButton.Text = "Locked";
            LockButton.BackColor = Color.IndianRed;
            StyleLockButton();
            PositionControls();

            if (Session.UserPermissions.Contains("sales_LockButton"))
            {
                LockButton.Visible = true;
            }
            else
            {
                LockButton.Visible = false;
            }

            AddPrintButton();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen yazdırmak için bir sipariş seçin.");
                return;
            }

            // Seçilen satırdaki SiparisID'yi al
            selectedSiparisId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SiparisID"].Value);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            printDocument.PrintPage -= PrintDocument_PrintPage; // Önceki olay aboneliğini kaldır
            printDocument.PrintPage += PrintDocument_PrintPage; // Yeni abonelik ekle
            previewDialog.Document = printDocument;
            previewDialog.ShowDialog();
        }
        FirmaBilgileriModel firma = ConfigService.GetFirmaBilgileri();


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 10);
            Font imzaFont = new Font("Arial", 14, FontStyle.Bold);
            Brush brush = Brushes.Black;

            float marginLeft = e.MarginBounds.Left;
            float marginTop = e.MarginBounds.Top;
            float pageWidth = e.MarginBounds.Width;

            // Sipariş detaylarını servis üzerinden çek
            Siparis siparis = siparisService.GetSiparisById(selectedSiparisId);
            if (siparis == null)
            {
                g.DrawString("Fatura bilgisi bulunamadı.", regularFont, brush, marginLeft, marginTop);
                e.HasMorePages = false;
                return;
            }

            // Firma bilgilerini JSON'dan çek
            FirmaBilgileriModel firma = ConfigService.GetFirmaBilgileri();


            if (firma == null)
            {
                g.DrawString("Firma bilgileri bulunamadı.", regularFont, brush, marginLeft, marginTop + 40);
                e.HasMorePages = false;
                return;
            }

            // Başlık
            string title = "SDR Yazılım Hizmetleri (Sipariş No: " + siparis.SiparisID + ")";
            SizeF titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, brush, marginLeft + (pageWidth - titleSize.Width) / 2, marginTop);

            float y = marginTop + titleSize.Height + 20;

            // Hizmet Sağlayan Bilgisi
            string hizmetSaglayan = GetHizmetSaglayanBilgi();

            // Hizmet Alan Bilgisi
            string hizmetAlan = $"HİZMETİ ALAN\n" +
                                 $"{siparis.MusteriAdSoyad} {(string.IsNullOrWhiteSpace(siparis.MusteriUnvan) ? "" : $" ({siparis.MusteriUnvan})")}\n" +
                                 $"{siparis.MusteriAdres}\n" +
                                 $"Telefon: {siparis.MusteriTelefon}\n" +
                                 $"E-posta: {siparis.MusteriEmail}\n" +
                                 $"Vergi Dairesi: {siparis.MusteriVergiDairesi}\n" +
                                 $"Vergi No: {siparis.MusteriVergiNo}";

            RectangleF hizmetSaglayanRect = new RectangleF(marginLeft, y, pageWidth / 2 - 10, 500); // Yüksekliği büyük ver
            RectangleF hizmetAlanRect = new RectangleF(marginLeft + pageWidth / 2 + 10, y, pageWidth / 2 - 10, 500);

            g.DrawString(hizmetSaglayan, regularFont, brush, hizmetSaglayanRect);
            g.DrawString(hizmetAlan, regularFont, brush, hizmetAlanRect);

            // Dinamik yükseklik hesapla
            SizeF hizmetSaglayanSize = g.MeasureString(hizmetSaglayan, regularFont, (int)(pageWidth / 2 - 10));
            SizeF hizmetAlanSize = g.MeasureString(hizmetAlan, regularFont, (int)(pageWidth / 2 - 10));

            float maxHizmetHeight = Math.Max(hizmetSaglayanSize.Height, hizmetAlanSize.Height);

            y += maxHizmetHeight + 10; // Hizmet bilgileri altından başlayacak

            // Fatura Tablosu
            float[] colWidths = { pageWidth * 0.4f, pageWidth * 0.15f, pageWidth * 0.2f, pageWidth * 0.2f };
            float currentX = marginLeft;
            string[] headers = { "Hizmet Açıklaması", "Miktar", "Birim Fiyat", "Toplam Tutar" };

            for (int i = 0; i < headers.Length; i++)
            {
                g.DrawRectangle(Pens.Black, currentX, y, colWidths[i], 25);
                g.DrawString(headers[i], headerFont, brush, currentX + 5, y + 5);
                currentX += colWidths[i];
            }

            y += 25;

            foreach (var detay in siparis.Detaylar)
            {
                currentX = marginLeft;

                g.DrawRectangle(Pens.Black, currentX, y, colWidths[0], 25);
                g.DrawString(detay.UrunAdi, regularFont, brush, currentX + 5, y + 5);
                currentX += colWidths[0];

                g.DrawRectangle(Pens.Black, currentX, y, colWidths[1], 25);
                g.DrawString(detay.Miktar.ToString(), regularFont, brush, currentX + 5, y + 5);
                currentX += colWidths[1];

                g.DrawRectangle(Pens.Black, currentX, y, colWidths[2], 25);
                g.DrawString(detay.BirimFiyat.ToString("N2") + " TL", regularFont, brush, currentX + 5, y + 5);
                currentX += colWidths[2];

                g.DrawRectangle(Pens.Black, currentX, y, colWidths[3], 25);
                g.DrawString(detay.DetaySonTutar.ToString("N2") + " TL", regularFont, brush, currentX + 5, y + 5);

                y += 25;
            }

            y += 10;

            float rightX = marginLeft + pageWidth - 200;
            decimal araToplam = 0;
            foreach (var detay in siparis.Detaylar)
                araToplam += detay.DetaySonTutar;

            decimal kdvTutari = araToplam * (siparis.KdvOrani / 100);
            decimal genelToplam = araToplam + kdvTutari;

            g.DrawString($"Ara Toplam: {araToplam:N2} TL", regularFont, brush, rightX, y);
            y += 20;
            g.DrawString($"KDV (%{siparis.KdvOrani:N0}): {kdvTutari:N2} TL", regularFont, brush, rightX, y);
            y += 20;
            g.DrawString($"Genel Toplam: {genelToplam:N2} TL", headerFont, brush, rightX, y);
            y += 40;

            // Ödeme Koşulları – JSON'dan banka bilgileri
            if (firma.BankaHesaplari != null && firma.BankaHesaplari.Count > 0)
            {
                string bankaBilgileri = "ÖDEME KOŞULLARI\nÖdeme Şekli: Havale/EFT";
                foreach (var banka in firma.BankaHesaplari)
                {
                    bankaBilgileri += $"\nBanka: {banka.BankaAdi}\nIBAN: {banka.IBAN}";
                }

                g.DrawString(bankaBilgileri, regularFont, brush, rightX, y);
                y += firma.BankaHesaplari.Count * 40;
            }



          
        }



        // Mevcut metotlar (dataGridView1_CellDoubleClick, LockButton_Click, gorsel, PositionLockButton, StyleLockButton) aynı kalabilir
        // Ancak dataGridView1_CellDoubleClick içinde DeleteSale yerine DeleteSiparis metodunu çağıracaksınız.

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
         
            
        }
        // sales.cs (Bu kodları mevcut sales.cs dosyanızdaki sınıfın içine yapıştırın)

        // ... (Mevcut kodlarınız, değişken tanımlamaları, constructor vb.) ...

        // LockButton'ın konumunu ayarlayan metot
        void PositionLockButton()
        {
            int paddingX = 20;
            int paddingY = 20;

            // LockButton'ın konumu
            LockButton.Location = new Point(paddingX, paddingY);

            // DataGridView'i LockButton'dan sonra başlatmak için
            // Bu metodun sadece buton konumlandırmasına odaklanması daha iyi olur.
            // gorsel() metodu DataGridView'in stil ve boyutlandırmasını halletmeli.
            // Ama şimdilik tam uyumlu olması için kopyalıyorum.
            dataGridView1.Location = new Point(paddingX, paddingY); // Başlangıçta aynı yere koydum, sonra adjust edilebilir.
        }

        // Kontrollerin genel konumunu ayarlayan metot (özellikle DataGridView ve butonlar)
        void PositionControls()
        {
            int leftPadding = 10;      // Formun solundan dataGridView'in önceki boşluğu
            int extraSpace = 30;       // Butonun kapladığı genişlik + boşluk

            int topPadding = 20;

            // Butonu formun solundan biraz içeri, topPadding kadar yukarı koy
            LockButton.Location = new Point(leftPadding, topPadding);

            // DataGridView'i butonun sağından başlat, araya 30 px boşluk ekle
            dataGridView1.Location = new Point(leftPadding + LockButton.Width + extraSpace, topPadding);

            // Eğer Print butonu varsa, onun da konumunu ayarla
            if (btnPrint != null)
            {
                btnPrint.Location = new Point(LockButton.Left, LockButton.Bottom + 10);
            }
        }

        // DataGridView ve diğer görsel öğelerin stilini ayarlayan metot
        void gorsel()
        {
            int paddingX = 20;
            int paddingY = 20;

            dataGridView1.Location = new Point(paddingX, paddingY);
            dataGridView1.RowTemplate.Height = 30;

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            // Seçim rengi iptal ediliyor (arka plan = beyaz, yazı rengi = siyah)
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.LightGray;

            // Kolonları tamamen form genişliğine yay (eşit veya orantılı)
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Yükseklik ayarı
            int totalHeight = dataGridView1.ColumnHeadersHeight +
                                 dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

            int minHeight = 150;
            dataGridView1.Height = Math.Max(totalHeight + 5, minHeight);
        }
        public void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki "SiparisID" hücresinin değerini al
                object siparisIdValue = dataGridView1.SelectedRows[0].Cells["SiparisID"].Value;

                // Değerin DBNull olup olmadığını kontrol et
                if (siparisIdValue != null && siparisIdValue != DBNull.Value)
                {
                    // Eğer DBNull değilse, int'e çevir
                    selectedSiparisId = Convert.ToInt32(siparisIdValue);
                }
                else
                {
                    // Eğer DBNull ise veya null ise -1 olarak ayarla (güvenli bir başlangıç değeri)
                    selectedSiparisId = -1;
                }
            }
            else
            {
                // Hiçbir satır seçili değilse -1 olarak ayarla
                selectedSiparisId = -1;
            }
        }

        // Layout'u yeniden hesaplayan metot (genellikle form boyutlandığında çağrılır)
        void RecalculateLayout()
        {
            int paddingTop = 20;
            int paddingLeft = 20;
            int spacingBetween = 30;

            // LockButton konumu sabit
            LockButton.Location = new Point(paddingLeft, paddingTop);

            // DataGridView LockButton’un sağında başlasın
            int dgvX = LockButton.Visible
                ? LockButton.Right + spacingBetween
                : paddingLeft;

            int dgvY = paddingTop;
            int dgvWidth = this.ClientSize.Width - dgvX - paddingLeft;
            int dgvHeight = this.ClientSize.Height - dgvY - paddingTop;

            dataGridView1.Location = new Point(dgvX, dgvY);
            dataGridView1.Size = new Size(dgvWidth, dgvHeight);

            // BONUS: Başlık fontunu ekran genişliğine göre ayarla
            float baseFontSize = 10f; // Minimum
            float scaleFactor = this.ClientSize.Width / 1200f; // 800px genişliğe göre ölçek
            float newFontSize = Math.Max(baseFontSize, baseFontSize * scaleFactor);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Inter", newFontSize, FontStyle.Bold);
        }


        // LockButton'ın stilini ayarlayan metot
        void StyleLockButton()
        {
            LockButton.Size = new Size(80, 30);
            LockButton.Font = new Font("Inter", 10, FontStyle.Bold);
            LockButton.FlatStyle = FlatStyle.Flat;
            LockButton.FlatAppearance.BorderSize = 1;
            LockButton.FlatAppearance.BorderColor = Color.Gray;
            LockButton.Cursor = Cursors.Hand;
            LockButton.TextAlign = ContentAlignment.MiddleCenter;
        }

        // Yazdırma butonunu ekleyen metot
        private void AddPrintButton()
        {
            btnPrint.Text = "Yazdır";
            btnPrint.Size = new Size(100, 30);
            btnPrint.Font = new Font("Inter", 10, FontStyle.Bold);
            // LockButton'ın hemen altında konumlandır
            btnPrint.Location = new Point(LockButton.Left, LockButton.Bottom + 10);
            btnPrint.Click += BtnPrint_Click;

            this.Controls.Add(btnPrint);
        }

        // Hizmet sağlayan firma bilgilerini döndüren metot (Sabit bilgi)
        private string GetHizmetSaglayanBilgi()
        {
            var firma = ConfigService.GetFirmaBilgileri();
            if (firma == null)
                return "Firma bilgisi bulunamadı.";

            string bankaBilgileri = "";
            if (firma.BankaHesaplari != null && firma.BankaHesaplari.Count > 0)
            {
                foreach (var banka in firma.BankaHesaplari)
                {
                    bankaBilgileri += $"Banka: {banka.BankaAdi}\nIBAN: {banka.IBAN}\n";
                }
            }

            return $"HİZMETİ SAĞLAYAN FİRMA BİLGİLERİ\n" +
                   $"{firma.FirmaAdi}\n"+
                   $"Vergi No: {firma.VergiNo}\n" +
                   $"{firma.Adres}\n" +
                   $"Telefon: {firma.Telefon}\n" +
                   $"E-posta: {firma.Email}\n" +
                   $"Vergi Dairesi: {firma.VergiDairesi}\n" +
                   $"Vergi No: {firma.VergiNo}\n" +
                   $"\n\n\n\n\n\n";
            // Örnek sabit 
        }


        // LockButton'a tıklandığında çalışan metot
        private void LockButton_Click(object sender, EventArgs e)
        {
            deleteEnabled = !deleteEnabled;  // Toggle

            if (deleteEnabled)
            {
                LockButton.Text = "Unlocked";
                LockButton.BackColor = Color.LightGreen;
            }
            else
            {
                LockButton.Text = "Locked";
                LockButton.BackColor = Color.IndianRed;
            }
        }

        // dataGridView1_CellContentClick olay işleyicisi (gerekmeyebilir, ama hata verdiğinde eklemek faydalı)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // dataGridView1_DoubleClick olay işleyicisi (gerekmeyebilir, ama hata verdiğinde eklemek faydalı)
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // CellDoubleClick zaten kullanıldığından bu metod gereksizdir.
            // Karışıklığı önlemek için kaldırılabilir.
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (!deleteEnabled)
            {
                MessageBox.Show("Satır silme işlemi için önce kilidi açın (Unlock).", "Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.RowIndex < 0 || dataGridView1.SelectedRows.Count == 0)
                return;

            DialogResult result = MessageBox.Show("Seçilen siparişi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int siparisId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SiparisID"].Value);
                siparisService.DeleteSiparis(siparisId);
                MessageBox.Show("Sipariş başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = siparisService.GetSiparislerForCurrentUser(); // Listeyi yenile
            }
        }

        // ... (Diğer metotlarınız ve sınıf kapanış parantezi) ...
    }
}
// SelectionChanged olayı için doğru imza

