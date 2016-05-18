using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XSmartNote
{
    //新建用户控件，继承需要扩展的控件
    public partial class LabelEx : Label
    {

        #region PARAMS
        private const int WIDTH = 0x0226;//550
        private const int HEIGHT = 0x002F;//47
        #endregion

        #region CONSTRUCTOR
        public LabelEx()
           : base()
        {
            
            this.AutoSize = false;
            //设置内边距
            this.Padding = new Padding(5);
            //this.Font = new Font(,FontStyle.Bold);
            this.Font = new Font(new FontFamily("微软雅黑"), 10.0f);
            InitializeComponent();
            //设置外边距
            this.Margin = new Padding(5);
            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.TextChanged += LabelEx_TextChanged;
        }
        #endregion


        #region Property
        public Color NormalBorderColor { get; set; }
        public Color HighLightBorderColor { get; set; }
        #endregion
        private int State { get; set; }
        #region EVENTS
        private void LabelEx_TextChanged(object sender, EventArgs e)
        {
            //文字变化了，那就改变一下当前的大小
            System.Drawing.Size ps = GetPreferredSize(this.Size);
            //这里构造一个新的Size对象，目的是使用原始的宽度。原因嘛，见上面
            if (ps.Height < 47)
            {
                ps.Height = 47;
            }
            this.Size = new System.Drawing.Size(this.Width, ps.Height);
        }
        #endregion

        #region OVERRIDE
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);//解决了文字不显示的问题
            Graphics g = e.Graphics;
            int x = this.Width;
            int y = this.Height;
            Point leftTop = new Point(0, 0);
            Point rightTop = new Point(x - 1, 0);
            Point leftBottom = new Point(0, y - 1);
            Point rightBottom = new Point(x - 1, y - 1);
            //绘制四个边缘，避免被背景色填充
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
        }

        public override bool AutoSize
        {
            get
            {
                return false;
            }
        }
        #endregion
    }
}
