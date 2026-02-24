using System.Diagnostics;

namespace StartProcess_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            calcProcess.StartInfo = new ProcessStartInfo("calc.exe");
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            calcProcess.Start();
            closeBtn.Enabled = true;
            startBtn.Enabled = false;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Process[] realCalcs = Process.GetProcessesByName("CalculatorApp");

            foreach (var p in realCalcs)
            {
                p.CloseMainWindow();

                if (!p.WaitForExit(2000))
                {
                    p.Kill();
                }
                p.Dispose();
            }

            closeBtn.Enabled = false;
            startBtn.Enabled = true;
        }
    }
}
