namespace EventWaitHandleExamples
{
    class Counter
    {
        public static int counter = 0;
    }

    public class Program
    {
        // false - початковий стан non-signaled (всі потоки блокуються)
        static ManualResetEvent mre = new ManualResetEvent(false);
        static AutoResetEvent are = new AutoResetEvent(true);

        static void Worker()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting...");
            mre.WaitOne(); // усі тут зависнуть, поки не буде Set()
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started work!");
            Thread.Sleep(3000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished work!");
        }

        static void Main(string[] args)
        {
            {
                Thread[] threads = new Thread[5];

                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(Worker);
                    threads[i].Start();
                }

                Console.WriteLine("Press any key to release all threads...");
                Console.ReadKey();

                mre.Set(); // розблокує ВСІ потоки одразу

                Console.WriteLine("Press any key to block threads again...");
                Console.ReadKey();

                mre.Reset(); // тепер наступні WaitOne() знову блокуватимуть

                Console.WriteLine("Done");
            }

            Counter.counter = 0;

            {
                // AutoResetEvent
                Thread[] threads = new Thread[5];
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(() =>
                    {
                        for (int j = 0; j < 10000; j++)
                        {
                            are.WaitOne();
                            // Вхід в критичну секцію
                            Counter.counter++;
                            // Повідомлення іншим потокам, що можна заходити
                            // Заходить найбільший за пріоритетом або той, що першим встиг.
                            // Після заходу наступного потоку автоматично стає unsignaled(блокує інші потоки)
                            are.Set();
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
}
