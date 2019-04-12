namespace YongYou.Server
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
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.cbAutoScrollLog = new System.Windows.Forms.CheckBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.Location = new System.Drawing.Point(0, 37);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(882, 419);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // cbAutoScrollLog
            // 
            this.cbAutoScrollLog.AutoSize = true;
            this.cbAutoScrollLog.Checked = true;
            this.cbAutoScrollLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoScrollLog.Location = new System.Drawing.Point(12, 12);
            this.cbAutoScrollLog.Name = "cbAutoScrollLog";
            this.cbAutoScrollLog.Size = new System.Drawing.Size(72, 16);
            this.cbAutoScrollLog.TabIndex = 11;
            this.cbAutoScrollLog.Text = "自动滚动";
            this.cbAutoScrollLog.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(795, 5);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 12;
            this.btnClearLog.Text = "清除日志";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 457);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.cbAutoScrollLog);
            this.Controls.Add(this.rtbLog);
            this.Name = "MainForm";
            this.Text = "物业管理平台";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.CheckBox cbAutoScrollLog;
        private System.Windows.Forms.Button btnClearLog;
    }
}

