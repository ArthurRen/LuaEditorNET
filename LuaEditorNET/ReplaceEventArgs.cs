using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEditorNet.Lua
{
    class ReplaceEventArgs : EventArgs
    {
        /// <summary>
        /// 旧的被替换的文本
        /// </summary>
        public string OldText { get; set; }
        /// <summary>
        /// 新的替换的文本
        /// </summary>
        public string NewText { get; set; }
        /// <summary>
        /// 是否替换选中的区域
        /// </summary>
        public bool ReplaceSelected { get; set; }
        /// <summary>
        /// 是否替换所有找到的目标
        /// </summary>
        public bool ReplaceAll { get; set; }
        /// <summary>
        /// 是否是正向（由上到下）搜索
        /// </summary>
        public bool Positive { get; set; }
    }
}
