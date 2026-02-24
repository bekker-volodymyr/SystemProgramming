using System.Reflection;

namespace UseAppDomains
{
    internal static class Program
    {
        static AppDomain Drawer; // зберігатиме об'єкт домену додатка //TextDrawer
        static AppDomain TextWindow; // зберігатиме домени додатка TextWindow
        static Assembly DrawerAsm; // зберігатиме об'єкт складання TextDrawer.exe
        static Assembly TextWindowAsm; // зберігатиме об'єкт складання TextWindow.exe
        static Form DrawerWindow; // зберігатиме об'єкт вікна TextDrawer
        static Form TextWindowWnd; // зберігатиме об'єкт вікна TextWindow

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
        static void Main()
        {
            // включаємо візуальні стилі для додатка, оскільки він є віконним
            Application.EnableVisualStyles();

            /* створюємо необхідні домени додатків з дружніми іменами і
               зберігаємо посилання на них у відповідні змінні */
            Drawer = AppDomain.CreateDomain("Drawer");
            TextWindow = AppDomain.CreateDomain("TextWindow");

            /* завантажуємо складання з віконними додатками у відповідні домени додатків */
            DrawerAsm = Drawer.Load(AssemblyName.GetAssemblyName("TextDrawer.exe"));
            TextWindowAsm = Drawer.Load(AssemblyName.GetAssemblyName("TextWindow.exe"));

            /* створюємо об'єкти вікон беручи за основу віконні типи даних із завантажених складань */
            DrawerWindow = Activator.CreateInstance(DrawerAsm.GetType("TextDrawer.Form1")) as Form;
            TextWindowWnd = Activator.CreateInstance(TextWindowAsm.GetType("TextWindow.Form1"), newobject[] { DrawerAsm.GetModule("TextDrawer.exe"), DrawerWindow }) asForm;

            /* запускаємо потоки */
            (new Thread(new ThreadStart(RunVisualizer))).Start();
            (new Thread(new ThreadStart(RunDrawer))).Start();

            /* додаємо обробник події DomainUnload */
            Drawer.DomainUnload += new EventHandler(Drawer_DomainUnload);
        }

        static void Drawer_DomainUnload(object sender, EventArgs e)
        {
            /* відкриваємо MessageBox, в якому виводимо ім'я поточного домену додатка */
            MessageBox.Show("Domain with name " + (sender as AppDomain).FriendlyName + " has been succesfully unloeded!");
        }

        static void RunDrawer()
        {
            /* запускаємо вікно модально, у поточному потоці */
            DrawerWindow.ShowDialog();
            /* відвантажуємо домен додатка */
            AppDomain.Unload(Drawer);
        }

        static void RunVisualizer()
        {
            /* запускаємо вікно модально, у поточному потоці */
            TextWindowWnd.ShowDialog();

            /* завершуємо роботу додатка, наслідком чого стане закриття потоку */
            Application.Exit();
        }
    }
}