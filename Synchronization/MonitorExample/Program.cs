namespace MonitorExample
{
    class Counter
    {
        public static int counter = 0;
        public static object locker = new object();
    }

    public class Program
    {
        static void Main(string[] args)
        {
            {
                Thread[] threads = new Thread[5];

                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(() =>
                    {
                        for (int j = 0; j < 10000; j++)
                        {
                            // Входимо в критичну секцію, використовуємо спеціальний об'єкт для блокування
                            Monitor.Enter(Counter.locker);
                            Counter.counter++;
                            // Покидаємо критичну секцію, розблоковуємо об'єкт
                            Monitor.Exit(Counter.locker);
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

            Counter.counter = 0;

            {
                // Конструкція lock - синтаксичний цукор над класом Monitor
                Thread[] threads = new Thread[5];

                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(() =>
                    {
                        for (int j = 0; j < 10000; j++)
                        {
                            lock (Counter.locker)
                            {
                                Counter.counter++;
                            }
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
