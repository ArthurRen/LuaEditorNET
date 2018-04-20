using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeEditorNet.Lua
{
    class SearchManager
    {
        private Scintilla _editor = null;
        private int _indexLastestSearch = 0;

        public SearchManager(Scintilla editor)
        {
            _editor = editor;
            _editor.TargetStart = 0;
            _indexLastestSearch = 0;
        }

        /// <summary>
        /// 搜索并选中字符串
        /// </summary>
        /// <param name="text">搜索的文本</param>
        /// <param name="next">正向或者反向搜索</param>
        /// <param name="_editor">编辑器</param>
        /// <returns>搜索成功返回搜索到的字符串位置，否则返回-1</returns>
        public int Search(string text , bool positive)
        {
            if (text == "" || text == Environment.NewLine)
            {
                return -1;
            }
            if (positive)
            {
                if (_indexLastestSearch >= _editor.Text.Length)
                {
                    MessageBox.Show("已经搜索到底部！");
                    return -1;
                }
                int pos = _editor.Text.IndexOf(text, _indexLastestSearch, _editor.Text.Length - _indexLastestSearch);
                if (pos == -1)
                {
                    MessageBox.Show("已经搜索到底部！");
                    return -1;
                }
                else
                {
                    _editor.SetSelection(pos, pos + text.Length);
                    _indexLastestSearch = pos + text.Length + 1;
                    if (_indexLastestSearch >= _editor.Text.Length)
                    {
                        _indexLastestSearch = _editor.Text.Length - 1;
                    }
                    return pos;
                }
            }
            else
            {
                if (_indexLastestSearch - text.Length <= 0)
                {
                    MessageBox.Show("已近搜索到顶部！");
                    return -1;
                }
                int pos = _editor.Text.LastIndexOf(text, _indexLastestSearch, _indexLastestSearch + 1);
                if (pos == -1)
                {
                    MessageBox.Show("已经搜索到顶部！");
                    return -1;
                }
                else
                {
                    _editor.SetSelection(pos, pos + text.Length);
                    _indexLastestSearch = pos - text.Length - 1;
                    if (_indexLastestSearch < 0)
                    {
                        _indexLastestSearch = 0;
                    }
                    return pos;
                }
            }
        }

        /// <summary>
        /// 搜索多个目标
        /// </summary>
        /// <param name="strSearch">需要搜索的字符串</param>
        /// <returns>搜索到的目标字符串的位置</returns>
        public int[] MultiSearch(string strSearch)
        {
            _editor.MultipleSelection = true;
            var poses = System.Text.RegularExpressions.Regex.Matches(_editor.Text, strSearch).Cast<System.Text.RegularExpressions.Match>().Select(x => x.Index).ToArray();

            _editor.ClearSelections();
            foreach (var item in poses)
            {
                _editor.AddSelection(item, item + strSearch.Length);
            }
            
            return poses;
        }
    }
}
