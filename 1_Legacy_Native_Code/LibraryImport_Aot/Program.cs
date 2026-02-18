namespace LibraryImport_Aot
{
    public class Program
    {
        static void Main(string[] args)
        {
            NativeMethods.MessageBoxW(new nint(0), "Привіт!", "Привітання!", 2);
        }
    }
}
