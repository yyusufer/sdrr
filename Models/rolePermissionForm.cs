using sdr.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace sdr.Models
{
    public partial class rolePermissionForm : baseForm
    {
        private RoleService _roleService = new RoleService();
        private PermissionService _permissionService = new PermissionService();

        private List<Role> _roles;
        private List<Permission> _allPermissions;

        public rolePermissionForm()
        {
            InitializeComponent();

            // Event bağlamaları
            this.Load += rolePermissionForm_Load;
            cmbRoles.SelectedIndexChanged += cmbRoles_SelectedIndexChanged;
            btnSavePermissions.Click += btnSavePermissions_Click;
        }

        private void rolePermissionForm_Load(object sender, EventArgs e)
        {
           

            // Roller ve izinleri getir
            _roles = _roleService.GetAllRoles();
            _allPermissions = _permissionService.GetAllPermissions();

            cmbRoles.DataSource = null;
            cmbRoles.DataSource = _roles;
            cmbRoles.DisplayMember = "Role"+ "Description";   // Rollerin adı gösterilecek
            cmbRoles.ValueMember = "RoleId";

            // Eğer en az 1 rol varsa ilkini seç ve izinleri yükle
            if (_roles.Count > 0)
            {
                cmbRoles.SelectedIndex = 0;
                LoadPermissionsForRole(_roles[0].RoleId);
            }

        }

        private void LoadPermissionsForRole(int roleId)
        {
            clbPermissions.Items.Clear();
            clbPermissions.DisplayMember = "PermissionName" ;
            var rolePermissions = _permissionService.GetPermissionsByRoleId(roleId);

            foreach (var perm in _allPermissions)
            {
                bool isChecked = rolePermissions.Any(p => p.PermissionId == perm.PermissionId);
                clbPermissions.Items.Add(perm, isChecked);
            }
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedItem is Role selectedRole)
            {
                LoadPermissionsForRole(selectedRole.RoleId);
            }
        }

        private void btnSavePermissions_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedItem is Role selectedRole)
            {
                var selectedPermissions = clbPermissions.CheckedItems.OfType<Permission>().ToList();
                    
                _permissionService.AssignPermissionsToRole(selectedRole.RoleId, selectedPermissions);
                //MessageBox.Show("Permissions updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clbPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clbPermissions_DoubleClick(object sender, EventArgs e)
        {
            if (clbPermissions.SelectedItem is Role selectedRole)
            {
                MessageBox.Show($"Selected Role: {selectedRole.RoleName}, Description: {selectedRole.Description}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
