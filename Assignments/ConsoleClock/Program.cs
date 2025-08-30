namespace ConsoleClock
{
    public class Program
    {
        static void Clock(object? state)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
        }

        static void Main(string[] args)
        {
            Timer clock = new Timer(new TimerCallback(Clock), null, 0, 1000);

            Console.ReadKey();
        }
    }
}
