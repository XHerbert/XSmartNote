using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XSmartNote.Controls
{
    public partial class LabelWithCheckSolidBorder : LabelWithCheck
    {
        public LabelWithCheckSolidBorder()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int x = base.Width;
            int y = base.Height;
            Point leftTop = new Point(0, 0);
            Point rightTop = new Point(x - 1, 0);
            Point leftBottom = new Point(0, y - 1);
            Point rightBottom = new Point(x - 1, y - 1);

            g.DrawLine(new Pen(Color.White), leftTop, rightTop);
            g.DrawLine(new Pen(Color.White), leftBottom, rightBottom);
            g.DrawLine(new Pen(Color.White), leftTop, leftBottom);
            g.DrawLine(new Pen(Color.White), rightTop, rightBottom);
            //画上边缘
            for (int i = 0; i < x - 1; i ++)
            {
                g.FillRectangle(new SolidBrush(Color.Purple), new Rectangle(i, 0, 1, 1));
            }

            //画下边缘
            for (int m = 0; m < x - 1; m ++)
            {
                g.FillRectangle(new SolidBrush(Color.Purple), new Rectangle(m, y - 1, 1, 1));
            }

            //画左边缘
            for (int i = 0; i < y - 1; i ++)
            {
                g.FillRectangle(new SolidBrush(Color.Purple), new Rectangle(0, i, 1, 1));
            }

            //画右边缘
            for (int i = 0; i < y; i ++)
            {
                g.FillRectangle(new SolidBrush(Color.Purple), new Rectangle(x - 1, i, 1, 1));
            }
        }
    }
}
