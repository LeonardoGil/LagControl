using AutoMapper;
using LagControlForms.Controls;
using LagControlForms.Models;
using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LagControlForms.Views
{
    public partial class MovimentacaoView : BaseView
    {
        private readonly IMapper _mapper;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        protected AdicionarMovimentacaoControl adicionarMovimentacaoControl;

        public MovimentacaoView(IMapper mapper,
                                IMovimentacaoRepository movimentacaoRepository) : base()
        {
            _mapper = mapper;
            _movimentacaoRepository = movimentacaoRepository;

            InitializeComponent();
        }

        private async Task CarregarGrid()
        {
            try
            {
                var movimentacoes = _movimentacaoRepository.Get()
                                                           .AsNoTracking()
                                                           .Include(x => x.Conta)
                                                           .Include(x => x.Categoria)
                                                           .ToList();

                View = new BindingSource
                {
                    DataSource = _mapper.Map<List<Movimentacao>, List<MovimentacaoModel>>(movimentacoes)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task CarregarControles()
        {
            try
            {
                adicionarMovimentacaoControl = Program.ServiceProvider.GetRequiredService<AdicionarMovimentacaoControl>();
                adicionarMovimentacaoControl.UpdateMovimentacaoList += UpdateMovimentacaoList_Event;

                panelSuperior.Controls.Add(adicionarMovimentacaoControl);
                adicionarMovimentacaoControl.Dock = DockStyle.Fill;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateMovimentacaoList_Event(object sender, EventArgs args)
        {
            if (sender is Movimentacao movimentacao)
            {
                var model = _mapper.Map<Movimentacao, MovimentacaoModel>(movimentacao);
                View.Add(model);
            }
        }

        private void MovimentacaoView_Load(object sender, EventArgs e)
        {
            CarregarControles();
            CarregarGrid();
        }
    }
}
