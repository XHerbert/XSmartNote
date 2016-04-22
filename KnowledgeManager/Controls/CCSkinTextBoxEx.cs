using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinControl;

namespace KnowledgeManager.Controls
{
    public partial class CCSkinTextBoxEx : SkinTextBox
    {
        public CCSkinTextBoxEx()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(new Point(1, 1), new Size(185, 28));
            g.FillRectangle(new SolidBrush(Color.Blue), rec);
        }
    }
}
