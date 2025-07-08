using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // <-- Gerekli!
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using static ReaLTaiizor.Util.RoundInt;

namespace sdr
{
    public partial class baseForm : Form
    {
        private int _radius = 20; // Oval köşe yarıçapı

        public baseForm()
        {

            InitializeComponent();
            InitializeBaseSettings();
            controlBox1.Location = new Point(this.ClientSize.Width - controlBox1.Width - 10, 10);
            controlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        protected void InitializeBaseSettings()
        {
            this.BackColor = Color.FromArgb(0, 0, 64);
            this.Font = new Font("Inter", 20F, FontStyle.Regular);
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.None; // Oval kenar için border kaldırılmalı

        }

        private void baseForm_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("sdr_logo.ico");
        }

        protected void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ✅ Form çizilirken kenarları oval yapar
        protected override void OnPaint(PaintEventArgs e)
        {

           
        }

        // ✅ Region'u yuvarlak hale getirir
        private void SetRoundedRegion(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);

            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();
            this.Region = new Region(path);
        }

        // ✅ Boyut değişince yeniden şekillendir
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.Region = null; // Oval kenarlık iptal

                // ControlBox’ı sağ üste sabitle
                if (controlBox1 != null)
                {
                    controlBox1.Location = new Point(this.ClientSize.Width - controlBox1.Width - 10, 10);
                }
            }
            else
            {
                SetRoundedRegion(_radius);

                if (controlBox1 != null)
                {
                    controlBox1.Location = new Point(this.ClientSize.Width - controlBox1.Width - 10, 10);
                }
            }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (this.WindowState == FormWindowState.Normal)
            {
                SetRoundedRegion(_radius);
            }
            else
            {
                this.Region = null;
            }
        }

        private void controlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}