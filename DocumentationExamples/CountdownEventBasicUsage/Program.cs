class Program
{
    // Умовний тип даних
    class Data
    {
        public int Value { get; set; }
    }

    // Джерело даних
    static IEnumerable<Data> GetData()
    {
        for (int i = 1; i <= 5; i++)
        {
            yield return new Data { Value = i };
        }
    }

    // Обробка даних
    static void ProcessData(object obj)
    {
        var data = (Data)obj;
        Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId} обробляє {data.Value}");
        Thread.Sleep(500); // симуляція роботи
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        IEnumerable<Data> source = GetData();
        using (CountdownEvent e = new CountdownEvent(1)) // 1 = "початковий" рахунок
        {
            // fork work:
            foreach (Data element in source)
            {
                e.AddCount(); // збільшуємо лічильник
                ThreadPool.QueueUserWorkItem((object state) =>
                {
                    try
                    {
                        ProcessData(state);
                    }
                    finally
                    {
                        e.Signal(); // зменшуємо лічильник, коли робота завершена
                    }
                }, element);
            }

            e.Signal(); // відпускаємо "початковий" рахунок

            // Чекаємо завершення всієї роботи
            e.Wait();
        }

        Console.WriteLine("Усі задачі завершені!");
    }
}
