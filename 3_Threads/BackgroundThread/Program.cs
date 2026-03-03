namespace BackgroundThread;

public class Program
{
    static void Main()
    {
        Thread threadBG = new Thread(() =>
        {
            while (true)
            {
                Console.WriteLine("Infinite background thread");
            }
        });
        threadBG.IsBackground = true; // за замовченням - false
        threadBG.Start();

        Console.ReadKey();
    }
}