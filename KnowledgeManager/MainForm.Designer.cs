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
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字体大小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Tree = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.tv_Folder = new System.Windows.Forms.TreeView();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.panel_Article = new System.Windows.Forms.Panel();
            this.panel_SeleSave = new System.Windows.Forms.Panel();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_SelectedLabel = new System.Windows.Forms.TextBox();
            this.btn_ChooseLabel = new System.Windows.Forms.Button();
            this.txt_Content = new System.Windows.Forms.TextBox();
            this.txt_Title = new System.Windows.Forms.TextBox();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.panel_List = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_LabelFixed = new System.Windows.Forms.Panel();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_ClearFixLabel = new System.Windows.Forms.Button();
            this.btn_EditLabel = new System.Windows.Forms.Button();
            this.panel_Label = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_ClearLabel = new System.Windows.Forms.Button();
            this.tree_folder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建子文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除该文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加新文章ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tree_article = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑文章ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除文章ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_CurrentNode = new System.Windows.Forms.Label();
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
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(94, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新建ToolStripMenuItem.Image")));
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开ToolStripMenuItem.Image")));
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存ToolStripMenuItem.Image")));
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.字体大小ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 字体大小ToolStripMenuItem
            // 
            this.字体大小ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("字体大小ToolStripMenuItem.Image")));
            this.字体大小ToolStripMenuItem.Name = "字体大小ToolStripMenuItem";
            this.字体大小ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.字体大小ToolStripMenuItem.Text = "字体大小";
            this.字体大小ToolStripMenuItem.Click += new System.EventHandler(this.字体大小ToolStripMenuItem_Click);
            // 
            // panel_Tree
            // 
            this.panel_Tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Tree.Controls.Add(this.btn_Add);
            this.panel_Tree.Controls.Add(this.tv_Folder);
            this.panel_Tree.Location = new System.Drawing.Point(12, 27);
            this.panel_Tree.Name = "panel_Tree";
            this.panel_Tree.Size = new System.Drawing.Size(174, 423);
            this.panel_Tree.TabIndex = 1;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(3, 396);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(166, 23);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "添加文章";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // tv_Folder
            // 
            this.tv_Folder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tv_Folder.ImageIndex = 0;
            this.tv_Folder.ImageList = this.images;
            this.tv_Folder.Indent = 19;
            this.tv_Folder.LabelEdit = true;
            this.tv_Folder.Location = new System.Drawing.Point(3, 3);
            this.tv_Folder.Name = "tv_Folder";
            this.tv_Folder.SelectedImageIndex = 1;
            this.tv_Folder.Size = new System.Drawing.Size(166, 388);
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
            // panel_Article
            // 
            this.panel_Article.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Article.Controls.Add(this.panel_SeleSave);
            this.panel_Article.Controls.Add(this.txt_Content);
            this.panel_Article.Controls.Add(this.txt_Title);
            this.panel_Article.Location = new System.Drawing.Point(192, 27);
            this.panel_Article.Name = "panel_Article";
            this.panel_Article.Size = new System.Drawing.Size(200, 423);
            this.panel_Article.TabIndex = 2;
            // 
            // panel_SeleSave
            // 
            this.panel_SeleSave.BackColor = System.Drawing.Color.Transparent;
            this.panel_SeleSave.Controls.Add(this.btn_Save);
            this.panel_SeleSave.Controls.Add(this.txt_SelectedLabel);
            this.panel_SeleSave.Controls.Add(this.btn_ChooseLabel);
            this.panel_SeleSave.Location = new System.Drawing.Point(3, 332);
            this.panel_SeleSave.Name = "panel_SeleSave";
            this.panel_SeleSave.Size = new System.Drawing.Size(194, 86);
            this.panel_SeleSave.TabIndex = 5;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(1, 59);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(192, 23);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_SelectedLabel
            // 
            this.txt_SelectedLabel.Location = new System.Drawing.Point(1, 32);
            this.txt_SelectedLabel.Name = "txt_SelectedLabel";
            this.txt_SelectedLabel.Size = new System.Drawing.Size(192, 21);
            this.txt_SelectedLabel.TabIndex = 6;
            // 
            // btn_ChooseLabel
            // 
            this.btn_ChooseLabel.Location = new System.Drawing.Point(1, 3);
            this.btn_ChooseLabel.Name = "btn_ChooseLabel";
            this.btn_ChooseLabel.Size = new System.Drawing.Size(192, 23);
            this.btn_ChooseLabel.TabIndex = 5;
            this.btn_ChooseLabel.Text = "选择标签";
            this.btn_ChooseLabel.UseVisualStyleBackColor = true;
            this.btn_ChooseLabel.Click += new System.EventHandler(this.btn_ChooseLabel_Click);
            // 
            // txt_Content
            // 
            this.txt_Content.Location = new System.Drawing.Point(3, 40);
            this.txt_Content.Multiline = true;
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.Size = new System.Drawing.Size(194, 286);
            this.txt_Content.TabIndex = 1;
            // 
            // txt_Title
            // 
            this.txt_Title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Title.ForeColor = System.Drawing.Color.Silver;
            this.txt_Title.Location = new System.Drawing.Point(3, 3);
            this.txt_Title.Multiline = true;
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(194, 31);
            this.txt_Title.TabIndex = 0;
            this.txt_Title.Text = "请输入标题";
            // 
            // panel_Main
            // 
            this.panel_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel_List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel_LabelFixed.Controls.Add(this.btn_ClearFixLabel);
            this.panel_LabelFixed.Controls.Add(this.btn_EditLabel);
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
            // btn_ClearFixLabel
            // 
            this.btn_ClearFixLabel.Location = new System.Drawing.Point(520, 39);
            this.btn_ClearFixLabel.Name = "btn_ClearFixLabel";
            this.btn_ClearFixLabel.Size = new System.Drawing.Size(56, 23);
            this.btn_ClearFixLabel.TabIndex = 12;
            this.btn_ClearFixLabel.Text = "清空";
            this.btn_ClearFixLabel.UseVisualStyleBackColor = true;
            this.btn_ClearFixLabel.Click += new System.EventHandler(this.btn_ClearFixLabel_Click);
            // 
            // btn_EditLabel
            // 
            this.btn_EditLabel.Location = new System.Drawing.Point(520, 7);
            this.btn_EditLabel.Name = "btn_EditLabel";
            this.btn_EditLabel.Size = new System.Drawing.Size(56, 23);
            this.btn_EditLabel.TabIndex = 12;
            this.btn_EditLabel.Text = "编辑";
            this.btn_EditLabel.UseVisualStyleBackColor = true;
            this.btn_EditLabel.Click += new System.EventHandler(this.btn_EditLabel_Click);
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
            this.btn_ClearLabel.Location = new System.Drawing.Point(520, 2);
            this.btn_ClearLabel.Name = "btn_ClearLabel";
            this.btn_ClearLabel.Size = new System.Drawing.Size(56, 60);
            this.btn_ClearLabel.TabIndex = 16;
            this.btn_ClearLabel.Text = "清空";
            this.btn_ClearLabel.UseVisualStyleBackColor = true;
            this.btn_ClearLabel.Click += new System.EventHandler(this.btn_ClearLabel_Click);
            // 
            // tree_folder
            // 
            this.tree_folder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建子文件夹ToolStripMenuItem,
            this.删除该文件夹ToolStripMenuItem,
            this.添加新文章ToolStripMenuItem,
            this.重命名文件夹ToolStripMenuItem});
            this.tree_folder.Name = "tree_MenuStrip";
            this.tree_folder.Size = new System.Drawing.Size(147, 92);
            // 
            // 新建子文件夹ToolStripMenuItem
            // 
            this.新建子文件夹ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新建子文件夹ToolStripMenuItem.Image")));
            this.新建子文件夹ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.新建子文件夹ToolStripMenuItem.Name = "新建子文件夹ToolStripMenuItem";
            this.新建子文件夹ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.新建子文件夹ToolStripMenuItem.Text = "新建子文件夹";
            this.新建子文件夹ToolStripMenuItem.Click += new System.EventHandler(this.新建子文件夹ToolStripMenuItem_Click);
            // 
            // 删除该文件夹ToolStripMenuItem
            // 
            this.删除该文件夹ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("删除该文件夹ToolStripMenuItem.Image")));
            this.删除该文件夹ToolStripMenuItem.Name = "删除该文件夹ToolStripMenuItem";
            this.删除该文件夹ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.删除该文件夹ToolStripMenuItem.Text = "删除该文件夹";
            // 
            // 添加新文章ToolStripMenuItem
            // 
            this.添加新文章ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("添加新文章ToolStripMenuItem.Image")));
            this.添加新文章ToolStripMenuItem.Name = "添加新文章ToolStripMenuItem";
            this.添加新文章ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.添加新文章ToolStripMenuItem.Text = "添加新文章";
            this.添加新文章ToolStripMenuItem.Click += new System.EventHandler(this.添加新文章ToolStripMenuItem_Click);
            // 
            // 重命名文件夹ToolStripMenuItem
            // 
            this.重命名文件夹ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("重命名文件夹ToolStripMenuItem.Image")));
            this.重命名文件夹ToolStripMenuItem.Name = "重命名文件夹ToolStripMenuItem";
            this.重命名文件夹ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.重命名文件夹ToolStripMenuItem.Text = "重命名文件夹";
            this.重命名文件夹ToolStripMenuItem.Click += new System.EventHandler(this.重命名文件夹ToolStripMenuItem_Click);
            // 
            // tree_article
            // 
            this.tree_article.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑文章ToolStripMenuItem,
            this.删除文章ToolStripMenuItem,
            this.重命名ToolStripMenuItem});
            this.tree_article.Name = "tree_article";
            this.tree_article.Size = new System.Drawing.Size(123, 70);
            // 
            // 编辑文章ToolStripMenuItem
            // 
            this.编辑文章ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("编辑文章ToolStripMenuItem.Image")));
            this.编辑文章ToolStripMenuItem.Name = "编辑文章ToolStripMenuItem";
            this.编辑文章ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.编辑文章ToolStripMenuItem.Text = "编辑文章";
            // 
            // 删除文章ToolStripMenuItem
            // 
            this.删除文章ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("删除文章ToolStripMenuItem.Image")));
            this.删除文章ToolStripMenuItem.Name = "删除文章ToolStripMenuItem";
            this.删除文章ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.删除文章ToolStripMenuItem.Text = "删除文章";
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("重命名ToolStripMenuItem.Image")));
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // lbl_CurrentNode
            // 
            this.lbl_CurrentNode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CurrentNode.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_CurrentNode.Location = new System.Drawing.Point(13, 463);
            this.lbl_CurrentNode.Name = "lbl_CurrentNode";
            this.lbl_CurrentNode.Size = new System.Drawing.Size(376, 19);
            this.lbl_CurrentNode.TabIndex = 4;
            this.lbl_CurrentNode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 493);
            this.Controls.Add(this.lbl_CurrentNode);
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.panel_Article);
            this.Controls.Add(this.panel_Tree);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShadowRectangle = new System.Drawing.Rectangle(30, 30, 30, 30);
            this.ShadowWidth = 6;
            this.Text = "万象知识管理 v8.88 ";
            this.TitleCenter = true;
            this.TitleColor = System.Drawing.Color.DarkSlateBlue;
            this.TitleOffset = new System.Drawing.Point(10, -3);
            this.TitleSuitColor = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_Tree.ResumeLayout(false);
            this.panel_Article.ResumeLayout(false);
            this.panel_Article.PerformLayout();
            this.panel_SeleSave.ResumeLayout(false);
            this.panel_SeleSave.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字体大小ToolStripMenuItem;
        private System.Windows.Forms.Panel panel_Tree;
        private System.Windows.Forms.Panel panel_Article;
        private System.Windows.Forms.TextBox txt_Content;
        private System.Windows.Forms.TextBox txt_Title;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TreeView tv_Folder;
        private System.Windows.Forms.Panel panel_LabelFixed;
        private System.Windows.Forms.Button btn_ClearFixLabel;
        private System.Windows.Forms.Button btn_EditLabel;
        private System.Windows.Forms.Panel panel_Label;
        private System.Windows.Forms.Button btn_ClearLabel;
        private System.Windows.Forms.Panel panel_SeleSave;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_SelectedLabel;
        private System.Windows.Forms.Button btn_ChooseLabel;
        private System.Windows.Forms.ContextMenuStrip tree_folder;
        private System.Windows.Forms.ContextMenuStrip tree_article;
        private System.Windows.Forms.ToolStripMenuItem 新建子文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除该文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加新文章ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑文章ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除文章ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel panel_List;
        private System.Windows.Forms.Label lbl_CurrentNode;
        private CCWin.SkinControl.SkinLine skinLine1;
    }
}

