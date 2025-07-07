namespace sdr
{
    partial class DatabaseInformation
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
            this.txtPAdress = new System.Windows.Forms.TextBox();
            this.checkWindows = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkLocalhost = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPAdress
            // 
            this.txtPAdress.Location = new System.Drawing.Point(266, 110);
            this.txtPAdress.Name = "txtPAdress";
            this.txtPAdress.Size = new System.Drawing.Size(201, 40);
            this.txtPAdress.TabIndex = 1;
            // 
            // checkWindows
            // 
            this.checkWindows.AutoSize = true;
            this.checkWindows.Font = new System.Drawing.Font("Inter", 13F);
            this.checkWindows.ForeColor = System.Drawing.Color.White;
            this.checkWindows.Location = new System.Drawing.Point(96, 350);
            this.checkWindows.Name = "checkWindows";
            this.checkWindows.Size = new System.Drawing.Size(277, 30);
            this.checkWindows.TabIndex = 2;
            this.checkWindows.Text = "Use Windows Authentication";
            this.checkWindows.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 15F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(91, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Adress";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(253, 421);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(156, 46);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click_1);
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(266, 162);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(201, 40);
            this.txtDBName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter", 15F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(91, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Database Name";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsername.Location = new System.Drawing.Point(266, 214);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(201, 40);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(266, 266);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(201, 40);
            this.txtPassword.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter", 15F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(91, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Inter", 15F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(91, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password";
            // 
            // checkLocalhost
            // 
            this.checkLocalhost.AutoSize = true;
            this.checkLocalhost.Font = new System.Drawing.Font("Inter", 13F);
            this.checkLocalhost.ForeColor = System.Drawing.Color.White;
            this.checkLocalhost.Location = new System.Drawing.Point(403, 350);
            this.checkLocalhost.Name = "checkLocalhost";
            this.checkLocalhost.Size = new System.Drawing.Size(152, 30);
            this.checkLocalhost.TabIndex = 2;
            this.checkLocalhost.Text = "Use Localhost";
            this.checkLocalhost.UseVisualStyleBackColor = true;
            // 
            // DatabaseInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 538);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.checkLocalhost);
            this.Controls.Add(this.checkWindows);
            this.Controls.Add(this.txtPAdress);
            this.Margin = new System.Windows.Forms.Padding(21, 27, 21, 27);
            this.Name = "DatabaseInformation";
            this.Text = "DatabaseInformation";
            this.Load += new System.EventHandler(this.DatabaseInformation_Load);
            this.Controls.SetChildIndex(this.txtPAdress, 0);
            this.Controls.SetChildIndex(this.checkWindows, 0);
            this.Controls.SetChildIndex(this.checkLocalhost, 0);
            this.Controls.SetChildIndex(this.txtUsername, 0);
            this.Controls.SetChildIndex(this.txtDBName, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnConnect, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPAdress;
        private System.Windows.Forms.CheckBox checkWindows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkLocalhost;
    }
}