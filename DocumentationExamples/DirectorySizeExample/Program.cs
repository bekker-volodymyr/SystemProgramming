using System.Diagnostics;

namespace DirectorySizeExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long totalSize = 0;

            //if (args.Length == 0)
            //{
            //    Console.WriteLine("There are no command line arguments.");
            //    return;
            //}

            Console.WriteLine("Enter path to the directory: ");
            string? path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("The directory does not exist.");
                return;
            }

            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            Stopwatch sw = Stopwatch.StartNew();

            foreach (var file in files)
            {
                FileInfo fi = new FileInfo(file);
                long size = fi.Length;
                totalSize += size;
            }

            Console.WriteLine($"Time subsequent: {sw.ElapsedMilliseconds}");

            totalSize = 0;

            sw = Stopwatch.StartNew();

            Parallel.For(0, files.Length,
                         index =>
                         {
                             FileInfo fi = new FileInfo(files[index]);
                             long size = fi.Length;
                             Interlocked.Add(ref totalSize, size);
                         });

            Console.WriteLine($"Time parallel: {sw.ElapsedMilliseconds}");

            Console.WriteLine($"Directory '{path}':");
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
        }
    }
}
