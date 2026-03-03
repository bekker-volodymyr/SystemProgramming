namespace MutexExample
{
    class Counter
    {
        public static int counter = 0;
    }

    public class Program
    {
        static Mutex mutex = new Mutex();

        static void Main(string[] args)
        {
            // Використання м'ютекса
            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 10000; j++)
                    {
                        mutex.WaitOne();
                        // Вхід в критичну секцію
                        Counter.counter++;
                        // Якщо не звільнити - deadlock
                        mutex.ReleaseMutex();
                    }
                });
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine($"Counter: {Counter.counter}");
        }
    }
}
