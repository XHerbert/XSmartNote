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
    public partial class LabelExSolidBorder : LabelEx
    {
        #region PARAMS
        public event Action<string,string> ShowNote;
        public event Action<Model.PostContents.PostContent> SetSelectedNode;
        #endregion

        #region CONSTRUCTOR      
        public LabelExSolidBorder()
            :base()
        {
            InitializeComponent();
            State = 0;
        }
        #endregion

        #region PROPERTY
        private int State { get; set; }
        #endregion

        #region EVENT
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="e"></param>
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

            switch (State)
            {
                case 0:
                    DrawNormalBorder(g);
                    break;
                case 1:
                    DrawHighLightBorder(g);
                    break;
                default:
                    DrawNormalBorder(g);
                    break;
            }

        }

        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelExSolidBorder_MouseEnter(object sender, EventArgs e)
        {
            State = 1;
            base.HighLightBorderColor = Color.Orange;// ★可配置
            //Console.WriteLine("Enter");
            this.Invalidate();
        }

        /// <summary>
        /// 激活态
        /// </summary>
        /// <param name="g"></param>
        private void DrawHighLightBorder(Graphics g)
        {
            int x = this.Width;
            int y = this.Height;
            //画上边缘
            for (int i = 0; i < x - 1; i++)
            {
                g.FillRectangle(new SolidBrush(base.HighLightBorderColor), new Rectangle(i, 0, 1, 1));
            }

            //画下边缘
            for (int m = 0; m < x - 1; m++)
            {
                g.FillRectangle(new SolidBrush(base.HighLightBorderColor), new Rectangle(m, y - 1, 1, 1));
            }

            //画左边缘
            for (int i = 0; i < y - 1; i++)
            {
                g.FillRectangle(new SolidBrush(base.HighLightBorderColor), new Rectangle(0, i, 1, 1));
            }

            //画右边缘
            for (int i = 0; i < y - 1; i++)
            {
                g.FillRectangle(new SolidBrush(base.HighLightBorderColor), new Rectangle(x - 1, i, 1, 1));
            }
        }

        /// <summary>
        /// 常规态
        /// </summary>
        /// <param name="g"></param>
        private void DrawNormalBorder(Graphics g)
        {
            int x = this.Width;
            int y = this.Height;
            //画上边缘
            for (int i = 0; i < x - 1; i++)
            {
                g.FillRectangle(new SolidBrush(base.NormalBorderColor), new Rectangle(i, 0, 1, 1));
            }

            //画下边缘
            for (int m = 0; m < x - 1; m++)
            {
                g.FillRectangle(new SolidBrush(base.NormalBorderColor), new Rectangle(m, y - 1, 1, 1));
            }

            //画左边缘
            for (int i = 0; i < y - 1; i++)
            {
                g.FillRectangle(new SolidBrush(base.NormalBorderColor), new Rectangle(0, i, 1, 1));
            }

            //画右边缘
            for (int i = 0; i < y - 1; i++)
            {
                g.FillRectangle(new SolidBrush(base.NormalBorderColor), new Rectangle(x - 1, i, 1, 1));
            }
        }

        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelExSolidBorder_MouseLeave(object sender, EventArgs e)
        {
            State = 0;
            base.NormalBorderColor = Color.White;// ★可配置
            //Console.Write("Leave");
            this.Invalidate();
        }
        #endregion

        /// <summary>
        /// 鼠标单击后，把当前Note内容显示在左侧的文本区域，观察者模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelExSolidBorder_Click(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)this.TopLevelControl;
            ShowNote += mf.SetText;//绑定事件
            SetSelectedNode += mf.SetSelectedNode;
            
            if (ShowNote != null)
            {
                Model.PostContents.PostContent post = (Model.PostContents.PostContent)this.Tag;
                SetSelectedNode(post);
                ShowNote(this.Text,post.Title);//此处后续完善
            }
        }
    }
}
