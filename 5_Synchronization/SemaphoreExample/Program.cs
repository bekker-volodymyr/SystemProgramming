namespace SemaphoreExample
{
    public class Program
    {

        static Semaphore semaphore = new Semaphore(0, 2);

        static void Main(string[] args)
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

            Console.WriteLine("Press any key to release semaphore. ");
            Console.ReadKey();
            semaphore.Release(2);
            Console.ReadKey();
        }
    }
}
