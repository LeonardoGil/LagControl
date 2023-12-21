using LagControlForms.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LagControlForms.Forms
{
    public partial class MainForm : Form
    {
        protected MovimentacaoView movimentacaoViewControl;

        public MainForm()
        {
            InitializeComponent();

            Load();
        }

        private async Task Load()
        {
            movimentacaoViewControl = Program.ServiceProvider.GetRequiredService<MovimentacaoView>();

            panelView.Controls.Add(movimentacaoViewControl);
            movimentacaoViewControl.Dock = DockStyle.Fill;
        }
    }
}
