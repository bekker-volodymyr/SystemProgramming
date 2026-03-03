using System.Reflection;
using System.Runtime.CompilerServices;

namespace AssemblyLoadContext_Usage
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            ExecutePluginAndUnload();

            // 4. Ініціюємо збір сміття для фізичного очищення пам'яті
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Контекст і збірку успішно вивантажено з пам'яті!");
        }

        // ВАЖЛИВО: Виносимо роботу з плагіном в окремий метод і забороняємо його "вбудовування" (inlining).
        // Це гарантує, що локальна змінна 'context' буде знищена після виходу з методу, 
        // інакше GC не зможе звільнити пам'ять.
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void ExecutePluginAndUnload()
        {
            // 2. Ініціалізуємо наш ізольований контекст
            PluginLoadContext context = new PluginLoadContext();

            // 3. Завантажуємо DLL (шлях має бути абсолютним)
            Assembly pluginAssembly = context.LoadFromAssemblyPath(@"C:\Users\ovsan\ITStep\SystemProgramming\2_Processes\AssemblyLoadContext_Example\MyLibrary\bin\Debug\net10.0\MyLibrary.dll");

            Console.WriteLine($"Завантажено збірку: {pluginAssembly.FullName}");

            // 1. Отримуємо тип класу (якщо клас у просторі імен, треба вказати повне ім'я: "MyNamespace.Beeper")
            Type beeperType = pluginAssembly.GetType("MyLibrary.Beeper");

            if (beeperType != null)
            {
                // 2. Створюємо екземпляр класу (викликається конструктор Beeper())
                object beeperInstance = Activator.CreateInstance(beeperType);

                // 3. Знаходимо властивості та задаємо їм валідні значення
                PropertyInfo freqProp = beeperType.GetProperty("Frequency");
                freqProp.SetValue(beeperInstance, 1000); // Частота звуку: 1000 Гц

                PropertyInfo durProp = beeperType.GetProperty("Duration");
                durProp.SetValue(beeperInstance, 500);   // Тривалість: 500 мілісекунд (пів секунди)

                // 4. Отримуємо інформацію про метод і викликаємо його
                MethodInfo doBeepMethod = beeperType.GetMethod("DoBeep");

                // Передаємо екземпляр об'єкта та масив аргументів (null, бо метод без параметрів)
                doBeepMethod.Invoke(beeperInstance, null);
            }

            // Даємо системі сигнал, що контекст більше не потрібен
            context.Unload();
        }
    }
}
