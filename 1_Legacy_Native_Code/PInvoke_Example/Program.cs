using System.Runtime.InteropServices;
using System.Text;

namespace PInvoke_Example
{
    public class Program
    {
        static void Main(string[] args)
        {
            NativeMethods.Beep(1000, 1000);

            NativeMethods.printf("Print params: %i %f", __arglist(10, 10.78));
            NativeMethods.printf("\nPrint params: %i %s", __arglist(10, "abc"));

            NativeMethods.MessageBox(new nint(0), "Hello, World!", "Message Box", 0);

            NativeMethods.PrintLineFormat("\nPrint: %i %f %s", __arglist(12, 12.3, "hello"));

            NativeMethods.MessageBoxW(new nint(0), "Привіт, світе!", "Повідомлення коробка", 1);

            IntPtr handle = NativeMethods.LoadLibrary("fakelibrary.dll");
            if(handle == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                Console.WriteLine($"\nError {errorCode}");
            }

            NativeMethods.EnumWindows(NativeMethods.OutputWindow, IntPtr.Zero);

            StringBuilder sb = new StringBuilder(260);

            uint result = NativeMethods.GetSystemDirectory(sb, (uint)sb.Capacity);

            if (result > 0)
            {
                Console.WriteLine($"Системна директорія: {sb.ToString()}");
            }
            else
            {
                Console.WriteLine($"Помилка! Код: {Marshal.GetLastWin32Error()}");
            }

            // Даний приклад не працює, бо функція GetVersionEx вважається застарілою та повертає false
            OSVERSIONINFO os = new OSVERSIONINFO();
            os.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFO));

            if (NativeMethods.GetVersionEx(ref os))
            {
                Console.WriteLine($"Версія: {os.dwMajorVersion}.{os.dwMinorVersion}");
                Console.WriteLine($"Build: {os.dwBuildNumber}");
                Console.WriteLine($"Service Pack: {os.szCSDVersion}");
            }
        }
    }
}
