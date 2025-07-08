using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static sdr.createSale;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using sdr.Helpers;
using sdr.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using sdr.Services;
namespace sdr
{
    public partial class createSale : baseForm
    {
        private readonly string connectionString = DbConnectionManager.GetConnectionString();
        private decimal toplamTutar = 0;
        private int selectedMusteriId = -1; // Otomatik bulunan müşteri ID'si
        private SiparisService siparisService = new SiparisService(); // BURAYI EKLE!

        private List<ProductInfo> allProducts = new List<ProductInfo>();
        private List<SelectedProduct> selectedProducts = new List<SelectedProduct>();


       

        public createSale()
        {
            InitializeComponent();
            phoneTextbox.Leave += phoneTextbox_Leave;
            this.Load += createSale_Load;
            txtProductSearch.TextChanged += TxtProductSearch_TextChanged;
            lstSearchResults.DoubleClick += LstSearchResults_DoubleClick;
            lstSelectedProducts.DoubleClick += LstSelectedProducts_DoubleClick;
        }

        private void createSale_Load(object sender, EventArgs e)
        {
            LoadProductsFromDatabase();

            lstSearchResults.Items.Clear();
            foreach (var product in allProducts)
            {
                lstSearchResults.Items.Add(product);
            }
        }

        private void LoadProductsFromDatabase()
        {
            allProducts.Clear();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UrunID, UrunAdi, UrunAdedi, UrunSatisFiyati FROM Urunler"; // UrunID'yi de çek
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allProducts.Add(new ProductInfo
                        {
                            UrunID = reader.GetInt32(0), // UrunID'yi al
                            UrunAdi = reader.GetString(1),
                            UrunAdedi = reader.GetInt32(2),
                            UrunSatisFiyati = reader.GetDecimal(3)
                        });
                    }
                }
            }
        }

        private int GetStockForProduct(string productName)
        {
            int stock = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UrunAdedi FROM Urunler WHERE UrunAdi = @productName";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int s))
                    {
                        stock = s;
                    }
                }
            }
            return stock;
        }

        private void TxtProductSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtProductSearch.Text.Trim().ToLower();

            var filtered = allProducts
                .Where(p => p.UrunAdi.ToLower().Contains(keyword))
                .ToList();

            lstSearchResults.Items.Clear();
            foreach (var item in filtered)
            {
                lstSearchResults.Items.Add(item); 
            }
        }
        public class ProductInfo
        {
            public int UrunID { get; set; } // BURAYI EKLE
            public string UrunAdi { get; set; }
            public int UrunAdedi { get; set; }
            public decimal UrunSatisFiyati { get; set; }

            public override string ToString()
            {
                return $"{UrunAdi} (Stok: {UrunAdedi}, Fiyat: {UrunSatisFiyati:C2})";
            }
        }

        private void LstSearchResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstSearchResults.SelectedItem == null)
                return;

            var selectedProduct = lstSearchResults.SelectedItem as ProductInfo;
            if (selectedProduct == null)
                return;

            string selectedProductName = selectedProduct.UrunAdi;
            int maxStock = selectedProduct.UrunAdedi;

            string input = Interaction.InputBox("How many do you want to add?", "Quantity Selection", "1");

            if (int.TryParse(input, out int quantity))
            {
                if (quantity < 1)
                {
                    MessageBox.Show("Please enter a number that is 1 or greater.");
                    return;
                }

                if (quantity > maxStock)
                {
                    MessageBox.Show($"Maximum stock quantity {maxStock}.");
                    return;
                }

                var existing = selectedProducts.FirstOrDefault(p => p.Name == selectedProductName);
                if (existing != null)
                {
                    if (existing.Quantity + quantity <= maxStock)
                    {
                        existing.Quantity += quantity;
                    }
                    else
                    {
                        MessageBox.Show("Exceeds stock amount!");
                        return;
                    }
                }
                else
                {
                    selectedProducts.Add(new SelectedProduct
                    {
                        Name = selectedProductName,
                        Quantity = quantity
                    });
                }

                // Listeyi güncelle
                lstSelectedProducts.Items.Clear();
                foreach (var prod in selectedProducts)
                {
                    lstSelectedProducts.Items.Add(prod);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid value.");
            }
            UpdatePriceLabel();

        }

        private void LstSelectedProducts_DoubleClick(object sender, EventArgs e)
        {
            if (lstSelectedProducts.SelectedItem != null)
            {
                var item = lstSelectedProducts.SelectedItem as SelectedProduct;
                if (item != null)
                {
                    selectedProducts.Remove(item);
                    lstSelectedProducts.Items.Remove(item);
                }
            }
            UpdatePriceLabel();

        }

        private void lstSearchResults_DoubleClick_1(object sender, EventArgs e)
        {
            
            
        }

        private void lstSelectedProducts_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        
        public class SelectedProduct
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public override string ToString()
            {
                return $"{Name} - Adet: {Quantity}";
            }
        }

        // Satis Kaydet Tarafı


        private void SaveSalesToDatabase(int musteriId, int personelId)
        {
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Please add at least one product to the sale.");
                return;
            }

            decimal iskontoYuzdesi = 0;
            string iskontoText = txtIskonto.Text.Trim();

            if (!string.IsNullOrEmpty(iskontoText))
            {
                if (!decimal.TryParse(iskontoText, out iskontoYuzdesi))
                {
                    MessageBox.Show("Please enter a valid discount value.");
                    return;
                }
                else if (iskontoYuzdesi < 0)
                {
                    MessageBox.Show("The discount rate cannot be negative.");
                    return;
                }
            }

            if (iskontoYuzdesi == 100)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure there is a 100% discount?",
                    "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            // Yeni Siparis nesnesi oluştur
            Siparis yeniSiparis = new Siparis
            {
                MusteriID = musteriId,
                SiparisTarihi = DateTime.Now,
                IskontoYuzdesi = iskontoYuzdesi,
                PersonelID = personelId,
                KdvOrani = 20 // Varsayılan KDV oranı, dilerseniz bu alanı formdan alabilirsiniz.
            };

            decimal siparisAraToplam = 0;

            foreach (var item in selectedProducts)
            {
                var product = allProducts.FirstOrDefault(p => p.UrunAdi == item.Name);
                if (product == null)
                {
                    MessageBox.Show($"Ürün bulunamadı: {item.Name}. Lütfen listeleri kontrol edin.");
                    return; // Veya hata durumunda devam etmek yerine işlemi durdurun.
                }

                decimal detaySonTutar = product.UrunSatisFiyati * item.Quantity * (1 - iskontoYuzdesi / 100);
                // NOT: Eğer ürün bazında iskonto uygulanacaksa, buradaki iskonto hesaplaması değişmelidir.
                // Şu anki kodunuz genel indirimi ürün detayı üzerinde de uyguluyor gibi görünüyor.
                // Eğer DetayIskontoYuzdesi alanı veritabanında ayrı bir indirim içinse, o zaman farklı bir mantık gerekir.
                // Şu anki yapıda genel iskonto, DetaySonTutar'a yansıyor.

                yeniSiparis.Detaylar.Add(new SiparisDetay
                {
                    UrunID = GetProductIdByName(item.Name), // UrunID'yi almak için yeni metod
                    Miktar = item.Quantity,
                    BirimFiyat = product.UrunSatisFiyati,
                    DetayIskontoYuzdesi = iskontoYuzdesi, // Genel indirimi detaylara da yansıtıyoruz
                    DetaySonTutar = detaySonTutar
                });

                siparisAraToplam += detaySonTutar; // Detayların ara toplamını hesapla
            }

            // Siparişin toplam tutarını hesapla (genel iskonto sonrası)
            yeniSiparis.ToplamTutar = siparisAraToplam; // Eğer KDV'yi de buraya dahil edecekseniz, KDV hesaplamasını da ekleyin.
                                                        // Örneğin: yeniSiparis.ToplamTutar = siparisAraToplam * (1 + yeniSiparis.KdvOrani / 100);

            // SiparişService kullanarak siparişi veritabanına kaydet
            int newSiparisId = siparisService.AddSiparis(yeniSiparis);

            if (newSiparisId > 0)
            {
                MessageBox.Show($"Sale recorded successfully! Order ID: {newSiparisId}");

                // Stokları güncelle (Her ürün satıldıktan sonra)
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (var item in selectedProducts)
                    {
                        int urunId = GetProductIdByName(item.Name);
                        string updateStockQuery = "UPDATE Urunler SET UrunAdedi = UrunAdedi - @adet WHERE UrunID = @urunId";
                        using (var updateCmd = new SqlCommand(updateStockQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@adet", item.Quantity);
                            updateCmd.Parameters.AddWithValue("@urunId", urunId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }

                // Formu temizle ve yenile
                selectedProducts.Clear();
                lstSelectedProducts.Items.Clear();
                LoadProductsFromDatabase(); // Ürün listesini ve stokları yenile
                txtIskonto.Text = string.Empty;
                UpdatePriceLabel(); // Fiyat etiketini sıfırla
            }
            else
            {
                MessageBox.Show("An error occurred while saving the sale.");
            }
        }

        private int GetProductIdByName(string productName)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UrunID FROM Urunler WHERE UrunAdi = @urunAdi";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@urunAdi", productName);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return -1; // Bulunamazsa -1 döndür
        }
        private void UpdatePriceLabel()
        {
            toplamTutar = 0;

            foreach (var item in selectedProducts)
            {
                var product = allProducts.FirstOrDefault(p => p.UrunAdi == item.Name);
                if (product != null)
                {
                    toplamTutar += product.UrunSatisFiyati * item.Quantity;
                }
            }

            decimal iskontoYuzde = 0;
            decimal sonTutar = toplamTutar;

            if (decimal.TryParse(txtIskonto.Text, out iskontoYuzde))
            {
                sonTutar = toplamTutar - (toplamTutar * iskontoYuzde / 100);
            }

            if (toplamTutar == sonTutar)
            {
                lblPrice.Text = $"Sum: {toplamTutar:C2}";
            }
            else
            {
                lblPrice.Text = $"Sum: {toplamTutar:C2} | Discounted: {sonTutar:C2}";
            }
            
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(phoneTextbox.Text))
            {
                selectedMusteriId = 1;
            }

            if (selectedMusteriId == -1)
            {
                MessageBox.Show("Geçerli bir müşteri seçiniz.");
                return;
            }

           


            int personelId = UserService.GetUserId.UserId; // Giriş yapan personelin ID’si burada sabit, istersen girişe göre çekersin.
            


            SaveSalesToDatabase(selectedMusteriId, personelId);
            LoadProductsFromDatabase();


        }

        private void txtIskonto_TextChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void PhoneTextbox_TextChanged(object sender, EventArgs e)
        {
            //string telefon = phoneTextbox.Text.Trim();

            //if (telefon.Length < 5)
            //{
            //    // Hatalı veya eksik numara için temizlik yap
            //    nameTextbox.Text = "";
            //    surnameTextbox.Text = "";
            //    selectedMusteriId = -1;
            //    return;
            //}

            //using (var conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            //    string query = "SELECT MusteriID, Ad, Soyad FROM Musteriler WHERE Telefon = @telefon";
            //    using (var cmd = new SqlCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@telefon", telefon);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                selectedMusteriId = reader.GetInt32(0);
            //                nameTextbox.Text = reader.GetString(1);
            //                surnameTextbox.Text = reader.GetString(2);
            //            }
            //            else
            //            {
            //                nameTextbox.Text = "";
            //                surnameTextbox.Text = "";
            //                selectedMusteriId = -1;
            //            }
            //        }
            //    }
            //}
        }


        private void phoneTextbox_TextChanged(object sender, EventArgs e)
        {
            string telefon = phoneTextbox.Text.Trim();
            if (telefon.Length >= 10)
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MusteriID, Ad, Soyad FROM Musteriler WHERE Telefon = @telefon";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@telefon", telefon);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedMusteriId = reader.GetInt32(0);
                                nameTextbox.Text = reader.GetString(1);
                                surnameTextbox.Text = reader.GetString(2);
                            }
                            else
                            {
                                nameTextbox.Text = "";
                                surnameTextbox.Text = "";
                                selectedMusteriId = -1;
                            }
                        }
                    }
                }
            }
        }

        private void phoneTextbox_Leave(object sender, EventArgs e)
        {
            string telefon = phoneTextbox.Text.Trim();

            if (telefon.Length < 5)
            {
                nameTextbox.Text = "";
                surnameTextbox.Text = "";
                selectedMusteriId = -1;
                return;
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MusteriID, Ad, Soyad FROM Musteriler WHERE Telefon = @telefon";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            selectedMusteriId = reader.GetInt32(0);
                            nameTextbox.Text = reader.GetString(1);
                            surnameTextbox.Text = reader.GetString(2);
                        }
                        else
                        {
                            nameTextbox.Text = "";
                            surnameTextbox.Text = "";
                            selectedMusteriId = -1;
                        }
                    }
                }
            }
        }
    }

}
