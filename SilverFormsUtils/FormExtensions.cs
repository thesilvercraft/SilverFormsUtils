namespace SilverFormsUtils
{
    public static class FormExtensions
    {
        /// <summary>
        /// Calls the windows api to make the title bar dark
        /// </summary>
        /// <remarks>
        /// You may need windows 10 enabled as an os that the app has been tested with for this to work in your app.manifest, and you need windows 10 1809 at least
        /// </remarks>
        /// <param name="useDarkMode">Do we make the titlebar dark or light</param>
        /// <returns>A bool stating if the operation was a success or a faliure</returns>
        public static bool UseDarkModeBar(this Form frm, bool useDarkMode = true)
        {
            return UseDarkMode.UseImmersiveDarkMode(frm.Handle, useDarkMode);
        }

        public static long SetRoundPreference(this Form frm, RoundTheWindow.RoundPreference pref)
        {
            return RoundTheWindow.RoundWindow(frm.Handle, pref);
        }

        private static void ColoringLogic(object t, bool dark, bool flat)
        {
            if (t is SplitContainer sc)
            {
                foreach (var mt in sc.Panel1.Controls)
                {
                    ColoringLogic(mt, dark, flat);
                }
                foreach (var mt in sc.Panel2.Controls)
                {
                    ColoringLogic(mt, dark, flat);
                }
            }
            if (t is GroupBox gb)
            {
                gb.ForeColor = dark ? Color.White : SystemColors.ControlText;
                foreach (var mt in gb.Controls)
                {
                    ColoringLogic(mt, dark, flat);
                }
            }
            if (dark)
            {
                if (t is RichTextBox rtb)
                {
                    if (flat)
                    {
                        rtb.BorderStyle = BorderStyle.None;
                    }
                    else
                    {
                        rtb.BorderStyle = BorderStyle.Fixed3D;
                    }
                    if (rtb.BackColor == Color.Black || rtb.BackColor == SystemColors.Window || rtb.BackColor == SystemColors.Control)
                    {
                        rtb.BackColor = Color.FromArgb(37, 37, 37);
                    }
                    if (rtb.ForeColor == SystemColors.WindowText)
                    {
                        rtb.ForeColor = Color.White;
                    }
                }
                if (t is Button btn)
                {
                    if (btn.BackColor == Color.Black || btn.BackColor == SystemColors.Control)
                    {
                        btn.BackColor = Color.FromArgb(37, 37, 37);
                    }
                    if (btn.ForeColor == Color.White || btn.ForeColor == SystemColors.ControlText)
                    {
                        btn.ForeColor = Color.White;
                    }
                    if (flat)
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 45);
                    }
                    else
                    {
                        btn.UseVisualStyleBackColor = true;
                        btn.FlatStyle = FlatStyle.System;
                    }
                }
                if (t is TreeView tv)
                {
                    if (tv.BackColor == SystemColors.Window)
                    {
                        tv.BackColor = Color.Black;
                    }
                    if (tv.ForeColor == SystemColors.WindowText)
                    {
                        tv.ForeColor = Color.White;
                    }
                }
                if (t is ComboBox cmb)
                {
                    if (cmb.ForeColor == SystemColors.WindowText)
                    {
                        cmb.ForeColor = Color.White;
                    }
                    if (cmb.BackColor == SystemColors.Window)
                    {
                        cmb.BackColor = Color.Black;
                    }
                    if (flat)
                    {
                        cmb.FlatStyle = FlatStyle.Flat;
                    }
                    else
                    {
                        cmb.FlatStyle = FlatStyle.System;
                    }
                }
            }
            else
            {
                if (t is RichTextBox rtb)
                {
                    if (flat)
                    {
                        rtb.BorderStyle = BorderStyle.None;
                    }
                    else
                    {
                        rtb.BorderStyle = BorderStyle.Fixed3D;
                    }
                    if (rtb.BackColor == Color.FromArgb(37, 37, 37))
                    {
                        rtb.BackColor = SystemColors.Window;
                    }
                    if (rtb.ForeColor == Color.White)
                    {
                        rtb.ForeColor = SystemColors.WindowText;
                    }
                }
                if (t is Button btn)
                {
                    if (btn.BackColor == Color.FromArgb(37, 37, 37))
                    {
                        btn.BackColor = SystemColors.Control;
                    }
                    if (btn.ForeColor == Color.White)
                    {
                        btn.ForeColor = SystemColors.ControlText;
                    }
                    if (btn.FlatStyle == FlatStyle.Flat && !flat)
                    {
                        btn.FlatStyle = FlatStyle.Standard;
                    }
                }
                if (t is TreeView tv)
                {
                    if (tv.BackColor == Color.Black)
                    {
                        tv.BackColor = SystemColors.Window;
                    }
                    if (tv.ForeColor == Color.White)
                    {
                        tv.ForeColor = SystemColors.WindowText;
                    }
                }
                if (t is ComboBox cmb)
                {
                    if (cmb.ForeColor == Color.White)
                    {
                        cmb.ForeColor = SystemColors.WindowText;
                    }
                    if (cmb.BackColor == Color.Black)
                    {
                        cmb.BackColor = SystemColors.Window;
                    }
                    cmb.FlatStyle = FlatStyle.Standard;
                }
            }
        }

        /// <summary>
        /// This method intentionally has a long name to discourage you from using it as I have coded it myself and may not work the way you want or expect and may break other things right now or in the future.
        /// </summary>
        /// <param name="frm"></param>
        /// <returns></returns>
        public static bool UseDarkModeForThingsInsideOfForm(this Form frm, bool dark = true, bool flat = false)
        {
            if (dark)
            {
                if (frm.BackColor == SystemColors.Control)
                {
                    frm.BackColor = Color.Black;
                }
                if (frm.ForeColor == SystemColors.ControlText)
                {
                    frm.ForeColor = Color.White;
                }
                foreach (var t in frm.Controls)
                {
                    ColoringLogic(t, dark, flat);
                }
            }
            else
            {
                if (frm.BackColor == Color.Black)
                {
                    frm.BackColor = SystemColors.Control;
                }
                if (frm.ForeColor == Color.White)
                {
                    frm.ForeColor = SystemColors.ControlText;
                }
                foreach (var t in frm.Controls)
                {
                    ColoringLogic(t, dark, flat);
                }
            }
            return true;
        }
    }
}