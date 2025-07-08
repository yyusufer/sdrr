using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using sdr.Helpers;
using sdr.Models;
using sdr.Services;

namespace sdr
{
    public partial class login : baseForm
    {
        private readonly PermissionService _permissionService = new PermissionService();

        private readonly string appDataFolder;
        private readonly string rememberMeFilePath;

        private readonly string _connectionString = DbConnectionManager.GetConnectionString();

        public login()
        {
            InitializeComponent();

            appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SDR Sistemleri");
            rememberMeFilePath = Path.Combine(appDataFolder, "rememberMe.json");

            if (!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;

            string remembered = LoadRememberedUsername();
            if (!string.IsNullOrEmpty(remembered))
            {
                txtUsername.Text = remembered;
                checkRemember.Checked = true;
            }

            this.Icon = new Icon("sdr_logo.ico");
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, EventArgs.Empty);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            UserService userService = new UserService();
            bool loginSuccess = userService.ValidateLogin(txtUsername.Text.Trim(), txtPass.Text.Trim());

            if (loginSuccess)
            {
                User loggedInUser = userService.GetUserByUsername(txtUsername.Text.Trim());
                if (loggedInUser == null)
                {
                    MessageBox.Show("User not found after login, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.UserId = loggedInUser.UserId;

                Session.UserPermissions = _permissionService.GetPermissionsByUserId(loggedInUser.UserId)
                                                            .Select(p => p.PermissionName)
                                                            .ToList();

                adminForm adminform = new adminForm();

                if (checkRemember.Checked)
                {
                    SaveRememberMe(txtUsername.Text);
                }
                else
                {
                    if (File.Exists(rememberMeFilePath))
                    {
                        File.Delete(rememberMeFilePath);
                    }
                }

                this.Hide();
                adminform.lblUsername.Text = txtUsername.Text + " logged in";

                adminform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatabaseInformation databaseInformation = new DatabaseInformation();
            databaseInformation.ShowDialog();
        }

        private void SaveRememberMe(string username)
        {
            var data = new RememberMeData
            {
                Username = username,
                RememberedAt = DateTime.Now
            };

            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(rememberMeFilePath, json);
        }

        private string LoadRememberedUsername()
        {
            if (!File.Exists(rememberMeFilePath))
                return null;

            try
            {
                string json = File.ReadAllText(rememberMeFilePath);
                var data = JsonConvert.DeserializeObject<RememberMeData>(json);

                if (data != null && (DateTime.Now - data.RememberedAt).TotalDays <= 30)
                {
                    return data.Username;
                }
                else
                {
                    File.Delete(rememberMeFilePath);
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
