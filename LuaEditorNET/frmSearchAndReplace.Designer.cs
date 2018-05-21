namespace CodeEditorNet.Lua
{
    partial class frmSearchAndReplace
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabs.SuspendLayout();
            this.pageSearch.SuspendLayout();
            this.pageReplace.SuspendLayout();
            this.panelReplaceAll.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.pageSearch);
            this.tabs.Controls.Add(this.pageReplace);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(560, 136);
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
            this.pageSearch.Size = new System.Drawing.Size(552, 110);
            this.pageSearch.TabIndex = 0;
            this.pageSearch.Text = "搜索";
            this.pageSearch.UseVisualStyleBackColor = true;
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Location = new System.Drawing.Point(372, 64);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(141, 23);
            this.btnSearchAll.TabIndex = 10;
            this.btnSearchAll.Text = "查找所有";
            this.btnSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // btnCountText
            // 
            this.btnCountText.Location = new System.Drawing.Point(371, 35);
            this.btnCountText.Name = "btnCountText";
            this.btnCountText.Size = new System.Drawing.Size(141, 23);
            this.btnCountText.TabIndex = 8;
            this.btnCountText.Text = "计 数";
            this.btnCountText.UseVisualStyleBackColor = true;
            this.btnCountText.Click += new System.EventHandler(this.btnCountText_Click);
            // 
            // btnSearchNext
            // 
            this.btnSearchNext.Location = new System.Drawing.Point(372, 6);
            this.btnSearchNext.Name = "btnSearchNext";
            this.btnSearchNext.Size = new System.Drawing.Size(141, 23);
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
            this.cbSearchText.FormattingEnabled = true;
            this.cbSearchText.Location = new System.Drawing.Point(103, 9);
            this.cbSearchText.Name = "cbSearchText";
            this.cbSearchText.Size = new System.Drawing.Size(263, 20);
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
            this.pageReplace.Size = new System.Drawing.Size(519, 110);
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
            this.cbReplaceNew.FormattingEnabled = true;
            this.cbReplaceNew.Location = new System.Drawing.Point(104, 32);
            this.cbReplaceNew.Name = "cbReplaceNew";
            this.cbReplaceNew.Size = new System.Drawing.Size(257, 20);
            this.cbReplaceNew.TabIndex = 15;
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(366, 32);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(141, 23);
            this.btnReplace.TabIndex = 14;
            this.btnReplace.Text = "替换";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // panelReplaceAll
            // 
            this.panelReplaceAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReplaceAll.Controls.Add(this.btnReplaceAll);
            this.panelReplaceAll.Controls.Add(this.cbReplaceSelected);
            this.panelReplaceAll.Location = new System.Drawing.Point(273, 58);
            this.panelReplaceAll.Name = "panelReplaceAll";
            this.panelReplaceAll.Size = new System.Drawing.Size(238, 33);
            this.panelReplaceAll.TabIndex = 13;
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(93, 3);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(141, 23);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.tabs);
            this.panel1.Controls.Add(this.cbReverseSearch);
            this.panel1.Location = new System.Drawing.Point(112, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 163);
            this.panel1.TabIndex = 11;
            // 
            // frmSearchAndReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(858, 387);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSearchAndReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "搜索";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.frmSearchAndReplace_PreviewKeyDown);
            this.tabs.ResumeLayout(false);
            this.pageSearch.ResumeLayout(false);
            this.pageSearch.PerformLayout();
            this.pageReplace.ResumeLayout(false);
            this.pageReplace.PerformLayout();
            this.panelReplaceAll.ResumeLayout(false);
            this.panelReplaceAll.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage pageSearch;
        private System.Windows.Forms.TabPage pageReplace;
        private System.Windows.Forms.Button btnCountText;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.CheckBox cbReplaceSelected;
        private System.Windows.Forms.Panel panelReplaceAll;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.ComboBox cbReplaceNew;
        private System.Windows.Forms.Label lbReplcaceNew;
        private System.Windows.Forms.CheckBox cbReverseSearch;
        private System.Windows.Forms.Button btnSearchNext;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.ComboBox cbSearchText;
        private System.Windows.Forms.Panel panel1;
    }
}