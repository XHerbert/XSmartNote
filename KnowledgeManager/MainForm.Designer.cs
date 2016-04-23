namespace KnowledgeManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSizeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.theme = new System.Windows.Forms.ToolStripMenuItem();
            this.bg_Line = new System.Windows.Forms.ToolStripMenuItem();
            this.roseRed = new System.Windows.Forms.ToolStripMenuItem();
            this.stoneBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.lightGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.yellow = new System.Windows.Forms.ToolStripMenuItem();
            this.bone = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Tree = new System.Windows.Forms.Panel();
            this.tv_Folder = new System.Windows.Forms.TreeView();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.btn_Add = new CCWin.SkinControl.SkinButton();
            this.panel_Article = new System.Windows.Forms.Panel();
            this.panel_SeleSave = new System.Windows.Forms.Panel();
            this.btn_ChooseLabel = new CCWin.SkinControl.SkinButton();
            this.btn_Save = new CCWin.SkinControl.SkinButton();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.panel_List = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_LabelFixed = new System.Windows.Forms.Panel();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_EditLabel = new CCWin.SkinControl.SkinButton();
            this.btn_ClearFixLabel = new CCWin.SkinControl.SkinButton();
            this.panel_Label = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_ClearLabel = new CCWin.SkinControl.SkinButton();
            this.tree_folder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tree_NewSubFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tree_DeleteFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tree_NewNoteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tree_RenameFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tree_article = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tree_EditNoteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tree_DeleteNoteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tree_RenameNoteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_CurrentNode = new System.Windows.Forms.Label();
            this.skinLine2 = new CCWin.SkinControl.SkinLine();
            this.txt_Content = new KnowledgeManager.Controls.TextBoxEx();
            this.txt_Title = new KnowledgeManager.Controls.TextBoxEx();
            this.txt_SelectedLabel = new KnowledgeManager.Controls.TextBoxEx();
            this.menuStrip1.SuspendLayout();
            this.panel_Tree.SuspendLayout();
            this.panel_Article.SuspendLayout();
            this.panel_SeleSave.SuspendLayout();
            this.panel_Main.SuspendLayout();
            this.panel_LabelFixed.SuspendLayout();
            this.panel_Label.SuspendLayout();
            this.tree_folder.SuspendLayout();
            this.tree_article.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.SetMenu,
            this.theme,
            this.HelpMenu,
            this.AboutMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(223, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenu,
            this.OpenMenu,
            this.SaveMenu});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(43, 20);
            this.FileMenu.Text = "文件";
            // 
            // NewMenu
            // 
            this.NewMenu.Image = ((System.Drawing.Image)(resources.GetObject("NewMenu.Image")));
            this.NewMenu.Name = "NewMenu";
            this.NewMenu.Size = new System.Drawing.Size(152, 22);
            this.NewMenu.Text = "新建";
            // 
            // OpenMenu
            // 
            this.OpenMenu.Image = ((System.Drawing.Image)(resources.GetObject("OpenMenu.Image")));
            this.OpenMenu.Name = "OpenMenu";
            this.OpenMenu.Size = new System.Drawing.Size(152, 22);
            this.OpenMenu.Text = "打开";
            // 
            // SaveMenu
            // 
            this.SaveMenu.Image = ((System.Drawing.Image)(resources.GetObject("SaveMenu.Image")));
            this.SaveMenu.Name = "SaveMenu";
            this.SaveMenu.Size = new System.Drawing.Size(152, 22);
            this.SaveMenu.Text = "保存";
            // 
            // SetMenu
            // 
            this.SetMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FontSizeMenu});
            this.SetMenu.Name = "SetMenu";
            this.SetMenu.Size = new System.Drawing.Size(43, 20);
            this.SetMenu.Text = "设置";
            // 
            // FontSizeMenu
            // 
            this.FontSizeMenu.Name = "FontSizeMenu";
            this.FontSizeMenu.Size = new System.Drawing.Size(122, 22);
            this.FontSizeMenu.Text = "字体大小";
            this.FontSizeMenu.Click += new System.EventHandler(this.FontSizeMenu_Click);
            // 
            // theme
            // 
            this.theme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bg_Line});
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(43, 20);
            this.theme.Text = "主题";
            // 
            // bg_Line
            // 
            this.bg_Line.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roseRed,
            this.stoneBlue,
            this.lightGreen,
            this.yellow,
            this.bone});
            this.bg_Line.Name = "bg_Line";
            this.bg_Line.Size = new System.Drawing.Size(122, 22);
            this.bg_Line.Text = "主题纹理";
            // 
            // roseRed
            // 
            this.roseRed.Name = "roseRed";
            this.roseRed.Size = new System.Drawing.Size(110, 22);
            this.roseRed.Text = "玫瑰红";
            this.roseRed.Click += new System.EventHandler(this.roseRed_Click);
            // 
            // stoneBlue
            // 
            this.stoneBlue.Name = "stoneBlue";
            this.stoneBlue.Size = new System.Drawing.Size(110, 22);
            this.stoneBlue.Text = "宝石蓝";
            this.stoneBlue.Click += new System.EventHandler(this.stoneBlue_Click);
            // 
            // lightGreen
            // 
            this.lightGreen.Name = "lightGreen";
            this.lightGreen.Size = new System.Drawing.Size(110, 22);
            this.lightGreen.Text = "青葱绿";
            this.lightGreen.Click += new System.EventHandler(this.lightGreen_Click);
            // 
            // yellow
            // 
            this.yellow.Name = "yellow";
            this.yellow.Size = new System.Drawing.Size(110, 22);
            this.yellow.Text = "小鸭黄";
            this.yellow.Click += new System.EventHandler(this.yellow_Click);
            // 
            // bone
            // 
            this.bone.Name = "bone";
            this.bone.Size = new System.Drawing.Size(110, 22);
            this.bone.Text = "青花瓷";
            this.bone.Click += new System.EventHandler(this.bone_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(43, 20);
            this.HelpMenu.Text = "帮助";
            // 
            // AboutMenu
            // 
            this.AboutMenu.Name = "AboutMenu";
            this.AboutMenu.Size = new System.Drawing.Size(43, 20);
            this.AboutMenu.Text = "关于";
            // 
            // panel_Tree
            // 
            this.panel_Tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Tree.Controls.Add(this.tv_Folder);
            this.panel_Tree.Controls.Add(this.btn_Add);
            this.panel_Tree.Location = new System.Drawing.Point(12, 27);
            this.panel_Tree.Name = "panel_Tree";
            this.panel_Tree.Size = new System.Drawing.Size(174, 423);
            this.panel_Tree.TabIndex = 1;
            // 
            // tv_Folder
            // 
            this.tv_Folder.BackColor = System.Drawing.Color.MistyRose;
            this.tv_Folder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_Folder.ImageIndex = 0;
            this.tv_Folder.ImageList = this.images;
            this.tv_Folder.Indent = 19;
            this.tv_Folder.LabelEdit = true;
            this.tv_Folder.Location = new System.Drawing.Point(3, 3);
            this.tv_Folder.Name = "tv_Folder";
            this.tv_Folder.SelectedImageIndex = 1;
            this.tv_Folder.Size = new System.Drawing.Size(166, 422);
            this.tv_Folder.TabIndex = 0;
            this.tv_Folder.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tv_Folder_AfterLabelEdit);
            this.tv_Folder.Click += new System.EventHandler(this.tv_Folder_Click);
            this.tv_Folder.DoubleClick += new System.EventHandler(this.tv_Folder_DoubleClick);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "text_dropcaps.png");
            this.images.Images.SetKeyName(1, "folder.png");
            this.images.Images.SetKeyName(2, "2.png");
            this.images.Images.SetKeyName(3, "text_columns.png");
            this.images.Images.SetKeyName(4, "style.png");
            this.images.Images.SetKeyName(5, "page_2.png");
            this.images.Images.SetKeyName(6, "cross.png");
            this.images.Images.SetKeyName(7, "book.png");
            this.images.Images.SetKeyName(8, "note.png");
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_Add.BaseColor = System.Drawing.Color.Silver;
            this.btn_Add.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Add.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Add.DownBack = null;
            this.btn_Add.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Add.Location = new System.Drawing.Point(3, 396);
            this.btn_Add.MouseBack = null;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.NormlBack = null;
            this.btn_Add.Size = new System.Drawing.Size(166, 23);
            this.btn_Add.TabIndex = 19;
            this.btn_Add.Text = "添加文章";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Visible = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // panel_Article
            // 
            this.panel_Article.BackColor = System.Drawing.Color.Transparent;
            this.panel_Article.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Article.Controls.Add(this.txt_Content);
            this.panel_Article.Controls.Add(this.txt_Title);
            this.panel_Article.Controls.Add(this.panel_SeleSave);
            this.panel_Article.Location = new System.Drawing.Point(192, 27);
            this.panel_Article.Name = "panel_Article";
            this.panel_Article.Size = new System.Drawing.Size(200, 423);
            this.panel_Article.TabIndex = 2;
            // 
            // panel_SeleSave
            // 
            this.panel_SeleSave.BackColor = System.Drawing.Color.Transparent;
            this.panel_SeleSave.Controls.Add(this.txt_SelectedLabel);
            this.panel_SeleSave.Controls.Add(this.btn_ChooseLabel);
            this.panel_SeleSave.Controls.Add(this.btn_Save);
            this.panel_SeleSave.Location = new System.Drawing.Point(3, 332);
            this.panel_SeleSave.Name = "panel_SeleSave";
            this.panel_SeleSave.Size = new System.Drawing.Size(194, 86);
            this.panel_SeleSave.TabIndex = 5;
            // 
            // btn_ChooseLabel
            // 
            this.btn_ChooseLabel.BackColor = System.Drawing.Color.Transparent;
            this.btn_ChooseLabel.BaseColor = System.Drawing.Color.Silver;
            this.btn_ChooseLabel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_ChooseLabel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_ChooseLabel.DownBack = null;
            this.btn_ChooseLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ChooseLabel.ForeColor = System.Drawing.Color.DimGray;
            this.btn_ChooseLabel.GlowColor = System.Drawing.Color.Blue;
            this.btn_ChooseLabel.Location = new System.Drawing.Point(1, 3);
            this.btn_ChooseLabel.MouseBack = null;
            this.btn_ChooseLabel.Name = "btn_ChooseLabel";
            this.btn_ChooseLabel.NormlBack = null;
            this.btn_ChooseLabel.Size = new System.Drawing.Size(192, 23);
            this.btn_ChooseLabel.TabIndex = 20;
            this.btn_ChooseLabel.Text = "选择标签";
            this.btn_ChooseLabel.UseVisualStyleBackColor = false;
            this.btn_ChooseLabel.Click += new System.EventHandler(this.btn_ChooseLabel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save.BaseColor = System.Drawing.Color.Silver;
            this.btn_Save.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Save.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Save.DownBack = null;
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Save.GlowColor = System.Drawing.Color.DarkGreen;
            this.btn_Save.Location = new System.Drawing.Point(1, 59);
            this.btn_Save.MouseBack = null;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.NormlBack = null;
            this.btn_Save.Size = new System.Drawing.Size(192, 23);
            this.btn_Save.TabIndex = 21;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.Color.MistyRose;
            this.panel_Main.Controls.Add(this.panel_List);
            this.panel_Main.Controls.Add(this.panel_LabelFixed);
            this.panel_Main.Controls.Add(this.panel_Label);
            this.panel_Main.Location = new System.Drawing.Point(398, 27);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(589, 423);
            this.panel_Main.TabIndex = 3;
            this.panel_Main.TabStop = true;
            // 
            // panel_List
            // 
            this.panel_List.AutoScroll = true;
            this.panel_List.Location = new System.Drawing.Point(3, 147);
            this.panel_List.Name = "panel_List";
            this.panel_List.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel_List.Size = new System.Drawing.Size(581, 271);
            this.panel_List.TabIndex = 1;
            // 
            // panel_LabelFixed
            // 
            this.panel_LabelFixed.AutoScroll = true;
            this.panel_LabelFixed.Controls.Add(this.skinLine1);
            this.panel_LabelFixed.Controls.Add(this.flowLayoutPanel2);
            this.panel_LabelFixed.Controls.Add(this.btn_EditLabel);
            this.panel_LabelFixed.Controls.Add(this.btn_ClearFixLabel);
            this.panel_LabelFixed.Location = new System.Drawing.Point(3, 75);
            this.panel_LabelFixed.Name = "panel_LabelFixed";
            this.panel_LabelFixed.Size = new System.Drawing.Size(581, 66);
            this.panel_LabelFixed.TabIndex = 0;
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.Maroon;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(1, -1);
            this.skinLine1.Margin = new System.Windows.Forms.Padding(0);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(579, 2);
            this.skinLine1.TabIndex = 6;
            this.skinLine1.Text = "skinLine1";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(511, 59);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // btn_EditLabel
            // 
            this.btn_EditLabel.BackColor = System.Drawing.Color.Transparent;
            this.btn_EditLabel.BaseColor = System.Drawing.Color.Silver;
            this.btn_EditLabel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_EditLabel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_EditLabel.DownBack = null;
            this.btn_EditLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_EditLabel.ForeColor = System.Drawing.Color.DimGray;
            this.btn_EditLabel.GlowColor = System.Drawing.Color.Maroon;
            this.btn_EditLabel.Location = new System.Drawing.Point(520, 7);
            this.btn_EditLabel.MouseBack = null;
            this.btn_EditLabel.Name = "btn_EditLabel";
            this.btn_EditLabel.NormlBack = null;
            this.btn_EditLabel.Size = new System.Drawing.Size(56, 23);
            this.btn_EditLabel.TabIndex = 22;
            this.btn_EditLabel.Text = "编辑";
            this.btn_EditLabel.UseVisualStyleBackColor = false;
            this.btn_EditLabel.Click += new System.EventHandler(this.btn_EditLabel_Click);
            // 
            // btn_ClearFixLabel
            // 
            this.btn_ClearFixLabel.BackColor = System.Drawing.Color.Transparent;
            this.btn_ClearFixLabel.BaseColor = System.Drawing.Color.Silver;
            this.btn_ClearFixLabel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_ClearFixLabel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_ClearFixLabel.DownBack = null;
            this.btn_ClearFixLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClearFixLabel.ForeColor = System.Drawing.Color.DimGray;
            this.btn_ClearFixLabel.GlowColor = System.Drawing.Color.DarkOrchid;
            this.btn_ClearFixLabel.Location = new System.Drawing.Point(520, 39);
            this.btn_ClearFixLabel.MouseBack = null;
            this.btn_ClearFixLabel.Name = "btn_ClearFixLabel";
            this.btn_ClearFixLabel.NormlBack = null;
            this.btn_ClearFixLabel.Size = new System.Drawing.Size(56, 23);
            this.btn_ClearFixLabel.TabIndex = 23;
            this.btn_ClearFixLabel.Text = "清空";
            this.btn_ClearFixLabel.UseVisualStyleBackColor = false;
            this.btn_ClearFixLabel.Click += new System.EventHandler(this.btn_ClearFixLabel_Click);
            // 
            // panel_Label
            // 
            this.panel_Label.AutoScroll = true;
            this.panel_Label.Controls.Add(this.flowLayoutPanel1);
            this.panel_Label.Controls.Add(this.btn_ClearLabel);
            this.panel_Label.Location = new System.Drawing.Point(3, 3);
            this.panel_Label.Name = "panel_Label";
            this.panel_Label.Size = new System.Drawing.Size(581, 66);
            this.panel_Label.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(511, 59);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // btn_ClearLabel
            // 
            this.btn_ClearLabel.BackColor = System.Drawing.Color.Transparent;
            this.btn_ClearLabel.BaseColor = System.Drawing.Color.Silver;
            this.btn_ClearLabel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_ClearLabel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_ClearLabel.DownBack = null;
            this.btn_ClearLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClearLabel.ForeColor = System.Drawing.Color.DimGray;
            this.btn_ClearLabel.GlowColor = System.Drawing.Color.Maroon;
            this.btn_ClearLabel.Location = new System.Drawing.Point(520, 2);
            this.btn_ClearLabel.MouseBack = null;
            this.btn_ClearLabel.Name = "btn_ClearLabel";
            this.btn_ClearLabel.NormlBack = null;
            this.btn_ClearLabel.Size = new System.Drawing.Size(56, 60);
            this.btn_ClearLabel.TabIndex = 18;
            this.btn_ClearLabel.Text = "清空";
            this.btn_ClearLabel.UseVisualStyleBackColor = false;
            this.btn_ClearLabel.Click += new System.EventHandler(this.btn_ClearLabel_Click);
            // 
            // tree_folder
            // 
            this.tree_folder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tree_NewSubFolderMenuItem,
            this.Tree_DeleteFolderMenuItem,
            this.Tree_NewNoteMenuItem,
            this.Tree_RenameFolderMenuItem});
            this.tree_folder.Name = "tree_MenuStrip";
            this.tree_folder.Size = new System.Drawing.Size(147, 92);
            // 
            // Tree_NewSubFolderMenuItem
            // 
            this.Tree_NewSubFolderMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Tree_NewSubFolderMenuItem.Image")));
            this.Tree_NewSubFolderMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.Tree_NewSubFolderMenuItem.Name = "Tree_NewSubFolderMenuItem";
            this.Tree_NewSubFolderMenuItem.Size = new System.Drawing.Size(146, 22);
            this.Tree_NewSubFolderMenuItem.Text = "新建子文件夹";
            this.Tree_NewSubFolderMenuItem.Click += new System.EventHandler(this.Tree_NewSubFolderMenuItem_Click);
            // 
            // Tree_DeleteFolderMenuItem
            // 
            this.Tree_DeleteFolderMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Tree_DeleteFolderMenuItem.Image")));
            this.Tree_DeleteFolderMenuItem.Name = "Tree_DeleteFolderMenuItem";
            this.Tree_DeleteFolderMenuItem.Size = new System.Drawing.Size(146, 22);
            this.Tree_DeleteFolderMenuItem.Text = "删除该文件夹";
            this.Tree_DeleteFolderMenuItem.Click += new System.EventHandler(this.Tree_DeleteFolderMenuItem_Click);
            // 
            // Tree_NewNoteMenuItem
            // 
            this.Tree_NewNoteMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Tree_NewNoteMenuItem.Image")));
            this.Tree_NewNoteMenuItem.Name = "Tree_NewNoteMenuItem";
            this.Tree_NewNoteMenuItem.Size = new System.Drawing.Size(146, 22);
            this.Tree_NewNoteMenuItem.Text = "添加新文章";
            this.Tree_NewNoteMenuItem.Click += new System.EventHandler(this.Tree_NewNoteMenuItem_Click);
            // 
            // Tree_RenameFolderMenuItem
            // 
            this.Tree_RenameFolderMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Tree_RenameFolderMenuItem.Image")));
            this.Tree_RenameFolderMenuItem.Name = "Tree_RenameFolderMenuItem";
            this.Tree_RenameFolderMenuItem.Size = new System.Drawing.Size(146, 22);
            this.Tree_RenameFolderMenuItem.Text = "重命名文件夹";
            this.Tree_RenameFolderMenuItem.Click += new System.EventHandler(this.Tree_RenameFolderMenuItem_Click);
            // 
            // tree_article
            // 
            this.tree_article.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tree_EditNoteMenuItem,
            this.Tree_DeleteNoteMenuItem,
            this.Tree_RenameNoteMenuItem});
            this.tree_article.Name = "tree_article";
            this.tree_article.Size = new System.Drawing.Size(123, 70);
            // 
            // Tree_EditNoteMenuItem
            // 
            this.Tree_EditNoteMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Tree_EditNoteMenuItem.Image")));
            this.Tree_EditNoteMenuItem.Name = "Tree_EditNoteMenuItem";
            this.Tree_EditNoteMenuItem.Size = new System.Drawing.Size(122, 22);
            this.Tree_EditNoteMenuItem.Text = "编辑文章";
            this.Tree_EditNoteMenuItem.Click += new System.EventHandler(this.Tree_EditNoteMenuItem_Click);
            // 
            // Tree_DeleteNoteMenuItem
            // 
            this.Tree_DeleteNoteMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Tree_DeleteNoteMenuItem.Image")));
            this.Tree_DeleteNoteMenuItem.Name = "Tree_DeleteNoteMenuItem";
            this.Tree_DeleteNoteMenuItem.Size = new System.Drawing.Size(122, 22);
            this.Tree_DeleteNoteMenuItem.Text = "删除文章";
            this.Tree_DeleteNoteMenuItem.Click += new System.EventHandler(this.Tree_DeleteNoteMenuItem_Click);
            // 
            // Tree_RenameNoteMenuItem
            // 
            this.Tree_RenameNoteMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Tree_RenameNoteMenuItem.Image")));
            this.Tree_RenameNoteMenuItem.Name = "Tree_RenameNoteMenuItem";
            this.Tree_RenameNoteMenuItem.Size = new System.Drawing.Size(122, 22);
            this.Tree_RenameNoteMenuItem.Text = "重命名";
            this.Tree_RenameNoteMenuItem.Click += new System.EventHandler(this.Tree_RenameNoteMenuItem_Click);
            // 
            // lbl_CurrentNode
            // 
            this.lbl_CurrentNode.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CurrentNode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CurrentNode.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_CurrentNode.Location = new System.Drawing.Point(13, 463);
            this.lbl_CurrentNode.Name = "lbl_CurrentNode";
            this.lbl_CurrentNode.Size = new System.Drawing.Size(336, 19);
            this.lbl_CurrentNode.TabIndex = 4;
            this.lbl_CurrentNode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skinLine2
            // 
            this.skinLine2.BackColor = System.Drawing.Color.Transparent;
            this.skinLine2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.skinLine2.LineHeight = 2;
            this.skinLine2.Location = new System.Drawing.Point(403, 170);
            this.skinLine2.Margin = new System.Windows.Forms.Padding(0);
            this.skinLine2.Name = "skinLine2";
            this.skinLine2.Size = new System.Drawing.Size(579, 1);
            this.skinLine2.TabIndex = 7;
            this.skinLine2.Text = "skinLine2";
            // 
            // txt_Content
            // 
            this.txt_Content.BackColor = System.Drawing.Color.MistyRose;
            this.txt_Content.BorderColor = System.Drawing.Color.Empty;
            this.txt_Content.BoxBackColor = System.Drawing.Color.MistyRose;
            this.txt_Content.ControlText = "请输入内容...";
            this.txt_Content.Location = new System.Drawing.Point(2, 40);
            this.txt_Content.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Content.Size = new System.Drawing.Size(194, 286);
            this.txt_Content.TabIndex = 0;
            this.txt_Content.WaterColor = System.Drawing.Color.Maroon;
            this.txt_Content.WaterText = "请输入内容...";
            // 
            // txt_Title
            // 
            this.txt_Title.BackColor = System.Drawing.Color.White;
            this.txt_Title.BorderColor = System.Drawing.Color.Empty;
            this.txt_Title.BoxBackColor = System.Drawing.Color.MistyRose;
            this.txt_Title.ControlText = "请输入标题";
            this.txt_Title.Location = new System.Drawing.Point(2, 3);
            this.txt_Title.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Title.Size = new System.Drawing.Size(194, 31);
            this.txt_Title.TabIndex = 0;
            this.txt_Title.WaterColor = System.Drawing.Color.Maroon;
            this.txt_Title.WaterText = "请输入标题";
            // 
            // txt_SelectedLabel
            // 
            this.txt_SelectedLabel.BackColor = System.Drawing.Color.White;
            this.txt_SelectedLabel.BorderColor = System.Drawing.Color.Empty;
            this.txt_SelectedLabel.BoxBackColor = System.Drawing.Color.MistyRose;
            this.txt_SelectedLabel.ControlText = "";
            this.txt_SelectedLabel.Location = new System.Drawing.Point(1, 30);
            this.txt_SelectedLabel.Margin = new System.Windows.Forms.Padding(0);
            this.txt_SelectedLabel.Name = "txt_SelectedLabel";
            this.txt_SelectedLabel.Padding = new System.Windows.Forms.Padding(5);
            this.txt_SelectedLabel.Size = new System.Drawing.Size(192, 26);
            this.txt_SelectedLabel.TabIndex = 22;
            this.txt_SelectedLabel.WaterColor = System.Drawing.Color.Empty;
            this.txt_SelectedLabel.WaterText = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KnowledgeManager.Properties.Resources.bg_10_03;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.ClientSize = new System.Drawing.Size(999, 493);
            this.Controls.Add(this.skinLine2);
            this.Controls.Add(this.lbl_CurrentNode);
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.panel_Article);
            this.Controls.Add(this.panel_Tree);
            this.Controls.Add(this.menuStrip1);
            this.EffectBack = System.Drawing.Color.DarkRed;
            this.EffectCaption = CCWin.TitleType.EffectTitle;
            this.EffectWidth = 4;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MdiBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Radius = 10;
            this.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.Shadow = true;
            this.ShadowRectangle = new System.Drawing.Rectangle(30, 30, 30, 30);
            this.ShadowWidth = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "万象知识管理 v8.88 ";
            this.TitleColor = System.Drawing.Color.Maroon;
            this.TitleOffset = new System.Drawing.Point(10, 2);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_Tree.ResumeLayout(false);
            this.panel_Article.ResumeLayout(false);
            this.panel_SeleSave.ResumeLayout(false);
            this.panel_Main.ResumeLayout(false);
            this.panel_LabelFixed.ResumeLayout(false);
            this.panel_Label.ResumeLayout(false);
            this.tree_folder.ResumeLayout(false);
            this.tree_article.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem NewMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenMenu;
        private System.Windows.Forms.ToolStripMenuItem SaveMenu;
        private System.Windows.Forms.ToolStripMenuItem SetMenu;
        private System.Windows.Forms.ToolStripMenuItem FontSizeMenu;
        private System.Windows.Forms.Panel panel_Tree;
        private System.Windows.Forms.Panel panel_Article;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.TreeView tv_Folder;
        private System.Windows.Forms.Panel panel_LabelFixed;
        private System.Windows.Forms.Panel panel_Label;
        private System.Windows.Forms.Panel panel_SeleSave;
        private System.Windows.Forms.ContextMenuStrip tree_folder;
        private System.Windows.Forms.ContextMenuStrip tree_article;
        private System.Windows.Forms.ToolStripMenuItem Tree_NewSubFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Tree_DeleteFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Tree_NewNoteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Tree_RenameFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Tree_EditNoteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Tree_DeleteNoteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Tree_RenameNoteMenuItem;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel panel_List;
        private System.Windows.Forms.Label lbl_CurrentNode;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.ToolStripMenuItem theme;
        private CCWin.SkinControl.SkinLine skinLine2;
        private CCWin.SkinControl.SkinButton btn_ClearLabel;
        private CCWin.SkinControl.SkinButton btn_Add;
        private CCWin.SkinControl.SkinButton btn_ChooseLabel;
        private CCWin.SkinControl.SkinButton btn_Save;
        private CCWin.SkinControl.SkinButton btn_EditLabel;
        private CCWin.SkinControl.SkinButton btn_ClearFixLabel;
        private System.Windows.Forms.ToolStripMenuItem AboutMenu;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem bg_Line;
        private System.Windows.Forms.ToolStripMenuItem roseRed;
        private System.Windows.Forms.ToolStripMenuItem stoneBlue;
        private System.Windows.Forms.ToolStripMenuItem lightGreen;
        private System.Windows.Forms.ToolStripMenuItem yellow;
        private System.Windows.Forms.ToolStripMenuItem bone;
        private Controls.TextBoxEx txt_Title;
        private Controls.TextBoxEx txt_Content;
        private Controls.TextBoxEx txt_SelectedLabel;
    }
}

