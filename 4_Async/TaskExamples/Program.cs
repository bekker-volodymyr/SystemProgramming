namespace TaskExamples
{
    public class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            #region Task Start
            /*
            Task task = new Task(SomeWork); // Створюємо асинхронну операцію
            task.Start(); // Виконуємо асинхронну операцію

            Console.WriteLine("Hello from Main!");

            task.Wait(); // Очікуємо завершення асинхронної операції

            Console.WriteLine("Finish");
            */
            #endregion

            #region Task Run
            /*
            Task taskA = Task.Run(SomeWork); // Створюємо та запускаємо асинхронну операцію

            taskA.Wait(); // Очікуємо завершення асинхронної операції
            */
            #endregion

            #region WhenAll

            //Task task1 = Task.Run(SomeWork);
            //Task task2 = Task.Run(SomeWork);
            //Task task3 = Task.Run(SomeWork);

            //Task whenAll = Task.WhenAll(task1, task2, task3);

            //whenAll.Wait();

            //Console.WriteLine("All tasks have been completed.");

            #endregion

            #region WhenAny

            //Task task4 = Task.Run(SomeWork);
            //Task task5 = Task.Run(SomeWork);
            //Task task6 = Task.Run(SomeWork);

            //Task whenAny = Task.WhenAny(task4, task5, task6);

            //whenAny.Wait();

            //Console.WriteLine("One or more tasks have been completed.");

            #endregion

            #region Task with result

            Task<int> taskI1 = new Task<int>(RandomNumber);
            Task<int> taskI2 = new Task<int>(RandomNumber);
            Task<int> taskI3 = new Task<int>(RandomNumber);

            taskI1.Start();
            taskI2.Start();
            taskI3.Start();

            int[] results = Task.WhenAll(taskI1, taskI2, taskI3).Result;

            foreach (int result in results)
            {
                Console.WriteLine(result);
            }

            #endregion
        }

        private static int RandomNumber()
        {
            int result = random.Next(1000, 5000);
            Task.Delay(result).Wait();
            return result;
        }

        private static void SomeWork()
        {
            Console.WriteLine("Hello form task!");
            Thread.Sleep(random.Next(1000, 5000));
            Console.WriteLine("Task completed");
        }
    }
}
