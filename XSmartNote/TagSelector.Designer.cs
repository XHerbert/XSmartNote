namespace XSmartNote
{
    partial class TagSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagSelector));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.txt_Tag = new System.Windows.Forms.TextBox();
            this.panel_Tags = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.txt_Tag);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 32);
            this.panel1.TabIndex = 0;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(251, 5);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 22);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // txt_Tag
            // 
            this.txt_Tag.Location = new System.Drawing.Point(3, 5);
            this.txt_Tag.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Tag.Multiline = true;
            this.txt_Tag.Name = "txt_Tag";
            this.txt_Tag.Size = new System.Drawing.Size(245, 22);
            this.txt_Tag.TabIndex = 0;
            // 
            // panel_Tags
            // 
            this.panel_Tags.AutoScroll = true;
            this.panel_Tags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Tags.Location = new System.Drawing.Point(0, 35);
            this.panel_Tags.Name = "panel_Tags";
            this.panel_Tags.Size = new System.Drawing.Size(339, 223);
            this.panel_Tags.TabIndex = 1;
            // 
            // TagSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 262);
            this.Controls.Add(this.panel_Tags);
            this.Controls.Add(this.panel1);
            this.EffectBack = System.Drawing.Color.DarkRed;
            this.EffectWidth = 3;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TagSelector";
            this.Text = "标签选择器";
            this.TitleColor = System.Drawing.Color.Maroon;
            this.TopMost = true;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TagSelector_MouseClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TextBox txt_Tag;
        public System.Windows.Forms.FlowLayoutPanel panel_Tags;
    }
}