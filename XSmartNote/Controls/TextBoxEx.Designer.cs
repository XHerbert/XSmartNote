namespace XSmartNote.Controls
{
    partial class TextBoxEx
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextBoxEx));
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.AcceptsReturn = true;
            this.textBox.AcceptsTab = true;
            this.textBox.BackColor = System.Drawing.SystemColors.Control;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.Name = "textBox";
            this.textBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox.Leave += new System.EventHandler(this.textBox_Leave);
            this.textBox.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.textBox.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // TextBoxEx
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textBox);
            resources.ApplyResources(this, "$this");
            this.Name = "TextBoxEx";
            this.Load += new System.EventHandler(this.TextBoxEx_Load);
            this.SizeChanged += new System.EventHandler(this.TextBoxEx_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
    }
}
