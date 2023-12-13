using AutoMapper;
using LagControlForms.Forms.MovimentacaoForms.Controls;
using LagControlForms.Models;
using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LagControlForms.Forms.MainForms
{
    public partial class MainForms : Form
    {
        protected MovimentacaoViewControl movimentacaoViewControl;

        private readonly IMapper _mapper;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MainForms(IMapper mapper,
                         IMovimentacaoRepository movimentacaoRepository)
        {
            _mapper = mapper;
            _movimentacaoRepository = movimentacaoRepository;

            InitializeComponent();

            Load();
        }

        private async Task Load()
        {
            var movimentacoesTask = _movimentacaoRepository.Get()
                                                           .Include(x => x.Conta)
                                                           .Include(x => x.Categoria)
                                                           .ToListAsync();

            movimentacaoViewControl = Program.ServiceProvider.GetRequiredService<MovimentacaoViewControl>();

            var bindingSource = new BindingSource();

            try
            {
                bindingSource.DataSource = _mapper.Map<List<Movimentacao>, List<MovimentacaoModel>>(await movimentacoesTask);

                movimentacaoViewControl.MovimentacaoView = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            panelView.Controls.Add(movimentacaoViewControl);
            movimentacaoViewControl.Dock = DockStyle.Fill;
        }
    }
}
