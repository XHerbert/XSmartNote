using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using KnowledgeManager.Model;
using System.Collections.Generic;
using System.Text;
using CCWin.SkinControl;
using CCWin;


namespace KnowledgeManager
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
            FitScreen();
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
            TreeNode root = new TreeNode("知识体系", 2, 2);
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

            if (this.Height < 550)//498
            {
                this.Height = 550;
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
            KeepSizeWithMainForm(this.panel_List);
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
                            int Id = node.Name.ToInt();
                            txt_Content.Text = SQLHelper.GetContentById(Id);
                            txt_Title.Text = node.Text;
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
            if (string.IsNullOrEmpty(txt_Content.Text) || string.IsNullOrEmpty(txt_Title.Text))
            {
                MessageBoxEx.Show("标题或内容不能为空！", "注意", MessageBoxButtons.OK);
                return;
            }
            TreeNode curNode = tv_Folder.SelectedNode;
            if (curNode == null)
            {
                MessageBoxEx.Show("请为该文章分配目录！", "注意", MessageBoxButtons.OK);
                return;
            }

            AddLabelToLocation(panel_List, this.txt_Content.Text);
            this.txt_Title.Text = string.Empty;
            this.txt_Content.Text = string.Empty;

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
                    MessageBoxEx.Show("保存成功！", "提示", MessageBoxButtons.OK);
                }
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
        /// <summary>
        /// 选择标签，用于“选中标签”并同步到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_LabelCheckedEvent(object sender, LabelWithCheckEventArgs e)
        {
            CheckBox lc = (CheckBox)sender;
            CheckState cs = lc.CheckState;
            if (cs.ToString() == "Checked")
            {
                labels = e.LabelText;
                labelsId = e.Id;
                if (labelDic.ContainsValue(labels))
                {
                    MessageBoxEx.Show("不能重复添加标签！", "注意", MessageBoxButtons.OK);
                    return;
                }
                labelDic.Add(labelsId, labels);
                //将关联存入数据库
                curNode = tv_Folder.SelectedNode;
                if (curNode == null)
                {
                    MessageBoxEx.Show("请选择文章节点！", "注意", MessageBoxButtons.OK);
                    return;
                }
                if (curNode.Tag.ToString() == Enums.LEAVES.ToString())
                {
                    int i = SQLHelper.AddRelations(curNode.Name.ToInt(), e.Id);
                    if (i < 0)
                    {
                        MessageBoxEx.Show("关联ID出错！", "注意", MessageBoxButtons.OK);
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
                    MessageBoxEx.Show("尚未选择文章！", "注意", MessageBoxButtons.OK);
                    return;
                }
                if (curNode.Tag.ToString() == Enums.LEAVES.ToString())
                {
                    int i = SQLHelper.RemoveRelations(curNode.Name.ToInt(), e.Id);
                    if (i < 0)
                    {
                        MessageBoxEx.Show("移除关联ID出错！", "注意", MessageBoxButtons.OK);
                    }
                }
            }
            txt_SelectedLabel.Text = ShowLabel(labelDic);
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
        public void ShowListOnPanel(DataTable dt, FlowLayoutPanel flp)
        {
            foreach (DataRow item in dt.Rows)
            {
                AddLabelToLocation(flp, item["Content"].ToString());
            }
        }

        /// <summary>
        /// 将Note添加在面板的指定位置
        /// </summary>
        /// <param name="flp"></param>
        /// <param name="text"></param>
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

        /// <summary>
        /// 更新文件夹树
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        private static void UpdateFolder(TreeNode node, string name)
        {
            //这里写你想更新到数据库的内容和相关的方法
            //发回数据到数据库
            int result = SQLHelper.UpdateFolder(node.Text, name, node.Name.ToInt());
            Debug.WriteLine(result);
            Debug.WriteLine(node.Text + "  " + name);
        }

        /// <summary>
        /// 文本框显示为文章添加的标签
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 打开标签库
        /// </summary>
        /// <param name="isRegisterEvent"></param>
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
            x = x * 4/5;
            y = y * 4/5;
            //Console.WriteLine(string.Format("X:{0}", x));
            //Console.WriteLine(string.Format("Y:{0}", y));
        }

        /// <summary>
        /// 设置窗体宽度高度为屏幕的80%
        /// </summary>
        private void FitScreen()
        {
            int X, Y = 0;
            GetScreenSize(out X, out Y);
            this.Width = X;
            this.Height = Y;
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
           // TipsForm tf = new TipsForm();
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
                    MessageBoxEx.Show("数据插入失败！", "注意", MessageBoxButtons.OK);
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
                    MessageBoxEx.Show("数据插入失败！", "注意", MessageBoxButtons.OK);
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
