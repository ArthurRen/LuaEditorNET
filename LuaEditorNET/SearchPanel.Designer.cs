namespace CodeEditorNet.Lua
{
    partial class SearchPanel
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
            this.panel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.pageSearch = new System.Windows.Forms.TabPage();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.btnCountText = new System.Windows.Forms.Button();
            this.btnSearchNext = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.Label();
            this.cbSearchText = new System.Windows.Forms.ComboBox();
            this.pageReplace = new System.Windows.Forms.TabPage();
            this.lbReplcaceNew = new System.Windows.Forms.Label();
            this.cbReplaceNew = new System.Windows.Forms.ComboBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.panelReplaceAll = new System.Windows.Forms.Panel();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.cbReplaceSelected = new System.Windows.Forms.CheckBox();
            this.cbReverseSearch = new System.Windows.Forms.CheckBox();
            this.panel.SuspendLayout();
            this.tabs.SuspendLayout();
            this.pageSearch.SuspendLayout();
            this.pageReplace.SuspendLayout();
            this.panelReplaceAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.btnClose);
            this.panel.Controls.Add(this.tabs);
            this.panel.Controls.Add(this.cbReverseSearch);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(422, 168);
            this.panel.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(338, 138);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.pageSearch);
            this.tabs.Controls.Add(this.pageReplace);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(422, 136);
            this.tabs.TabIndex = 1;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // pageSearch
            // 
            this.pageSearch.Controls.Add(this.btnSearchAll);
            this.pageSearch.Controls.Add(this.btnCountText);
            this.pageSearch.Controls.Add(this.btnSearchNext);
            this.pageSearch.Controls.Add(this.lbSearch);
            this.pageSearch.Controls.Add(this.cbSearchText);
            this.pageSearch.Location = new System.Drawing.Point(4, 22);
            this.pageSearch.Name = "pageSearch";
            this.pageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.pageSearch.Size = new System.Drawing.Size(414, 110);
            this.pageSearch.TabIndex = 0;
            this.pageSearch.Text = "搜索";
            this.pageSearch.UseVisualStyleBackColor = true;
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchAll.Location = new System.Drawing.Point(310, 64);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(89, 23);
            this.btnSearchAll.TabIndex = 10;
            this.btnSearchAll.Text = "查找所有";
            this.btnSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // btnCountText
            // 
            this.btnCountText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCountText.Location = new System.Drawing.Point(310, 35);
            this.btnCountText.Name = "btnCountText";
            this.btnCountText.Size = new System.Drawing.Size(88, 23);
            this.btnCountText.TabIndex = 8;
            this.btnCountText.Text = "计 数";
            this.btnCountText.UseVisualStyleBackColor = true;
            this.btnCountText.Click += new System.EventHandler(this.btnCountText_Click);
            // 
            // btnSearchNext
            // 
            this.btnSearchNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchNext.Location = new System.Drawing.Point(310, 6);
            this.btnSearchNext.Name = "btnSearchNext";
            this.btnSearchNext.Size = new System.Drawing.Size(89, 23);
            this.btnSearchNext.TabIndex = 7;
            this.btnSearchNext.Text = "查找下一个";
            this.btnSearchNext.UseVisualStyleBackColor = true;
            this.btnSearchNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(32, 12);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(65, 12);
            this.lbSearch.TabIndex = 6;
            this.lbSearch.Text = "查找目标：";
            // 
            // cbSearchText
            // 
            this.cbSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearchText.FormattingEnabled = true;
            this.cbSearchText.Location = new System.Drawing.Point(103, 9);
            this.cbSearchText.Name = "cbSearchText";
            this.cbSearchText.Size = new System.Drawing.Size(201, 20);
            this.cbSearchText.TabIndex = 5;
            // 
            // pageReplace
            // 
            this.pageReplace.Controls.Add(this.lbReplcaceNew);
            this.pageReplace.Controls.Add(this.cbReplaceNew);
            this.pageReplace.Controls.Add(this.btnReplace);
            this.pageReplace.Controls.Add(this.panelReplaceAll);
            this.pageReplace.Location = new System.Drawing.Point(4, 22);
            this.pageReplace.Name = "pageReplace";
            this.pageReplace.Padding = new System.Windows.Forms.Padding(3);
            this.pageReplace.Size = new System.Drawing.Size(414, 110);
            this.pageReplace.TabIndex = 1;
            this.pageReplace.Text = "替换";
            this.pageReplace.UseVisualStyleBackColor = true;
            // 
            // lbReplcaceNew
            // 
            this.lbReplcaceNew.AutoSize = true;
            this.lbReplcaceNew.Location = new System.Drawing.Point(35, 35);
            this.lbReplcaceNew.Name = "lbReplcaceNew";
            this.lbReplcaceNew.Size = new System.Drawing.Size(53, 12);
            this.lbReplcaceNew.TabIndex = 16;
            this.lbReplcaceNew.Text = "替换为：";
            // 
            // cbReplaceNew
            // 
            this.cbReplaceNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReplaceNew.FormattingEnabled = true;
            this.cbReplaceNew.Location = new System.Drawing.Point(104, 32);
            this.cbReplaceNew.Name = "cbReplaceNew";
            this.cbReplaceNew.Size = new System.Drawing.Size(207, 20);
            this.cbReplaceNew.TabIndex = 15;
            // 
            // btnReplace
            // 
            this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplace.Location = new System.Drawing.Point(318, 32);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(82, 23);
            this.btnReplace.TabIndex = 14;
            this.btnReplace.Text = "替换";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // panelReplaceAll
            // 
            this.panelReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReplaceAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReplaceAll.Controls.Add(this.btnReplaceAll);
            this.panelReplaceAll.Controls.Add(this.cbReplaceSelected);
            this.panelReplaceAll.Location = new System.Drawing.Point(223, 58);
            this.panelReplaceAll.Name = "panelReplaceAll";
            this.panelReplaceAll.Size = new System.Drawing.Size(181, 33);
            this.panelReplaceAll.TabIndex = 13;
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplaceAll.Location = new System.Drawing.Point(93, 3);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(83, 23);
            this.btnReplaceAll.TabIndex = 11;
            this.btnReplaceAll.Text = "全部替换";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // cbReplaceSelected
            // 
            this.cbReplaceSelected.AutoSize = true;
            this.cbReplaceSelected.Location = new System.Drawing.Point(3, 7);
            this.cbReplaceSelected.Name = "cbReplaceSelected";
            this.cbReplaceSelected.Size = new System.Drawing.Size(84, 16);
            this.cbReplaceSelected.TabIndex = 12;
            this.cbReplaceSelected.Text = "选取范围内";
            this.cbReplaceSelected.UseVisualStyleBackColor = true;
            // 
            // cbReverseSearch
            // 
            this.cbReverseSearch.AutoSize = true;
            this.cbReverseSearch.Location = new System.Drawing.Point(4, 142);
            this.cbReverseSearch.Name = "cbReverseSearch";
            this.cbReverseSearch.Size = new System.Drawing.Size(72, 16);
            this.cbReverseSearch.TabIndex = 10;
            this.cbReverseSearch.Text = "反向查找";
            this.cbReverseSearch.UseVisualStyleBackColor = true;
            // 
            // SearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel);
            this.Name = "SearchPanel";
            this.Size = new System.Drawing.Size(422, 168);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.frmSearchAndReplace_PreviewKeyDown);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.pageSearch.ResumeLayout(false);
            this.pageSearch.PerformLayout();
            this.pageReplace.ResumeLayout(false);
            this.pageReplace.PerformLayout();
            this.panelReplaceAll.ResumeLayout(false);
            this.panelReplaceAll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage pageSearch;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.Button btnCountText;
        private System.Windows.Forms.Button btnSearchNext;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.ComboBox cbSearchText;
        private System.Windows.Forms.TabPage pageReplace;
        private System.Windows.Forms.Label lbReplcaceNew;
        private System.Windows.Forms.ComboBox cbReplaceNew;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Panel panelReplaceAll;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.CheckBox cbReplaceSelected;
        private System.Windows.Forms.CheckBox cbReverseSearch;
        private System.Windows.Forms.Button btnClose;
    }
}
