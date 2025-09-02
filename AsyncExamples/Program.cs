using System.Diagnostics;

namespace AsyncExamples
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Say Hello Async
            var task = SayHelloAsync(); // Створюємо асинхронний виклик

            await task; // очікуємо завершення виконання асинхронної операції

            Console.WriteLine("Finish");
            #endregion

            #region Progress Bar

            Task work = Task.Run(async () =>
            {
                await Task.Delay(3000);
            });

            while (!work.IsCompleted)
            {
                Console.Write(".");
                await Task.Delay(300);
            }

            Console.WriteLine("\nDone!");

            #endregion

            #region Sync vs. Async

            var sw = Stopwatch.StartNew();

            Console.WriteLine($"Main запущено на потоці: {Thread.CurrentThread.ManagedThreadId}");

            Task t1 = SimulateWorkAsync("Задача 1", 2000);
            Task t2 = SimulateWorkAsync("Задача 2", 2000);
            Task t3 = SimulateWorkAsync("Задача 3", 2000);

            Console.WriteLine("Усі задачі запущено паралельно");

            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine($"Час (асинхронно): {sw.Elapsed.TotalSeconds} сек");
            Console.WriteLine("Усі задачі завершено");

            sw = Stopwatch.StartNew();

            await SimulateWorkAsync("Задача 1", 2000);
            await SimulateWorkAsync("Задача 2", 2000);
            await SimulateWorkAsync("Задача 3", 2000);

            Console.WriteLine($"Час (по черзі): {sw.Elapsed.TotalSeconds} сек");

            #endregion
        }

        static async Task SimulateWorkAsync(string name, int delayMs)
        {
            Console.WriteLine($"{name} стартувала на потоці {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(delayMs);
            Console.WriteLine($"{name} завершилась на потоці {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task SayHelloAsync()
        {
            Console.WriteLine("Working...");
            await Task.Delay(3000);
            Console.WriteLine("Hello World!");
        }
    }
}
