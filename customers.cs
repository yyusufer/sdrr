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
using sdr.Helpers;
namespace sdr
{
    public partial class customers : baseForm
    {
        private readonly string connectionString = DbConnectionManager.GetConnectionString();
        public customers()
        {
            InitializeComponent();
        }
        public class Musteri
        {
            public int MusteriID { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Adres { get; set; }
            public string Unvan { get; set; }
            public string Telefon { get; set; }
            public DateTime EklenmeTarihi { get; set; }
            public int? EkleyenPersonelID { get; set; }
            public string Email { get; set; }
            public string VergiDairesi { get; set; }
            public string VergiNo { get; set; }
        }


        public List<Musteri> GetAllMusteriler()
        {
            var list = new List<Musteri>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Musteriler", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var m = new Musteri
                        {
                            MusteriID = (int)reader["MusteriID"],
                            Ad = reader["Ad"].ToString(),
                            Soyad = reader["Soyad"].ToString(),
                            Adres = reader["Adres"] as string,
                            Unvan = reader["Unvan"] as string,
                            Telefon = reader["Telefon"] as string,
                            EklenmeTarihi = (DateTime)reader["EklenmeTarihi"],
                            EkleyenPersonelID = reader["EkleyenPersonelID"] as int?,
                            Email = reader["Email"] as string,
                            VergiDairesi = reader["VergiDairesi"] as string,
                            VergiNo = reader["VergiNo"] as string
                        };
                        list.Add(m);
                    }
                }
            }

