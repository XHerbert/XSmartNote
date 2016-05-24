namespace XSmartNote
{
    partial class TipsForm
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
            this.components = new System.ComponentModel.Container();
            this.timerSlide = new System.Windows.Forms.Timer(this.components);
            this.lbl_Msg = new System.Windows.Forms.Label();
            this.labelExSolidBorder1 = new XSmartNote.LabelExSolidBorder();
            this.labelWithCheck1 = new XSmartNote.LabelWithCheck();
            this.rectangleLabel1 = new XSmartNote.RectangleLabel();
            this.textBoxEx1 = new XSmartNote.Controls.TextBoxEx();
            this.SuspendLayout();
            // 
            // timerSlide
            // 
            this.timerSlide.Tick += new System.EventHandler(this.timerSlide_Tick);
            // 
            // lbl_Msg
            // 
            this.lbl_Msg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Msg.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lbl_Msg.Location = new System.Drawing.Point(12, 9);
            this.lbl_Msg.Name = "lbl_Msg";
            this.lbl_Msg.Size = new System.Drawing.Size(191, 67);
            this.lbl_Msg.TabIndex = 0;
            this.lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelExSolidBorder1
            // 
            this.labelExSolidBorder1.BackColor = System.Drawing.Color.LightCyan;
            this.labelExSolidBorder1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelExSolidBorder1.ForeColor = System.Drawing.Color.Brown;
            this.labelExSolidBorder1.HighLightBorderColor = System.Drawing.Color.Empty;
            this.labelExSolidBorder1.Location = new System.Drawing.Point(37, 186);
            this.labelExSolidBorder1.Margin = new System.Windows.Forms.Padding(5);
            this.labelExSolidBorder1.Name = "labelExSolidBorder1";
            this.labelExSolidBorder1.NormalBorderColor = System.Drawing.Color.Empty;
            this.labelExSolidBorder1.Padding = new System.Windows.Forms.Padding(5);
            this.labelExSolidBorder1.Size = new System.Drawing.Size(550, 47);
            this.labelExSolidBorder1.TabIndex = 5;
            this.labelExSolidBorder1.Text = "悠扬的牧笛";
            // 
            // labelWithCheck1
            // 
            this.labelWithCheck1.BackColor = System.Drawing.Color.Honeydew;
            this.labelWithCheck1.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.labelWithCheck1.LabelText = "输入标签";
            this.labelWithCheck1.LabelWidth = 298;
            this.labelWithCheck1.LabelWithCheckColor = System.Drawing.Color.Maroon;
            this.labelWithCheck1.Location = new System.Drawing.Point(161, 137);
            this.labelWithCheck1.Name = "labelWithCheck1";
            this.labelWithCheck1.Size = new System.Drawing.Size(74, 22);
            this.labelWithCheck1.TabIndex = 4;
            // 
            // rectangleLabel1
            // 
            this.rectangleLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rectangleLabel1.BorderColor = System.Drawing.Color.Purple;
            this.rectangleLabel1.BorderWidth = 1.5F;
            this.rectangleLabel1.ControlText = ".NET";
            this.rectangleLabel1.InnerColor = System.Drawing.Color.Transparent;
            this.rectangleLabel1.Location = new System.Drawing.Point(41, 137);
            this.rectangleLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.rectangleLabel1.Name = "rectangleLabel1";
            this.rectangleLabel1.Size = new System.Drawing.Size(82, 22);
            this.rectangleLabel1.TabIndex = 3;
            // 
            // textBoxEx1
            // 
            this.textBoxEx1.BackColor = System.Drawing.Color.White;
            this.textBoxEx1.BorderColor = System.Drawing.Color.Empty;
            this.textBoxEx1.BoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxEx1.ControlText = "";
            this.textBoxEx1.Location = new System.Drawing.Point(41, 76);
            this.textBoxEx1.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxEx1.Name = "textBoxEx1";
            this.textBoxEx1.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxEx1.Size = new System.Drawing.Size(194, 31);
            this.textBoxEx1.TabIndex = 1;
            this.textBoxEx1.WaterColor = System.Drawing.Color.Empty;
            this.textBoxEx1.WaterText = null;
            // 
            // TipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(633, 280);
            this.Controls.Add(this.labelExSolidBorder1);
            this.Controls.Add(this.labelWithCheck1);
            this.Controls.Add(this.rectangleLabel1);
            this.Controls.Add(this.textBoxEx1);
            this.Controls.Add(this.lbl_Msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TipsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerSlide;
        private System.Windows.Forms.Label lbl_Msg;
        private Controls.TextBoxEx textBoxEx1;
        private RectangleLabel rectangleLabel1;
        private LabelWithCheck labelWithCheck1;
        private LabelExSolidBorder labelExSolidBorder1;
    }
}