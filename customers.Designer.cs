namespace sdr
{
    partial class customers
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
            this.lstCustomers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstCustomers
            // 
            this.lstCustomers.Font = new System.Drawing.Font("Inter Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstCustomers.FormattingEnabled = true;
            this.lstCustomers.ItemHeight = 35;
            this.lstCustomers.Location = new System.Drawing.Point(51, 35);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(1048, 354);
            this.lstCustomers.TabIndex = 1;
            // 
            // customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 949);
            this.Controls.Add(this.lstCustomers);
            this.Margin = new System.Windows.Forms.Padding(21, 27, 21, 27);
            this.Name = "customers";
            this.Text = "customers";
            this.Load += new System.EventHandler(this.customers_Load);
            this.Controls.SetChildIndex(this.lstCustomers, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCustomers;
    }
}