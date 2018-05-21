using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEditorNet.Lua
{
    class CommentManager
    {
        private ScintillaNET.Scintilla _editor = null;

        public CommentManager(ScintillaNET.Scintilla editor)
        {
            _editor = editor;
        }


        private static readonly string FUNCTRION_COMMENT =  //函数注释
@"--[[ 
    @func : 

    @param : 

    @return :

--]]";

        public void AddFunctionComment()
        {
            _editor.InsertText(_editor.CurrentPosition, FUNCTRION_COMMENT);
        }

        public void AddComment()
        {
            if (_editor.SelectedText == Environment.NewLine)
            {
                return;
            }
            int start = _editor.SelectionStart;
            int end = _editor.SelectionEnd;
            var lineStart = _editor.Lines.FirstOrDefault(
                x =>
                {
                    return (x.Position <= start && x.EndPosition > start);
                });
            var lineEnd = _editor.Lines.FirstOrDefault(
                x =>
                {
                    return (x.Position < end && x.EndPosition >= end);
                });
            if (lineStart == null || lineEnd == null)
            {
                return;
            }
            _editor.SetSelection(lineStart.Position, lineEnd.EndPosition);

            string textSelect = _editor.SelectedText;
            string[] strsSplit = System.Text.RegularExpressions.Regex.Split(textSelect, System.Environment.NewLine);
            Func<char, bool> funcSearch = x => { return !(x == '\r' || x == '\n' || x == ' '); };
            for (int i = 0; i < strsSplit.Length; i++)
            {
                if (strsSplit[i] == null || strsSplit[i].FirstOrDefault(funcSearch) == char.MinValue)
                    continue;
                strsSplit[i] = strsSplit[i].Insert(StringIndex(strsSplit[i], funcSearch), "--");
            }
            _editor.ReplaceSelection(string.Join(System.Environment.NewLine, strsSplit));
            _editor.SetSelection(lineStart.Position, lineEnd.EndPosition);
        }

        public void RemoveComment()
        {
            if (_editor.SelectedText == Environment.NewLine)
            {
                return;
            }
            int start = _editor.SelectionStart;
            int end = _editor.SelectionEnd;
            var lineStart = _editor.Lines.FirstOrDefault(
                x =>
                {
                    return (x.Position <= start && x.EndPosition > start);
                });
            var lineEnd = _editor.Lines.FirstOrDefault(
                x =>
                {
                    return (x.Position < end && x.EndPosition >= end);
                });
            if (lineStart == null || lineEnd == null)
            {
                return;
            }
            _editor.SetSelection(lineStart.Position, lineEnd.EndPosition);
            string[] strsSplit = System.Text.RegularExpressions.Regex.Split(_editor.SelectedText, System.Environment.NewLine);
            for (int i = 0; i < strsSplit.Length; i++)
            {
                if (strsSplit[i] == null || strsSplit[i] == "" || strsSplit[i] == System.Environment.NewLine)
                {
                    continue;
                }
                int index = StringIndexComment(strsSplit[i]);
                if (index != -1)
                {
                    strsSplit[i] = strsSplit[i].Remove(index, 2);
                }
            }
            _editor.ReplaceSelection(string.Join(System.Environment.NewLine, strsSplit));
            _editor.SetSelection(lineStart.Position, lineEnd.EndPosition);
        }
        
        private int StringIndex(string strSerach, Func<char, bool> searchFunc)
        {
            for (int i = 0; i < strSerach.Length; i++)
                if (searchFunc(strSerach[i]))
                    return i;
            return -1;
        }

        private int StringIndexComment(string strSerch)
        {
            for (int i = 0; i < strSerch.Length - 1; i++)
            {
                if (strSerch[i] == '-')
                {
                    return strSerch[i + 1] == '-' ? i : -1;
                }
            }
            return -1;
        }
    }
}
