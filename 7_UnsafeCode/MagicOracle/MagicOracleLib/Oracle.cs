namespace MagicOracleLib
{
    public class Oracle
    {
        // Масив з можливими відповідями
        private string[] _answers = {
            "Безсумнівно!",
            "Шанси дуже хороші.",
            "Зірки кажуть 'Так'.",
            "Спитайте пізніше, зараз не ясно.",
            "Краще вам цього не знати.",
            "Зовсім ні.",
            "Дуже сумнівно.",
            "Навіть не сподівайся."
        };

        // Генератор випадкових чисел
        private Random _randomizer = new Random();

        // Публічний метод, який зможе викликати інша програма
        public string GetAnswer()
        {
            // Отримуємо випадковий індекс від 0 до кількості елементів у масиві
            int index = _randomizer.Next(_answers.Length);
            return _answers[index];
        }
    }
}
