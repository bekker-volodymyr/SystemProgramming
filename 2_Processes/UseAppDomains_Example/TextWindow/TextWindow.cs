using System.Reflection;

namespace TextWindow
{
    public partial class TextWindow : Form
    {
        /* посилання на модуль, з якого будемо викликати методи */
        Module DrawerModule { get; set; }

        /* об'єкт, від якого викликатимемо методи */
        object Drawer;

        public TextWindow(Module drawer, object targetWindow)
        {
            DrawerModule = drawer;
            Drawer = targetWindow;
            InitializeComponent();
        }

        private void txtField_TextChanged(object sender, EventArgs e)
        {
            /* викликаємо метод SetText головного вікна додатка TextDrawer */
            DrawerModule.GetType("TextDrawer.Form1").GetMethod("SetText").
            Invoke(Drawer, new object[] { txtField.Text });
        }

        private void TextWindow_LocationChanged(object sender, EventArgs e)
        {
            /* викликаємо метод Move головного вікна додатка TextDrawer */
            DrawerModule.GetType("TextDrawer.Form1").GetMethod("Move").
            Invoke(Drawer, new object[] {
                new Point(this.Location.X, this.Location.Y +
                                        this.Height), this.Width });
        }
    }
}
