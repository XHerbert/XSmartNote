using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace KnowledgeManager
{
    public partial class RectangleLabel : UserControl
    {
        public RectangleLabel()
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer |
            //ControlStyles.ResizeRedraw |
            //ControlStyles.UserPaint |
            //ControlStyles.DoubleBuffer |
            //ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.Selectable, false);


            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            InitializeComponent();
        }

        #region FIELDS

        private Color _BorderColor=Color.Purple;
        private float _BorderWidth=1.5f;
        private Color _InnerColor=Color.Transparent;

        #endregion

        #region PROPERTIES
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }

            set
            {
                _BorderColor = value;
            }
        }

        public string ControlText
        {
            get
            {
                return this.lblText.Text;
            }

            set
            {
                this.lblText.Text = value;
            }
        }

        public Color InnerColor
        {
            get
            {
                return _InnerColor;
            }

            set
            {
                _InnerColor = value;
            }
        }

        public float BorderWidth
        {
            get
            {
                return _BorderWidth;
            }

            set
            {
                _BorderWidth = value;
            }
        }



        #endregion

        //private void UserControl1_Paint(object sender, PaintEventArgs e)
        //{
            
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(20, 20));
            Rectangle rect2 = new Rectangle(new Point(20, 10), new Size(40, 20));
            Rectangle rect3 = new Rectangle(new Point(60, 0), new Size(20, 20));
            Point[] ps = { new Point(11, 0), new Point(69, 0) };
            Point[] pq = { new Point(11, 20), new Point(69, 20) };
            float start = 90f;
            float end = 180f;
            float start2 = 270f;
            float end2 = 180f;
            Pen p = new Pen(this.BorderColor, this.BorderWidth);
            SolidBrush sl = new SolidBrush(this.InnerColor);
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawArc(p, rect, start, end);
                g.DrawArc(p, rect3, start2, end2);
                g.DrawLine(p, ps[0], ps[1]);
                g.DrawLine(p, pq[0], pq[1]);
            }
        }

        /*
        private void Type(Control sender, int p_1, double p_2)
        {
            GraphicsPath oPath = new GraphicsPath();
            oPath.AddClosedCurve(
                new Point[] {
            new Point(0, sender.Height / p_1),
            new Point(sender.Width / p_1, 0),
            new Point(sender.Width - sender.Width / p_1, 0),
            new Point(sender.Width, sender.Height / p_1),
            new Point(sender.Width, sender.Height - sender.Height / p_1),
            new Point(sender.Width - sender.Width / p_1, sender.Height),
            new Point(sender.Width / p_1, sender.Height),
            new Point(0, sender.Height - sender.Height / p_1) },

                (float)p_2);

            sender.Region = new Region(oPath);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            //   左上角     
            path.AddArc(arcRect, 180, 90);
            //   右上角     
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            //   右下角     
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            //   左下角     
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }


        public void SetWindowRegion(int width, int height)
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, width, height);
            FormPath = GetRoundedRectPath(rect, 8);
            this.Region = new Region(FormPath);
        }
         * */
    }
}
