using LagFinanceLib.Domain;

namespace LagControlForms.Forms.Views
{
    public partial class FinanceView : BaseView
    {
        public BindingSource MovimentacoesBindingSource = new BindingSource() { DataSource = new List<Movimentacao>() };

        public FinanceView()
        {
            InitializeComponent();

            dataGridView.DataSource = MovimentacoesBindingSource;
        }


    }
}
