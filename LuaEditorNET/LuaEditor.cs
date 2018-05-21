using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeEditorNet.Lua
{
    public partial class LuaEditor : UserControl
    {
        #region Color
        private Color _selectionBackColor = Color.FromArgb(14, 69, 131 );
        [Description("文本被选中后的背景色")]
        [Category("颜色")]
        public Color SelectionBackColor
        {
            get
            {
                return _selectionBackColor;
            }
            set
            {
                _selectionBackColor = value;
            }
        }
        
        private Color _selectionForeColor = Color.FromArgb(173, 192, 211);
        [Description("文本被选中后的前景色")]
        [Category("颜色")]
        public Color SelectionForeColor
        {
            get
            {
                return _selectionForeColor;
            }
            set
            {
                _selectionForeColor = value;
            }
        }

        private Color _textBackColor = Color.FromArgb(0x1E1E1E);
        [Description("文本的背景色")]
        [Category("颜色")]
        public Color TextBackColor
        {
            get
            {
                return _textBackColor;
            }
            set
            {
                _textBackColor = value;
            }
        }

        private Color _textForeColor = Color.FromArgb(0xffffff);
        [Description("文本的前景色")]
        [Category("颜色")]
        public Color TextForeColor
        {
            get
            {
                return _textForeColor;
            }
            set
            {
                _textForeColor = value;
            }
        }

        private Color _lineNumForeColor = Color.FromArgb(0x2B91AF);
        [Description("行号的前景色")]
        [Category("颜色")]
        public Color LineNumForeColor
        {
            get
            {
                return _lineNumForeColor;
            }
            set
            {
                _lineNumForeColor = value;
            }
        }

        private Color _lineNumBackColor = Color.FromArgb(0x1E1E1E);
        [Description("行号的背景色")]
        [Category("颜色")]
        public Color LineNumBackColor
        {
            get
            {
                return _lineNumBackColor;
            }
            set
            {
                _lineNumBackColor = value;
            }
        }

        private Color _caretColor = Color.White;
        [Description("指针颜色")]
        [Category("颜色")]
        public Color CaretColor
        {
            get
            {
                return _caretColor;
            }
            set
            {
                _caretColor = value;
            }
        }
        #endregion

        #region Attribute
        public int Zoom
        {
            get
            {
                return _editor.Zoom;
            }
            set
            {
                _editor.Zoom = value;
            }
        }
        
        public IndentView IndentationGuides
        {
            get
            {
                return _editor.IndentationGuides;
            }
            set
            {
                _editor.IndentationGuides = value;
            }
        }

        [Browsable(false)]
        public int CurrentPosition
        {
            get
            {
                return _editor.CurrentPosition;
            }
            set
            {
                _editor.CurrentPosition = value;
            }
        }

        public AutomaticFold AutomaticFold
        {
            get
            {
                return _editor.AutomaticFold;
            }
            set
            {
                _editor.AutomaticFold = value;
            }
        }

        public WrapMode WrapMode
        {
            get
            {
                return _editor.WrapMode;
            }
            set
            {
                _editor.WrapMode = value;
            }
        }

        public WhitespaceMode ViewWhitespace
        {
            get
            {
                return _editor.ViewWhitespace;
            }
            set
            {
                _editor.ViewWhitespace = value;
            }
        }


        public int SelectionStart
        {
            get
            {
                return _editor.SelectionStart;
            }
            set
            {
                _editor.SelectionStart = value;
            }
        }

        public int SelectionEnd
        {
            get
            {
                return _editor.SelectionEnd;
            }
            set
            {
                _editor.SelectionEnd = value;
            }
        }

        public string SelectedText
        {
            get
            {
                return _editor.SelectedText;
            }
        }

        public LineCollection Lines
        {
            get
            {
                return _editor.Lines;
            }
        }

        private string _filename = "";
        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                if (value != "")
                {
                    LoadDataFromFile(value);
                    _filename = value;
                    int index = value.LastIndexOf('\\') + 1;
                    _scriptName = value.Substring(index, value.Length - index);
                }
            }
        }

        private string _scriptName = "";
        public string ScriptName
        {
            get
            {
                return _scriptName;
            }
        }

        /// <summary>
        /// 编辑的脚本
        /// </summary>
        public new string Text
        {
            get
            {
                return _editor.Text;
            }
        }

        /// <summary>
        /// 右击菜单
        /// </summary>
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return _editor.ContextMenuStrip;
            }

            set
            {
                _editor.ContextMenuStrip = value;
            }
        }

        #endregion

        private SearchManager _searchManager = null;
        private ReplaceManager _replaceManager = null;
        private CommentManager _commentManager = null;

        public event EventHandler ScriptSaved = null;
        public new event EventHandler TextChanged = null;
        
        public LuaEditor()
        {
            InitializeComponent();
            _searchManager = new SearchManager(_editor);
            _replaceManager = new ReplaceManager(_editor);
            _commentManager = new CommentManager(_editor);
            searchPanel.BackColor = Color.FromArgb(TextBackColor.R + 50, TextBackColor.G + 50, TextBackColor.B + 50);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            InitEditor();
        }
        
        private void InitEditor()
        {
            //construct
            InitHotkeys();
            InitView();
            InitStyle();
            InitNumberMargin();
            InitBookmarkMargin();
            InitCodeFolding();
            InitDragDropFile();

            searchPanel.SearchText += Instance_SearchText;
            searchPanel.CountText += Instance_CountText;
            searchPanel.ReplaceText += Instance_ReplaceText;
        }

        private void Instance_ReplaceText(object sender, ReplaceEventArgs e)
        {
            if (e.ReplaceAll)
            {
                ReplaceTextMulti(e.OldText, e.NewText, e.ReplaceSelected);
            }
            else
            {
                ReplaceText(e.OldText, e.NewText, e.Positive);
            }
        }

        private void Instance_CountText(object sender, CountEventArgs e)
        {
            CountText(e.CountText);
        }

        private void Instance_SearchText(object sender, SearchEventArgs e)
        {
            SearchText(e);
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        private void InitView()
        {
            _editor.WrapMode = WrapMode.None;
            _editor.IndentationGuides = IndentView.None;
            _editor.MultipleSelection = true;
        }

        private static readonly string alphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string numericChars = "0123456789";
        private void InitStyle()
        {
            //Colors
            _editor.SetProperty("SCI_SETCODEPAGE", "SC_CP_UTF8");
            _editor.CaretForeColor = CaretColor; //color of cursor
            _editor.SetSelectionBackColor(true, SelectionBackColor);
            _editor.SetSelectionForeColor(true, SelectionForeColor);
            _editor.StyleResetDefault();
            _editor.Styles[Style.Default].Font = "Consolas";
            _editor.Styles[Style.Default].Size = 10;
            _editor.Styles[Style.Default].BackColor = TextBackColor;
            _editor.Styles[Style.Default].ForeColor = TextForeColor;
            _editor.StyleClearAll();
            // Configure the LUA lexer styles
            _editor.Styles[Style.Lua.Identifier].ForeColor = IntToColor(0xD0DAE2);
            _editor.Styles[Style.Lua.Comment].ForeColor = Color.Green;
            _editor.Styles[Style.Lua.CommentLine].ForeColor = IntToColor(0x40BF57);
            _editor.Styles[Style.Lua.CommentDoc].ForeColor = IntToColor(0x2FAE35);
            _editor.Styles[Style.Lua.Number].ForeColor = IntToColor(0xFFFF00);
            _editor.Styles[Style.Lua.String].ForeColor = IntToColor(0xFFFF00);
            _editor.Styles[Style.Lua.Character].ForeColor = IntToColor(0xE95454);
            _editor.Styles[Style.Lua.Preprocessor].ForeColor = IntToColor(0x8AAFEE);
            _editor.Styles[Style.Lua.Operator].ForeColor = Color.Gray;

            _editor.Styles[Style.Lua.Word].ForeColor = IntToColor(0x48A8EE);
            _editor.Styles[Style.Lua.Word2].ForeColor = IntToColor(0xF98906);
            _editor.Styles[Style.Lua.Word3].ForeColor = Color.Violet;
            _editor.Styles[Style.Lua.Word4].ForeColor = Color.Orange;
            _editor.Lexer = Lexer.Lua;
            _editor.WordChars = alphaChars + numericChars;
            //fold keywords
            _editor.SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while" + " false true" + " goto");
            _editor. SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall table math coroutine io os debug getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
            _editor.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult" + " bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift" + " utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
            _editor.SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname" + " coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath require package.cpath package.loaded package.loadlib package.path package.preload");
        }

        #region Color
        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0x2A211C;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0xB7B7B7;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = false;
        #endregion

        private void InitNumberMargin()
        {
            _editor.Styles[Style.LineNumber].BackColor = LineNumBackColor;
            _editor.Styles[Style.LineNumber].ForeColor = LineNumForeColor;
            _editor.Styles[Style.IndentGuide].ForeColor = LineNumForeColor; //IntToColor(FORE_COLOR);
            _editor.Styles[Style.IndentGuide].BackColor = LineNumBackColor;// IntToColor(BACK_COLOR);

            var nums = _editor.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            _editor.MarginClick += MarginClick; 
        }

        private void MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = _editor.Lines[_editor.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }

        private void InitBookmarkMargin()
        {
            //TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            var margin = _editor.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;
            var marker = _editor.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);
        }

        private void InitCodeFolding()
        {
            _editor.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            _editor.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            _editor.SetProperty("fold", "1");
            _editor.SetProperty("fold.compact", "0");

            // Configure a margin to display folding symbols
            _editor.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            _editor.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            _editor.Margins[FOLDING_MARGIN].Sensitive = true;
            _editor.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                _editor.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                _editor.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            _editor.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            _editor.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            _editor.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            _editor.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            _editor.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            _editor.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            _editor.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            _editor.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }
        
        public void InitDragDropFile()
        {
            AllowDrop = true;
            DragEnter += (sender, e) => {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            };
            DragDrop += (sender, e) => {

                // get file drop
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
                    if (a != null)
                    {
                        string path = a.GetValue(0).ToString();
                        LoadDataFromFile(path);
                    }
                }
            };
        }

        private void LoadDataFromFile(string path)
        {
            _editor.Text = File.ReadAllText(path);
        }
        
        Keys[] _keysInUse = new Keys[] { Keys.Z, Keys.Y, Keys.C, Keys.X, Keys.V, Keys.A };
        private void InitHotkeys()
        {
            HotKeyManager.AddHotKey(ParentForm, AddComment, Keys.M, true);
            HotKeyManager.AddHotKey(ParentForm, RemoveComment, Keys.M, true, false, true);
            HotKeyManager.AddHotKey(ParentForm, AddFunctionComment, Keys.F, true, true);
            HotKeyManager.AddHotKey(ParentForm, Save, Keys.S, true, false, false);
            HotKeyManager.AddHotKey(ParentForm, OpenSearchDialog, Keys.F, true, false, false, true);
            HotKeyManager.AddHotKey(ParentForm, OpenSearchDialog, Keys.H, true, false, false, false);
            HotKeyManager.AddHotKey(ParentForm, CloseSearchDialog, Keys.Escape);
            HotKeyManager.AddHotKey(ParentForm, Uppercase, Keys.U, true);
            HotKeyManager.AddHotKey(ParentForm, Lowercase, Keys.L, true);
            HotKeyManager.AddHotKey(ParentForm, ZoomIn, Keys.Oemplus, true);
            HotKeyManager.AddHotKey(ParentForm, ZoomOut, Keys.OemMinus, true);
            HotKeyManager.AddHotKey(ParentForm, () => { Zoom = 0; }, Keys.D0, true);

            // remove conflicting hotkeys from scintilla
            for (int i = 65; i <= 90; i++)
            {
                Keys key = (Keys)i;
                if (!_keysInUse.Contains(key))
                {
                    _editor.ClearCmdKey(Keys.Control | (Keys)i);
                }
            }
        }

        #region Comment
        public void AddComment()
        {
            _commentManager.AddComment();
        }

        public void RemoveComment()
        {
            _commentManager.RemoveComment();
        }

        public void AddFunctionComment()
        {
            _commentManager.AddFunctionComment();
        }

        private void 插入注释ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFunctionComment();
        }

        private void 注释ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddComment();
        }

        private void 取消注释ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveComment();
        }
        #endregion

        #region upper & lower
        public void Lowercase()
        {

            // save the selection
            int start = _editor.SelectionStart;
            int end = _editor.SelectionEnd;

            // modify the selected text
            _editor.ReplaceSelection(_editor.GetTextRange(start, end - start).ToLower());

            // preserve the original selection
            _editor.SetSelection(start, end);
        }

        public void Uppercase()
        {

            // save the selection
            int start = _editor.SelectionStart;
            int end = _editor.SelectionEnd;

            // modify the selected text
            _editor.ReplaceSelection(_editor.GetTextRange(start, end - start).ToUpper());

            // preserve the original selection
            _editor.SetSelection(start, end);
        }
        #endregion

        #region search && replace
        public int Search(string text , bool positive)
        {
            return _searchManager.Search(text, positive);
        }

        public int[] SearchMulti(string text)
        {
            return _searchManager.SearchMulti(text);
        }

        public int Replace(string strOld , string strNew , bool positive)
        {
            return _replaceManager.Replace(strOld, strNew, positive);
        }

        public void ReplaceMulti(string strOld, string strNew , bool replcaeSelected)
        {
            _replaceManager.ReplaceMulti(strOld, strNew, replcaeSelected);
        }
        
        private void OpenSearchDialog(object[] objs)
        {
            bool b = (bool)objs[0];
            if (!searchPanel.Visible)
            {
                searchPanel.Visible = true;
                searchPanel.SearchOrReplace = b;
            }
        }

        public void CloseSearchDialog()
        {
            if (searchPanel.Visible)
            {
                searchPanel.Visible = false;
            }
        }

        public void OpenSearchDialog(bool searchOrReplace)
        {
            OpenSearchDialog(new object[] { searchOrReplace });
        }

        #endregion

        #region Indent
        public void Indent()
        {
            GenerateKeystrokes("{TAB}");
        }

        public void Outdent()
        {
            GenerateKeystrokes("+{TAB}");
        }

        private void GenerateKeystrokes(string keys)
        {
            HotKeyManager.Enable = false;
            SendKeys.Send(keys);
            HotKeyManager.Enable = true;
        }
        #endregion

        #region edit
        public void ZoomIn()
        {
            _editor.ZoomIn();
        }

        public void ZoomOut()
        {
            _editor.ZoomOut();
        }

        public void ReplaceSelection(string strNew)
        {
            _editor.ReplaceSelection(strNew);
        }

        public void Paste()
        {
            _editor.Paste();
        }

        public void FoldAll(FoldAction action)
        {
            _editor.FoldAll(action);
        }

        public void InsertText(int pos, string text)
        {
            _editor.InsertText(pos, text);
        }

        public void Cut()
        {
            _editor.Cut();
        }

        public void Copy()
        {
            _editor.Copy();
        }

        private void SearchText(SearchEventArgs args)
        {
            if (args.MulitSearch)
            {
                SearchTextMulti(args.SearchText);
            }
            else
            {
                SearchText(args.SearchText, args.Positive);
            }
        }

        public void CountText(string text)
        {
            int count = System.Text.RegularExpressions.Regex.Matches(_editor.Text, text).Count;
            MessageBox.Show("匹配到" + count.ToString() + "个！");
        }

        public int SearchText(string text, bool positive)
        {
            return _searchManager.Search(text, positive);
        }

        public int[] SearchTextMulti(string text)
        {
            return _searchManager.SearchMulti(text);
        }

        public int ReplaceText(string strOld, string strNew, bool positive)
        {
            return _replaceManager.Replace(strOld, strNew, positive);
        }

        public void ReplaceTextMulti(string strOld, string strNew, bool replaceSelected)
        {
            _replaceManager.ReplaceMulti(strOld, strNew, replaceSelected);
        }
        #endregion

        #region select
        
        public void SelectCurrentLine()
        {
            var line = _editor.Lines.FirstOrDefault(x =>
            {
                return (x.Position <= _editor.CurrentPosition && x.EndPosition > _editor.CurrentPosition);
            });
            _editor.SetSelection(line.Position, line.EndPosition);
        }

        public void SetSelection(int caret, int anchor)
        {
            _editor.SetSelection(caret, anchor);
        }

        public void SelectAll()
        {
            _editor.SelectAll();
        }

        private void 选中当前行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectCurrentLine();
        }
        
        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        #endregion

        #region file
        
        /// <summary>
        /// 保存代码
        /// </summary>
        public void Save()
        {
            if (Filename != "")
            {
                System.IO.File.WriteAllText(Filename, _editor.Text);
                OnScriptSaved();
            }
        }

        protected void OnScriptSaved()
        {
            if (ScriptSaved != null)
            {
                ScriptSaved.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 保存代码至指定路径
        /// </summary>
        /// <param name="filename"></param>
        public void SaveTo(string filename)
        {
            System.IO.File.WriteAllText(filename, _editor.Text);
        }

        public void ImportScriptFile(string filename)
        {
            _editor.Text = System.IO.File.ReadAllText(filename);
        }
        #endregion

        private void _editor_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
            {
                TextChanged.Invoke(this, e);
            }
        }

        //#region Insert Extension Function
        ///// <summary>
        ///// 插入扩展函数菜单项
        ///// </summary>
        ///// <param name="strClass">类别</param>
        ///// <param name="strFuncName">函数名称</param>
        ///// <param name="strFuncFull">函数声明</param>
        ///// <param name="strComment">函数注释</param>
        //public void InsertExtensionFunction(string strClass , string strFuncName , string strFuncFull , string strComment)
        //{
        //    var itemRoot = menu.Items[5] as ToolStripMenuItem; // root node 插入扩展函数
        //    int index = IndexFunctionClass(strClass); // index of class node
        //    ToolStripItem itemClass = null;
        //    ToolStripItem itemFunc = null;
        //    if (index != -1)
        //    {
        //        itemClass = itemRoot.DropDownItems[index];
        //    }
        //    else
        //    {
        //        int indexItemClass = itemRoot.DropDownItems.Add(new ToolStripMenuItem(strClass));
        //        itemClass = itemRoot.DropDownItems[indexItemClass];
        //    }
        //    itemFunc = (itemClass as ToolStripMenuItem).DropDownItems.Add(strFuncName);
        //    //itemFunc.Tag = strFuncFull;
        //    itemFunc.Click += (obj, args) =>
        //    {
        //        string strInsert = (strComment == null || strComment == "") ? strFuncFull : string.Format("{0}\r\n{1}", strComment, strFuncFull);
        //        _editor.InsertText(_editor.CurrentPosition, strInsert);
        //    };
        //}

        //private int IndexFunctionClass(string strClass)
        //{
        //    var itemRoot = menu.Items[5] as ToolStripMenuItem;
        //    if (itemRoot != null)
        //    {
        //        for (int i = 0; i < itemRoot.DropDownItems.Count; i++)
        //        {
        //            if (itemRoot.DropDownItems[i].Text == strClass)
        //            {
        //                return i;
        //            }
        //        }
        //    }
        //    return -1;
        //}
        //#endregion
    }
}
