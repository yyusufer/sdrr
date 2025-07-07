namespace sdr
{
    partial class settingsForm
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
            this.btnDbConfigure = new ReaLTaiizor.Controls.LostButton();
            this.btnCreateUser = new ReaLTaiizor.Controls.LostButton();
            this.pctCreateUser = new sdr.shapes.ovalPictureBox.OvalPictureBox();
            this.pctDBConfigure = new sdr.shapes.ovalPictureBox.OvalPictureBox();
            this.grpCredentials = new System.Windows.Forms.GroupBox();
            this.btnRoles = new ReaLTaiizor.Controls.LostButton();
            this.btnCreateRole = new ReaLTaiizor.Controls.LostButton();
            ((System.ComponentModel.ISupportInitialize)(this.pctCreateUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctDBConfigure)).BeginInit();
            this.grpCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDbConfigure
            // 
            this.btnDbConfigure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDbConfigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDbConfigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDbConfigure.Font = new System.Drawing.Font("Inter Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDbConfigure.ForeColor = System.Drawing.Color.White;
            this.btnDbConfigure.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.btnDbConfigure.Image = null;
            this.btnDbConfigure.Location = new System.Drawing.Point(140, 72);
            this.btnDbConfigure.Name = "btnDbConfigure";
            this.btnDbConfigure.Size = new System.Drawing.Size(228, 84);
            this.btnDbConfigure.TabIndex = 3;
            this.btnDbConfigure.Text = "Database Configure";
            this.btnDbConfigure.Click += new System.EventHandler(this.btnDbConfigure_Click);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCreateUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateUser.Font = new System.Drawing.Font("Inter Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCreateUser.ForeColor = System.Drawing.Color.White;
            this.btnCreateUser.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.btnCreateUser.Image = null;
            this.btnCreateUser.Location = new System.Drawing.Point(140, 153);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(228, 84);
            this.btnCreateUser.TabIndex = 3;
            this.btnCreateUser.Text = "Create User";
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // pctCreateUser
            // 
            this.pctCreateUser.BackColor = System.Drawing.Color.White;
            this.pctCreateUser.Image = global::sdr.Properties.Resources.icons8_add_user_26;
            this.pctCreateUser.Location = new System.Drawing.Point(374, 177);
            this.pctCreateUser.Name = "pctCreateUser";
            this.pctCreateUser.Size = new System.Drawing.Size(40, 40);
            this.pctCreateUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctCreateUser.TabIndex = 6;
            this.pctCreateUser.TabStop = false;
            // 
            // pctDBConfigure
            // 
            this.pctDBConfigure.BackColor = System.Drawing.Color.White;
            this.pctDBConfigure.Image = global::sdr.Properties.Resources.icons8_server_26;
            this.pctDBConfigure.Location = new System.Drawing.Point(374, 96);
            this.pctDBConfigure.Name = "pctDBConfigure";
            this.pctDBConfigure.Size = new System.Drawing.Size(40, 40);
            this.pctDBConfigure.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctDBConfigure.TabIndex = 7;
            this.pctDBConfigure.TabStop = false;
            // 
            // grpCredentials
            // 
            this.grpCredentials.Controls.Add(this.btnCreateRole);
            this.grpCredentials.Controls.Add(this.btnRoles);
            this.grpCredentials.Controls.Add(this.btnDbConfigure);
            this.grpCredentials.Controls.Add(this.pctDBConfigure);
            this.grpCredentials.Controls.Add(this.btnCreateUser);
            this.grpCredentials.Controls.Add(this.pctCreateUser);
            this.grpCredentials.Location = new System.Drawing.Point(12, 47);
            this.grpCredentials.Name = "grpCredentials";
            this.grpCredentials.Size = new System.Drawing.Size(776, 474);
            this.grpCredentials.TabIndex = 8;
            this.grpCredentials.TabStop = false;
            this.grpCredentials.Text = " ";
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRoles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoles.Font = new System.Drawing.Font("Inter Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRoles.ForeColor = System.Drawing.Color.White;
            this.btnRoles.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.btnRoles.Image = null;
            this.btnRoles.Location = new System.Drawing.Point(140, 233);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(228, 84);
            this.btnRoles.TabIndex = 8;
            this.btnRoles.Text = "Roles - Permissions";
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnCreateRole
            // 
            this.btnCreateRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCreateRole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateRole.Font = new System.Drawing.Font("Inter Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCreateRole.ForeColor = System.Drawing.Color.White;
            this.btnCreateRole.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.btnCreateRole.Image = null;
            this.btnCreateRole.Location = new System.Drawing.Point(140, 323);
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.Size = new System.Drawing.Size(228, 84);
            this.btnCreateRole.TabIndex = 9;
            this.btnCreateRole.Text = "Create New Role";
            this.btnCreateRole.Click += new System.EventHandler(this.btnCreateRole_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(798, 589);
            this.Controls.Add(this.grpCredentials);
            this.Margin = new System.Windows.Forms.Padding(21, 27, 21, 27);
            this.Name = "settingsForm";
            this.Text = "settingsForm";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.Controls.SetChildIndex(this.grpCredentials, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pctCreateUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctDBConfigure)).EndInit();
            this.grpCredentials.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.LostButton btnDbConfigure;
        private ReaLTaiizor.Controls.LostButton btnCreateUser;
        private shapes.ovalPictureBox.OvalPictureBox pctCreateUser;
        private shapes.ovalPictureBox.OvalPictureBox pctDBConfigure;
        private System.Windows.Forms.GroupBox grpCredentials;
        private ReaLTaiizor.Controls.LostButton btnRoles;
        private ReaLTaiizor.Controls.LostButton btnCreateRole;
    }
}