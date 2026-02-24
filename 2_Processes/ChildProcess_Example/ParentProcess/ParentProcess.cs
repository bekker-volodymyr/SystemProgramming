using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;

namespace ParentProcess
{
    public partial class ParentProcess : Form
    {
        // константа, що ідентифікує повідомлення WM_SETTEXT
        const uint WM_SETTEXT = 0x0C;

        // імпортуємо функкцію SendMEssage з бібліотеки user32.dll
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        /* список, в якому зберігатимуться об'єкти, з описом дочірніх процесів додатка */
        List<Process> _processes = new List<Process>();

        /* лічильник запущених процесів */
        int _counter = 0;

        public ParentProcess()
        {
            InitializeComponent();

            LoadAvailableAssemblies();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            RunProcess(availableLbx.SelectedItem.ToString());
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(startedLbx.SelectedItem.ToString(), Kill);
            startedLbx.Items.Remove(startedLbx.SelectedItem);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(startedLbx.SelectedItem.ToString(), CloseMainWindow);
            startedLbx.Items.Remove(startedLbx.SelectedItem);
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(startedLbx.SelectedItem.ToString(), Refresh);
        }

        private void runCalcBtn_Click(object sender, EventArgs e)
        {
            RunProcess("calc.exe");
        }

        void LoadAvailableAssemblies()
        {
            // назва файлу складання поточного додатка
            string except = new FileInfo(Application.ExecutablePath).Name;

            // отримуємо назву файлу без розширення
            except = except.Substring(0, except.IndexOf("."));

            // отримуємо усі *.exe файли з домашньої директорії
            string[] files = Directory.GetFiles(Application.StartupPath, "*.exe");

            foreach (var file in files)
            {
                // отримуємо ім'я файлу
                string fileName = new FileInfo(file).Name;

                /* якщо ім'я афйлу не містить імені виконуваного файлу проєкту,
                   тоді воно додається до списку */

                if (fileName.IndexOf(except) == -1)
                    availableLbx.Items.Add(fileName);
            }
        }

        /* метод, що запускає процес для виконання і що зберігає об'єкт, який його описує */
        void RunProcess(string AssamblyName)
        {
            // 1. Запускаємо процес
            Process proc = Process.Start(AssamblyName);

            if (proc == null)
            {
                MessageBox.Show("Не вдалося запустити процес. Можливо, виконуваний файл пошкоджено.");
                return;
            }

            // 2. ЗАМІСТЬ Thread.Sleep: чекаємо, поки дочірній процес не завантажить свій UI
            // Це не блокує систему наглухо на 5 секунд, а чекає лише доки дочірня програма не буде готова (максимум 5 сек)
            proc.WaitForInputIdle(5000);

            // 3. ПЕРЕВІРКА: чи процес не вмер одразу після старту?
            if (proc.HasExited)
            {
                MessageBox.Show($"Процес запустився, але одразу впав. Код завершення: {proc.ExitCode}");
                return; // Виходимо, бо шукати мертвого процесу у WMI немає сенсу
            }

            /* перевіряємо, чи став створений процес дочірнім
               по відношенню до поточного і, якщо став, виводимо MessageBox */
            if (Process.GetCurrentProcess().Id == GetParentProcessId(proc.Id))
                MessageBox.Show(proc.ProcessName + " дійсно, дочірній процес поточного процесу!");

            /* вказуємо, що процес має генерувати події */
            proc.EnableRaisingEvents = true;

            // додаємо обробник на подію завершення процесу
            proc.Exited += proc_Exited;

            /* розміщуємо новий текст головного вікна дочірнього процесу */
            SetChildWindowText(proc.MainWindowHandle, "Chils process #" + (++_counter));

            /* перевіряємо, чи запускали ми екземпляр такого додатка * і,
               якщо немає, то додаємо до списку запущених додатків */
            if (!startedLbx.Items.Contains(proc.ProcessName))
                startedLbx.Items.Add(proc.ProcessName);

            /* видаляємо додаток зі списку доступних додатків */
            availableLbx.Items.Remove(availableLbx.SelectedItem);
        }

        /* метод обгортання для надсилання повідомлення WM_SETTEXT */
        void SetChildWindowText(IntPtr Handle, string text)
        {
            SendMessage(Handle, WM_SETTEXT, 0, text);
        }

        /* метод, який отримує PID батьківського процесу (використовує WMI) */
        int GetParentProcessId(int Id)
        {
            int parentId = 0;
            using (ManagementObject obj = new ManagementObject($"win32_process.handle='{Id}'"))
            {
                obj.Get();
                parentId = Convert.ToInt32(obj["ParentProcessId"]);
            }
            return parentId;
        }

        /* обробник події Exited класу Process */
        void proc_Exited(object sender, EventArgs e)
        {
            Process proc = sender as Process;

            // забираємо процес зі списку запущених додатків
            startedLbx.Items.Remove(proc.ProcessName);

            // додаємо процес до списку доступних додатків
            availableLbx.Items.Add(proc.ProcessName);

            // забираємо процес зі списку дочірніх процесів
            _processes.Remove(proc);

            // зменшуємо лічильник дочірніх процесів на 1
            _counter--;
            int index = 0;

            /* змінюємо текст для головних вікон усіх дочірніх процесів */
            foreach (var p in _processes)
                SetChildWindowText(p.MainWindowHandle, "Child process #" + ++index);
        }

        // оголошення делегата, що приймає параметр типу Process
        delegate void ProcessDelegate(Process proc);

        /* метод, який виконує прохід по всіх дочірніх процесах із заданим
           ім'ям і виконує для цих процесів заданий делегатом метод */
        void ExecuteOnProcessesByName(string ProcessName, ProcessDelegate func)
        {
            /* отримуємо список запущених в операційній системі процесів */
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (var process in processes)

                /* якщо PID батьківського процесу дорівнює PID поточного процесу */
                if (Process.GetCurrentProcess().Id == GetParentProcessId(process.Id))

                    // запускаємо метод
                    func(process);
        }

        void Kill(Process proc)
        {
            proc.Kill();
        }

        void CloseMainWindow(Process proc)
        {
            proc.CloseMainWindow();
        }

        void Refresh(Process proc)
        {
            proc.Refresh();
        }

        private void startedLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startedLbx.SelectedItems.Count == 0)
            {
                stopBtn.Enabled = false;
                refreshBtn.Enabled = false;
                closeBtn.Enabled = false;
            }
            else
            {
                stopBtn.Enabled = true;
                closeBtn.Enabled = true;
                refreshBtn.Enabled = true;
            }
        }

        private void availableLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableLbx.SelectedItems.Count == 0)
                startBtn.Enabled = false;
            else
                startBtn.Enabled = true;
        }

        private void ParentProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var proc in _processes)
                proc.Kill();
        }
    }
}
