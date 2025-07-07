namespace sdr
{
    partial class FirmaAyarlariForm
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
            this.txtFirmaAdi = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtVergiDairesi = new System.Windows.Forms.TextBox();
            this.txtVergiNo = new System.Windows.Forms.TextBox();
            this.dgvBankaHesaplari = new System.Windows.Forms.DataGridView();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnBankaSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblHesapSahibi = new System.Windows.Forms.Label();
            this.lblIBAN = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtHesapSahibi = new System.Windows.Forms.TextBox();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.txtBankaAdi = new System.Windows.Forms.TextBox();
            this.btnBankaBilgisiEkle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankaHesaplari)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFirmaAdi
            // 
            this.txtFirmaAdi.Location = new System.Drawing.Point(218, 35);
            this.txtFirmaAdi.Name = "txtFirmaAdi";
            this.txtFirmaAdi.Size = new System.Drawing.Size(345, 40);
            this.txtFirmaAdi.TabIndex = 1;
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(218, 81);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(345, 40);
            this.txtAdres.TabIndex = 2;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(218, 127);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(345, 40);
            this.txtTelefon.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(218, 173);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(345, 40);
            this.txtEmail.TabIndex = 4;
            // 
            // txtVergiDairesi
            // 
            this.txtVergiDairesi.Location = new System.Drawing.Point(218, 219);
            this.txtVergiDairesi.Name = "txtVergiDairesi";
            this.txtVergiDairesi.Size = new System.Drawing.Size(345, 40);
            this.txtVergiDairesi.TabIndex = 5;
            // 
            // txtVergiNo
            // 
            this.txtVergiNo.Location = new System.Drawing.Point(218, 265);
            this.txtVergiNo.Name = "txtVergiNo";
            this.txtVergiNo.Size = new System.Drawing.Size(345, 40);
            this.txtVergiNo.TabIndex = 6;
            // 
            // dgvBankaHesaplari
            // 
            this.dgvBankaHesaplari.Location = new System.Drawing.Point(651, 17);
            this.dgvBankaHesaplari.Name = "dgvBankaHesaplari";
            this.dgvBankaHesaplari.Size = new System.Drawing.Size(686, 360);
            this.dgvBankaHesaplari.TabIndex = 10;
            this.dgvBankaHesaplari.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBankaHesaplari_CellContentClick_1);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Inter", 12F);
            this.btnKaydet.Location = new System.Drawing.Point(497, 602);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(120, 32);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click_1);
            // 
            // btnBankaSil
            // 
            this.btnBankaSil.AutoSize = true;
            this.btnBankaSil.Font = new System.Drawing.Font("Inter", 12F);
            this.btnBankaSil.Location = new System.Drawing.Point(344, 602);
            this.btnBankaSil.Name = "btnBankaSil";
            this.btnBankaSil.Size = new System.Drawing.Size(147, 33);
            this.btnBankaSil.TabIndex = 8;
            this.btnBankaSil.Text = "Seçili Bankayı Sil";
            this.btnBankaSil.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Firma Adı";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Firma Adresi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Firma Telefonu";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Inter", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Firma E-Mail";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Inter", 12F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Vergi Dairesi";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Inter", 12F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Vergi No";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHesapSahibi
            // 
            this.lblHesapSahibi.AutoSize = true;
            this.lblHesapSahibi.Font = new System.Drawing.Font("Inter", 12F);
            this.lblHesapSahibi.ForeColor = System.Drawing.Color.White;
            this.lblHesapSahibi.Location = new System.Drawing.Point(12, 543);
            this.lblHesapSahibi.Name = "lblHesapSahibi";
            this.lblHesapSahibi.Size = new System.Drawing.Size(109, 23);
            this.lblHesapSahibi.TabIndex = 14;
            this.lblHesapSahibi.Text = "Hesap Sahibi";
            this.lblHesapSahibi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIBAN
            // 
            this.lblIBAN.AutoSize = true;
            this.lblIBAN.Font = new System.Drawing.Font("Inter", 12F);
            this.lblIBAN.ForeColor = System.Drawing.Color.White;
            this.lblIBAN.Location = new System.Drawing.Point(12, 495);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(47, 23);
            this.lblIBAN.TabIndex = 15;
            this.lblIBAN.Text = "IBAN";
            this.lblIBAN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Inter", 12F);
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(12, 451);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(86, 23);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "Banka Adı";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHesapSahibi
            // 
            this.txtHesapSahibi.Location = new System.Drawing.Point(218, 528);
            this.txtHesapSahibi.Name = "txtHesapSahibi";
            this.txtHesapSahibi.Size = new System.Drawing.Size(399, 40);
            this.txtHesapSahibi.TabIndex = 13;
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(218, 482);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Size = new System.Drawing.Size(399, 40);
            this.txtIBAN.TabIndex = 12;
            // 
            // txtBankaAdi
            // 
            this.txtBankaAdi.Location = new System.Drawing.Point(218, 436);
            this.txtBankaAdi.Name = "txtBankaAdi";
            this.txtBankaAdi.Size = new System.Drawing.Size(399, 40);
            this.txtBankaAdi.TabIndex = 11;
            // 
            // btnBankaBilgisiEkle
            // 
            this.btnBankaBilgisiEkle.Font = new System.Drawing.Font("Inter", 12F);
            this.btnBankaBilgisiEkle.Location = new System.Drawing.Point(218, 603);
            this.btnBankaBilgisiEkle.Name = "btnBankaBilgisiEkle";
            this.btnBankaBilgisiEkle.Size = new System.Drawing.Size(120, 32);
            this.btnBankaBilgisiEkle.TabIndex = 8;
            this.btnBankaBilgisiEkle.Text = "Banka Ekle";
            this.btnBankaBilgisiEkle.UseVisualStyleBackColor = true;
            this.btnBankaBilgisiEkle.Click += new System.EventHandler(this.btnBankaBilgisiEkle_Click_1);
            // 
            // FirmaAyarlariForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 760);
            this.Controls.Add(this.lblHesapSahibi);
            this.Controls.Add(this.lblIBAN);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtHesapSahibi);
            this.Controls.Add(this.txtIBAN);
            this.Controls.Add(this.txtBankaAdi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBankaSil);
            this.Controls.Add(this.btnBankaBilgisiEkle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dgvBankaHesaplari);
            this.Controls.Add(this.txtVergiNo);
            this.Controls.Add(this.txtVergiDairesi);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtFirmaAdi);
            this.Margin = new System.Windows.Forms.Padding(21, 27, 21, 27);
            this.Name = "FirmaAyarlariForm";
            this.Text = "FirmaAyarlariForm";
            this.Load += new System.EventHandler(this.FirmaAyarlariForm_Load);
            this.Controls.SetChildIndex(this.txtFirmaAdi, 0);
            this.Controls.SetChildIndex(this.txtAdres, 0);
            this.Controls.SetChildIndex(this.txtTelefon, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.txtVergiDairesi, 0);
            this.Controls.SetChildIndex(this.txtVergiNo, 0);
            this.Controls.SetChildIndex(this.dgvBankaHesaplari, 0);
            this.Controls.SetChildIndex(this.btnKaydet, 0);
            this.Controls.SetChildIndex(this.btnBankaBilgisiEkle, 0);
            this.Controls.SetChildIndex(this.btnBankaSil, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtBankaAdi, 0);
            this.Controls.SetChildIndex(this.txtIBAN, 0);
            this.Controls.SetChildIndex(this.txtHesapSahibi, 0);
            this.Controls.SetChildIndex(this.lblEmail, 0);
            this.Controls.SetChildIndex(this.lblIBAN, 0);
            this.Controls.SetChildIndex(this.lblHesapSahibi, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankaHesaplari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirmaAdi;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtVergiDairesi;
        private System.Windows.Forms.TextBox txtVergiNo;
        private System.Windows.Forms.DataGridView dgvBankaHesaplari;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnBankaSil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHesapSahibi;
        private System.Windows.Forms.Label lblIBAN;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtHesapSahibi;
        private System.Windows.Forms.TextBox txtIBAN;
        private System.Windows.Forms.TextBox txtBankaAdi;
        private System.Windows.Forms.Button btnBankaBilgisiEkle;
    }
}