namespace CodeEditorNet.Lua
{
    partial class LuaEditor
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
            this.components = new System.ComponentModel.Container();
            this._editor = new ScintillaNET.Scintilla();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.插入注释ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注释ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消注释ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选中当前行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extensionFunctionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPanel = new CodeEditorNet.Lua.SearchPanel();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _editor
            // 
            this._editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this._editor.Location = new System.Drawing.Point(0, 0);
            this._editor.Name = "_editor";
            this._editor.Size = new System.Drawing.Size(697, 547);
            this._editor.TabIndex = 0;
            this._editor.TextChanged += new System.EventHandler(this._editor_TextChanged);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.插入注释ToolStripMenuItem,
            this.注释ToolStripMenuItem,
            this.取消注释ToolStripMenuItem,
            this.选中当前行ToolStripMenuItem,
            this.全选ToolStripMenuItem,
            this.extensionFunctionItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(149, 136);
            // 
            // 插入注释ToolStripMenuItem
            // 
            this.插入注释ToolStripMenuItem.Name = "插入注释ToolStripMenuItem";
            this.插入注释ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.插入注释ToolStripMenuItem.Text = "插入函数注释";
            this.插入注释ToolStripMenuItem.Click += new System.EventHandler(this.插入注释ToolStripMenuItem_Click);
            // 
            // 注释ToolStripMenuItem
            // 
            this.注释ToolStripMenuItem.Name = "注释ToolStripMenuItem";
            this.注释ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.注释ToolStripMenuItem.Text = "注释";
            this.注释ToolStripMenuItem.Click += new System.EventHandler(this.注释ToolStripMenuItem_Click);
            // 
            // 取消注释ToolStripMenuItem
            // 
            this.取消注释ToolStripMenuItem.Name = "取消注释ToolStripMenuItem";
            this.取消注释ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.取消注释ToolStripMenuItem.Text = "取消注释";
            this.取消注释ToolStripMenuItem.Click += new System.EventHandler(this.取消注释ToolStripMenuItem_Click);
            // 
            // 选中当前行ToolStripMenuItem
            // 
            this.选中当前行ToolStripMenuItem.Name = "选中当前行ToolStripMenuItem";
            this.选中当前行ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.选中当前行ToolStripMenuItem.Text = "选中当前行";
            this.选中当前行ToolStripMenuItem.Click += new System.EventHandler(this.选中当前行ToolStripMenuItem_Click);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // extensionFunctionItem
            // 
            this.extensionFunctionItem.Name = "extensionFunctionItem";
            this.extensionFunctionItem.Size = new System.Drawing.Size(148, 22);
            this.extensionFunctionItem.Text = "插入扩展函数";
            // 
            // searchPanel
            // 
            this.searchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Location = new System.Drawing.Point(346, 3);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.SearchOrReplace = true;
            this.searchPanel.Size = new System.Drawing.Size(331, 170);
            this.searchPanel.TabIndex = 2;
            this.searchPanel.Visible = false;
            // 
            // LuaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this._editor);
            this.Name = "LuaEditor";
            this.Size = new System.Drawing.Size(697, 547);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ScintillaNET.Scintilla _editor;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 插入注释ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注释ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消注释ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选中当前行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private SearchPanel searchPanel;
        private System.Windows.Forms.ToolStripMenuItem extensionFunctionItem;
    }
}
