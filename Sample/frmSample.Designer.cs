namespace Sample
{
    partial class frmSample
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.editor1 = new CodeEditorNet.Lua.LuaEditor();
            this.SuspendLayout();
            // 
            // editor1
            // 
            this.editor1.CaretColor = System.Drawing.Color.White;
            this.editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor1.LineNumBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.editor1.LineNumForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Name = "editor1";
            this.editor1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(69)))), ((int)(((byte)(131)))));
            this.editor1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(192)))), ((int)(((byte)(211)))));
            this.editor1.Size = new System.Drawing.Size(937, 539);
            this.editor1.TabIndex = 0;
            this.editor1.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.editor1.TextForeColor = System.Drawing.Color.White;
            // 
            // frmSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 539);
            this.Controls.Add(this.editor1);
            this.KeyPreview = true;
            this.Name = "frmSample";
            this.Text = "样例";
            this.ResumeLayout(false);

        }

        #endregion

        private CodeEditorNet.Lua.LuaEditor editor1;
    }
}

