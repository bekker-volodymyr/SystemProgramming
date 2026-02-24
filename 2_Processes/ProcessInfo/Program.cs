using System.Diagnostics;
using System.Text;

namespace ProcessInfo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Отримуємо посилання на поточний процес, у якому працює ця програма
            Process self = Process.GetCurrentProcess();

            Console.Title = $"Monitoring: {self.ProcessName} (PID: {self.Id})";
            Console.WriteLine("Натисніть Ctrl+C, щоб зупинити програму.\n");

            while (true)
            {
                // Оновлюємо стан процесу, щоб отримати актуальні дані про ресурси
                self.Refresh();

                Console.Clear();
                Console.WriteLine("=== Інформація про поточний процес ===");
                Console.WriteLine($"Назва:            {self.ProcessName}");
                Console.WriteLine($"PID:              {self.Id}");
                Console.WriteLine($"Пріоритет:       {self.PriorityClass}");

                // Переводимо байти в Мегабайти для зручності
                long memUsed = self.WorkingSet64 / 1024 / 1024;
                Console.WriteLine($"Пам'ять (RAM):    {memUsed} MB");

                // Кількість активних потоків всередині процесу
                Console.WriteLine($"Кількість потоків: {self.Threads.Count}");

                // Загальний час, який процесор виділив цьому процесу
                Console.WriteLine($"Процесорний час:  {self.TotalProcessorTime.TotalSeconds:F2} сек");

                Console.WriteLine("=======================================");

                // Робимо невелику паузу, щоб не перевантажувати консоль
                Thread.Sleep(1000);
            }
        }
    }
}
