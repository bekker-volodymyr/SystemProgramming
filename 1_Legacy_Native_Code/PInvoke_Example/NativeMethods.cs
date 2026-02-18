using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PInvoke_Example
{
    public static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(uint dwFreq, uint dwDuration);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int printf(string format, __arglist);

        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string msg, string caption, uint type);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "printf")]
        public static extern int PrintLineFormat(string format, __arglist);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling =true)]
        public static extern int MessageBoxW(IntPtr hWnd, string msg, string caption, uint type);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        public delegate bool EnumWC(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWC lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public static bool OutputWindow(IntPtr hwnd, IntPtr lParam)
        {
            StringBuilder sb = new StringBuilder(256);

            if (GetWindowText(hwnd, sb, sb.Capacity) > 0)
            {
                string windowName = sb.ToString();
                Console.WriteLine($"HWND: {hwnd.ToInt64().ToString().PadRight(10)} | Title: {windowName}");
            }

            return true;
        }
    }
}
