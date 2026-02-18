using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LibraryImport_Aot
{
    public partial class NativeMethods
    {
        [LibraryImport("user32.dll", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
        public static partial int MessageBoxW(IntPtr hWnd, string lpText, string lpCaption, uint uType);   
    }
}
