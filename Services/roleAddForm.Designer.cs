namespace sdr.Services
{
    partial class roleAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.btnSave = new ReaLTaiizor.Controls.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnCancel = new ReaLTaiizor.Controls.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblRoleDescription = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.btnDeleteRole = new ReaLTaiizor.Controls.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(203, 101);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(277, 27);
            this.txtRoleName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSave.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Image = null;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnSave.Location = new System.Drawing.Point(231, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(203, 147);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(277, 27);
            this.txtDescription.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCancel.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Image = null;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCancel.Location = new System.Drawing.Point(357, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCancel.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Inter", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(59, 99);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(109, 27);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "Role Name";
            // 
            // lblRoleDescription
            // 
            this.lblRoleDescription.AutoSize = true;
            this.lblRoleDescription.Font = new System.Drawing.Font("Inter", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRoleDescription.ForeColor = System.Drawing.Color.White;
            this.lblRoleDescription.Location = new System.Drawing.Point(59, 148);
            this.lblRoleDescription.Name = "lblRoleDescription";
            this.lblRoleDescription.Size = new System.Drawing.Size(115, 27);
            this.lblRoleDescription.TabIndex = 5;
            this.lblRoleDescription.Text = "Description";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtRoleName);
            this.groupBox1.Controls.Add(this.lblRoleDescription);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.lblRole);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(33, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(876, 345);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Role Add";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lstRoles
            // 
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.ItemHeight = 23;
            this.lstRoles.Location = new System.Drawing.Point(37, 39);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(233, 188);
            this.lstRoles.TabIndex = 7;
            this.lstRoles.SelectedIndexChanged += new System.EventHandler(this.lstRoles_SelectedIndexChanged);
            this.lstRoles.DoubleClick += new System.EventHandler(this.lstRoles_DoubleClick);
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteRole.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnDeleteRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteRole.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnDeleteRole.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnDeleteRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDeleteRole.Image = null;
            this.btnDeleteRole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRole.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnDeleteRole.Location = new System.Drawing.Point(99, 244);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnDeleteRole.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnDeleteRole.Size = new System.Drawing.Size(120, 40);
            this.btnDeleteRole.TabIndex = 8;
            this.btnDeleteRole.Text = "Delete Role";
            this.btnDeleteRole.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstRoles);
            this.groupBox2.Controls.Add(this.btnDeleteRole);
            this.groupBox2.Font = new System.Drawing.Font("Inter", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(540, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 310);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete Role";
            // 
            // roleAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 420);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(21, 27, 21, 27);
            this.Name = "roleAddForm";
            this.Text = "roleAddForm";
            this.Load += new System.EventHandler(this.roleAddForm_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRoleName;
        private ReaLTaiizor.Controls.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private ReaLTaiizor.Controls.Button btnCancel;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblRoleDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstRoles;
        private ReaLTaiizor.Controls.Button btnDeleteRole;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}