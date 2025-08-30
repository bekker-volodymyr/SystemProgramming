namespace SuspendResumeThread;

public class Program
{
    static void Main()
    {
        Thread thread = new Thread(() =>
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.Beep();
                Thread.Sleep(1000);
            }
        });

        thread.Start();

        Console.WriteLine("Press any key to pause the thread");
        Console.ReadKey();

        Console.WriteLine("Process is paused.");
        thread.Suspend();

        Console.WriteLine("Press any key to resume thread");
        Console.ReadKey();

        Console.WriteLine("Thread is resumed");
        thread.Resume();

        Console.WriteLine("Press any key to close the app.");
        Console.ReadKey();
    }
}