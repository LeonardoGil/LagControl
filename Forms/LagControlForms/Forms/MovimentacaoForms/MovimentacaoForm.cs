using AutoMapper;
using LagControlForms.Models;
using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;

namespace LagControlForms
{
    public partial class MovimentacaoForm : Form
    {
        private readonly IMapper _mapper;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoForm(IMapper mapper,
                                IMovimentacaoRepository movimentacaoRepository)
        {
            _mapper = mapper;
            _movimentacaoRepository = movimentacaoRepository;

            LoadDataGrid();
            InitializeComponent();
        }

        private async void LoadDataGrid()
        {
            var movimentacoes = _movimentacaoRepository.Get().ToList();

            var models = _mapper.Map<List<Movimentacao>, List<MovimentacaoModel>>(movimentacoes);

            dataGridViewMovimentacao.DataSource = models;
        }
    }
}