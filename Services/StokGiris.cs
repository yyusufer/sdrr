    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using sdr.Models;
    using sdr.Helpers;
    namespace sdr.Services
    {
        public partial class StokGiris :baseForm
        {
            private readonly string connectionString = DbConnectionManager.GetConnectionString();
            private int selectedUrunId = -1;
            public StokGiris()
            {
                InitializeComponent();
            }

            private void StokGiris_Load(object sender, EventArgs e)
            {
            LoadUrunler();
            dataGridViewUrunler.SelectionChanged += dataGridViewUrunler_SelectionChanged;
            btnUrunEkle.Click += btnUrunEkle_Click;
            btnUrunSil.Click += btnUrunSil_Click;
        }
            private void LoadUrunler()
            {
                var urunler = GetAllUrunler();
                dataGridViewUrunler.DataSource = urunler;
            StyleDataGridView();


            txtAra.TextChanged += txtAra_TextChanged;
        }

            private List<Urun> GetAllUrunler()
            {
                var list = new List<Urun>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Urunler", conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var u = new Urun
                            {
                                UrunID = (int)reader["UrunID"],
                                UrunAdi = reader["UrunAdi"].ToString(),
                                UrunAdedi = (int)reader["UrunAdedi"],
                                UrunOzelligi = reader["UrunOzelligi"] as string,
                                UrunAlisFiyati = (decimal)reader["UrunAlisFiyati"],
                                UrunSatisFiyati = (decimal)reader["UrunSatisFiyati"],
                                EklenmeTarihi = (DateTime)reader["EklenmeTarihi"],
                                EkleyenPersonelID = reader["EkleyenPersonelID"] as int?
                            };
                            list.Add(u);
                        }
                    }
                }
                return list;
            }

            private void dataGridViewUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void btnUrunSil_Click(object sender, EventArgs e)
            {
                if (selectedUrunId == -1)
                {
                    MessageBox.Show("Lütfen silmek için bir ürün seçin.");
                    return;
                }

                var confirm = MessageBox.Show("Seçilen ürünü silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM Urunler WHERE UrunID = @UrunID", conn);
                    deleteCmd.Parameters.AddWithValue("@UrunID", selectedUrunId);
                    deleteCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Ürün silindi.");

                LoadUrunler();
                ClearInputFields();
            }
            private void ClearInputFields()
            {
                txtUrunAdi.Clear();
                txtUrunAdedi.Clear();
                txtUrunOzelligi.Clear();
                txtUrunAlisFiyati.Clear();
                txtUrunSatisFiyati.Clear();
                selectedUrunId = -1;
            }
            private void dataGridViewUrunler_SelectionChanged(object sender, EventArgs e)
            {
                if (dataGridViewUrunler.SelectedRows.Count == 0)
                {
                    ClearInputFields();
                    selectedUrunId = -1;
                    return;
                }

                var row = dataGridViewUrunler.SelectedRows[0];
                selectedUrunId = (int)row.Cells["UrunID"].Value;
                txtUrunAdi.Text = row.Cells["UrunAdi"].Value?.ToString();
                txtUrunAdedi.Text = row.Cells["UrunAdedi"].Value?.ToString();
                txtUrunOzelligi.Text = row.Cells["UrunOzelligi"].Value?.ToString();
                txtUrunAlisFiyati.Text = row.Cells["UrunAlisFiyati"].Value?.ToString();
                txtUrunSatisFiyati.Text = row.Cells["UrunSatisFiyati"].Value?.ToString();
            }

            private void btnUrunEkle_Click(object sender, EventArgs e)
            {
            string urunAdi = txtUrunAdi.Text.Trim();
            bool adetParse = int.TryParse(txtUrunAdedi.Text.Trim(), out int urunAdedi);
            string urunOzelligi = txtUrunOzelligi.Text.Trim();
            bool alisParse = decimal.TryParse(txtUrunAlisFiyati.Text.Trim(), out decimal urunAlisFiyati);
            bool satisParse = decimal.TryParse(txtUrunSatisFiyati.Text.Trim(), out decimal urunSatisFiyati);

            if (string.IsNullOrWhiteSpace(urunAdi) || !adetParse || urunAdedi < 0 || !alisParse || !satisParse)
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doğru şekilde doldurun.");
                return;
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (selectedUrunId != -1)
                {
                    SqlCommand updateCmd = new SqlCommand(@"
                UPDATE Urunler SET
                UrunAdi = @UrunAdi,
                UrunAdedi = @UrunAdedi,
                UrunOzelligi = @UrunOzelligi,
                UrunAlisFiyati = @UrunAlisFiyati,
                UrunSatisFiyati = @UrunSatisFiyati
                WHERE UrunID = @UrunID", conn);

                    updateCmd.Parameters.AddWithValue("@UrunAdi", urunAdi);
                    updateCmd.Parameters.AddWithValue("@UrunAdedi", urunAdedi);
                    updateCmd.Parameters.AddWithValue("@UrunOzelligi", string.IsNullOrWhiteSpace(urunOzelligi) ? (object)DBNull.Value : urunOzelligi);
                    updateCmd.Parameters.AddWithValue("@UrunAlisFiyati", urunAlisFiyati);
                    updateCmd.Parameters.AddWithValue("@UrunSatisFiyati", urunSatisFiyati);
                    updateCmd.Parameters.AddWithValue("@UrunID", selectedUrunId);

                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Ürün başarıyla güncellendi.");
                }
                else
                {
                    SqlCommand insertCmd = new SqlCommand(@"
                INSERT INTO Urunler (UrunAdi, UrunAdedi, UrunOzelligi, UrunAlisFiyati, UrunSatisFiyati, EklenmeTarihi)
                VALUES (@UrunAdi, @UrunAdedi, @UrunOzelligi, @UrunAlisFiyati, @UrunSatisFiyati, @EklenmeTarihi)", conn);

                    insertCmd.Parameters.AddWithValue("@UrunAdi", urunAdi);
                    insertCmd.Parameters.AddWithValue("@UrunAdedi", urunAdedi);
                    insertCmd.Parameters.AddWithValue("@UrunOzelligi", string.IsNullOrWhiteSpace(urunOzelligi) ? (object)DBNull.Value : urunOzelligi);
                    insertCmd.Parameters.AddWithValue("@UrunAlisFiyati", urunAlisFiyati);
                    insertCmd.Parameters.AddWithValue("@UrunSatisFiyati", urunSatisFiyati);
                    insertCmd.Parameters.AddWithValue("@EklenmeTarihi", DateTime.Now);

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Yeni ürün başarıyla eklendi.");
                }
            }

            LoadUrunler();
            ClearInputFields(); // <-- en son çalışmalı
        }
        private void StyleDataGridView()
        {
            // Kenarlık ve başlık ayarları
            dataGridViewUrunler.BorderStyle = BorderStyle.None;
            dataGridViewUrunler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewUrunler.EnableHeadersVisualStyles = false;

            // Satır stili
            dataGridViewUrunler.DefaultCellStyle.BackColor = Color.White;
            dataGridViewUrunler.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewUrunler.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewUrunler.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewUrunler.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Başlık stili
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewUrunler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Alternatif satır rengi
            dataGridViewUrunler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);

            // Satır seçimi
            dataGridViewUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUrunler.MultiSelect = false;

            // Otomatik sütun genişliği
            dataGridViewUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Satır yüksekliği
            dataGridViewUrunler.RowTemplate.Height = 28;

            // Kullanıcı ekleyemesin, sadece görüntüleme
            dataGridViewUrunler.ReadOnly = true;
            dataGridViewUrunler.AllowUserToAddRows = false;
            dataGridViewUrunler.AllowUserToDeleteRows = false;
            dataGridViewUrunler.AllowUserToResizeRows = false;
        }

        private void dataGridViewUrunler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string value = dataGridViewUrunler.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    Clipboard.SetText(value);
                    MessageBox.Show($"“{value}” kopyalandı!", "Kopyalandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {

            string aranan = txtAra.Text.Trim().ToLower();

            var filtreliListe = GetAllUrunler()
                .Where(u => u.UrunAdi.ToLower().Contains(aranan) ||
                            (u.UrunOzelligi != null && u.UrunOzelligi.ToLower().Contains(aranan)))
                .ToList();

            dataGridViewUrunler.DataSource = filtreliListe;
        }
    }
    }
