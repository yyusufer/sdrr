namespace sdr
{
    partial class personelForm
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
            this.lstPersonel = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstPersonel
            // 
            this.lstPersonel.FormattingEnabled = true;
            this.lstPersonel.ItemHeight = 39;
            this.lstPersonel.Location = new System.Drawing.Point(24, 59);
            this.lstPersonel.Name = "lstPersonel";
            this.lstPersonel.Size = new System.Drawing.Size(322, 121);
            this.lstPersonel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(106, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Personels";
            // 
            // personelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 400);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPersonel);
            this.Margin = new System.Windows.Forms.Padding(21, 27, 21, 27);
            this.Name = "personelForm";
            this.Text = "personelForm";
            this.Load += new System.EventHandler(this.personelForm_Load);
            this.Controls.SetChildIndex(this.lstPersonel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPersonel;
        private System.Windows.Forms.Label label1;
    }
}