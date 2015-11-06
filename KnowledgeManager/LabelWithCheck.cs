using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeManager
{
    public partial class LabelWithCheck : UserControl
    {
        #region PARAMS
        private string labelText;
        private int labelWidth = 74;
        private bool labelChecked = false;
        int width = 0;
        int height = 0;
        #endregion

        #region ATTRIBUTES
        public string LabelText
        {
            get
            {
                if (!String.IsNullOrEmpty(lb.Text))
                    return lb.Text;
                return "输入标签";
            }

            set
            {
                lb.Text = value;
            }
        }
        private int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;

            }
        }

        public int LabelWidth
        {
            get
            {
                return labelWidth;
            }

            set
            {
                labelWidth = value + ck.Width + 13;
                this.Refresh();
            }
        }

        public bool LabelChecked
        {
            get
            {
                return ck.Checked;
            }

            set
            {
                ck.Checked = value;
            }
        }
        #endregion

        #region CONSTRUCTOR
        public LabelWithCheck()
        {
            InitializeComponent();
            width = lb.Width + 6 + ck.Width;
            height = lb.Height + 6;
        }
        #endregion

        #region OVERRIDE
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x = this.Width;
            int y = this.Height;
            Point leftTop = new Point(0, 0);
            Point rightTop = new Point(x - 1, 0);
            Point leftBottom = new Point(0, y - 1);
            Point rightBottom = new Point(x - 1, y - 1);

            g.DrawLine(new Pen(Color.White), leftTop, rightTop);
            g.DrawLine(new Pen(Color.White), leftBottom, rightBottom);
            g.DrawLine(new Pen(Color.White), leftTop, leftBottom);
            g.DrawLine(new Pen(Color.White), rightTop, rightBottom);
            //画上边缘
            for (int i = 0; i < x - 1; i += 3)
            {
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(i, 0, 2, 1));
            }

            //画下边缘
            for (int m = 0; m < x - 1; m += 3)
            {
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(m, y - 1, 2, 1));
            }

            //画左边缘
            for (int i = 0; i < y - 1; i += 3)
            {
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, i, 1, 2));
            }

            //画右边缘
            for (int i = 0; i < y - 1; i += 3)
            {
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(x - 1, i, 1, 2));
            }
            base.OnPaint(e);
        }
        #endregion

        #region EVENT
        public delegate void LabelWithCheckSelectedHandler(object sender, LabelWithCheckEventArgs e);
        public event LabelWithCheckSelectedHandler LabelCheckedEvent;
        private void ck_CheckedChanged(object sender, EventArgs e)//checkBox原型
        {
            if (LabelCheckedEvent != null)
            {
                LabelCheckedEvent(sender, new LabelWithCheckEventArgs(this._Id,this.LabelText));
            }
        }

        #endregion


    }

    public class LabelWithCheckEventArgs :EventArgs
    {
        private string _LabelText;
        private int _Id;
        public LabelWithCheckEventArgs(int id,string labelText)
        {
            this._LabelText = labelText;
            this._Id = id;
        }
        public string LabelText
        {
            get
            {
                return _LabelText;
            }

            set
            {
                _LabelText = value;
            }
        }

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }
    }
}
