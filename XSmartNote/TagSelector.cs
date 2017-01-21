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
using XSmartNote.DAL;
using XSmartNote.DAL.Tags;
using XSmartNote.Model;

namespace XSmartNote
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
                //Model.Tags.Tag tag = TagsDAO.CreateTagsDAO().GetTagByName(txt_Tag.Text.Trim());
                Model.Tags.Tag tag = new Model.Tags.Tag();
                tag.TagId = Guid.NewGuid();
                tag.TagContent = txt_Tag.Text;
                Guid gid=(Guid)TagsDAO.CreateTagsDAO().Save(tag);
                if (gid == Guid.Empty)
                {
                    MessageBoxEx.Show("未知错误",Constant.KM_TYPE_ERROR);
                    return;
                }
                    
                new MainForm(false).AddLabelToLocation(this.panel_Tags, 4, txt_Tag.Text,tag.TagId,false,true);
                this.txt_Tag.Text = string.Empty;
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
            this.panel_Tags.Height = this.ClientSize.Height - 80;            
        }

        private void TagSelector_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(this.ClientSize.Width.ToString());
        }
        #endregion

        #region COMMON METHOD
        private bool IsContainInputLabel(string txt)
        {
            //isContain = SQLHelper.CheckOverrideName(txt.Trim());
            isContain = TagsDAO.CreateTagsDAO().IsExistTag(txt);
            return isContain;
        }
        #endregion

        private void panel_Tags_Click(object sender, EventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    this.Dispose();
            //    this.Close();
            //}

        }
    }
}
