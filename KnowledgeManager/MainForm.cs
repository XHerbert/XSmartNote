using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using KnowledgeManager.Model;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeManager
{
    public partial class MainForm : Form
    {
        #region PARAMS
        private const int WIDTH = 0x004A;//74
        private const int HEIGHT = 0x0016;//22
        private const int MARGIN = 0x0005;//5
        private const int CONTENT_MARGIN = 0x0005;
        private const int CONTENT_HEIGHT = 0x002F;//47
        private const int LOCATION_X = 0x0003;

        private static int flagForPanelEdit = 0;
        private static string currentNode = string.Empty;
        private static string labels = string.Empty;
        private static int labelsId;
        private static List<string> labelList = new List<string>();
        private static TreeNode curNode;
        private static Dictionary<int, string> labelDic = new Dictionary<int, string>();
        #endregion

        #region CONSTRUCTOR

        public MainForm()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.DoubleBuffer, true);// 双缓冲
            InitializeComponent();
            //当窗体大小发生改变时，Panel自动变化
            this.Resize += Form1_Resize;
            this.RenameFolder += UpdateFolder;
        }
        #endregion

        #region BUILD TREE FOLDER
        private DataTable GetFolder()
        {
            DataTable dt = SQLHelper.GetFoldersTable();
            return dt;
        }

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
            foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
            {
                object obj = null;
                if (childRow["Type"].ToInt() == 0)
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
            TreeNode root = new TreeNode("文件系统", 2, 2);
            root.Tag = Enums.ROOT;
            tv.Nodes.Add(root);//添加根节点
            foreach (DataRow item in ds.Tables[0].Rows)//将一级节点的父节点设置为NULL
            {
                if (string.IsNullOrEmpty(item[Enums.ParentId.ToString()].ToString()))
                {
                    item[Enums.ParentId.ToString()] = DBNull.Value;

                }
            }
            //建立表内字段关系
            DataRelation rs = new DataRelation("NodeRelation", ds.Tables[0].Columns[Enums.Id.ToString()], ds.Tables[0].Columns[Enums.ParentId.ToString()], false);
            ds.Relations.Add(rs);

            foreach (DataRow dbRow in ds.Tables[0].Rows)
            {
                if (dbRow.IsNull(Enums.ParentId.ToString()))
                {
                    int id = Convert.ToInt32(dbRow[Enums.Id.ToString()]);
                    DataTable dt = SQLHelper.GetNameById(id);
                    TreeNode newNode = CreateNode(dbRow[Enums.Title.ToString()].ToString(), dt.Rows[0][0].ToString());
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

            if (this.Height < 498)
            {
                this.Height = 498;
            }
            if (this.Width < 1015)
            {
                this.Width = 1015;
            }
            //Panel_Tree
            panel_Tree.Height = this.Height - 75;
            this.tv_Folder.Height = panel_Tree.Height - 14 - this.btn_Add.Height;
            this.btn_Add.Location = new Point(3, tv_Folder.Height + 9);

            //Panel_Article
            panel_Article.Height = this.Height - 75;
            txt_Content.Height = panel_Article.Height - txt_Content.Location.Y - panel_SeleSave.Height - 14;
            panel_SeleSave.Location = new Point(3, txt_Content.Height + txt_Content.Location.Y + 5);

            //Panel_Main
            panel_Main.Height = this.Height - 75;
            panel_List.Height = panel_Main.Height - panel_LabelFixed.Location.Y - panel_LabelFixed.Height - 14;


            //int vCommonWidth = this.Width - panel_Main.Location.X -14;
            ////this.panel_Main.Width = vCommonWidth-4;
            //this.panel_Label.Width = vCommonWidth-4;
            //this.panel_LabelFixed.Width = vCommonWidth;
            //this.panel_List.Width = vCommonWidth;
            ////int vCommonWidth = this.Width - panel_Article.Location.X - panel_Article.Width - 24;
            //this.panel_Main.Width = vCommonWidth - 24;
            //this.panel_Label.Width = this.panel_Main.Width - 4;
        }
        private void btn_ClearLabel_Click(object sender, EventArgs e)
        {
            //ClearControls(flowLayoutPanel1);
            //清空控件的选择状态，而不是清空控件
            foreach (LabelWithCheck item in flowLayoutPanel1.Controls)
            {
                if (item.LabelChecked)
                {
                    item.LabelChecked = false;
                }
            }
        }

        private void btn_ClearFixLabel_Click(object sender, EventArgs e)
        {
            //ClearControls(flowLayoutPanel2);
            foreach (LabelWithCheck item in flowLayoutPanel2.Controls)
            {
                if (item.LabelChecked)
                {
                    item.LabelChecked = false;
                }
            }
        }
        //
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

        //单击
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
                            txt_SelectedLabel.Text = string.Empty;
                            int id = node.Name.ToInt();
                            DataTable articles = SQLHelper.GetListByFolderId(id);
                            if (articles.Rows.Count > 0)
                            {
                                foreach (DataRow item in articles.Rows)
                                {
                                    int cid = item["Id"].ToInt();
                                    if (!string.IsNullOrEmpty(cid.ToString()))
                                    {
                                        DataTable labels = SQLHelper.GetTagsByPostId(cid);//取得一篇文章里的所有书签
                                        if (labels.Rows.Count > 0)
                                        {
                                            foreach (DataRow aticle in labels.Rows)
                                            {
                                                AddLabelToLocation(flowLayoutPanel1, 6, aticle["tagContent"].ToString(), aticle["tagId"].ToInt(), false,false);
                                            }
                                        }
                                    }
                                }
                            }
                            ShowListOnPanel(articles, this.panel_List);
                        }
                        if (node.Tag.ToString() == Enums.LEAVES.ToString())
                        {
                            this.lbl_CurrentNode.Text = "当前节点：" + node.Text;
                            ClearControls(flowLayoutPanel1);
                            int cid = node.Name.ToInt();
                            //new TipsForm().Show(cid.ToString());
                            DataTable labels = SQLHelper.GetTagsByPostId(cid);//取得一篇文章里的所有书签
                            if (labels.Rows.Count > 0)
                            {
                                foreach (DataRow aticle in labels.Rows)
                                {
                                    AddLabelToLocation(flowLayoutPanel1, 6, aticle["tagContent"].ToString(), aticle["tagId"].ToInt(), true,false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //isClickOnNode = false;
                }
            }
        }
        //双击
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
                            int Id = node.Name.ToInt();
                            txt_Content.Text = SQLHelper.GetContentById(Id);
                            txt_Title.Text = node.Text;
                        }
                    }
                }
            }
        }
        //选择标签
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
        //新增文章
        private void btn_Add_Click(object sender, EventArgs e)
        {
            TipsForm tf = new TipsForm();
            //添加文章，直接在文本框中输入标题内容，再选择节点（右侧直接出现该节点下所有文章）和标签
            //点击添加后，右侧尾部追加该文章
            if (string.IsNullOrEmpty(txt_Content.Text) || string.IsNullOrEmpty(txt_Title.Text))
            {
                tf.Show("标题或内容不能为空！");
                return;
            }
            TreeNode curNode = tv_Folder.SelectedNode;
            if (curNode == null)
            {
                tf.Show("请为该文章分配目录！");
                return;
            }

            AddLabelToLocation(panel_List, this.txt_Content.Text);
            this.txt_Title.Text = string.Empty;
            this.txt_Content.Text = string.Empty;

        }
        //保存文章
        private void btn_Save_Click(object sender, EventArgs e)
        {
            TreeNode node = tv_Folder.SelectedNode;
            TipsForm tf = new TipsForm();
            if (node == null)
            {
                return;
            }
            if (node.Tag.ToString() == Enums.LEAVES.ToString())
            {
                //同时更新标题和内容
                int i = SQLHelper.UpdateContent(node.Name.ToInt(), txt_Title.Text, txt_Content.Text);
                //同时更新文章标签
                if (!string.IsNullOrEmpty(txt_SelectedLabel.Text))
                {

                }
                //同时重新加载Treeview
                BuildTree(this.tv_Folder, GetFolderSet());
                if (i > 0)
                {
                    tf.Show("保存成功！");
                }
            }
        }
        #endregion

        #region DELEGATE
        public delegate void RenameFolderEventHandler(TreeNode node, string name);
        public event RenameFolderEventHandler RenameFolder;
        #endregion

        #region COMMON METHOD
        //清除LabelWithCheck控件
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
        public void AddLabelToLocation(FlowLayoutPanel flp, int column, string tag, int Id, bool ischecked,bool registerEvent)
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
        //选择标签，用于“选中标签”并同步到数据库
        private void Label_LabelCheckedEvent(object sender, LabelWithCheckEventArgs e)
        {
            TipsForm tf = new TipsForm();
            CheckBox lc = (CheckBox)sender;
            CheckState cs = lc.CheckState;
            if (cs.ToString() == "Checked")
            {
                labels = e.LabelText;
                labelsId = e.Id;
                if (labelDic.ContainsValue(labels))
                {
                    tf.Show("不能重复添加标签！");
                    return;
                }
                labelDic.Add(labelsId, labels);
                //将关联存入数据库
                curNode = tv_Folder.SelectedNode;
                if (curNode == null)
                {
                    tf.Show("请选择文章节点！");
                    return;
                }
                if (curNode.Tag.ToString() == Enums.LEAVES.ToString())
                {
                    int i = SQLHelper.AddRelations(curNode.Name.ToInt(), e.Id);
                    if (i < 0)
                    {
                        tf.Show("关联ID出错");
                    }
                }
            }
            else if (cs.ToString() == "Unchecked")
            {
                labelDic.Remove(e.Id);
                //将关联移出数据库
                curNode = tv_Folder.SelectedNode;
                if (curNode == null)
                {
                    tf.Show("尚未选择文章！");
                    return;
                }
                if (curNode.Tag.ToString() == Enums.LEAVES.ToString())
                {
                    int i = SQLHelper.RemoveRelations(curNode.Name.ToInt(), e.Id);
                    if (i < 0)
                    {
                        tf.Show("移除关联ID出错");
                    }
                }
            }
            txt_SelectedLabel.Text = ShowLabel(labelDic);
        }

        //选择标签，用于“编辑”过滤F区域文章
        private void Label_LabelSelectEvent(object sender, LabelWithCheckEventArgs e)
        {
            AddLabelToLocation(flowLayoutPanel2,6,e.LabelText,e.Id,false,false); //Stack Overflow 重复绑定重复执行 形成无限循环导致
        }

        public void ShowListOnPanel(DataTable dt, FlowLayoutPanel flp)
        {
            foreach (DataRow item in dt.Rows)
            {
                AddLabelToLocation(flp, item["Content"].ToString());
            }
        }

        public static void AddLabelToLocation(FlowLayoutPanel flp, string text)
        {
            int labelCount = flp.Controls.Count;
            LabelEx le = new LabelEx();
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
            le.Text = text;
            flp.Controls.Add(le);
            flp.ScrollControlIntoView(le);
        }

        private static void UpdateFolder(TreeNode node, string name)
        {
            //这里写你想更新到数据库的内容和相关的方法
            //发回数据到数据库
            int result = SQLHelper.UpdateFolder(node.Text, name, node.Name.ToInt());
            Debug.WriteLine(result);
            Debug.WriteLine(node.Text + "  " + name);
        }

        //文本框显示为文章添加的标签
        private static string ShowLabel(Dictionary<int, string> dic)
        {
            StringBuilder labels = new StringBuilder();
            foreach (KeyValuePair<int, string> item in dic)
            {
                labels.Append(item.Value);
                labels.Append(',');
            }
            return labels.ToString();
        }

        //打开标签库
        private void ShowLabelsList(bool isRegisterEvent)
        {
            TagSelector tag = new TagSelector();
            DataTable dt = SQLHelper.GetAllTags();
            foreach (DataRow item in dt.Rows)
            {
                AddLabelToLocation(tag.panel_Tags, 4, item["tagContent"].ToString(), item["tagId"].ToInt(), false, isRegisterEvent);
            }
            tag.Show();
        }
        #endregion

        #region CONTEXTMENUTRIPS

        private void 字体大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            //fontDialog.ShowDialog();
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {

                foreach (LabelEx item in this.panel_List.Controls)
                {
                    item.Font = fontDialog.Font;//将当前选定的文字改变字体　
                }
            }
        }
        private void 新建子文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = tv_Folder.SelectedNode;
            TipsForm tf = new TipsForm();
            PostContent post = null;
            int flag = -1;

            if (tn != null)
            {
                TreeNode node = new TreeNode("新建文件夹");
                node.ImageIndex = 1;
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

                post = new PostContent();
                post.Title = node.Text;
                post.Type = false;//目录 非文章
                post.ModifyDate = DateTime.Now;
                post.CreateDate = DateTime.Now;
                post.Content = string.Empty;
                if (tn.Tag.ToString() == Enums.ROOT.ToString())//如果是根节点
                {
                    post.ParentId = null;
                    flag = SQLHelper.InsertFolder(post, true);
                }
                else
                {
                    post.ParentId = SQLHelper.GetIdByName(tn.Text);
                    flag = SQLHelper.InsertFolder(post, false);
                }

                if (flag > 0)
                {
                    //tn.Nodes.Insert(folders, node);
                    tn.Nodes.Insert(tn.Nodes.Count, node);
                }
                else
                {
                    tf.Show("插入失败！");
                }

            }
        }
        private void tv_Folder_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //相应的判断逻辑
            UpdateFolder(e.Node, e.Label);
        }
        private void 重命名文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tv_Folder.SelectedNode;
            string newName = string.Empty;
            if (node != null)
            {
                node.BeginEdit();
            }
        }
        private void 添加新文章ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = tv_Folder.SelectedNode;
            TipsForm tf = new TipsForm();
            PostContent post = null;
            int flag = -1;
            if (tn != null)
            {
                TreeNode node = new TreeNode("新建文章");
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.Tag = Enums.LEAVES;
                //node.Name = (SQLHelper.GetMaxID(Enums.tagContent.ToString(),"Id") +1).ToString();
                node.Name = (SQLHelper.GetMaxID(Enums.Table_Content.ToString(), "Id") + 1).ToString();
                post = new PostContent();
                post.Title = node.Text;
                post.Type = true;//目录 非文章
                post.ModifyDate = DateTime.Now;
                post.CreateDate = DateTime.Now;
                post.Content = "请输入内容";

                //if (tn.Tag.ToString() == Enums.ROOT.ToString())//如果是根节点
                //{
                //    post.ParentId = null;
                //    flag = SQLHelper.InsertFolder(post, true);
                //}
                //else
                {
                    post.ParentId = SQLHelper.GetIdByName(tn.Text);
                    flag = SQLHelper.InsertFolder(post, false);
                }

                if (flag > 0)
                {
                    //tn.Nodes.Insert(folders, node);
                    tn.Nodes.Insert(tn.Nodes.Count, node);
                }
                else
                {
                    tf.Show("插入失败！");
                }
            }
        }
        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            重命名文件夹ToolStripMenuItem_Click(sender, e);
        }
        #endregion

    }

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
            catch (Exception ex)
            {

                MessageBox.Show("convert failed," + ex.ToString());
            }
            return i;
        }
    }
}
