using LagControlForms.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LagControlForms.Controls
{
    public partial class MenuLateralControl : UserControl
    {
        public Panel View { get; set; }

        protected DropDownMenuControl MenuFinanceiroControl;

        private void GerarFinanceiroMenu()
        {
            var menuFinanceiroDic = new Dictionary<string, EventHandler>
            {
                { "Financeiro", ExibirMovimentacao_ClickEvent }
            };

            MenuFinanceiroControl = new DropDownMenuControl("Movimentacao", menuFinanceiroDic);

            flowLayoutPanel.Controls.Add(MenuFinanceiroControl);
        }

        public void ExibirMovimentacao_ClickEvent(object a, EventArgs args)
        {
            var movimentacaoViewControl = Program.ServiceProvider.GetRequiredService<MovimentacaoView>();

            View.Controls.Add(movimentacaoViewControl);
            movimentacaoViewControl.Dock = DockStyle.Fill;
        }

        public MenuLateralControl()
        {
            InitializeComponent();
            GerarFinanceiroMenu();
        }
    }
}
