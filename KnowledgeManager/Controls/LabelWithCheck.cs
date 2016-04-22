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
        private Color labelWithCheckColor;
        private Color DefaultColor = Color.Maroon;
        int width = 0;
        int height = 0;
        #endregion

        #region ATTRIBUTES
        [Category("XHB.Controls")]
        [Browsable(true)]
        [Description("设置或获取LabelText文本")]
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
        [Category("XHB.Controls")]
        [Browsable(true)]
        [Description("设置或获取LabelText宽度")]
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
        [Category("XHB.Controls")]
        [Browsable(true)]
        [Description("指示LabelText是否被选中")]
        [DefaultValue(false)]
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
        
        public Color LabelWithCheckColor
        {
            get
            {
                return this.labelWithCheckColor;
            }
            set
            {
                this.labelWithCheckColor = value;
            }
        }
        #endregion

        #region CONSTRUCTOR
        public LabelWithCheck()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            InitializeComponent();
            LabelWithCheckColor = DefaultColor;
            width = lb.Width + 6 + ck.Width;
            height = lb.Height + 6;
        }
        #endregion

        #region OVERRIDE
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
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
            for (int i = 0; i < x - 1; i ++)
            {
                g.FillRectangle(new SolidBrush(LabelWithCheckColor), new Rectangle(i, 0, 1, 1));
            }

            //画下边缘
            for (int i = 0; i < x ; i ++)
            {
                g.FillRectangle(new SolidBrush(LabelWithCheckColor), new Rectangle(i, y - 1, 1, 1));
            }

            //画左边缘
            for (int i = 0; i < y - 1; i ++)
            {
                g.FillRectangle(new SolidBrush(LabelWithCheckColor), new Rectangle(0, i, 1, 1));
            }

            //画右边缘
            for (int i = 0; i < y - 1; i ++)
            {
                g.FillRectangle(new SolidBrush(LabelWithCheckColor), new Rectangle(x - 1, i, 1, 1));
            }
        }
        #endregion

        #region EVENT
        public delegate void LabelWithCheckSelectedHandler(object sender, LabelWithCheckEventArgs e);
        public event LabelWithCheckSelectedHandler LabelCheckedEvent;
        /// <summary>
        /// CheckBox变化时触发LabelCheckedEvent事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ck_CheckedChanged(object sender, EventArgs e)
        {
            if (LabelCheckedEvent != null)
            {
                LabelCheckedEvent(sender, new LabelWithCheckEventArgs(this._Id,this.LabelText));
            }
        }
        /// <summary>
        /// 单击Label也可以触发CheckBox的选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Click(object sender, EventArgs e)
        {
            ck.Checked = ck.Checked ? false : true;
        }


        #endregion

        private void LabelWithCheck_MouseEnter(object sender, EventArgs e)
        {
            HighLightControl();
        }

        private void LabelWithCheck_MouseLeave(object sender, EventArgs e)
        {
            NormalControl();
        }

        private void lb_MouseEnter(object sender, EventArgs e)
        {
            HighLightControl();
        }

        private void lb_MouseLeave(object sender, EventArgs e)
        {
            NormalControl();
        }

        private void ck_MouseEnter(object sender, EventArgs e)
        {
            HighLightControl();
        }


        private void HighLightControl()
        {
            this.LabelWithCheckColor = Color.Orange;
            this.Invalidate();
        }

        private void ck_MouseLeave(object sender, EventArgs e)
        {
            NormalControl();
        }

        private void NormalControl()
        {
            this.LabelWithCheckColor = Color.Maroon;
            this.Invalidate();
        }

       
    }
    /// <summary>
    /// 事件参数包含的信息
    /// </summary>
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
