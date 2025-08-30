namespace ThreadingTimer
{
    public class Program
    {
        // Timer - об'єкт, що виконує заданий метод у зазначеному інтервалі
        private static Timer timer;

        static void Main(string[] args)
        {
            // Об'єкт-помічник для підрахунку кількості виконання методів в таймері
            var timerState = new TimerState { Counter = 0 };

            // Створення автоматично запускає таймер
            // Таймер очікує dueTime та виконує TimerTask в перший раз, після чого очікує period перед кожним виконанням TimerTask
            timer = new Timer(
                callback: new TimerCallback(TimerTask), // делегат з методом, який буде виконувати таймер
                state: timerState, // об'єкт-помічник
                dueTime: 1000, // час затримки перед першим виконанням методу
                period: 2000 // інтервал, через який метод буде виконуватись
                );

            // Доки timer не виконав метод 10 разів тримаємо основний потік в роботі
            while (timerState.Counter < 10)
            {
                Task.Delay(1000).Wait();
            }

            // Звільняємо ресурси таймеру
            timer.Dispose();
            // Сповіщаємо про завершення основного потоку
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: done.");
        }

        // Задача, яку буде виконувати таймер
        private static void TimerTask(object timerState)
        {
            // Сповіщаємо про виконання
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: done.");
            // Збільшуємо лічильник кількості виконання методів
            var state = timerState as TimerState;
            Interlocked.Increment(ref state.Counter); // Використовуємо клас Interlocked для збільшення лічильника, який є спільним ресурсом між потоками
        }

        // Клас-помічник для підрахунку кількості виконання методу
        class TimerState
        {
            public int Counter;
        }
    }
}

// Link to docs: https://learn.microsoft.com/en-us/dotnet/standard/threading/timers#the-systemthreadingtimer-class
