using LagControlForms.Forms.Views;

namespace LagControlForms.Forms
{
    public partial class MainForm : Form
    {
        private InicioView _inicioView;
        private FinanceView _financeView;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            _inicioView = new InicioView
            {
                Dock = DockStyle.Fill
            };

            _financeView = new FinanceView
            {
                Dock = DockStyle.Fill
            };

            panelView.Controls.Add(_inicioView);
        }

        public void LoadFinanceView_Clicled(object? sender, EventArgs e)
        {
            panelView.Controls.Clear();
            panelView.Controls.Add(_financeView);
        }
    }
}
