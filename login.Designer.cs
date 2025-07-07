namespace sdr
{
    partial class login
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
            this.checkRemember = new System.Windows.Forms.CheckBox();
            this.btnLogin = new ReaLTaiizor.Controls.CyberButton();
            this.txtUsername = new ReaLTaiizor.Controls.TextBoxEdit();
            this.txtPass = new ReaLTaiizor.Controls.TextBoxEdit();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCredentials = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.grpCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkRemember
            // 
            this.checkRemember.AutoSize = true;
            this.checkRemember.Font = new System.Drawing.Font("Inter", 10F);
            this.checkRemember.ForeColor = System.Drawing.Color.White;
            this.checkRemember.Location = new System.Drawing.Point(98, 282);
            this.checkRemember.Name = "checkRemember";
            this.checkRemember.Size = new System.Drawing.Size(125, 25);
            this.checkRemember.TabIndex = 3;
            this.checkRemember.Text = "Remember Me";
            this.checkRemember.UseVisualStyleBackColor = true;
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
            this.btnLogin.Location = new System.Drawing.Point(271, 310);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PenWidth = 15;
            this.btnLogin.Rounding = true;
            this.btnLogin.RoundingInt = 70;
            this.btnLogin.Size = new System.Drawing.Size(130, 49);
            this.btnLogin.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Tag = "Cyber";
            this.btnLogin.TextButton = "Login";
            this.btnLogin.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnLogin.Timer_Effect_1 = 5;
            this.btnLogin.Timer_RGB = 300;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.txtUsername.Image = null;
            this.txtUsername.Location = new System.Drawing.Point(228, 173);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = false;
            this.txtUsername.Size = new System.Drawing.Size(218, 40);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.Transparent;
            this.txtPass.Font = new System.Drawing.Font("Inter", 10F);
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.txtPass.Image = null;
            this.txtPass.Location = new System.Drawing.Point(228, 221);
            this.txtPass.MaxLength = 32767;
            this.txtPass.Multiline = false;
            this.txtPass.Name = "txtPass";
            this.txtPass.ReadOnly = false;
            this.txtPass.Size = new System.Drawing.Size(218, 40);
            this.txtPass.TabIndex = 2;
            this.txtPass.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Inter", 13F);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(93, 180);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(99, 26);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Inter", 13F);
            this.lblPass.ForeColor = System.Drawing.Color.White;
            this.lblPass.Location = new System.Drawing.Point(93, 230);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(97, 26);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(165, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "SDR Stock Tracking System";
            // 
            // grpCredentials
            // 
            this.grpCredentials.Controls.Add(this.linkLabel1);
            this.grpCredentials.Controls.Add(this.label1);
            this.grpCredentials.Controls.Add(this.lblPass);
            this.grpCredentials.Controls.Add(this.checkRemember);
            this.grpCredentials.Controls.Add(this.btnLogin);
            this.grpCredentials.Controls.Add(this.lblUsername);
            this.grpCredentials.Controls.Add(this.txtUsername);
            this.grpCredentials.Controls.Add(this.txtPass);
            this.grpCredentials.Location = new System.Drawing.Point(263, 109);
            this.grpCredentials.Name = "grpCredentials";
            this.grpCredentials.Size = new System.Drawing.Size(596, 417);
            this.grpCredentials.TabIndex = 1;
            this.grpCredentials.TabStop = false;
            this.grpCredentials.Text = " ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Inter", 10F);
            this.linkLabel1.Location = new System.Drawing.Point(94, 338);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(120, 21);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Database Config";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1086, 634);
            this.Controls.Add(this.grpCredentials);
            this.Margin = new System.Windows.Forms.Padding(21, 27, 21, 27);
            this.Name = "login";
            this.Text = "login";
            this.Load += new System.EventHandler(this.login_Load);
            this.Controls.SetChildIndex(this.grpCredentials, 0);
            this.grpCredentials.ResumeLayout(false);
            this.grpCredentials.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkRemember;
        private ReaLTaiizor.Controls.CyberButton btnLogin;
        private ReaLTaiizor.Controls.TextBoxEdit txtUsername;
        private ReaLTaiizor.Controls.TextBoxEdit txtPass;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpCredentials;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}