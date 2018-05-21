using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeEditorNet.Lua
{
    class ReplaceManager
    {
        private SearchManager _seacherManager = null;
        private Scintilla _editor = null;

        public ReplaceManager(Scintilla editor) 
        {
            _seacherManager = new SearchManager(editor);
            _editor = editor;
        }

        public int Replace(string strOld, string strNew, bool positive)
        {
            int pos = _seacherManager.Search(strOld, positive);
            if (pos != -1)
            {
                _editor.TargetStart = pos; //set targt ready to replace string
                _editor.TargetEnd = pos + strOld.Length;
                _editor.ReplaceTarget(strNew);
                _editor.SetSelection(pos, pos + strNew.Length);
            }
            return pos;
        }

        public void ReplaceMulti(string strOld, string strNew , bool replaceSelected)
        {
            if (strOld == "")
            {
                return;
            }
            if (replaceSelected)
            {
                string text = _editor.SelectedText;
                int start = _editor.SelectionStart;
                string strReplaced = text.Replace(strOld, strNew);
                _editor.ReplaceSelection(strReplaced);
                MessageBox.Show("替换完成！");
            }
            else
            {
                string text = _editor.Text.Replace(strOld, strNew);
                _editor.Text = text;
                MessageBox.Show("替换完成！");
            }
        }
    }
}
