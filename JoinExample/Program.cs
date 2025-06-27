namespace JoinExample;

class Program
{
    static void Main(string[] args)
    {
        ThreadStart TS = new ThreadStart(Method);
        Thread T = new Thread(TS);
        Console.WriteLine("Start the thread");
        T.Start();
        Thread.Sleep(200);
        Console.WriteLine("Wait for thread finish");
        T.Join();
        Console.WriteLine("End of program");
    }

    static void Method()
    {
        Console.WriteLine("Thread is working");
        Thread.Sleep(2000);
        Console.WriteLine("Thread is finished");
    }
}
