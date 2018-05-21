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
    static class HotKeyManager
    {
        public static bool Enable = true;

        public static void AddHotKey(Form form, Action<object[]> action, Keys key, bool ctrl = false, bool shift = false, bool alt = false, params object[] objs)
        {
            form.KeyPreview = true;

            form.KeyDown += delegate (object sender, KeyEventArgs e) {
                if (IsHotkey(e, key, ctrl, shift, alt))
                {
                    action(objs);
                }
            };
        }

        public static void AddHotKey(Form form, Action action, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
        {
            form.KeyPreview = true;

            form.KeyDown += (sender, e) =>
            {
                if (IsHotkey(e, key, ctrl, shift, alt))
                {
                    action();
                }
            };
        }

        public static bool IsHotkey(KeyEventArgs eventData, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
        {
            return eventData.KeyCode == key && eventData.Control == ctrl && eventData.Shift == shift && eventData.Alt == alt;
        }
    }
}