            return list;
        }

        private void LoadMusteriler()
        {
            var list = GetAllMusteriler();
            dataGridViewMusteri.DataSource = list; // dataGridViewMusteri adını kendi DataGridView'in adıyla değiştir
            StyleDataGridView();
        }
        private void StyleDataGridView()
        {
            // Kenarlık ve başlık ayarları
            dataGridViewMusteri.BorderStyle = BorderStyle.None;
            dataGridViewMusteri.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewMusteri.EnableHeadersVisualStyles = false;

            // Satır stili
            dataGridViewMusteri.DefaultCellStyle.BackColor = Color.White;
            dataGridViewMusteri.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewMusteri.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewMusteri.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewMusteri.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Başlık stili
            dataGridViewMusteri.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dataGridViewMusteri.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewMusteri.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewMusteri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Alternatif satır rengi
            dataGridViewMusteri.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);

            // Satır seçimi
            dataGridViewMusteri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMusteri.MultiSelect = false;

            // Otomatik sütun genişliği
            dataGridViewMusteri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Satır yüksekliği
            dataGridViewMusteri.RowTemplate.Height = 28;

            // Kullanıcı ekleyemesin, sadece görüntüleme
            dataGridViewMusteri.ReadOnly = true;
            dataGridViewMusteri.AllowUserToAddRows = false;
            dataGridViewMusteri.AllowUserToDeleteRows = false;
            dataGridViewMusteri.AllowUserToResizeRows = false;
        }

        private void customers_Load(object sender, EventArgs e)
        {
            LoadMusteriler();
        }

        public void AddMusteri(Musteri m)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Musteriler
                (Ad, Soyad, Adres, Unvan, Telefon, EklenmeTarihi, EkleyenPersonelID, Email, VergiDairesi, VergiNo)
                VALUES
                (@Ad, @Soyad, @Adres, @Unvan, @Telefon, @EklenmeTarihi, @EkleyenPersonelID, @Email, @VergiDairesi, @VergiNo)", conn);

                cmd.Parameters.AddWithValue("@Ad", m.Ad);
                cmd.Parameters.AddWithValue("@Soyad", m.Soyad);
                cmd.Parameters.AddWithValue("@Adres", (object)m.Adres ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Unvan", (object)m.Unvan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefon", (object)m.Telefon ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EklenmeTarihi", m.EklenmeTarihi);
                cmd.Parameters.AddWithValue("@EkleyenPersonelID", (object)m.EkleyenPersonelID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)m.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VergiDairesi", (object)m.VergiDairesi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VergiNo", (object)m.VergiNo ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridViewMusteri_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMusteri.SelectedRows.Count > 0)
            {
                var row = dataGridViewMusteri.SelectedRows[0];
                txtAd.Text = row.Cells["Ad"].Value?.ToString();
                txtSoyad.Text = row.Cells["Soyad"].Value?.ToString();
                txtAdres.Text = row.Cells["Adres"].Value?.ToString();
                txtUnvan.Text = row.Cells["Unvan"].Value?.ToString();
                txtTelefon.Text = row.Cells["Telefon"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtVergiDairesi.Text = row.Cells["VergiDairesi"].Value?.ToString();
                txtVergiNo.Text = row.Cells["VergiNo"].Value?.ToString();
            }
        }
        private void dataGridViewMusteri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            int? musteriId = null;

            if (dataGridViewMusteri.SelectedRows.Count > 0)
            {
                musteriId = (int?)dataGridViewMusteri.SelectedRows[0].Cells["MusteriID"].Value;
            }

            Musteri musteri = new Musteri
            {
                Ad = txtAd.Text.Trim(),
                Soyad = txtSoyad.Text.Trim(),
                Adres = string.IsNullOrWhiteSpace(txtAdres.Text) ? null : txtAdres.Text.Trim(),
                Unvan = string.IsNullOrWhiteSpace(txtUnvan.Text) ? null : txtUnvan.Text.Trim(),
                Telefon = string.IsNullOrWhiteSpace(txtTelefon.Text) ? null : txtTelefon.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                VergiDairesi = string.IsNullOrWhiteSpace(txtVergiDairesi.Text) ? null : txtVergiDairesi.Text.Trim(),
                VergiNo = string.IsNullOrWhiteSpace(txtVergiNo.Text) ? null : txtVergiNo.Text.Trim(),
                EklenmeTarihi = DateTime.Now,
                EkleyenPersonelID = Session.UserId
            };

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd;

                    if (musteriId.HasValue)
                    {
                        // GÜNCELLE
                        cmd = new SqlCommand(@"
                    UPDATE Musteriler SET 
                        Ad = @Ad, Soyad = @Soyad, Adres = @Adres, Unvan = @Unvan,
                        Telefon = @Telefon, Email = @Email,
                        VergiDairesi = @VergiDairesi, VergiNo = @VergiNo
                    WHERE MusteriID = @MusteriID", conn);

                        cmd.Parameters.AddWithValue("@MusteriID", musteriId.Value);
                    }
                    else
                    {
                        // EKLE
                        cmd = new SqlCommand(@"
                    INSERT INTO Musteriler 
                        (Ad, Soyad, Adres, Unvan, Telefon, EklenmeTarihi, EkleyenPersonelID, Email, VergiDairesi, VergiNo)
                    VALUES
                        (@Ad, @Soyad, @Adres, @Unvan, @Telefon, @EklenmeTarihi, @EkleyenPersonelID, @Email, @VergiDairesi, @VergiNo)", conn);

                        cmd.Parameters.AddWithValue("@EklenmeTarihi", musteri.EklenmeTarihi);
                        cmd.Parameters.AddWithValue("@EkleyenPersonelID", (object)musteri.EkleyenPersonelID ?? DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@Ad", musteri.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", musteri.Soyad);
                    cmd.Parameters.AddWithValue("@Adres", (object)musteri.Adres ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Unvan", (object)musteri.Unvan ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefon", (object)musteri.Telefon ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)musteri.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VergiDairesi", (object)musteri.VergiDairesi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VergiNo", (object)musteri.VergiNo ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(musteriId.HasValue ? "Müşteri güncellendi." : "Müşteri eklendi.");
                LoadMusteriler();

                // Temizle
                txtAd.Clear();
                txtSoyad.Clear();
                txtAdres.Clear();
                txtUnvan.Clear();
                txtTelefon.Clear();
                txtEmail.Clear();
                txtVergiDairesi.Clear();
                txtVergiNo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void dataGridViewMusteri_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string value = dataGridViewMusteri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    Clipboard.SetText(value);
                    MessageBox.Show($"“{value}” kopyalandı!", "Kopyalandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void DeleteMusteri(int musteriId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Musteriler WHERE MusteriID = @MusteriID", conn);
                cmd.Parameters.AddWithValue("@MusteriID", musteriId);
                cmd.ExecuteNonQuery();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewMusteri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriId = (int)dataGridViewMusteri.SelectedRows[0].Cells["MusteriID"].Value;

            DialogResult result = MessageBox.Show("Seçilen müşteriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteMusteri(musteriId);
                    MessageBox.Show("Müşteri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMusteriler(); // Listeyi yenile
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewMusteri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
