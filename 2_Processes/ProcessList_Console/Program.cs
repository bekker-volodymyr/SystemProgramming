using System.Diagnostics;

namespace ProcessList_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // встановлюємо заголовок коннсолі
            Console.Title = "Список процесів";
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            while (true)
            {
                // отримуємо список процесів
                Process[] processes = Process.GetProcesses();

                // для кожного процесу виводимо ім'я і PID
                foreach (Process p in processes)
                    Console.WriteLine($"Ім'я процесу: {p.ProcessName} ==== PID: {p.Id}");

                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
