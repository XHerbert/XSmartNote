using System.Windows.Forms;
namespace KnowledgeManager
{
    partial class RectangleLabel
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblText.ForeColor = System.Drawing.Color.Maroon;
            this.lblText.Location = new System.Drawing.Point(14, 2);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(57, 17);
            this.lblText.TabIndex = 0;
            this.lblText.Text = ".NET";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RectangleLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblText);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RectangleLabel";
            this.Size = new System.Drawing.Size(82, 22);
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblText;

    }
}
