class Program
{
    // AutoResetEvent початково у стані unsignaled (false)
    static AutoResetEvent autoEvent = new AutoResetEvent(false);

    // ManualResetEvent теж у стані unsignaled (false)
    static ManualResetEvent manualEvent = new ManualResetEvent(false);

    static void Worker(string name, WaitHandle handle)
    {
        Console.WriteLine($"{name} чекає сигнал...");
        handle.WaitOne(); // потік блокується, доки handle не стане signaled
        Console.WriteLine($"{name} отримав сигнал і працює!");
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // запускаємо три потоки з AutoResetEvent
        new Thread(() => Worker("Auto-1", autoEvent)).Start();
        new Thread(() => Worker("Auto-2", autoEvent)).Start();
        new Thread(() => Worker("Auto-3", autoEvent)).Start();

        Thread.Sleep(1000);
        Console.WriteLine("== AutoResetEvent приклад ==");

        autoEvent.Set(); // розбудить тільки один потік
        Thread.Sleep(500);
        autoEvent.Set(); // розбудить ще один
        Thread.Sleep(500);
        autoEvent.Set(); // розбудить третій

        Thread.Sleep(1000);

        // запускаємо три потоки з ManualResetEvent
        new Thread(() => Worker("Manual-1", manualEvent)).Start();
        new Thread(() => Worker("Manual-2", manualEvent)).Start();
        new Thread(() => Worker("Manual-3", manualEvent)).Start();

        Thread.Sleep(1000);
        Console.WriteLine("== ManualResetEvent приклад ==");

        manualEvent.Set();   // розбудить одразу всіх, хто чекає
        Thread.Sleep(500);
        manualEvent.Reset(); // знову ставимо unsignaled (нові потоки чекатимуть)
    }
}

