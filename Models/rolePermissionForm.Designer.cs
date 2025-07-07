namespace sdr.Models
{
    partial class rolePermissionForm
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
            this.clbPermissions = new System.Windows.Forms.CheckedListBox();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnSavePermissions = new ReaLTaiizor.Controls.CyberButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbPermissions
            // 
            this.clbPermissions.Font = new System.Drawing.Font("Inter", 12F);
            this.clbPermissions.FormattingEnabled = true;
            this.clbPermissions.Location = new System.Drawing.Point(27, 90);
            this.clbPermissions.Name = "clbPermissions";
            this.clbPermissions.Size = new System.Drawing.Size(427, 158);
            this.clbPermissions.TabIndex = 1;
            this.clbPermissions.SelectedIndexChanged += new System.EventHandler(this.clbPermissions_SelectedIndexChanged);
            this.clbPermissions.DoubleClick += new System.EventHandler(this.clbPermissions_DoubleClick);
            // 
            // cmbRoles
            // 
            this.cmbRoles.Font = new System.Drawing.Font("Inter", 12F);
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(128, 26);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(227, 31);
            this.cmbRoles.TabIndex = 2;
            // 
            // btnSavePermissions
            // 
            this.btnSavePermissions.Alpha = 20;
            this.btnSavePermissions.BackColor = System.Drawing.Color.Transparent;
            this.btnSavePermissions.Background = true;
            this.btnSavePermissions.Background_WidthPen = 4F;
            this.btnSavePermissions.BackgroundPen = true;
            this.btnSavePermissions.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnSavePermissions.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnSavePermissions.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnSavePermissions.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnSavePermissions.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnSavePermissions.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnSavePermissions.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnSavePermissions.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnSavePermissions.Effect_1 = true;
            this.btnSavePermissions.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnSavePermissions.Effect_1_Transparency = 25;
            this.btnSavePermissions.Effect_2 = true;
            this.btnSavePermissions.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnSavePermissions.Effect_2_Transparency = 20;
            this.btnSavePermissions.Font = new System.Drawing.Font("Arial", 11F);
            this.btnSavePermissions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnSavePermissions.Lighting = false;
            this.btnSavePermissions.LinearGradient_Background = false;
            this.btnSavePermissions.LinearGradientPen = false;
            this.btnSavePermissions.Location = new System.Drawing.Point(156, 285);
            this.btnSavePermissions.Name = "btnSavePermissions";
            this.btnSavePermissions.PenWidth = 15;
            this.btnSavePermissions.Rounding = true;
            this.btnSavePermissions.RoundingInt = 70;
            this.btnSavePermissions.Size = new System.Drawing.Size(130, 50);
            this.btnSavePermissions.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnSavePermissions.TabIndex = 3;
            this.btnSavePermissions.Tag = "Cyber";
            this.btnSavePermissions.TextButton = "Save";
            this.btnSavePermissions.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnSavePermissions.Timer_Effect_1 = 5;
            this.btnSavePermissions.Timer_RGB = 300;
            this.btnSavePermissions.Click += new System.EventHandler(this.btnSavePermissions_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Role:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRoles);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.clbPermissions);
            this.groupBox1.Controls.Add(this.btnSavePermissions);
            this.groupBox1.Font = new System.Drawing.Font("Inter", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(110, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 348);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Permissions";
            // 
            // rolePermissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 425);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(21, 27, 21, 27);
            this.Name = "rolePermissionForm";
            this.Text = "rolePermissionForm";
            this.Load += new System.EventHandler(this.rolePermissionForm_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbPermissions;
        private System.Windows.Forms.ComboBox cmbRoles;
        private ReaLTaiizor.Controls.CyberButton btnSavePermissions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}