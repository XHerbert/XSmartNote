using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using XSmartNote.Model;
using XSmartNote.Properties;
using XSmartNote.DAL.PostContents;
using XSmartNote.DAL.Tags;
using XSmartNote.DAL.Relations;
using XSmartNote.Model.Relations;

namespace XSmartNote
{
    public partial class MainForm : Skin_DevExpress//CCWin.Skin_Mac//CCWin.Skin_DevExpress
    {
        #region PARAMS
        private const int WIDTH = 0x004A;//74
        private const int HEIGHT = 0x0016;//22
        private const int MARGIN = 0x0005;//5
        private const int CONTENT_MARGIN = 0x0005;
        private const int CONTENT_HEIGHT = 0x002F;//47
        private const int LOCATION_X = 0x0003;

        private static int flagForPanelEdit = 0;
        private static bool CallBack = false;

        private static string currentNode = string.Empty;
        private static string labels = string.Empty;
        private static Guid guidFlag = Guid.Empty;
        private static Guid labelsId;
        private static List<string> labelList = new List<string>();
        private static TreeNode curNode;
        private static Dictionary<Guid, Guid> labelDic = new Dictionary<Guid, Guid>();
        private Relation removeRelation = new Relation();
        #endregion

        #region CONSTRUCTOR

        public MainForm()
        {
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.DoubleBuffer, true);// 双缓冲
            
