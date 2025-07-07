using sdr.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace sdr.Services
{
    public partial class roleAddForm : baseForm
    {
        private RoleService _roleService = new RoleService();
        public roleAddForm()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
            btnDeleteRole.Click += BtnDeleteRole_Click;
            LoadRoles();
            lstRoles.DrawMode = DrawMode.OwnerDrawFixed;
            lstRoles.DrawItem += LstRoles_DrawItem;
        }
        private void LoadRoles()
        {
            lstRoles.DataSource = null;
            var roles = _roleService.GetAllRoles();
            lstRoles.DataSource = roles;
            lstRoles.DisplayMember = "RoleName";
            lstRoles.ValueMember = "RoleId";
           
        }
        private void LstRoles_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var listBox = sender as ListBox;
            var item = listBox.Items[e.Index];

            // Arka plan rengi: çift indeks beyaz, tek indeks gri
            Color backColor = e.Index % 2 == 0 ? Color.White : Color.LightGray;

            // Seçiliyse mavi yap
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backColor = SystemColors.Highlight;
            }

            // Arka planı boya
            using (SolidBrush backgroundBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            // Yazı rengini belirle
            Color textColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? SystemColors.HighlightText
                : Color.Black;

            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(item.ToString(), e.Font, textBrush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private void BtnDeleteRole_Click(object sender, EventArgs e)
        {
            if (lstRoles.SelectedItem is Role selectedRole)
            {
                var confirm = MessageBox.Show($"Are you sure you want to delete role '{selectedRole.RoleName}'?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool success = _roleService.DeleteRole(selectedRole.RoleId);
                    if (success)
                    {
                        MessageBox.Show("Role deleted successfully.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        LoadRoles();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete role.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a role to delete.");
            }
        }
        private void roleAddForm_Load(object sender, EventArgs e)
        {

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string roleName = txtRoleName.Text.Trim();
        string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(roleName))
            {
                MessageBox.Show("Role name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

    var newRole = new Role
    {
        RoleName = roleName,
        Description = description
    };

            if (_roleService.AddRole(newRole))
            {
                MessageBox.Show("Role added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
    }
            else
            {
                //MessageBox.Show("Failed to add role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {

        }

        private void lstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void lstRoles_DoubleClick(object sender, EventArgs e)
        {
            if (lstRoles.SelectedItem is Role selectedRole)
            {
                MessageBox.Show($"Selected Role: {selectedRole.RoleName}, Description: {selectedRole.Description}","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
