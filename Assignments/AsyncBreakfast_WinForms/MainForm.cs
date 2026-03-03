using AsyncBreakfast_WinForms.Food;

namespace AsyncBreakfast_WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            CoffeCup coffe = await PourCoffe();

            await Task.WhenAll(FryEggs(), FryBacon(), MakeToast());

            JuiceGlass juice = await PourJuice();
        }

        private async Task<JuiceGlass> PourJuice()
        {
            lblJuiceStatus.Text = "Сік: наливаємо сік...";
            JuiceGlass juice = new JuiceGlass();
            await Task.Delay(1000);
            juice.IsFilled = true;
            lblJuiceStatus.Text = "Сік готовий!";
            return juice;
        }

        private async Task<Bread> MakeToast()
        {
            lblToastStatus.Text = "Тост: підсмажуємо тост...";
            Bread bread = new Bread();
            await Task.Delay(6000);
            bread.IsToasted = true;

            lblToastStatus.Text = "Тост: наносимо варень'я...";
            await Task.Delay(2000);
            bread.WithJam = true;

            lblToastStatus.Text = "Тост готовий!";
            return bread;
        }

        private async Task<CoffeCup> PourCoffe()
        {
            lblCoffeStatus.Text = "Кава: наливаємо каву...";
            CoffeCup cup = new CoffeCup();
            await Task.Delay(2000);
            cup.IsFull = true;
            lblCoffeStatus.Text = "Кава готова!";
            return cup;
        }

        private async Task<Eggs> FryEggs()
        {
            lblEggsStatus.Text = "Яйця: смажу яйця...";
            Eggs g = new Eggs();
            await Task.Delay(5000);
            g.IsFried = true;
            lblEggsStatus.Text = "Яйця готові!";
            return g;
        }

        private async Task<Bacon> FryBacon()
        {
            lblBaconStatus.Text = "Бекон: смажу бекон...";
            Bacon g = new Bacon();
            await Task.Delay(5000);
            g.IsFried = true;
            lblBaconStatus.Text = "Бекон готовий!";
            return g;
        }
    
        
    }
}
