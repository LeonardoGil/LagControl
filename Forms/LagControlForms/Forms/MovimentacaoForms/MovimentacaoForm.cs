using LagFinanceLib.Interfaces;

namespace LagControlForms
{
    public partial class MovimentacaoForm : Form
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoForm(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;

            InitializeComponent();

            var movimentacoes = _movimentacaoRepository.Get().ToList();

            dataGridViewMovimentacao.DataSource = movimentacoes;
        }
    }
}