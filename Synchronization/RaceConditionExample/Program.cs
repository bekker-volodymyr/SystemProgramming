namespace RaceConditionExample
{
    class Counter
    {
        public static int counter = 0;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // Створюємо 5 потоків
            Thread[] threads = new Thread[5];

            // Запускаємо кожен потік, який буде збільшувати лічильник 10000 разів
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 10000; j++)
                    {
                        Counter.counter++;
                    }
                });
                threads[i].Start();
            }

            // Чекаємо завершення всіх потоків
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            // Виводимо значення лічильника
            // Очікуємо 50000 - 5 потоків * 10000 збільшень
            // Але через відсутність синхронізації, значення може бути меншим
            Console.WriteLine($"Counter: {Counter.counter}");
        }
    }
}
