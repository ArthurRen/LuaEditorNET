﻿using System;
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
    public static class HotKeyManager
    {
        public static bool Enable = true;

        public static void AddHotKey(Form form, Action function, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
        {
            form.KeyPreview = true;

            form.KeyDown +=(obj , args)=> {
                if (IsHotkey(args, key, ctrl, shift, alt))
                {
                    function();
                }
            };
        }

        public static bool IsHotkey(KeyEventArgs eventData, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
        {
            return eventData.KeyCode == key && eventData.Control == ctrl && eventData.Shift == shift && eventData.Alt == alt;
        }
    }
}
