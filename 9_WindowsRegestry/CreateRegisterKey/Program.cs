using Microsoft.Win32;

namespace CreateRegisterKey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. ПІДГОТОВКА ШЛЯХІВ
            string currentUser = Registry.CurrentUser.Name;
            string subKeyName = "GetSetValueDemo";
            string fullRegistryPath = $@"{currentUser}\{subKeyName}";

            // 2. ЗАПИС ДАНИХ (Створення розділу та параметрів)
            // Порожній рядок "" означає запис у параметр (За замовчуванням / Default)
            Registry.SetValue(fullRegistryPath, "", 0x1234);

            // Явно вказуємо типи даних для специфічних параметрів
            Registry.SetValue(fullRegistryPath, "DemoQWord", 0x0123456789ABCDEF, RegistryValueKind.QWord);
            Registry.SetValue(fullRegistryPath, "DemoString", "Шлях: %path%");
            Registry.SetValue(fullRegistryPath, "DemoExpandString", "Шлях: %path%", RegistryValueKind.ExpandString);

            // Масив рядків автоматично конвертується у MultiString
            Registry.SetValue(fullRegistryPath, "DemoArray", new[] { "Рядок 1", "Рядок 2", "Рядок 3" });

            // 3. ЗЧИТУВАННЯ ДАНИХ
            string missingValue = (string)Registry.GetValue(fullRegistryPath, "NotExists", "Параметр відсутній!");
            Console.WriteLine($"Тест відсутнього параметра: {missingValue}\n");

            // Відкриваємо розділ через using, щоб гарантовано закрити його після використання
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKeyName))
            {
                if (key != null)
                {
                    // Отримуємо імена всіх параметрів у цьому розділі
                    string[] valueNames = key.GetValueNames();

                    foreach (string name in valueNames)
                    {
                        // Якщо ім'я порожнє, це параметр за замовчуванням
                        string displayName = string.IsNullOrEmpty(name) ? "(Default)" : name;
                        Console.Write($"{displayName}: ");

                        // Перевіряємо тип: масиви треба виводити окремим циклом
                        if (key.GetValueKind(name) == RegistryValueKind.MultiString)
                        {
                            string[] arrayValues = (string[])key.GetValue(name);
                            Console.WriteLine(); // Перехід на новий рядок для списку

                            foreach (string item in arrayValues)
                            {
                                Console.WriteLine($"\t\"{item}\"");
                            }
                        }
                        else
                        {
                            // Всі інші типи виводимо як є
                            Console.WriteLine(key.GetValue(name));
                        }
                    }
                }
            }

            // 4. ПАУЗА ТА ВИДАЛЕННЯ
            Console.WriteLine("\nПерегляньте створені значення в Реєстрі (regedit) і натисніть Enter для очищення...");
            Console.ReadLine();

            // Видаляємо весь створений тестовий розділ
            Registry.CurrentUser.DeleteSubKey(subKeyName);
            Console.WriteLine("Розділ успішно видалено.");
        }
    }
}
