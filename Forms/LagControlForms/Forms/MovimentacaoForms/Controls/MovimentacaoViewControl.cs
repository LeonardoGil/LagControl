namespace LagControlForms.Forms.MovimentacaoForms.Controls
{
    public partial class MovimentacaoViewControl : UserControl
    {
        private BindingSource movimentacaoView { get; set; }

        public BindingSource MovimentacaoView
        {
            get => movimentacaoView;
            
            set
            {
                movimentacaoView = value;
                dataGridViewMovimentacao.DataSource = movimentacaoView.DataSource;
            }
        }

        public MovimentacaoViewControl()
        {
            InitializeComponent();
        }
    }
}
