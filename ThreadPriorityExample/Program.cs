namespace ThreadPriorityExample;

public class Program
{
    static void Main()
    {
        List<Thread> threads = new List<Thread>();
        // Створюємо 5 нових фонових потоків. Пріоритет потоку відповідає індексу потоку в списку
        for (int i = 0; i < 5; i++)
        {
            Thread newThread = new Thread(Method);
            newThread.IsBackground = true;
            newThread.Priority = (ThreadPriority)i;
            threads.Add(newThread);
        }

        foreach (var t in threads)
        {
            t.Start();
        }

        Console.ReadKey();
    }

    static void Method()
    {
        for (int i = 0; i < 500; i++)
        {
            string tab = new string('\t', (int)Thread.CurrentThread.Priority);

            Console.WriteLine($"{tab}Message from thread with priority {Thread.CurrentThread.Priority}");
        }
    }
}