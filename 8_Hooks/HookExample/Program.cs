using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HookExample
{
    internal static class Program
    {
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private const int WM_MOUSEMOVE = 0x0200;

        private static HookProc procWinKeyBlock = HookCallback_WinKeyBlock;
        private static HookProc procMouseMove = HookCallback_MouseMove;
        private static IntPtr hookWinKey = IntPtr.Zero;
        private static IntPtr hookMouseMove = IntPtr.Zero;

        [STAThread]
        static void Main()
        {
            hookWinKey = SetHook(procWinKeyBlock);
            hookMouseMove = SetHook(procMouseMove);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            UnhookWindowsHookEx(hookWinKey);
            UnhookWindowsHookEx(hookMouseMove);
        }

        private static IntPtr SetHook(HookProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback_WinKeyBlock(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if ((nCode >= 0) && (wParam == (IntPtr)WM_KEYDOWN))
            {
                int wkCode = Marshal.ReadInt32(lParam);
                if (((Keys)wkCode == Keys.LWin) || ((Keys)wkCode == Keys.RWin))
                {
                    Console.WriteLine("{0} blocked!", (Keys)wkCode);
                    return (IntPtr)1;
                }
            }
            return CallNextHookEx(hookWinKey, nCode, wParam, lParam);
        }

        private static IntPtr HookCallback_MouseMove(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if ((nCode >= 0) && (wParam == (IntPtr)WM_MOUSEMOVE))
            {
                int X = Marshal.ReadInt32(lParam);
                if (X < 400) return (IntPtr)1;
            }
            return CallNextHookEx(hookWinKey, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}