using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using sdr.Services;
using sdr.Models;
namespace sdr
{
    public partial class settingsForm : baseForm
    {
        public settingsForm()
        {
            InitializeComponent();

           
        }
        public Image ByteArrayToImage(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void settingsForm_Load(object sender, EventArgs e)
        {
         
        }

        private void btnDbConfigure_Click(object sender, EventArgs e)
        {
            DatabaseInformation databaseInformation = new DatabaseInformation();
            databaseInformation.Show();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser();
            createUser.Show();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            rolePermissionForm rolePermissionForm = new rolePermissionForm();
            rolePermissionForm.Show();
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            roleAddForm RoleForm = new roleAddForm();
            RoleForm.Show();
        }
    }
}
