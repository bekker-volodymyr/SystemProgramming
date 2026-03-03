using System.Diagnostics;

namespace WorkloadTypesDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnCpuBound_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Рахуємо важку математику (CPU-bound)...";
            btnCpuBound.Enabled = false;

            Stopwatch sw = Stopwatch.StartNew();

            long result = await Task.Run(() => CpuBoundTask());
            //long result = CpuBoundTask();
            //long result = await CpuBoundTask(); // Блокування потоку!

            sw.Stop();

            lblStatus.Text = $"Математика готова! Результат: {result}. Час: {sw.ElapsedMilliseconds} мс";
            btnCpuBound.Enabled = true;
        }

        private async void btnIoBound_ClickAsync(object sender, EventArgs e)
        {
            lblStatus.Text = "Йдемо в мережу за даними (I/O-bound)...";
            btnIoBound.Enabled = false;

            Stopwatch sw = Stopwatch.StartNew();

            using (HttpClient client = new HttpClient())
            {
                string html = await client.GetStringAsync("https://example.com");

                sw.Stop();
                lblStatus.Text = $"Завантажено {html.Length} байт з мережі. Час: {sw.ElapsedMilliseconds} мс";
            }

            btnIoBound.Enabled = true;
        }

        private async Task<long> CpuBoundTaskAsync()
        {
            long sum = 0;
            for (long i = 0; i < 2_000_000_000; i++)
            {
                sum += i;
            }
            return sum;
        }

        private long CpuBoundTask()
        {
            long sum = 0;
            for (long i = 0; i < 2_000_000_000; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
