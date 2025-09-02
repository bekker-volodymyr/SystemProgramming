namespace ThreadPoolExamples
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            #region Basic Thread Pool Example

            Console.WriteLine($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}");

            // Додаємо виконавця (метод) у ThreadPool
            // Виконання методу починається автоматично, якщо є вільний потік
            ThreadPool.QueueUserWorkItem((state) =>
            {
                Console.WriteLine($"Thread in thread pool Id: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(5000);
                Console.WriteLine($"Work finished on thread with id: {Thread.CurrentThread.ManagedThreadId}");
            });

            Thread.Sleep(6000); // Чекаємо на завершення потоку з ThreadPool

            #endregion

            #region Example of re-used threads in ThreadPool

            for (int i = 0; i < 4; i++)
            {
                ThreadPool.QueueUserWorkItem(PrintThreadIdAndWait);
            }

            Thread.Sleep(6000);

            for (int i = 0; i < 4; i++)
            {
                ThreadPool.QueueUserWorkItem(PrintThreadIdAndWait);
            }

            Thread.Sleep(6000);

            #endregion

            #region ThreadPool Info

            int workerThreads;
            int portThreads; // Використовується асинхронними потоками вводу-виводу

            // Визначаємо мінімальну кількість потоків (зазвичай залежить від кількості ядер процесора)
            ThreadPool.GetMinThreads(out workerThreads, out portThreads);
            Console.WriteLine("\nMinimum worker threads: \t{0}" +
                "\nMinimum completion port threads: {1}",
                workerThreads, portThreads);

            // Визначаємо максимальну кількість потоків
            ThreadPool.GetMaxThreads(out workerThreads, out portThreads);
            Console.WriteLine("\nMaximum worker threads: \t{0}" +
                "\nMaximum completion port threads: {1}",
                workerThreads, portThreads);

            // Встановлюємо максимум потоків - 12
            ThreadPool.SetMaxThreads(12, 1000);

            // Перевіряємо новий максимум
            ThreadPool.GetMaxThreads(out workerThreads, out portThreads);
            Console.WriteLine("\nMaximum worker threads: \t{0}" +
                "\nMaximum completion port threads: {1}",
                workerThreads, portThreads);

            // Додаємо виконавців більше, ніж максимум
            for (int i = 0; i < 14; i++)
            {
                ThreadPool.QueueUserWorkItem(PrintThreadIdAndWait);
            }

            // Отримуємо кількість виконавців, що очікують вільний потік
            Console.WriteLine($"Number of work items that currently queued to be processed: {ThreadPool.PendingWorkItemCount}");

            // Виводимо кількість доступних потоків
            ThreadPool.GetAvailableThreads(out workerThreads,
                out portThreads);
            Console.WriteLine("\nAvailable worker threads: \t{0}" +
                "\nAvailable completion port threads: {1}\n",
                workerThreads, portThreads);

            // Очікуємо завершення
            Console.ReadKey();

            #endregion
        }

        private static void PrintThreadIdAndWait(object? state)
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}. Working for 5 seconds.");
            Thread.Sleep(5000);
            Console.WriteLine($"Work finished on thread with id: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
