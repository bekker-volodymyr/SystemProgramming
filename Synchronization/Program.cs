namespace Synchronization
{
    class Counter
    {
        public static int counter = 0;
        public static object locker = new object();
    }

    public class Program
    {
        static Mutex mutex = new Mutex();
        static Semaphore semaphore = new Semaphore(2, 2);
        static AutoResetEvent ae = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            {
                // Створюємо 5 потоків
                Thread[] threads = new Thread[5];

                // Запускаємо кожен потік, який буде збільшувати лічильник 10000 разів
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(() =>
                    {
                        for (int j = 0; j < 10000; j++)
                        {
                            Counter.counter++;
                        }
                    });
                    threads[i].Start();
                }

                // Чекаємо завершення всіх потоків
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i].Join();
                }

                // Виводимо значення лічильника
                // Очікуємо 50000 - 5 потоків * 10000 збільшень
                // Але через відсутність синхронізації, значення може бути меншим
                Console.WriteLine($"Counter: {Counter.counter}");
            }

            Counter.counter = 0;

            {
                // Використання Interlocked
                Thread[] threads = new Thread[5];

                // Запускаємо кожен потік, який буде збільшувати лічильник 10000 разів
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(() =>
                    {
                        for (int j = 0; j < 10000; j++)
                        {
                            Interlocked.Increment(ref Counter.counter);
                        }
                    });
                    threads[i].Start();
                }

                // Чекаємо завершення всіх потоків
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i].Join();
                }

                // Виводимо значення лічильника
                // Очікуємо 50000 - 5 потоків * 10000 збільшень
                // Завдяки синхронізації отримуємо очікуваний результат
                Console.WriteLine($"Counter: {Counter.counter}");
            }

            Counter.counter = 0;

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

            Counter.counter = 0;

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

            {
                // Використання семафору
                Thread[] threads = new Thread[5];
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread((id) =>
                    {
                        Console.WriteLine($"Thread {id} is waiting...");
                        semaphore.WaitOne();

                        Console.WriteLine($"Thread {id} has entered critical section");
                        Thread.Sleep(2000); // імітація роботи

                        Console.WriteLine($"Thread {id} exits critical section");
                        semaphore.Release();
                    });
                    threads[i].Start(i);
                }
            }

            Counter.counter = 0;

            {
                Thread[] threads = new Thread[5];
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(() =>
                    {
                        for (int j = 0; j < 10000; j++)
                        {
                            ae.WaitOne();
                            // Вхід в критичну секцію
                            Counter.counter++;
                            // Повідомлення іншим потокам, що можна заходити
                            // Заходить найбільший за пріоритетом або той, що першим встиг.
                            ae.Set();
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
