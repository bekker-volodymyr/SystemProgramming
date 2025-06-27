
namespace ThreadExample;

public class Program
{
    static void Main()
    {
        Console.WriteLine("\n===Потоки без параметрів===\n");
        #region Потоки без параметрів
        // Створення потоку з делегатом початку потоку
        Thread threadNoParams = new Thread(new ThreadStart(ThreadMethodNoParams));
        // Запуск потоку
        threadNoParams.Start();
        // Вивід повідомлень з основного потоку
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine("Hello from Main!");
        }
        #endregion

        Console.WriteLine("\n===Потоки з параметром===\n");
        #region Потоки з параметром
        Thread threadWithParams = new Thread(new ParameterizedThreadStart(ThreadMethodWithParam));

        threadWithParams.Start("Message from Main to Thread");

        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine("Hello from Main!");
        }
        #endregion

        Console.WriteLine("\n===Потоки з параметром (через лямбду)===\n");
        #region Потоки з параметром (через лямбду)
        string msg = "Message from Main to Thread!";
        Thread threadWithLambda = new Thread(() => MethodWithParam(msg));

        threadWithLambda.Start();

        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine("Hello from Main!");
        }
        #endregion

        #region Thread.Sleep()
        Console.WriteLine("Sleep на 10 секунд.");
        Thread.Sleep(10000);
        Console.WriteLine("Прокидання потоку та завершення програми");
        #endregion

        #region Thread.CurrentThread GetHashCode()
        Thread newThread = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread thisThread = Thread.CurrentThread;
                Console.WriteLine($"Thread hashcode: {thisThread.GetHashCode()}");
            }
        });

        newThread.Start();

        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine($"Hashcode in Main: {newThread.GetHashCode()}");
        }
        #endregion

        
    }
    // Метод - вхідна точка в новий потік
    private static void ThreadMethodNoParams()
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine("\t\t\t\t\tHello from Thread!");
        }
    }

    private static void ThreadMethodWithParam(object msg)
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine($"\t\t\t\t\tHello from Thread! {msg}");
        }
    }

    private static void MethodWithParam(string msg)
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine($"\t\t\t\t\tHello from Thread! {msg}");
        }
    }
}