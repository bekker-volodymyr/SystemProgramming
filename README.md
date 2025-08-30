# Системне програмування | System Programming

Даний репозиторій містить набір прикладів, які супроводжують та доповнюють курс лекцій із предмету **_«Системне програмування»_**. 

У курсі розглядаються такі теми: 
- робота з legacy-кодом,
- використання динамічних бібліотек (DLL),
- робота з процесами та багатопоточність,
- паралельне та асинхронне програмування,
- застосування інструментів синхронізації.

Презентації, що доповнюють даний курс можна знайти за [посиланням](https://drive.google.com/drive/folders/19v3PphTRkWeBbgxWQ9_MD9vXlrUDiPBw?usp=sharing).

## Вміст:
- [Timer Example](https://github.com/bekker-volodymyr/SystemProgramming/blob/master/TimerExample/Program.cs) - проєкт, що демонструє базове використання класу System.Threading.Timer.
- [Thread Examples](https://github.com/bekker-volodymyr/SystemProgramming/blob/master/ThreadExample/Program.cs) - даний проєкт демонструє створення потоків за допомогою класу System.Threading.Thread. Він включає приклад потоку без параметрів та з параметром, створення потоку через лямбда-функцію, призупинення потоку за допомогою Thread.Sleep() та отримання хеш-коду (ідентифікатору) потоку за допомогою Thread.GetHashCode().
- [Background Thread](https://github.com/bekker-volodymyr/SystemProgramming/blob/master/BackgroundThread/Program.cs) - приклад створення простого фонового потоку з нескінченним циклом.
- [Suspend and Resume Thread](https://github.com/bekker-volodymyr/SystemProgramming/blob/master/SuspendResumeThread/Program.cs) - приклад використання методу Thread.Sleep() для призупинення потоку та використання застарілих методів Suspend() та Resume().
- [Abort Thread](https://github.com/bekker-volodymyr/SystemProgramming/blob/master/AbortThread/Program.cs) - демонстрація використання застарілого способу примусового завершення виконання потоку за допомогою методу Abort(). Не рекомендований підхід, краще використовувати Cancelation Token.
