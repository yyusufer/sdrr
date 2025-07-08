namespace sdr.Services
{
    partial class StokGiris
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
            this.dataGridViewUrunler = new System.Windows.Forms.DataGridView();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.txtUrunAdedi = new System.Windows.Forms.TextBox();
            this.txtUrunOzelligi = new System.Windows.Forms.TextBox();
            this.txtUrunAlisFiyati = new System.Windows.Forms.TextBox();
            this.txtUrunSatisFiyati = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUrunler
            // 
            this.dataGridViewUrunler.AllowUserToOrderColumns = true;
            this.dataGridViewUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUrunler.Location = new System.Drawing.Point(531, 24);
            this.dataGridViewUrunler.Name = "dataGridViewUrunler";
            this.dataGridViewUrunler.Size = new System.Drawing.Size(748, 354);
            this.dataGridViewUrunler.TabIndex = 1;
            this.dataGridViewUrunler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUrunler_CellContentClick);
            this.dataGridViewUrunler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUrunler_CellDoubleClick);
            this.dataGridViewUrunler.SelectionChanged += new System.EventHandler(this.dataGridViewUrunler_SelectionChanged);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.AutoSize = true;
            this.btnUrunEkle.ForeColor = System.Drawing.Color.Black;
            this.btnUrunEkle.Location = new System.Drawing.Point(158, 233);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(116, 31);
            this.btnUrunEkle.TabIndex = 2;
            this.btnUrunEkle.Text = "Ekle / Güncelle";
            this.btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Font = new System.Drawing.Font("Inter", 12F);
            this.txtUrunAdi.Location = new System.Drawing.Point(158, 49);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(200, 27);
            this.txtUrunAdi.TabIndex = 3;
            // 
            // txtUrunAdedi
            // 
            this.txtUrunAdedi.Font = new System.Drawing.Font("Inter", 12F);
            this.txtUrunAdedi.Location = new System.Drawing.Point(158, 82);
            this.txtUrunAdedi.Name = "txtUrunAdedi";
            this.txtUrunAdedi.Size = new System.Drawing.Size(200, 27);
            this.txtUrunAdedi.TabIndex = 3;
            // 
            // txtUrunOzelligi
            // 
            this.txtUrunOzelligi.Font = new System.Drawing.Font("Inter", 12F);
            this.txtUrunOzelligi.Location = new System.Drawing.Point(158, 114);
            this.txtUrunOzelligi.Name = "txtUrunOzelligi";
            this.txtUrunOzelligi.Size = new System.Drawing.Size(200, 27);
            this.txtUrunOzelligi.TabIndex = 3;
            // 
            // txtUrunAlisFiyati
            // 
            this.txtUrunAlisFiyati.Font = new System.Drawing.Font("Inter", 12F);
            this.txtUrunAlisFiyati.Location = new System.Drawing.Point(158, 147);
            this.txtUrunAlisFiyati.Name = "txtUrunAlisFiyati";
            this.txtUrunAlisFiyati.Size = new System.Drawing.Size(200, 27);
            this.txtUrunAlisFiyati.TabIndex = 3;
            // 
            // txtUrunSatisFiyati
            // 
            this.txtUrunSatisFiyati.Font = new System.Drawing.Font("Inter", 12F);
            this.txtUrunSatisFiyati.Location = new System.Drawing.Point(158, 180);
            this.txtUrunSatisFiyati.Name = "txtUrunSatisFiyati";
            this.txtUrunSatisFiyati.Size = new System.Drawing.Size(200, 27);
            this.txtUrunSatisFiyati.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ürün adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stok Miktarı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Özelliği";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Inter", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(26, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Alış fiyatı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Inter", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "Satış Fiyatı";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnUrunSil);
            this.groupBox1.Controls.Add(this.btnUrunEkle);
            this.groupBox1.Controls.Add(this.txtUrunAdi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUrunAdedi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUrunOzelligi);
            this.groupBox1.Controls.Add(this.txtUrunSatisFiyati);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUrunAlisFiyati);
            this.groupBox1.Font = new System.Drawing.Font("Inter", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(23, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 291);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stok Ekle";
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.ForeColor = System.Drawing.Color.Black;
            this.btnUrunSil.Location = new System.Drawing.Point(280, 233);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(85, 31);
            this.btnUrunSil.TabIndex = 2;
            this.btnUrunSil.Text = "Sil";
            this.btnUrunSil.UseVisualStyleBackColor = true;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // txtAra
            // 
            this.txtAra.Font = new System.Drawing.Font("Inter", 12F);
            this.txtAra.Location = new System.Drawing.Point(93, 331);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(335, 27);
            this.txtAra.TabIndex = 9;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Inter", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ürün Ara";
            // 
            // StokGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 427);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewUrunler);
            this.Margin = new System.Windows.Forms.Padding(21, 27, 21, 27);
            this.Name = "StokGiris";
            this.Text = "StokGiris";
            this.Load += new System.EventHandler(this.StokGiris_Load);
            this.Controls.SetChildIndex(this.dataGridViewUrunler, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtAra, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUrunler;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.TextBox txtUrunAdedi;
        private System.Windows.Forms.TextBox txtUrunOzelligi;
        private System.Windows.Forms.TextBox txtUrunAlisFiyati;
        private System.Windows.Forms.TextBox txtUrunSatisFiyati;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Label label5;
    }
}