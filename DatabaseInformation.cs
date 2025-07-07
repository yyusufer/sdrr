using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace sdr
{
    public partial class DatabaseInformation : baseForm
    {
        private string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbconfig.json");


        public DatabaseInformation()
        {
            InitializeComponent();

            checkLocalhost.CheckedChanged += (s, e) =>
            {
                bool enabled = !checkLocalhost.Checked;
                txtPAdress.Enabled = enabled;
                txtPAdress.BackColor = enabled ? Color.White : Color.LightGray;

                if (checkLocalhost.Checked)
                    txtPAdress.Text = "localhost";
                else
                    txtPAdress.Text = "";
            };

            checkWindows.CheckedChanged += (s, e) =>
            {
                bool enabled = !checkWindows.Checked;
                txtUsername.Enabled = enabled;
                txtPassword.Enabled = enabled;

                txtUsername.BackColor = enabled ? Color.White : Color.LightGray;
                txtPassword.BackColor = enabled ? Color.White : Color.LightGray;
            };

            btnConnect.Click += BtnConnect_Click;
            this.Load += DatabaseInformation_Load;
        }

        private void DatabaseInformation_Load(object sender, EventArgs e)
        {
            if (File.Exists(configPath))
            {
                try
                {
                    string json = File.ReadAllText(configPath);
                    var config = JsonConvert.DeserializeObject<DbConfig>(json);

                    if (config != null)
                    {
                        txtPAdress.Text = config.Server;
                        txtDBName.Text = config.Database;
                        checkWindows.Checked = config.UseWindowsAuth;
                        txtUsername.Text = config.Username;
                        txtPassword.Text = config.Password;

                        // Ayar varsa textboxları disable yap
                        txtPAdress.Enabled = false;
                        txtDBName.Enabled = false;
                        txtUsername.Enabled = false;
                        txtPassword.Enabled = false;
                        checkWindows.Enabled = false;
                        checkLocalhost.Enabled = false;

                        btnConnect.Text = "Clear Config";
                    }
                }
                catch
                {
                    // Okuma hatası olursa silent geç
                }
            }
        }

        public string username
        {
            get { return txtUsername.Text; }
        }
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Clear Config")
            {
                // Dosyayı sil ve kutucukları enable yap, kutucukları temizle
                if (File.Exists(configPath))
                    File.Delete(configPath);

                txtPAdress.Enabled = true;
                txtDBName.Enabled = true;
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                checkWindows.Enabled = true;
                checkLocalhost.Enabled = true;

                txtPAdress.Text = "";
                txtDBName.Text = "";
                txtUsername.Text = "";
                txtPassword.Text = "";

                btnConnect.Text = "Connect";
                return;
            }

            string server = checkLocalhost.Checked ? "localhost" : txtPAdress.Text.Trim();
            string database = txtDBName.Text.Trim();
            bool useWindowsAuth = checkWindows.Checked;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(database))
            {
                MessageBox.Show("Server and Database cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!useWindowsAuth && (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)))
            {
                MessageBox.Show("Username or Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString;
            if (useWindowsAuth)
            {
                connectionString = $"Server={server};Database={database};Integrated Security=True;";
            }
            else
            {
                connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveConfig(server, database, useWindowsAuth, username, password);

                    // Disable input controls after successful save
                    txtPAdress.Enabled = false;
                    txtDBName.Enabled = false;
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                    checkWindows.Enabled = false;
                    checkLocalhost.Enabled = false;

                    btnConnect.Text = "Clear Config";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveConfig(string server, string database, bool useWindowsAuth, string username, string password)
        {
            var config = new DbConfig
            {
                Server = server,
                Database = database,
                UseWindowsAuth = useWindowsAuth,
                Username = username,
                Password = password
            };

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(configPath, json);
        }

        private class DbConfig
        {
            public string Server { get; set; }
            public string Database { get; set; }
            public bool UseWindowsAuth { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {

        }
    }
}
