namespace AbortThread;

public class Program
{
    static void Main()
    {
        Thread thread = new Thread(() =>
        {
            while (true)
            {
                Console.Beep();
                Thread.Sleep(1000);
            }
        });
        thread.Start();

        Console.WriteLine("Press any key to close the thread");
        Console.ReadKey();

        thread.Abort();

        Console.WriteLine("Press any key to close the app");
        Console.ReadKey();
    }
}