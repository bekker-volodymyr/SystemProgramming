namespace TextDrawer
{
    public partial class TextDrawer : Form
    {
        string SourceText = "No text was added!";
        Font DrawingFont;

        public TextDrawer()
        {
            InitializeComponent();
            DrawingFont = new Font("Arial", 45);
            panel1.Paint += Panel1_Paint;
            this.Paint += Form1_Paint;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (SourceText.Length > 0)
            {
                /* створюємо буферне зображення, ґрунтуючись на розмірах
                   клієнтської частини елемента керування Panel */
                Image img = new Bitmap(panel1.ClientRectangle.Width,
                panel1.ClientRectangle.Height);

                /* отримуємо графічний контекст створеного нами зображення */
                Graphics imgDC = Graphics.FromImage(img);

                /* очищуємо зображення, використовуючи колір фону вікна */
                imgDC.Clear(BackColor);

                /* прорисовуємо на елементі керування Panel
                   текст, використовуючи вибраний шрифт */
                imgDC.DrawString(SourceText, DrawingFont, Brushes.Brown, ClientRectangle, newStringFormat(StringFormatFlags.NoFontFallback));

                /* прорисовуємо зображення на елементі керування Panel */
                e.Graphics.DrawImage(img, 0, 0);
            }
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Panel1_Paint(panel1,
            new PaintEventArgs(panel1.CreateGraphics(),
            panel1.ClientRectangle));
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* створюємо об'єкт стандартного діалогу FontDialog */
            FontDialog dlg = new FontDialog();

            /* ініціалізуємо об'єкт шрифту для діалогу */
            dlg.Font = DrawingFont;

            /* відкриваємо діалог модально */
            if (dlg.ShowDialog() == DialogResult.OK)

                /* якщо була натиснута кнопка OK, зберігаємо обрані налаштування */
                DrawingFont = dlg.Font;

            /* ініціюємо перерисовування елемента керування Panel */
            Panel1_Paint(panel1, new PaintEventArgs(panel1.CreateGraphics(),
                         panel1.ClientRectangle));
        }

        public void SetText(string text)
        {
            /* зберігаємо нове значення змінної SourceText */
            SourceText = text;

            /* ініціюємо перерисовку вікна */
            Panel1_Paint(panel1,
            new PaintEventArgs(panel1.CreateGraphics(),
            panel1.ClientRectangle));
        }

        public void Move(Point newLocation, int width)
        {
            /* встановлюємо нове значення позиції вікна */
            this.Location = newLocation;

            /* встановлюємо нове значення ширини вікна */
            this.Width = width;
        }
    }
}
