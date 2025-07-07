using sdr.Models;
using sdr.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace sdr
{
    public partial class roleForm : baseForm
    {
        private RoleService _roleService = new RoleService();
        private List<Role> _roles;

        public roleForm()
        {
            InitializeComponent();
            this.Load += roleForm_Load;
            btnOpenPermissionForm.Click += btnOpenPermissionForm_Click;

        }
        private void roleForm_Load(object sender, EventArgs e)
        {
            _roles = _roleService.GetAllRoles();
            cmbRoles.DataSource = _roles;
            cmbRoles.DisplayMember = "Name";
            cmbRoles.ValueMember = "RoleId";
        }

        private void btnOpenPermissionForm_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedItem is Role selectedRole)
            {
                rolePermissionForm permissionForm = new rolePermissionForm();
                permissionForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a role first.");
            }
        }
    }
}
