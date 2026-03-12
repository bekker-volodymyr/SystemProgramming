using MagicOracleLib;

namespace MagicOracleWF
{
    public partial class MagicOracle : Form
    {
        private Oracle _oracle = new Oracle();

        public MagicOracle()
        {
            InitializeComponent();
        }

        public void btnAsk_Click(object sender, EventArgs e)
        {
            txtAnswer.Text = _oracle.GetAnswer();
        }
    }
}
