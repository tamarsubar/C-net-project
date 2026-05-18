namespace UI
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MamagerForm().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CashierForm().ShowDialog();
        }
    }
}
