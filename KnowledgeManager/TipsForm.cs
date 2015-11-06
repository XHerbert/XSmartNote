using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeManager
{
    public partial class TipsForm : Form
    {
        //设置用于指示淡入淡出变化方向的变量
        private bool bIsFade = true;
        public TipsForm()
        {
            InitializeComponent();
        }

        private void timerSlide_Tick(object sender, EventArgs e)
        {
            if (bIsFade)
            {
                //由不透明变为透明
                this.Opacity += 0.06;
                //当完全不透明时再由不透明变为透明
                if (this.Opacity >= 1)
                {
                    bIsFade = false;
                }
            }
            else
            {
                //由透明变为不透明
                this.Opacity -= 0.06;
                //当完全透明时停止计时器，并退出欢迎界面
                if (this.Opacity <= 0)
                {
                    this.timerSlide.Stop();
                    this.Close();
                }
            }
        }

        public void Show(string message)
        {
            
            this.Opacity = 0;
            this.Show();
            //设置timer1的时间间隔
            this.timerSlide.Interval = 50;
            //使记时器timer开始工作
            this.timerSlide.Enabled = true;
            this.lbl_Msg.Text = message;
            this.timerSlide.Start();
        }
    }
}
