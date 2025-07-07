using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sdr.Helpers;
using sdr.Services;
using sdr.Models;
using System.Data.SqlClient;
namespace sdr.Services
{
    public partial class CreateUser : baseForm
    {
        private readonly string _connection = DbConnectionManager.GetConnectionString();
        public CreateUser()
        {
            InitializeComponent();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            LoadRolesIntoComboBox();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }


        private bool ValidateFormInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("The username field cannot be left blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPass.Text) && string.IsNullOrWhiteSpace(txtPassAgain.Text))
            {
                MessageBox.Show("The password field and again password field cannot be left blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("The password field cannot be left blank.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassAgain.Text))
            {
                MessageBox.Show("The again password field cannot be left blank.");
                return false;
            }

            if (txtPass.Text != txtPassAgain.Text)
            {
                MessageBox.Show("Passwords do not match. Try again.");
                return false;
            }

            return true; // Her şey doğruysa
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateFormInputs())
            {
                var selectedRoleId = (int)cmbRoles.SelectedValue;
                var service = new UserService();
                bool success = service.AddUser(new User
                {
                    Email = txtEmail.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    PasswordHash = txtPass.Text.Trim(), // düz yaz! hash helper içeride çalışıyor
                    RoleId = selectedRoleId
                });

                   
                }





        }

        

        private void LoadRolesIntoComboBox()
        {
            using (var conn = new SqlConnection(_connection))
            {
                conn.Open();
                string query = "SELECT RoleId, RoleName FROM Roles";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var roles = new List<Role>();
                    while (reader.Read())
                    {
                        roles.Add(new Role
                        {
                            RoleId = Convert.ToInt32(reader["RoleId"]),
                            RoleName = reader["RoleName"].ToString()
                        });
                    }

                    cmbRoles.DataSource = roles;
                    cmbRoles.DisplayMember = "RoleName";
                    cmbRoles.ValueMember = "RoleId";
                }
            }
        }





    }
    }

