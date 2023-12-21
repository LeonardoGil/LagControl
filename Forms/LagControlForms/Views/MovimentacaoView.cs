using AutoMapper;
using LagControlForms.Controls;
using LagControlForms.Models;
using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LagControlForms.Views
{
    public partial class MovimentacaoView : UserControl
    {
        private readonly IMapper _mapper;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        private BindingSource bindingSourceMovimentacao { get; set; }

        public BindingSource BindingSourceMovimentacao
        {
            get => bindingSourceMovimentacao;

            set
            {
                bindingSourceMovimentacao = value;
                dataGridViewMovimentacao.DataSource = bindingSourceMovimentacao;
            }
        }

        protected AdicionarMovimentacaoControl adicionarMovimentacaoControl;

        public MovimentacaoView(IMapper mapper,
                                       IMovimentacaoRepository movimentacaoRepository)
        {
            _mapper = mapper;
            _movimentacaoRepository = movimentacaoRepository;

            InitializeComponent();

            CarregarControles();
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                var movimentacoesTask = _movimentacaoRepository.Get()
                                               .Include(x => x.Conta)
                                               .Include(x => x.Categoria)
                                               .ToList();

                BindingSourceMovimentacao = new BindingSource
                {
                    DataSource = _mapper.Map<List<Movimentacao>, List<MovimentacaoModel>>(movimentacoesTask)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarControles()
        {
            adicionarMovimentacaoControl = Program.ServiceProvider.GetRequiredService<AdicionarMovimentacaoControl>();
            adicionarMovimentacaoControl.UpdateMovimentacaoList += UpdateMovimentacaoList_Event;

            panelSuperior.Controls.Add(adicionarMovimentacaoControl);
            adicionarMovimentacaoControl.Dock = DockStyle.Fill;
        }

        private void UpdateMovimentacaoList_Event(object sender, EventArgs args)
        {
            if (sender is Movimentacao movimentacao)
            {
                var model = _mapper.Map<Movimentacao, MovimentacaoModel>(movimentacao);
                BindingSourceMovimentacao.Add(model);
            }
        }
    }
}
