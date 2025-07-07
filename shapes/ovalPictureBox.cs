using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdr.shapes
{
    internal class ovalPictureBox
    {

public class OvalPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                this.Region = new Region(gp);
            }
            base.OnPaint(pe);
        }
    }
}
}
