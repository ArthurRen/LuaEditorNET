using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeEditorNet.Lua
{
    partial class SearchPanel : UserControl
    {
        public bool SearchOrReplace
        {
            get
            {
                return tabs.SelectedIndex == 0;
            }
            set
            {
                tabs.SelectedIndex = value ? 0 : 1;
            }
        }

        public event EventHandler<SearchEventArgs> SearchText = null;
        public event EventHandler<CountEventArgs> CountText = null;
        public event EventHandler<ReplaceEventArgs> ReplaceText = null;

        public SearchPanel()
        {
            InitializeComponent();
        }

        private string _strLatestSearch = "";
        private void btnFindNext_Click(object sender, EventArgs e)
        {
            string text = cbSearchText.Text;
            if (text == "")
            {
                return;
            }
            if (text != _strLatestSearch && !cbSearchText.Items.Contains(text))
            {
                cbSearchText.Items.Insert(0, text);
            }
            _searchArgs.MulitSearch = false;
            _searchArgs.Positive = !cbReverseSearch.Checked;
            _searchArgs.SearchText = text;
            OnSearchText(_searchArgs);
            _strLatestSearch = text;
        }

        private SearchEventArgs _searchArgs = new SearchEventArgs();
        public void OnSearchText(SearchEventArgs args)
        {
            if (SearchText != null)
            {
                SearchText.Invoke(this, args);
            }
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            string text = cbSearchText.Text;
            if (text == "")
            {
                return;
            }
            if (text != _strLatestSearch && !cbSearchText.Items.Contains(text))
            {
                cbSearchText.Items.Insert(0, text);
            }
            _searchArgs.MulitSearch = true;
            _searchArgs.Positive = true;
            _searchArgs.SearchText = cbSearchText.Text;
            OnSearchText(_searchArgs);
            _strLatestSearch = text;
        }


        public void OnCountText(CountEventArgs args)
        {
            if (SearchText != null)
            {
                CountText.Invoke(this, args);
            }
        }

        CountEventArgs _countArgs = new CountEventArgs();
        private void btnCountText_Click(object sender, EventArgs e)
        {
            string text = cbSearchText.Text;
            if (text == "")
            {
                return;
            }
            if (text != _strLatestSearch && !cbSearchText.Items.Contains(text))
            {
                cbSearchText.Items.Insert(0, text);
            }
            _countArgs.CountText = text;
            OnCountText(_countArgs);
            _strLatestSearch = text;
        }

        private ReplaceEventArgs _replaceArgs = new ReplaceEventArgs();
        private string _strLastestReplaceNew = "";
        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            string textOld = cbSearchText.Text;
            if (textOld == "")
                return;
            if (textOld != _strLatestSearch && !cbSearchText.Items.Contains(textOld))
            {
                cbSearchText.Items.Insert(0, textOld);
                _strLatestSearch = textOld;
            }
            string textNew = cbReplaceNew.Text;
            if (textNew != "" && textNew != _strLastestReplaceNew && !cbReplaceNew.Items.Contains(textOld))
            {
                cbReplaceNew.Items.Insert(0, textNew);
                _strLastestReplaceNew = textNew;
            }
            _replaceArgs.OldText = textOld;
            _replaceArgs.NewText = cbReplaceNew.Text;
            _replaceArgs.ReplaceAll = true;
            _replaceArgs.ReplaceSelected = cbReplaceSelected.Checked;
            _replaceArgs.Positive = !cbReverseSearch.Checked;
            OnReplaceText(_replaceArgs);
        }

        protected virtual void OnReplaceText(ReplaceEventArgs args)
        {
            if (ReplaceText != null)
            {
                ReplaceText.Invoke(this, args);
            }
        }

        private void frmSearchAndReplace_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Visible = false;
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var page = tabs.SelectedTab;

            cbSearchText.Parent.Controls.Remove(cbSearchText);
            page.Controls.Add(cbSearchText);

            btnSearchNext.Parent.Controls.Remove(btnSearchNext);
            page.Controls.Add(btnSearchNext);

            lbSearch.Parent.Controls.Remove(lbSearch);
            page.Controls.Add(lbSearch);

            ManualLayout(page.Text == "搜索");
        }

        private static readonly int Interval = 6;
        private void ManualLayout(bool searchOrReplace)
        {
            if (searchOrReplace)
            {
                btnCountText.Location = new Point(btnSearchNext.Location.X, btnSearchNext.Bottom + Interval);
                btnSearchAll.Location = new Point(btnCountText.Location.X, btnCountText.Bottom + Interval);
            }
            else
            {
                cbReplaceNew.Location = new Point(cbSearchText.Location.X, cbSearchText.Bottom + Interval);
                cbReplaceNew.Size = cbSearchText.Size;
                lbReplcaceNew.Location = new Point(lbSearch.Left + (lbSearch.Width - lbReplcaceNew.Width), cbReplaceNew.Location.Y + 3);

                btnReplace.Location = new Point(btnSearchNext.Location.X, btnSearchNext.Bottom + Interval);
                btnReplace.Size = btnSearchNext.Size;

                btnReplaceAll.Size = btnReplace.Size;

                panelReplaceAll.Size = new Size(btnReplaceAll.Width + cbReplaceSelected.Width + Interval * 3, (btnReplaceAll.Height + Interval - 1));
                panelReplaceAll.Location = new Point(pageReplace.Width - panelReplaceAll.Width - Interval / 2, btnReplace.Bottom + Interval / 2);

                btnReplaceAll.Location = new Point(btnReplace.Left - panelReplaceAll.Left - 1, Interval / 2 - 1);
                cbReplaceSelected.Location = new Point(Interval / 2, btnReplaceAll.Top + Interval / 2);
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            string textOld = cbSearchText.Text;
            if (textOld == "")
                return;
            if (textOld != _strLatestSearch && !cbSearchText.Items.Contains(textOld))
            {
                cbSearchText.Items.Insert(0, textOld);
                _strLatestSearch = textOld;
            }
            string textNew = cbReplaceNew.Text;
            if (textNew != "" && textNew != _strLastestReplaceNew && !cbReplaceNew.Items.Contains(textOld))
            {
                cbReplaceNew.Items.Insert(0, textNew);
                _strLastestReplaceNew = textNew;
            }
            _replaceArgs.OldText = textOld;
            _replaceArgs.NewText = cbReplaceNew.Text;
            _replaceArgs.ReplaceAll = false;
            _replaceArgs.ReplaceSelected = cbReplaceSelected.Checked;
            _replaceArgs.Positive = !cbReverseSearch.Checked;
            OnReplaceText(_replaceArgs);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
