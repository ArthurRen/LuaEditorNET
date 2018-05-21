using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEditorNet.Lua
{
    class SearchEventArgs : EventArgs
    {
        /// <summary>
        /// 是否是正向（由上到下）搜索
        /// </summary>
        public bool Positive { get; set; }
        /// <summary>
        /// 搜索文本
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 多项搜索
        /// </summary>
        public bool MulitSearch { get; set; }

        public SearchEventArgs()
        {
            Positive = true;
            SearchText = "";
            MulitSearch = false;
        }
    }
}
