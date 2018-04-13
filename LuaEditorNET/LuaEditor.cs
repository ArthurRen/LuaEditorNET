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

namespace CodeEditorNet.Lua
{
    public partial class LuaEditor : UserControl
    {
        ScintillaNET.Scintilla _editor = null;

        private Color _selectionBackColor = Color.FromArgb(14, 69, 131 );
        [Description("文本被选中后的背景色")]
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

        public LuaEditor()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            InitEditor();
        }
        
        /// <summary>
        /// Initialize the editor attribute
        /// </summary>
        private void InitEditor()
        {
            //construct
            _editor = new Scintilla();
            _editor.Location = new Point(0, menu.Bottom);
            _editor.Width = this.ClientSize.Width;
            _editor.Height = this.ClientSize.Height - menu.ClientSize.Height;
            _editor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            _editor.TabWidth = 4;

            Controls.Add(_editor);

            InitHotkeys();
            InitView();
            InitStyle();
            InitNumberMargin();
            InitBookmarkMargin();
            InitCodeFolding();
            InitDragDropFile();
            InitHotkeys();
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        private void InitView()
        {
            _editor.WrapMode = WrapMode.None;
            _editor.IndentationGuides = IndentView.None;
        }

        string alphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numericChars = "0123456789";
        private void InitStyle()
        {
            //Colors
            _editor.CaretForeColor = Color.White; //color of cursor
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

            _editor.Styles[Style.Lua.Word].ForeColor = IntToColor(0x007ACC);
            _editor.Styles[Style.Lua.Word2].ForeColor = Color.Gray;
            _editor.Styles[Style.Lua.Word3].ForeColor = Color.Violet;
            _editor.Styles[Style.Lua.Word4].ForeColor = Color.Orange; 
            //_editor.Styles[Style.Lua.Word5].ForeColor = Color.Black;
            //_editor.Styles[Style.Lua.Word6].ForeColor = IntToColor(0xF98906);
            //_editor.Styles[Style.Lua.Word7].ForeColor = Color.Black;
            //_editor.Styles[Style.Lua.Word8].ForeColor = IntToColor(0xF98906);
            _editor.Lexer = Lexer.Lua;
            _editor.WordChars = alphaChars + numericChars;
            // Keywords
            _editor.SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while" + " false true" + " goto");
            // Basic Functions
            _editor.SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug" + " getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
            // String Manipulation & Mathematical
            _editor.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan" + " string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult" + " bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift" + " utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
            // Input and Output Facilities and System Facilities
            _editor.SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname" + " coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath" + " require package.cpath package.loaded package.loadlib package.path package.preload");

            //_editor.SetKeywords(4, "");
            //_editor.SetKeywords(5, "local");
            //_editor.SetKeywords(6, "local");
            //_editor.SetKeywords(7, "local");
        }
        
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

            _editor.MarginClick += _editor_MarginClick;
        }

        private void _editor_MarginClick(object sender, MarginClickEventArgs e)
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
            _editor.SetProperty("fold.compact", "0"); //不知道为什么置0后 LUA就可以折叠function段代码了？？？

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
            _editor.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            _editor.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            _editor.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            _editor.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            _editor.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            _editor.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            _editor.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
           
