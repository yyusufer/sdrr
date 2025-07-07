namespace sdr
{
    partial class roleForm : baseForm
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
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnOpenPermissionForm = new ReaLTaiizor.Controls.CyberButton();
            this.lblSelectRole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbRoles
            // 
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(264, 111);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(285, 47);
            this.cmbRoles.TabIndex = 1;
            // 
            // btnOpenPermissionForm
            // 
            this.btnOpenPermissionForm.Alpha = 20;
            this.btnOpenPermissionForm.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenPermissionForm.Background = true;
            this.btnOpenPermissionForm.Background_WidthPen = 4F;
            this.btnOpenPermissionForm.BackgroundPen = true;
            this.btnOpenPermissionForm.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnOpenPermissionForm.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnOpenPermissionForm.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnOpenPermissionForm.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnOpenPermissionForm.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnOpenPermissionForm.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnOpenPermissionForm.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnOpenPermissionForm.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnOpenPermissionForm.Effect_1 = true;
            this.btnOpenPermissionForm.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnOpenPermissionForm.Effect_1_Transparency = 25;
            this.btnOpenPermissionForm.Effect_2 = true;
            this.btnOpenPermissionForm.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnOpenPermissionForm.Effect_2_Transparency = 20;
            this.btnOpenPermissionForm.Font = new System.Drawing.Font("Arial", 11F);
            this.btnOpenPermissionForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnOpenPermissionForm.Lighting = false;
            this.btnOpenPermissionForm.LinearGradient_Background = false;
            this.btnOpenPermissionForm.LinearGradientPen = false;
            this.btnOpenPermissionForm.Location = new System.Drawing.Point(342, 201);
            this.btnOpenPermissionForm.Name = "btnOpenPermissionForm";
            this.btnOpenPermissionForm.PenWidth = 15;
            this.btnOpenPermissionForm.Rounding = true;
            this.btnOpenPermissionForm.RoundingInt = 70;
            this.btnOpenPermissionForm.Size = new System.Drawing.Size(130, 50);
            this.btnOpenPermissionForm.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnOpenPermissionForm.TabIndex = 3;
            this.btnOpenPermissionForm.Tag = "Cyber";
            this.btnOpenPermissionForm.TextButton = "Edit Permission";
            this.btnOpenPermissionForm.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnOpenPermissionForm.Timer_Effect_1 = 5;
            this.btnOpenPermissionForm.Timer_RGB = 300;
            this.btnOpenPermissionForm.Click += new System.EventHandler(this.btnOpenPermissionForm_Click);
            // 
            // lblSelectRole
            // 
            this.lblSelectRole.AutoSize = true;
            this.lblSelectRole.ForeColor = System.Drawing.Color.White;
            this.lblSelectRole.Location = new System.Drawing.Point(12, 114);
            this.lblSelectRole.Name = "lblSelectRole";
            this.lblSelectRole.Size = new System.Drawing.Size(246, 39);
            this.lblSelectRole.TabIndex = 4;
            this.lblSelectRole.Text = "Select Permission";
            // 
            // roleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.ClientSize = new System.Drawing.Size(784, 584);
            this.Controls.Add(this.lblSelectRole);
            this.Controls.Add(this.btnOpenPermissionForm);
            this.Controls.Add(this.cmbRoles);
            this.Name = "roleForm";
            this.Load += new System.EventHandler(this.roleForm_Load);
            this.Controls.SetChildIndex(this.cmbRoles, 0);
            this.Controls.SetChildIndex(this.btnOpenPermissionForm, 0);
            this.Controls.SetChildIndex(this.lblSelectRole, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRoles;
        private ReaLTaiizor.Controls.CyberButton btnOpenPermissionForm;
        private System.Windows.Forms.Label lblSelectRole;
    }
}