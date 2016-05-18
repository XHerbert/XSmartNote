using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XSmartNote.ThemeManager;

namespace XSmartNote.Controls
{
    public partial class TextBoxEx : UserControl
    {
        public TextBoxEx()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer |
               ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, true);
            this.BorderStyle = BorderStyle.None;
            this.textBox.Width = this.Width - 6;
            this.textBox.Height = this.Height - 6;
            this.textBox.Location = new Point(3, 3);
        }
        private static TextBoxExState State = TextBoxExState.Normal;
        private Color _borderColor;
        private Color _boxBackColor=Color.MistyRose;
        private Color _waterColor;
        private string _waterText;
        private string _controlText;

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }

            set
            {
                _borderColor = value;
            }
        }

        public Color BoxBackColor
        {
            get
            {
                return this.textBox.BackColor;
            }

            set
            {
                this.textBox.BackColor = value;
            }
        }

        public string WaterText
        {
            get
            {
                return _waterText;
            }

            set
            {
                _waterText = value;
            }
        }

        public Color WaterColor
        {
            get
            {
                return _waterColor;
            }

            set
            {
                _waterColor = value;
                this.textBox.ForeColor = _waterColor;
            }
        }

        public string ControlText
        {
            get
            {
                return this.textBox.Text;
            }

            set
            {
                //this.textBox.Text = _controlText;
                this.textBox.Text = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            {
                switch (State)
                {
                    case TextBoxExState.Normal:
                        NormalState(g);
                        break;
                    case TextBoxExState.HighLight:
                        HighLightState(g);
                        break;
                    default:
                        break;
                }
            }
            base.OnPaint(e);
        }

        private void HighLightState(Graphics g)
        {
            Color highLightOut = ColorTranslator.FromHtml(ThemeEnums.ColorTable.KM_C_A2C3E7.KM_ColorTranslator());
            Color highLightIn = ColorTranslator.FromHtml(ThemeEnums.ColorTable.KM_C_2F85B8.KM_ColorTranslator());
            Color corner = ColorTranslator.FromHtml(ThemeEnums.ColorTable.KM_C_EADDE2.KM_ColorTranslator());
            //g.FillRectangle(new SolidBrush(Color.Pink), new Rectangle(new Point(2, 2), new Size(100, 20)));
            g.DrawLine(new Pen(corner),new Point(0,0),new Point(0,0));
            g.DrawLine(new Pen(highLightOut),new Point(1,1),new Point(1,1));

            //画上边缘
            g.DrawLine(new Pen(highLightOut), new Point(1, 0), new Point(this.Width-1, 0));
            g.DrawLine(new Pen(highLightIn), new Point(1, 1), new Point(this.Width-2, 1));
            //画下边缘
            g.DrawLine(new Pen(highLightOut), new Point(1, this.Height-1), new Point(this.Width - 1, this.Height - 1));
            g.DrawLine(new Pen(highLightIn), new Point(2, this.Height-2), new Point(this.Width - 2, this.Height - 2));
            //画左边缘
            g.DrawLine(new Pen(highLightOut), new Point(0, 1), new Point(0, this.Height - 1));
            g.DrawLine(new Pen(highLightIn), new Point(1, 2), new Point(1, this.Height - 2));
            //画右边缘
            g.DrawLine(new Pen(highLightOut), new Point(this.Width-1, 1), new Point(this.Width - 1, this.Height - 1));
            g.DrawLine(new Pen(highLightIn), new Point(this.Width-2, 2), new Point(this.Width-2, this.Height - 2));
        }   

        private void NormalState(Graphics g)
        {
            Color normalLine = ColorTranslator.FromHtml(ThemeEnums.ColorTable.KM_C_9AB6C7.KM_ColorTranslator());
            Color normalCorner = ColorTranslator.FromHtml(ThemeEnums.ColorTable.KM_C_E6EDF1.KM_ColorTranslator());
            g.DrawLine(new Pen(normalLine), new Point(2, 1), new Point(this.Width - 4, 1));
            g.DrawLine(new Pen(normalLine), new Point(2, this.Height-2), new Point(this.Width - 4, this.Height - 2));
            g.DrawLine(new Pen(normalCorner), new Point(1, 1), new Point(1, 1));

            g.DrawLine(new Pen(normalLine), new Point(1, 2), new Point(1, this.Height - 2));
            g.DrawLine(new Pen(normalLine), new Point(this.Width - 2, 2), new Point(this.Width - 2, this.Height - 2));
        }

        public enum TextBoxExState
        {
            Normal,
            HighLight
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = TextBoxExState.HighLight;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = TextBoxExState.Normal;
            this.Invalidate();
        }

        private void textBox_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseLeave(e);
            State = TextBoxExState.HighLight;
            this.Invalidate();
        }

        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            base.OnMouseLeave(e);
            State = TextBoxExState.Normal;
            this.Invalidate();
        }

        private void TextBoxEx_SizeChanged(object sender, EventArgs e)
        {
            this.textBox.Width = this.Width - 6;
            this.textBox.Height = this.Height - 6;
            this.textBox.Location = new Point(3, 3);
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            if ("请输入标题".Equals(this.textBox.Text)|| "请输入内容...".Equals(this.textBox.Text))
            {
                this.textBox.Text = string.Empty;
            }

        }

        private void textBox_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.textBox.Text))
            {
                this.textBox.Text = this.WaterText;
            }
        }

        private void TextBoxEx_Load(object sender, EventArgs e)
        {
            this.textBox.Text = WaterText;
        }
    }

    public static class ColorExtension
    {
        public static string KM_ColorTranslator(this ThemeEnums.ColorTable color)
        {
            string targetColor=string.Empty;
            if (!string.IsNullOrEmpty(color.ToString()))
            {
                string[] targetColors = color.ToString().Split('_');
                targetColor = targetColors[2];
                targetColor = targetColor.Insert(0, "#");
            }
            return targetColor;
        }
    }
}