            // Enable automatic folding
            _editor.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }
        
        public void InitDragDropFile()
        {

            _editor.AllowDrop = true;
            _editor.DragEnter += (sender, e) => {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            };
            _editor.DragDrop += (sender, e) => {

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
            if (File.Exists(path))
            {
                _editor.Text = File.ReadAllText(path);
            }
        }

        private void InitHotkeys()
        {

            // register the hotkeys with the form
            HotKeyManager.AddHotKey(this.ParentForm, OpenSearch, Keys.F, true);
            //HotKeyManager.AddHotKey(this.ParentForm, OpenFindDialog, Keys.F, true, false, true);
            //HotKeyManager.AddHotKey(this.ParentForm, OpenReplaceDialog, Keys.R, true);
            //HotKeyManager.AddHotKey(this.ParentForm, OpenReplaceDialog, Keys.H, true);
            HotKeyManager.AddHotKey(this.ParentForm, Uppercase, Keys.U, true);
            HotKeyManager.AddHotKey(this.ParentForm, Lowercase, Keys.L, true);
            HotKeyManager.AddHotKey(this.ParentForm, ZoomIn, Keys.Oemplus, true);
            HotKeyManager.AddHotKey(this.ParentForm, ZoomOut, Keys.OemMinus, true);
            HotKeyManager.AddHotKey(this.ParentForm, ZoomDefault, Keys.D0, true);
            HotKeyManager.AddHotKey(this.ParentForm, CloseSearch, Keys.Escape);

            // remove conflicting hotkeys from scintilla
            _editor.ClearCmdKey(Keys.Control | Keys.F);
            _editor.ClearCmdKey(Keys.Control | Keys.R);
            _editor.ClearCmdKey(Keys.Control | Keys.H);
            _editor.ClearCmdKey(Keys.Control | Keys.L);
            _editor.ClearCmdKey(Keys.Control | Keys.U);
            _editor.ClearCmdKey(Keys.Control | Keys.S);
        }

        private void ZoomIn()
        {
            _editor.ZoomIn();
        }

        private void ZoomOut()
        {
            _editor.ZoomOut();
        }

        private void ZoomDefault()
        {
            _editor.Zoom = 0;
        }

        private void CloseSearch()
        {
            if (SearchIsOpen)
            {
                SearchIsOpen = false;
                InvokeIfNeeded(delegate () {
                    PanelSearch.Visible = false;
                    //CurBrowser.GetBrowser().StopFinding(true);
                });
            }
        }

        private void Lowercase()
        {

            // save the selection
            int start = _editor.SelectionStart;
            int end = _editor.SelectionEnd;

            // modify the selected text
            _editor.ReplaceSelection(_editor.GetTextRange(start, end - start).ToLower());

            // preserve the original selection
            _editor.SetSelection(start, end);
        }

        private void Uppercase()
        {

            // save the selection
            int start = _editor.SelectionStart;
            int end = _editor.SelectionEnd;

            // modify the selected text
            _editor.ReplaceSelection(_editor.GetTextRange(start, end - start).ToUpper());

            // preserve the original selection
            _editor.SetSelection(start, end);
        }

        bool SearchIsOpen = false;
        private void OpenSearch()
        {
            SearchManager.SearchBox = TxtSearch;
            SearchManager.TextArea = _editor;

            if (!SearchIsOpen)
            {
                SearchIsOpen = true;
                InvokeIfNeeded(delegate () {
                    PanelSearch.Visible = true;
                    TxtSearch.Text = SearchManager.LastSearch;
                    TxtSearch.Focus();
                    TxtSearch.SelectAll();
                });
            }
            else
            {
                InvokeIfNeeded(delegate () {
                    TxtSearch.Focus();
                    TxtSearch.SelectAll();
                });
            }
        }

        private void wordWrapItem_Click(object sender, EventArgs e)
        {
            wordWrapItem.Checked = !wordWrapItem.Checked;
            _editor.WrapMode = wordWrapItem.Checked ? WrapMode.Word : WrapMode.None;
        }

        public void InvokeIfNeeded(Action action)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (HotKeyManager.IsHotkey(e, Keys.Enter))
            {
                SearchManager.Find(true, false);
            }
            if (HotKeyManager.IsHotkey(e, Keys.Enter, true) || HotKeyManager.IsHotkey(e, Keys.Enter, false, true))
            {
                SearchManager.Find(false, false);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchManager.Find(true, true);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (importFileDialog.ShowDialog() == DialogResult.OK)
            {
                _editor.Text = File.ReadAllText(importFileDialog.FileName);
            }
        }

        private void BtnCloseSearch_Click(object sender, EventArgs e)
        {
            CloseSearch();
        }

        private void BtnNextSearch_Click(object sender, EventArgs e)
        {
            SearchManager.Find(true, false);
        }

        private void BtnPrevSearch_Click(object sender, EventArgs e)
        {
            SearchManager.Find(false, false);
        }
    }
}
