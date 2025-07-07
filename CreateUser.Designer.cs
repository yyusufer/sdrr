namespace sdr.Services
{
    partial class CreateUser
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
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new ReaLTaiizor.Controls.TextBoxEdit();
            this.txtPass = new ReaLTaiizor.Controls.TextBoxEdit();
            this.btnLogin = new ReaLTaiizor.Controls.CyberButton();
            this.txtPassAgain = new ReaLTaiizor.Controls.TextBoxEdit();
            this.lblSelectRole = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.txtFullName = new ReaLTaiizor.Controls.TextBoxEdit();
            this.txtEmail = new ReaLTaiizor.Controls.TextBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Inter", 13F);
            this.lblPass.ForeColor = System.Drawing.Color.White;
            this.lblPass.Location = new System.Drawing.Point(79, 205);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(97, 26);
            this.lblPass.TabIndex = 0;
            this.lblPass.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Inter", 13F);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(79, 155);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(99, 26);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.Font = new System.Drawing.Font("Inter", 13F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.txtUsername.Image = null;
            this.txtUsername.Location = new System.Drawing.Point(247, 150);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = false;
            this.txtUsername.Size = new System.Drawing.Size(218, 44);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.Transparent;
            this.txtPass.Font = new System.Drawing.Font("Inter", 10F);
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.txtPass.Image = null;
            this.txtPass.Location = new System.Drawing.Point(247, 196);
            this.txtPass.MaxLength = 32767;
            this.txtPass.Multiline = false;
            this.txtPass.Name = "txtPass";
            this.txtPass.ReadOnly = false;
            this.txtPass.Size = new System.Drawing.Size(218, 40);
            this.txtPass.TabIndex = 4;
            this.txtPass.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Alpha = 20;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Background = true;
            this.btnLogin.Background_WidthPen = 4F;
            this.btnLogin.BackgroundPen = true;
            this.btnLogin.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLogin.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLogin.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnLogin.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLogin.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLogin.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLogin.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnLogin.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnLogin.Effect_1 = true;
            this.btnLogin.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLogin.Effect_1_Transparency = 25;
            this.btnLogin.Effect_2 = true;
            this.btnLogin.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnLogin.Effect_2_Transparency = 20;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 11F);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnLogin.Lighting = false;
            this.btnLogin.LinearGradient_Background = false;
            this.btnLogin.LinearGradientPen = false;
            this.btnLogin.Location = new System.Drawing.Point(219, 369);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PenWidth = 15;
            this.btnLogin.Rounding = true;
            this.btnLogin.RoundingInt = 70;
            this.btnLogin.Size = new System.Drawing.Size(130, 49);
            this.btnLogin.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Tag = "Cyber";
            this.btnLogin.TextButton = "Create User";
            this.btnLogin.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnLogin.Timer_Effect_1 = 5;
            this.btnLogin.Timer_RGB = 300;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassAgain
            // 
            this.txtPassAgain.BackColor = System.Drawing.Color.Transparent;
            this.txtPassAgain.Font = new System.Drawing.Font("Inter", 10F);
            this.txtPassAgain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.txtPassAgain.Image = null;
            this.txtPassAgain.Location = new System.Drawing.Point(247, 238);
            this.txtPassAgain.MaxLength = 32767;
            this.txtPassAgain.Multiline = false;
            this.txtPassAgain.Name = "txtPassAgain";
            this.txtPassAgain.ReadOnly = false;
            this.txtPassAgain.Size = new System.Drawing.Size(218, 40);
            this.txtPassAgain.TabIndex = 5;
            this.txtPassAgain.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassAgain.UseSystemPasswordChar = true;
            this.txtPassAgain.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // lblSelectRole
            // 
            this.lblSelectRole.AutoEllipsis = true;
            this.lblSelectRole.AutoSize = true;
            this.lblSelectRole.Font = new System.Drawing.Font("Inter", 13F);
            this.lblSelectRole.ForeColor = System.Drawing.Color.White;
            this.lblSelectRole.Location = new System.Drawing.Point(79, 314);
            this.lblSelectRole.Name = "lblSelectRole";
            this.lblSelectRole.Size = new System.Drawing.Size(106, 26);
            this.lblSelectRole.TabIndex = 0;
            this.lblSelectRole.Text = "Select Role";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRoles);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.txtPassAgain);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblSelectRole);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblPass);
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(186, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 453);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // cmbRoles
            // 
            this.cmbRoles.Font = new System.Drawing.Font("Inter", 12F);
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(247, 314);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(218, 31);
            this.cmbRoles.TabIndex = 6;
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.Transparent;
            this.txtFullName.Font = new System.Drawing.Font("Inter", 13F);
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.txtFullName.Image = null;
            this.txtFullName.Location = new System.Drawing.Point(247, 58);
            this.txtFullName.MaxLength = 32767;
            this.txtFullName.Multiline = false;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = false;
            this.txtFullName.Size = new System.Drawing.Size(218, 44);
            this.txtFullName.TabIndex = 1;
            this.txtFullName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFullName.UseSystemPasswordChar = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.Font = new System.Drawing.Font("Inter", 13F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.txtEmail.Image = null;
            this.txtEmail.Location = new System.Drawing.Point(247, 104);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = false;
            this.txtEmail.Size = new System.Drawing.Size(218, 44);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter", 13F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(79, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Full Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter", 13F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(79, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "E-Mail";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(79, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Again Password";
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(926, 621);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(21, 27, 21, 27);
            this.Name = "CreateUser";
            this.Text = "CreateUser";
            this.Load += new System.EventHandler(this.CreateUser_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUsername;
        private ReaLTaiizor.Controls.TextBoxEdit txtUsername;
        private ReaLTaiizor.Controls.TextBoxEdit txtPass;
        private ReaLTaiizor.Controls.CyberButton btnLogin;
        private ReaLTaiizor.Controls.TextBoxEdit txtPassAgain;
        private System.Windows.Forms.Label lblSelectRole;
        private System.Windows.Forms.GroupBox groupBox1;
        private ReaLTaiizor.Controls.TextBoxEdit txtFullName;
        private ReaLTaiizor.Controls.TextBoxEdit txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Label label1;
    }
}