            InitializeComponent();
            
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.DoubleBuffer, true);// 双缓冲
            //当窗体大小发生改变时，Panel自动变化
            this.Resize += Form1_Resize;
            this.RenameFolder += UpdateFolder;
            FitScreen();
        }
        #endregion

        #region BUILD TREE FOLDER
        //private DataTable GetFolder()
        //{
        //    DataTable dt = SQLHelper.GetFoldersTable();
        //    return dt;
        //}

        private DataSet GetFolderSet()
        {
            DataSet dt = SQLHelper.GetFoldersSet();
            return dt;
        }

        private TreeNode CreateNode(string text, string tag)
        {
            TreeNode node = new TreeNode();
            node.Text = text;
            node.Tag = tag;
            return node;
        }

        private void PopulateSubTree(DataRow dbRow, TreeNode node)
        {
            //Type N:Folder  Y:Note
            foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
            {
                object obj = null;
                if (childRow["Type"].ToString().Trim()=="N")
                {
                    obj = Enums.FOLDER;
                }
                else
                {
                    obj = Enums.LEAVES;
                }
                TreeNode childNode = CreateNode(childRow[Enums.Title.ToString()].ToString(), obj.ToString());
                childNode.Name = childRow[Enums.Id.ToString()].ToString();
                Debug.WriteLine(childNode.Name);
                node.Nodes.Add(childNode);
                PopulateSubTree(childRow, childNode);
            }
        }

        private void BuildTree(TreeView tv, DataSet ds)
        {
            tv.Nodes.Clear();
            TreeNode root = new TreeNode(Constant.KM_KNOWLEDGESYSTEM, 2, 2);
            root.Tag = Enums.ROOT;
            root.Name = Guid.Empty.ToString();
            tv.Nodes.Add(root);//添加根节点
            //foreach (DataRow item in ds.Tables[0].Rows)//将一级节点的父节点设置为NULL
            //{
            //    //if (string.IsNullOrEmpty(item[Enums.ParentId.ToString()].ToString()))
            //    if(Guid.Empty.ToString()==item[Enums.ParentId.ToString()].ToString())
            //    {
            //        //item[Enums.ParentId.ToString()] = DBNull.Value;
            //        item[Enums.ParentId.ToString()] = Guid.Empty.ToString();
            //    }
            //}
            //建立表内字段关系
            DataRelation rs = new DataRelation("NodeRelation", ds.Tables[0].Columns[Enums.Id.ToString()], ds.Tables[0].Columns[Enums.ParentId.ToString()], false);
            ds.Relations.Add(rs);

            foreach (DataRow dbRow in ds.Tables[0].Rows)
            {
                //if (dbRow.IsNull(Enums.ParentId.ToString()))
                if(dbRow[Enums.ParentId.ToString()].ToString()==Guid.Empty.ToString())  
                //if(dbRow[5].ToString()=="N")              
                {
                    //int id = Convert.ToInt32(dbRow[Enums.Id.ToString()]);
                    Guid id = Guid.Parse(dbRow[Enums.Id.ToString()].ToString());//拿到实体Id
                    //根据LineNum取到Id
                    //Guid guid=PostContentsDAO.CreatePostContentsDAO().GetGuidByLineNum(id);
                    //DataTable dt = SQLHelper.GetNameById(id);
                    Model.PostContents.PostContent post = PostContentsDAO.CreatePostContentsDAO().GetEntityById(id);
                    //TreeNode newNode = CreateNode(dbRow[Enums.Title.ToString()].ToString(), dt.Rows[0][0].ToString());
                    TreeNode newNode = CreateNode(post.Title, id.ToString());
                    newNode.Tag = Enums.FOLDER;
                    newNode.Name = dbRow[Enums.Id.ToString()].ToString();
                    Debug.WriteLine(newNode.Name);
                    root.Nodes.Add(newNode);
                    PopulateSubTree(dbRow, newNode);
                }
            }
            AddImages(root);
            root.Expand();            
        }

        private void AddImages(TreeNode tn)
        {
            TreeNodeCollection curNodes = tn.Nodes;

            foreach (TreeNode item in curNodes)
            {
                if (item.Tag.ToString() == Enums.FOLDER.ToString())//有子节点
                {
                    item.ImageIndex = 1;
                    item.Tag = Enums.FOLDER;
                    item.SelectedImageIndex = 1;
                    AddImages(item);//递归
                }
                else
                {
                    item.ImageIndex = 0;
                    item.Tag = Enums.LEAVES;
                    item.SelectedImageIndex = 0;
                }
            }
        }


        //public void BindTree(TreeView treeView, DataTable dt, TreeNode parentNode, string parentColName, string parentNodeId)
        //{
        //    DataRow[] rows = dt.Select(string.Format(parentColName + "='{0}'", parentNodeId));
        //    foreach (DataRow row in rows)
        //    {
        //        TreeNode node = new TreeNode();
        //        node.Tag = row[0].ToString();
        //        node.Text = row[1].ToString();

        //        BindTree(treeView, dt, node, parentColName, row[0].ToString());

        //        if (parentNode == null)
        //        {
        //            treeView.Nodes.Add(node);
        //        }
        //        else
        //        {
        //            parentNode.Nodes.Add(node);
        //        }
        //    }
        //}

        #endregion

        #region EVENTS

        private void MainForm_Load(object sender, EventArgs e)
        {
            BuildTree(this.tv_Folder, GetFolderSet());
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.Height < Constant.KM_MIN_HIGHT)
            {
                this.Height = Constant.KM_MIN_HIGHT;
            }
            if (this.Width < Constant.KM_MIN_WIDTH)
            {
                this.Width = Constant.KM_MIN_WIDTH;
            }
            //Panel_Tree
            panel_Tree.Height = this.Height - Constant.KM_TREE_LESS_MAIN;
            this.tv_Folder.Height = panel_Tree.Height - Constant.KM_TREE_ADJUST_TVFOLDER;

            //Panel_Article
            panel_Article.Height = this.Height - Constant.KM_ARTICLE_LESS_MAIN;
            txt_Content.Height = panel_Article.Height - txt_Content.Location.Y - panel_SeleSave.Height - Constant.KM_ARTICLE_ADJUST_CONTENT ;
            panel_SeleSave.Height = 166;
            panel_SeleSave.Location = new Point(Constant.KM_PANELSELECTSAVE_X, txt_Content.Height + txt_Content.Location.Y + Constant.KM_PANELSELECTSAVE_Y);

            //Panel_Main
            panel_Main.Height = this.Height - Constant.KM_PANELMAIN_LESS_MAIN;
            panel_List.Height = panel_Main.Height - panel_LabelFixed.Location.Y - panel_LabelFixed.Height - Constant.KM_PANELLIST_HEIGHT;

        }

        private void btn_ClearLabel_Click(object sender, EventArgs e)
        {
            //清空控件的选择状态，而不是清空控件
            foreach (LabelWithCheck item in flowLayoutPanel1.Controls)
            {
                if (item.LabelChecked)
                {
                    item.LabelChecked = false;
                }
            }
        }
      
        /// <summary>
        /// Unchecked复选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearFixLabel_Click(object sender, EventArgs e)
        {
            foreach (Control item in flowLayoutPanel2.Controls)
            {
                LabelWithCheck lc;
                if(item is LabelWithCheck)
                {
                    lc = item as LabelWithCheck;
                    if (lc.LabelChecked)
                        lc.LabelChecked = false;
                }
            }
        }
       
        /// <summary>
        /// 编辑按钮列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditLabel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            bool isRegisterEvent = true;//过滤，根据结果来决定要不要注册事件
            if (btn.Text.Equals("编辑"))
            {
                isRegisterEvent = false;
            }
            ShowLabelsList(isRegisterEvent);
        }

        /// <summary>
        /// 单击结构树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_Folder_Click(object sender, EventArgs e)
        {
            
            MouseEventArgs me = e as MouseEventArgs;
            if (me == null)
            {
                return;
            }

            object tmpObj = this.tv_Folder.GetNodeAt(me.Location);
            if (tmpObj != null)
            {
                TreeNode node = tmpObj as TreeNode;
                if ((tmpObj as TreeNode).Bounds.Contains(me.Location))
                {
                    #region RIGHT BUTTON CLICK

                    if (me.Button == MouseButtons.Right)
                    {
                        tv_Folder.SelectedNode = node;
                        this.lbl_CurrentNode.Text = "当前节点：" + node.Text;
                        if (node.Tag.ToString() == Enums.ROOT.ToString())
                        {
                            tree_folder.Show(tv_Folder, me.X, me.Y);
                        }
                        else if (node.Tag.ToString() == Enums.FOLDER.ToString())
                        {
                            if (node.Level == 2)
                            {
                                tree_folder.Items[0].Enabled = false;
                            }
                            else
                            {
                                tree_folder.Items[0].Enabled = true;
                            }
                            tree_folder.Show(tv_Folder, me.X, me.Y);
                        }
                        else
                        {
                            tree_article.Show(tv_Folder, me.X, me.Y);
                        }
                    }

                    #endregion

                    #region LEFT BUTTON CLICK

                    //如果是单击左键，显示该目录下的所有文章
                    else if (me.Button == MouseButtons.Left)
                    {
                        if (node.Tag.ToString() == Enums.ROOT.ToString())
                        {
                            this.lbl_CurrentNode.Text = "当前节点：" + node.Text;
                            return;//后期进行改动，实现显示根目录下的文章
                        }
                        if (node.Tag.ToString() == Enums.FOLDER.ToString())
                        {
                            this.lbl_CurrentNode.Text = "当前节点：" + node.Text;
                            ClearControls(panel_List);
                            ClearControls(flowLayoutPanel1);//清除Labels
                            //txt_SelectedLabel.ControlText = string.Empty;

                            //原方案
                            //int id = node.Name.ToInt();
                            //DataTable articles = SQLHelper.GetListByFolderId(id);
                            //if (articles.Rows.Count > 0)
                            //{
                            //    foreach (DataRow item in articles.Rows)
                            //    {
                            //        int cid = item["Id"].ToInt();
                            //        if (!string.IsNullOrEmpty(cid.ToString()))
                            //        {
                            //            DataTable labels = SQLHelper.GetTagsByPostId(cid);//取得一篇文章里的所有书签
                            //            if (labels.Rows.Count > 0)
                            //            {
                            //                foreach (DataRow aticle in labels.Rows)
                            //                {
                            //                    AddLabelToLocation(flowLayoutPanel1, Constant.KM_PANELLIST_COLUMN, aticle["tagContent"].ToString(), aticle["tagId"].ToInt(), false,false);
                            //                }
                            //            }
                            //        }
                            //    }
                            //}

                            //新方案
                            Guid parentId = Guid.Parse(node.Name);
                            Model.PostContents.PostContent post = PostContentsDAO.CreatePostContentsDAO().GetEntityById(parentId);
                            //根据当前父节点Id获取子节点
                            //IList<Model.PostContents.PostContent> postList = PostContentsDAO.CreatePostContentsDAO().GetEntityByCondition("select P.Id,P.ParentId,P.Title,P.Content,P.Type,P.LineNum,P.ModifyDate,P.CreateDate,P.Enable from PostContent P where ParentId=:fn", parentId.ToString());
                            IList<Model.PostContents.PostContent> postList = PostContentsDAO.CreatePostContentsDAO().GetEntitiesByParentId(parentId,true);
                            ShowListOnPanel(postList, this.panel_List);
                        }
                        if (node.Tag.ToString() == Enums.LEAVES.ToString())
                        {
                            this.lbl_CurrentNode.Text = "当前节点：" + node.Text;
                            ClearControls(flowLayoutPanel1);
                            //int cid = node.Name.ToInt();
                            //DataTable labels = SQLHelper.GetTagsByPostId(cid);

                            Guid id = Guid.Parse(node.Name);
                            //获取该Note下所有标签 //取得一篇文章里的所有书签
                            IList<Model.Tags.Tag> tags= TagsDAO.CreateTagsDAO().GetTagsByPostId(id);
                            if (tags.Count > 0)
                            {
                                foreach (Model.Tags.Tag tag in tags)
                                {
                                    AddLabelToLocation(flowLayoutPanel1, Constant.KM_PANELLIST_COLUMN, tag.TagContent, tag.TagId, true, false);
                                }
                            }
                            //if (labels.Rows.Count > 0)
                            //{
                            //    foreach (DataRow aticle in labels.Rows)
                            //    {
                            //        AddLabelToLocation(flowLayoutPanel1, Constant.KM_PANELLIST_COLUMN, aticle["tagContent"].ToString(), aticle["tagId"].ToInt(), true,false);
                            //    }
                            //}
                            SetReadOnly(true);
                            
                        }
                    }
                    #endregion
                }
                else
                {
                    //isClickOnNode = false;
                }
            }
            tv_Folder_DoubleClick(sender, e);
            KeepSizeWithMainForm(this.panel_List);
        }

        private void SetReadOnly(bool IsReadOnly)
        {
            this.txt_Content.Enabled = !IsReadOnly;
            this.txt_Title.Enabled = !IsReadOnly;
        }

        /// <summary>
        /// 双击结构树并将数据显示在文本域中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_Folder_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            if (me == null)
            {
                return;
            }
            //TreeNode node = tv_Folder.SelectedNode;
            object tmpObj = this.tv_Folder.GetNodeAt(me.Location);
            if (tmpObj != null)
            {
                TreeNode node = tmpObj as TreeNode;
                if ((tmpObj as TreeNode).Bounds.Contains(me.Location))
                {
                    if (me.Button == MouseButtons.Left)
                    {
                        if (node.Tag.ToString() == Enums.LEAVES.ToString())
                        {
                            //显示文章到C区域
                            //int Id = node.Name.ToInt();
                            //txt_Content.ControlText = SQLHelper.GetContentById(Id);
                            //txt_Title.ControlText = node.Text;

                            Guid Id = node.Name.ToGuid();
                            Model.PostContents.PostContent post= PostContentsDAO.CreatePostContentsDAO().GetEntityById(Id);
                            txt_Content.ControlText = post.Content;
                            txt_Title.ControlText = post.Title;
                        }
                    }
                }
            }
        }
       
        /// <summary>
        /// 选择标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChooseLabel_Click(object sender, EventArgs e)
        {
            
            Button btn = sender as Button;
            bool isRegisterEvent = false;//过滤，根据结果来决定要不要注册事件
            if (btn.Text.Equals("选择标签"))
            {
                isRegisterEvent = true;
            }
            ShowLabelsList(isRegisterEvent);
        }
      
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //添加文章，直接在文本框中输入标题内容，再选择节点（右侧直接出现该节点下所有文章）和标签
            //点击添加后，右侧尾部追加该文章
            /*
            if (string.IsNullOrEmpty(txt_Content.Text) || string.IsNullOrEmpty(txt_Title.Text))
            {
                MessageBoxEx.Show(Constant.KM_WN_TITLE_OR_CONTENT_NOT_NULL, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
                return;
            }
            TreeNode curNode = tv_Folder.SelectedNode;
            if (curNode == null)
            {
                MessageBoxEx.Show(Constant.KM_WN_DISPATCH_DIR, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
                return;
            }

            AddLabelToLocation(panel_List, this.txt_Content.Text);
            this.txt_Title.Text = string.Empty;
            this.txt_Content.Text = string.Empty;
            */
        }
      
        /// <summary>
        /// 保存文章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            TreeNode node = tv_Folder.SelectedNode;
            if (node == null)
            {
                return;
            }
            if (node.Tag.ToString() == Enums.LEAVES.ToString())
            {
                bool IsSuccess = false;
                //同时更新标题和内容(原方案)
                //int i = SQLHelper.UpdateContent(node.Name.ToInt(), txt_Title.Text, txt_Content.Text);

                //同时更新标题和内容(新方案)
                Model.PostContents.PostContent post = PostContentsDAO.CreatePostContentsDAO().GetEntityById(node.Name.ToGuid());
                post.Enable = true;
                post.Type = true;
                post.Title = txt_Title.ControlText;
                post.Content = txt_Content.ControlText;
                post.ModifyDate = DateTime.Now;
                IsSuccess= PostContentsDAO.CreatePostContentsDAO().Update(post);

                //重要！同时更新文章标签，此处需要设计一个额外的控件，圆角矩形来存储Relation对象

                if (rectlblContainer.Controls.Count > 0)
                {
                    //循环添加Tag和Post的关系Relation
                    foreach (Control rectLbl in rectlblContainer.Controls)
                    {
                        Model.PostContents.PostContent currentPost = PostContentsDAO.CreatePostContentsDAO().GetEntityById(node.Name.ToGuid());//Guid.NewGuid 临时替代真正的ID
                        Model.Tags.Tag currentag = TagsDAO.CreateTagsDAO().GetTagById(rectLbl.Tag.ToGuid());//Guid.NewGuid 临时替代真正的ID
                        Model.Relations.Relation relation = new Model.Relations.Relation();
                        relation.RelationId = Guid.NewGuid();
                        relation.Post = currentPost;
                        relation.TagId = currentag.TagId;
                        bool IsSaved = RelationsDAO.CreateRelationsDAO().Save(relation);
                    }
                }

                //同时重新加载Treeview。已注掉，暂时没有必要Reload
                //BuildTree(this.tv_Folder, GetFolderSet());
                if (IsSuccess)
                {
                    SetReadOnly(true);
                    MessageBoxEx.Show(Constant.KM_INFO_SAVE_OK,Constant.KM_TYPE_INFO , MessageBoxButtons.OK);
                    tv_Folder.SelectedNode = node;

                }
            }
            else
            {
                MessageBoxEx.Show("请选择要保存的文章",Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
            }
        }
      
        /// <summary>
        /// 组件自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //当前节点提示框所在Location
            this.lbl_CurrentNode.Location = new Point(10, this.Height - this.lbl_CurrentNode.Height - 5);
            //MainPanel宽度随主窗体变化
            this.panel_Main.Width = this.Width - this.panel_Main.Location.X - 10;
            //MainPanel中各个组件随着MainPanel的宽度变化而变化
            this.skinLine1.Width = this.panel_Main.Width - this.skinLine1.Location.X - 10;
            this.skinLine2.Width = this.Width - this.skinLine2.Location.X - 14;
            this.panel_LabelFixed.Width = this.panel_Main.Width - this.panel_LabelFixed.Location.X;
            this.panel_List.Width = this.panel_Main.Width - this.panel_List.Location.X;
            this.btn_ClearLabel.Location = new Point(this.panel_Main.Width - this.btn_ClearLabel.Width - 10, 2);
            this.panel_Label.Width = this.panel_Main.Width - this.panel_Label.Location.X;
            this.panel_LabelFixed.Width = this.panel_Main.Width - this.panel_LabelFixed.Location.X;
            this.btn_ClearFixLabel.Location = new Point(this.panel_Main.Width - this.btn_ClearFixLabel.Width - 10, 39);
            this.btn_EditLabel.Location = new Point(this.panel_Main.Width - this.btn_EditLabel.Width - 10, 7);
            KeepSizeWithMainForm(this.panel_List);
            //MessageBox.Show(this.skinLine1.Parent.Name);
        }
        #endregion

        #region DELEGATE
        public delegate void RenameFolderEventHandler(TreeNode node, string name);
        public event RenameFolderEventHandler RenameFolder;
        #endregion

        #region COMMON METHOD
        /// <summary>
        /// 移除LabelWithCheck控件
        /// </summary>
        /// <param name="flp"></param>
        private void ClearControls(FlowLayoutPanel flp)
        {
            //最有效的删除控件方式
            for (int i = flp.Controls.Count - 1; i >= 0; i--)
            {

                if (flp.Controls[i] is LabelEx || flp.Controls[i] is LabelWithCheck)
                {
                    flp.Controls.RemoveAt(i);
                }
            }
        }       //添加LabelWithCheck控件

        /// <summary>
        /// 将Note添加在面板的指定位置(重载)
        /// </summary>
        /// <param name="flp"></param>
        /// <param name="column"></param>
        /// <param name="tag"></param>
        /// <param name="Id"></param>
        /// <param name="ischecked"></param>
        /// <param name="registerEvent"></param>
        public void AddLabelToLocation(FlowLayoutPanel flp, int column, string tag, Guid Id, bool ischecked,bool registerEvent)
        {
            //int flag = 0;
            int labelCount = flp.Controls.Count;
            int lines = labelCount / column;
            int left = labelCount % column;
            int X = (left * WIDTH) + (left + 1) * MARGIN;
            int Y = lines * HEIGHT + (lines + 1) * MARGIN;
            LabelWithCheck label = new LabelWithCheck();
            //注册事件
            if (registerEvent)
            {
                label.LabelCheckedEvent += Label_LabelCheckedEvent;
                //new TipsForm().Show("注册插入数据库事件");
            }
            else
            {
                label.LabelCheckedEvent += Label_LabelSelectEvent;
                //new TipsForm().Show("注册过滤事件");
            }
           
            label.BackColor = ColorTranslator.FromHtml(ColorManager.ColorConvertor(flagForPanelEdit));
            label.Location = new Point(X, Y);
            label.LabelText = tag;//存储标签名称
            label.Id = Id;//存储标签ID

            label.LabelChecked = ischecked;//选中状态

            flp.Controls.Add(label);
            flagForPanelEdit++;
            if (flagForPanelEdit > 19)
            {
                flagForPanelEdit = 0;
            }
        }
       
        public void AddLabelToLocation(TX.Framework.WindowUI.Controls.TXPanel panel,int column, RectangleLabel label)
        {
            int labelCount = panel.Controls.Count;
            int lines = labelCount / column;
            int left = labelCount % column;
            int X = (left * WIDTH) + (left + 1) * (MARGIN*3);
            int Y = lines * HEIGHT + (lines + 1) * (MARGIN*3);
            //LabelWithCheck label = new LabelWithCheck();

            label.Location = new Point(X,Y);
            panel.Controls.Add(label);
        }

        /// <summary>
        /// 选择标签，用于“选中标签”并同步到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_LabelCheckedEvent(object sender, LabelWithCheckEventArgs e)
        {
            if (CallBack)
            {
                return;
            }
            
            CheckBox lc = (CheckBox)sender;
            CheckState cs = lc.CheckState;
            curNode = tv_Folder.SelectedNode;
            if (curNode == null)
            {
                MessageBoxEx.Show(Constant.KM_WN_NODE_NOT_SELECTED, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
                return;
            }

            if (cs.ToString() == "Checked")
            {
                
                //removeRelation = null;
                //labels = e.LabelText;
                labelsId = e.Id;//tagId
                guidFlag = Guid.NewGuid();
                bool exist = CheckExistTag(curNode.Name.ToGuid(), e.Id);
                if (exist)
                {
                    MessageBoxEx.Show(Constant.KM_WN_ADD_EXIST_LABEL_NOT_ALLOWED, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
                    CallBack = true;
                    lc.CheckState = CheckState.Unchecked;
                    CallBack = false;
                    return;
                }


                if (labelDic.ContainsValue(labelsId))
                {
                    MessageBoxEx.Show(Constant.KM_WN_ADD_EXIST_LABEL_NOT_ALLOWED, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
                    return;
                }
                labelDic.Add(labelsId, guidFlag);
                //将关联存入数据库
                if (curNode == null)
                {
                    MessageBoxEx.Show(Constant.KM_WN_NODE_NOT_SELECTED, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
                    return;
                }
                if (curNode.Tag.ToString() == Enums.LEAVES.ToString())
                {
                    //int i = SQLHelper.AddRelations(curNode.Name.ToInt(), e.Id);
                    removeRelation=AddRelation(curNode.Name.ToGuid(), e.Id, guidFlag,removeRelation);
                }
            }
            else if (cs.ToString() == "Unchecked")
            {
                //guidFlag = Guid.Empty;
                //将关联移出数据库
                curNode = tv_Folder.SelectedNode;
                if (curNode == null)
                {
                    MessageBoxEx.Show(Constant.KM_WN_NOTE_NOT_SELECTED, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
                    return;
                }
                if (curNode.Tag.ToString() == Enums.LEAVES.ToString())
                {
                    bool Nothing;
                    Relation i = RelationsDAO.CreateRelationsDAO().IsExistTag(curNode.Name.ToGuid(),e.Id,out  Nothing);
                    if (removeRelation != null)
                    {
                        removeRelation = i;
                        RemoveRelation(removeRelation, labelDic[e.Id]);
                        labelDic.Remove(e.Id);
                    }
                }
            }
            //txt_SelectedLabel.ControlText = ShowLabel(labelDic);
            //变更为 向Panel中添加Rectanglelabel  重点
        }


                
        private Relation AddRelation(Guid postId,Guid tagId, Guid guidFlag,Relation removeRelation)
        {
            //加非空校验;
            removeRelation.RelationId = Guid.NewGuid();
            removeRelation.PostId = postId;
            removeRelation.TagId = tagId;
            bool IsSucess = RelationsDAO.CreateRelationsDAO().Save(removeRelation);
            Model.Tags.Tag tag = TagsDAO.CreateTagsDAO().GetTagById(tagId);
            //removeRelation = relation;
            if (IsSucess)
            {
                RectangleLabel label = new RectangleLabel();
                label.ControlText = tag.TagContent;
                label.BorderColor = Color.Purple;
                label.BorderWidth = 1;
                label.InnerColor = Color.Transparent;
                label.Tag = guidFlag;
                //计算位置
                AddLabelToLocation(rectlblContainer, 2, label);
                //rectlblContainer.Controls.Add(label);//添加一个事件，E区显示已添加标签
            }
            if (!IsSucess)
            {
                MessageBoxEx.Show(Constant.KM_ER_REFERENCE_ID_WRONG, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
            }
            return removeRelation;
        }


        private void RemoveRelation(Relation removeRelation,Guid guidFlag)
        {
            bool IsRemoved = RelationsDAO.CreateRelationsDAO().Delete(removeRelation);
            if (!IsRemoved)
            {
                MessageBoxEx.Show(Constant.KM_REMOVE_REFERENCE_WRONG, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
            }
            else
            {
                //rectlblContainer.Controls.RemoveAt(0);
                RectangleLabel removeLabel = null;
                foreach (RectangleLabel rlbl in rectlblContainer.Controls)
                {
                    if (rlbl.Tag.ToString() == guidFlag.ToString())
                    {
                        removeLabel = rlbl;
                    }
                }
                if (removeLabel != null)
                {
                    rectlblContainer.Controls.Remove(removeLabel);
                }
            }
        }


        private bool CheckExistTag(Guid postId,Guid tagId)
        {
            bool IsExist;
            RelationsDAO.CreateRelationsDAO().IsExistTag(postId, tagId, out IsExist);
            return IsExist;
        }

        /// <summary>
        /// 选择标签，用于“编辑”过滤F区域文章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_LabelSelectEvent(object sender, LabelWithCheckEventArgs e)
        {
            //AddLabelToLocation(flowLayoutPanel2,6,e.LabelText,e.Id,false,false); //Stack Overflow 重复绑定重复执行 形成无限循环导致
        }

        /// <summary>
        /// 将Note展示在Panel面板上
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="flp"></param>
        //原方案
        //public void ShowListOnPanel(DataTable dt, FlowLayoutPanel flp)
        //{
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        AddLabelToLocation(flp, item["Content"].ToString());
        //    }
        //}
        public void ShowListOnPanel(IList<Model.PostContents.PostContent> posts, FlowLayoutPanel flp)
        {
            foreach (Model.PostContents.PostContent post in posts)
            {
                AddLabelToLocation(flp, post);
            }
        }

        /// <summary>
        /// 将Note添加在面板的指定位置
        /// </summary>
        /// <param name="flp"></param>
        /// <param name="text"></param>
        public static void AddLabelToLocation(FlowLayoutPanel flp, Model.PostContents.PostContent post)
        {
            int labelCount = flp.Controls.Count;
            LabelExSolidBorder le = new LabelExSolidBorder();//此处可变更LabelEx样式，可配置
            int flag = 0;
            int X = LOCATION_X;
            int Y = CONTENT_MARGIN;
            if (labelCount == 0)
            {
                le.BackColor = ColorTranslator.FromHtml(ColorManager.ColorConvertor(flag));
                flag++;
            }
            for (int i = 0; i < labelCount; i++)
            {
                flag++;
                Y += CONTENT_HEIGHT;
                Y += CONTENT_MARGIN;
                le.BackColor = ColorTranslator.FromHtml(ColorManager.ColorConvertor(flag));

                if (flag > 19)
                {
                    flag = 0;
                }
            }

            le.Location = new Point(X, Y);
            le.Text = post.Content;
            le.Tag = post;
            flp.Controls.Add(le);
            flp.ScrollControlIntoView(le);
        }

        /// <summary>
        /// 更新文件夹树
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        private static void UpdateFolder(TreeNode node, string name)
        {
            //这里写你想更新到数据库的内容和相关的方法
            //发回数据到数据库
            //原方案
            //int result = SQLHelper.UpdateFolder(node.Text, name, node.Name.ToInt());
            //新方案
            Model.PostContents.PostContent post = PostContentsDAO.CreatePostContentsDAO().GetEntityById(node.Name.ToGuid());
            post.Title = string.IsNullOrEmpty(name)?node.Text:name;
            post.ModifyDate = DateTime.Now;
            if (node.Tag.ToString() == "LEAVES")
                post.Type = true;
            post.Enable = true;
            bool IsSuccess=PostContentsDAO.CreatePostContentsDAO().Update(post);
            Debug.WriteLine(IsSuccess);
        }

        /// <summary>
        /// 文本框显示为文章添加的标签
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        //private static string ShowLabel(Dictionary<Guid, string> dic)
        //{
        //    StringBuilder labels = new StringBuilder();
        //    foreach (KeyValuePair<Guid, string> item in dic)
        //    {
        //        labels.Append(item.Value);
        //        labels.Append(',');
        //    }
        //    return labels.ToString();
        //}

        /// <summary>
        /// 初始化标签库
        /// </summary>
        /// <param name="isRegisterEvent"></param>
        private void ShowLabelsList(bool isRegisterEvent)
        {
            TagSelector tag = new TagSelector();
            //DataTable dt = SQLHelper.GetAllTags();
            //foreach (DataRow item in dt.Rows)
            //{
            //    //AddLabelToLocation(tag.panel_Tags, 4, item["tagContent"].ToString(), item["tagId"].ToInt(), false, isRegisterEvent);
            //    AddLabelToLocation(tag.panel_Tags, 4, item["tagContent"].ToString(), Guid.NewGuid(), false, isRegisterEvent);
            //}
            IList<Model.Tags.Tag> list = TagsDAO.CreateTagsDAO().GetAllTags();
            foreach (Model.Tags.Tag item in list)
            {
                //AddLabelToLocation(tag.panel_Tags, 4, item["tagContent"].ToString(), item["tagId"].ToInt(), false, isRegisterEvent);
                AddLabelToLocation(tag.panel_Tags, 4, item.TagContent, item.TagId, false, isRegisterEvent);
            }
            tag.Show();
        }

        /// <summary>
        /// 使得FlowLayoutPanel上的LabelEx组件随窗体的变化而变化，保证控件的宽度自适应
        /// </summary>
        /// <param name="flp"></param>
        private void KeepSizeWithMainForm(FlowLayoutPanel flp)
        {
            foreach (Control label in flp.Controls)
            {
                if (label is LabelEx)
                {
                    LabelEx lbl = label as LabelEx;
                    lbl.Width = this.Width - this.panel_Main.Location.X - 45;
                }
            }
        }

        /// <summary>
        /// 获取当前屏幕大小，并设置宽高参数为当前屏幕的80%
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void GetScreenSize(out int x,out int y)
        {
            x = Screen.PrimaryScreen.Bounds.Width;
            y = Screen.PrimaryScreen.Bounds.Height;
            x = x * 9/10;
            y = y * 9/10;
            //Console.WriteLine(string.Format("X:{0}", x));
            //Console.WriteLine(string.Format("Y:{0}", y));
        }

        /// <summary>
        /// 设置窗体宽度高度为屏幕的80%，可配置
        /// </summary>
        private void FitScreen()
        {
            int X, Y = 0;
            GetScreenSize(out X, out Y);
            this.Width = X;
            this.Height = Y;
        }
        
        private void SetThemeColor(Color color)
        {
            this.panel_Main.BackColor = color;
            this.tv_Folder.BackColor =color;
            this.txt_Title.BoxBackColor = color;
            this.txt_Content.BoxBackColor =color;
            //this.txt_SelectedLabel.BoxBackColor = color;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="title"></param>
        public void SetText(string text,string title)
        {
            this.txt_Content.ControlText = text;
            this.txt_Title.ControlText = title;
            SetReadOnly(true);
        }


        /// <summary>
        /// 单击右侧Note时，选中与之对应的Node
        /// </summary>
        /// <param name="post"></param>
        public void SetSelectedNode(Model.PostContents.PostContent post)
        {
            tv_Folder.Focus();
            TreeNode node = null;
            //此处暂未实现，需要遍历所有的Node，耗费性能，暂时不做
            node = tv_Folder.Nodes[0].Nodes[0];
            tv_Folder.SelectedNode = node;
            this.lbl_CurrentNode.Text= "当前节点：" + node.Text;
        }

        public void SetTheme(ThemeManager.ThemeEnums.ThemeEnum enums)
        {
            switch (enums)
            {
                case ThemeManager.ThemeEnums.ThemeEnum.KM_THEME_MISTYROSE:
                    this.BackgroundImage = Resources.bg_10_03;
                    SetThemeColor(Color.MistyRose);
                    this.Invalidate();
                    break;
                case ThemeManager.ThemeEnums.ThemeEnum.KM_THEME_ALICEBLUE:
                    this.BackgroundImage = Resources.bg_10_04;
                    SetThemeColor(Color.AliceBlue);
                    break;
                case ThemeManager.ThemeEnums.ThemeEnum.KM_THEME_HONEYDEW:
                    this.BackgroundImage = Resources.bg_10_02;
                    SetThemeColor(Color.Honeydew);
                    break;
                case ThemeManager.ThemeEnums.ThemeEnum.KM_THEME_LEMONCHIFFON:
                    this.BackgroundImage = Resources.bg_10_01;
                    SetThemeColor(Color.LemonChiffon);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region CONTEXTMENUTRIPS
      
        private void tv_Folder_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //相应的判断逻辑
            if (e.Node.Name.ToString()==Guid.Empty.ToString())
            {
                return;
            }

            if (!e.CancelEdit)
            {
                UpdateFolder(e.Node, e.Label);
            }
        }

        #endregion

        #region THEMES
        private void roseRed_Click(object sender, EventArgs e)
        {
            ThemeManager.IThemeManager manager = ThemeManager.ThemeManager.CreateThemeManager(this);
            manager.ChangeFormTheme(ThemeManager.ThemeEnums.ThemeEnum.KM_THEME_MISTYROSE);
        }

        private void stoneBlue_Click(object sender, EventArgs e)
        {
            ThemeManager.IThemeManager manager = ThemeManager.ThemeManager.CreateThemeManager(this);
            manager.ChangeFormTheme(ThemeManager.ThemeEnums.ThemeEnum.KM_THEME_ALICEBLUE);
        }

        private void lightGreen_Click(object sender, EventArgs e)
        {
            ThemeManager.IThemeManager manager = ThemeManager.ThemeManager.CreateThemeManager(this);
            manager.ChangeFormTheme(ThemeManager.ThemeEnums.ThemeEnum.KM_THEME_HONEYDEW);
        }

        private void yellow_Click(object sender, EventArgs e)
        {
            ThemeManager.IThemeManager manager = ThemeManager.ThemeManager.CreateThemeManager(this);
            manager.ChangeFormTheme(ThemeManager.ThemeEnums.ThemeEnum.KM_THEME_LEMONCHIFFON);
        }

        private void bone_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.bg_10_05;
        }

        #endregion

        #region MENU OPERATIONS

        private void Tree_NewSubFolderMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = tv_Folder.SelectedNode;
            Model.PostContents.PostContent post = null;
            bool flag = false;

            if (tn != null)
            {
                TreeNode node = new TreeNode(Constant.KM_DEFAULT_FOLDERNAME);
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                node.Tag = Enums.FOLDER;
                TreeNodeCollection tc = tn.Nodes;

                //插入节点的排序问题
                //int folders = 0;
                //foreach (TreeNode item in tc)
                //{
                //    if (item.Tag.ToString() == Enums.FOLDER.ToString())
                //    {
                //        folders++;
                //    }
                //}

                post = new Model.PostContents.PostContent();
                post.Id = Guid.NewGuid();
                post.Title = node.Text;
                post.Type = false;//目录 非文章
                post.ModifyDate = DateTime.Now;
                post.CreateDate = DateTime.Now;
                post.Content = string.Empty;
                post.Enable = true;

                node.Name = post.Id.ToString();
                if (tn.Tag.ToString() == Enums.ROOT.ToString())//如果是根节点
                {
                    post.ParentId = Guid.Empty;
                    //flag = SQLHelper.InsertFolder(post, true);
                    flag = (bool)PostContentsDAO.CreatePostContentsDAO().Save(post);
                }
                else
                {
                    post.ParentId = tn.Name.ToGuid();
                    //flag = SQLHelper.InsertFolder(post, false);
                    flag = (bool)PostContentsDAO.CreatePostContentsDAO().Save(post);
                    node.ForeColor = Color.Maroon;
                    tn.Expand();
                }

                if (flag)
                {
                    //tn.Nodes.Insert(folders, node);
                    tn.Nodes.Insert(tn.Nodes.Count, node);
                }
                else
                {
                    MessageBoxEx.Show(Constant.KM_ER_DATA_SAVE_FAILED, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
                }

            }
        }

        private void Tree_DeleteFolderMenuItem_Click(object sender, EventArgs e)
        {
            //删除实际数据
            TreeNode tn = tv_Folder.SelectedNode;
            if (null == tn)
                return;
            IList<Model.PostContents.PostContent> posts = PostContentsDAO.CreatePostContentsDAO().GetEntitiesByParentId(tn.Name.ToGuid(), false);

            //删除前提示框警告

            DialogResult dr = MessageBoxEx.Show(Constant.KM_CONFIRM_REMOVE, Constant.KM_TYPE_WARN, MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                bool IsSuccess = PostContentsDAO.CreatePostContentsDAO().Delete(posts);
                bool ParentRemoved = PostContentsDAO.CreatePostContentsDAO().Delete(PostContentsDAO.CreatePostContentsDAO().GetEntityById(tn.Name.ToGuid()));
                //暂时只写删除树，不是几删除数据
                if (IsSuccess && ParentRemoved)
                {
                    //删除当前节点前，把右侧的区域清空
                    if (panel_List.Controls.Count > 0)
                    {
                        panel_List.Controls.Clear();
                    }
                    this.txt_Title.ControlText = txt_Title.WaterText;
                    this.txt_Content.ControlText = txt_Content.WaterText;
                    tn.Remove();
                    MessageBoxEx.Show(Constant.KM_REMOVE_OK, Constant.KM_TYPE_INFO);
                }
                //状态栏  日志
            }

        }

        private void Tree_NewNoteMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = tv_Folder.SelectedNode;
            //PostContent post = null;
            Model.PostContents.PostContent post = null;
            bool flag = false;
            if (tn != null)
            {
                TreeNode node = new TreeNode(Constant.KM_DEFAULT_NOTENAME);
                //int lineNum;
                node.BeginEdit();
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.Tag = Enums.LEAVES;
                //原方案
                //node.Name = (SQLHelper.GetMaxID(Enums.Table_Content.ToString(), "Id") + 1).ToString();
                //新方案
                //PostContentsDAO.CreatePostContentsDAO().QueryAll(out lineNum);
                //node.Name = (lineNum+1).ToString();
                post = new Model.PostContents.PostContent();
                post.Id = Guid.NewGuid();
                post.Title = node.Text;
                post.Type = true;//非目录 文章
                post.Enable = true;
                post.ModifyDate = DateTime.Now;
                post.CreateDate = DateTime.Now;
                //原方案
                //post.ParentId = SQLHelper.GetIdByName(tn.Text);
                //新方案
                //post.ParentId = PostContentsDAO.CreatePostContentsDAO().GetGuidByLineNum(node.Name.ToInt()-1);
                post.ParentId = tn.Name.ToGuid();
                node.Name = post.Id.ToString();

                //原方案
                //flag = SQLHelper.InsertFolder(post, false);
                //新方案
                flag = (bool)PostContentsDAO.CreatePostContentsDAO().Save(post);

                if (flag)
                {
                    //这里需要改进，对文件夹和Note区分下，所有文件夹在所有的Note之上
                    tn.Nodes.Insert(tn.Nodes.Count, node);
                    node.ForeColor = Color.Maroon;
                    tn.Expand();
                }
                else
                {
                    MessageBoxEx.Show(Constant.KM_ER_NOTE_SAVE_FAILED, Constant.KM_TYPE_WARN, MessageBoxButtons.OK);
                }

            }
        }

        private void Tree_RenameFolderMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tv_Folder.SelectedNode;
            string newName = string.Empty;
            if (node != null)
            {
                node.BeginEdit();
            }
        }

        private void Tree_RenameNoteMenuItem_Click(object sender, EventArgs e)
        {
            Tree_RenameFolderMenuItem_Click(sender, e);
        }

        private void Tree_DeleteNoteMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = tv_Folder.SelectedNode;
            Model.PostContents.PostContent post = PostContentsDAO.CreatePostContentsDAO().GetEntityById(tn.Name.ToGuid());
            
            DialogResult dr = MessageBoxEx.Show(Constant.KM_CONFIRM_REMOVE, Constant.KM_TYPE_WARN, MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                bool HasDeleted = PostContentsDAO.CreatePostContentsDAO().Delete(post);
                if (HasDeleted)
                {
                    tn.Remove();
                    this.txt_Content.ControlText = this.txt_Content.WaterText;
                    this.txt_Title.ControlText = this.txt_Title.WaterText; ;
                }
            }
        }

        private void Tree_EditNoteMenuItem_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);
        }

        private void FontSizeMenu_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            //fontDialog.ShowDialog();
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                //要判断Panel上是否有其他控件，增强代码的健壮性
                foreach (Control item in this.panel_List.Controls)
                {
                    if (item is LabelEx)
                    {
                        item.Font = fontDialog.Font;//将当前选定的文字改变字体　
                    }

                }
            }
        }
        #endregion

    }


    #region 扩展


    public static class Extension
    {
        public static int ToInt(this object o)
        {
            int i = -1;
            try
            {
                if (!string.IsNullOrEmpty(o.ToString()) && o != null)
                {
                    i = Convert.ToInt32(o);
                }
            }
            catch (Exception)
            {
                MessageBoxEx.Show(Constant.KM_ER_CONVERT_FAIL);
            }
            return i;
        }

        public static Guid ToGuid(this object obj)
        {
            Guid guid = Guid.Empty;
            try
            {
                if(null != obj && !string.IsNullOrEmpty(obj.ToString()))
                {
                    guid = Guid.Parse(obj.ToString());
                }
            }
            catch (Exception)
            {
                MessageBoxEx.Show(Constant.KM_ER_CONVERT_FAIL);
            }
            return guid;
        }
    }
    #endregion

}
