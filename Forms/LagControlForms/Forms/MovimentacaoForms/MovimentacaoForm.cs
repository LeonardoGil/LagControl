using AutoMapper;
using LagControlForms.Forms.MovimentacaoForms.Controls;
using LagControlForms.Models;
using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagControlForms
{
    public partial class MovimentacaoForm : Form
    {
        private readonly IMapper _mapper;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        private BindingSource MovimentacaoView = new BindingSource();

        public MovimentacaoForm(IMapper mapper,
                                IMovimentacaoRepository movimentacaoRepository)
        {
            _mapper = mapper;
            _movimentacaoRepository = movimentacaoRepository;

            InitializeComponent();
            LoadDataGrid();

            adicionarMovimentacaoControl.UpdateMovimentacaoList += UpdateMovimentacaoList_Event;
        }

        private async void LoadDataGrid()
        {
            var movimentacoes = _movimentacaoRepository.Get()
                                                       .Include(x => x.Conta)
                                                       .Include(x => x.Categoria).ToList();

            MovimentacaoView.DataSource = _mapper.Map<List<Movimentacao>, List<MovimentacaoModel>>(movimentacoes);

            dataGridViewMovimentacao.DataSource = MovimentacaoView;
        }

        private void UpdateMovimentacaoList_Event(object sender, EventArgs args)
        {
            if (sender is Movimentacao movimentacao)
            {
                var model = _mapper.Map<Movimentacao, MovimentacaoModel>(movimentacao);

                MovimentacaoView.Add(model);
            }
        }
    }
}