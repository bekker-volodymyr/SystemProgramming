namespace CancellationTokenExample
{
    public class Program
    {
        static void Worker(CancellationToken token)
        {
            for (int i = 0; i < 10000; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Work is canceled.");
                    Console.Beep(3432, i * 1000);
                    break;
                }
                Console.Beep();
                Thread.Sleep(3000);
            }
        }

        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Thread thread = new Thread(() => Worker(cts.Token));
            thread.Start();

            Console.WriteLine("Press any key to stop beeping.");
            Console.ReadKey();

            cts.Cancel();

            Console.WriteLine("Press any key to close app.");
            Console.ReadKey();
        }
    }
}
