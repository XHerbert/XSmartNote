using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCWin;
using System.Windows.Forms;

namespace KnowledgeManager
{
    public partial class TagSelector :Skin_Mac
    {
        #region CONSTRUCTOR
        public TagSelector()
        {
            InitializeComponent();
            this.Resize += TagSelector_Resize;
        }
        #endregion

        #region PARAMS
        private const int WIDTH = 74;
        private const int HEIGHT = 22;
        private const int MARGIN = 5;

        private bool isContain = false;
        #endregion

        #region EVENTS
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //TipsForm tf = new TipsForm();
            #region MyRegion
            //int labelCount = this.panel_Tags.Controls.Count;
            //int lines = labelCount / 4;
            //int left = labelCount % 4;
            //int X = (left * WIDTH) + (left + 1) * MARGIN;
            //int Y = lines * HEIGHT + (lines + 1) * MARGIN;
            //LabelWithCheck label = new LabelWithCheck();
            ////if (string.IsNullOrEmpty(txt_Tag.Text))
            ////{
            ////    MessageBox.Show("请填写标签名称！");
            ////    return;
            ////}
            ////label.LabelText = this.txt_Tag.Text;
            //label.Location = new Point(X,Y);
            //panel_Tags.Controls.Add(label);
            #endregion
           
            if (!string.IsNullOrEmpty(txt_Tag.Text)&&!IsContainInputLabel(txt_Tag.Text))
            {
                //new MainForm().AddLabelToLocation(this.panel_Tags, 4, txt_Tag.Text,SQLHelper.GetMaxID(Enums.Table_Tag.ToString(),"tagId"),false,true);
                //SQLHelper.InsertTag(txt_Tag.Text);
            }
            else
            {
                MessageBoxEx.Show(string.Format("请输入标签或\r\n确保标签唯一!", txt_Tag.Text),"注意",MessageBoxButtons.OK);
                txt_Tag.Text = string.Empty;
                return;
            }
        }

        private void TagSelector_Resize(object sender, EventArgs e)
        {
            this.panel_Tags.Height = this.ClientSize.Height - 38;
        }

        private void TagSelector_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(this.ClientSize.Width.ToString());
        }
        #endregion

        #region COMMON METHOD
        private bool IsContainInputLabel(string txt)
        {
            isContain = SQLHelper.CheckOverrideName(txt.Trim());
            return isContain;
        }
        #endregion
    }
}
