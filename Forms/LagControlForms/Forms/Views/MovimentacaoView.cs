using AutoMapper;
using LagControlForms.Forms.Controls;
using LagControlForms.Models;
using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LagControlForms.Forms.Views
{
    public partial class MovimentacaoView : BaseView
    {
        private readonly IMapper _mapper;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        private DataGridView dataGridView;

        protected AdicionarMovimentacaoControl adicionarMovimentacaoControl;

        public MovimentacaoView(IMapper mapper,
                                IMovimentacaoRepository movimentacaoRepository) : base()
        {
            _mapper = mapper;
            _movimentacaoRepository = movimentacaoRepository;

            InitializeComponent();
        }

        private async Task LoadGrid()
        {
            try
            {
                var movimentacoes = _movimentacaoRepository.Get()
                                                           .AsNoTracking()
                                                           .Include(x => x.Conta)
                                                           .Include(x => x.Categoria)
                                                           .ToList();

                new BindingSource
                {
                    DataSource = _mapper.Map<List<Movimentacao>, List<MovimentacaoModel>>(movimentacoes)
                };

                dataGridView.CellMouseDoubleClick += EditMovimentacao_DoubleClickEvent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private async Task LoadControls()
        {
            try
            {
                adicionarMovimentacaoControl = Program.ServiceProvider.GetRequiredService<AdicionarMovimentacaoControl>();
                adicionarMovimentacaoControl.UpdateMovimentacaoList += UpdateMovimentacaoList_Event;

                //panelSuperior.Controls.Add(adicionarMovimentacaoControl);
                adicionarMovimentacaoControl.Dock = DockStyle.Fill;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #region Events 
        private void UpdateMovimentacaoList_Event(object sender, EventArgs args)
        {
            if (sender is Movimentacao movimentacao)
            {
                var model = _mapper.Map<Movimentacao, MovimentacaoModel>(movimentacao);
                //dataGridView.Invoke(() => View.Add(model));
            }
        }

        private void MovimentacaoView_Load(object sender, EventArgs e)
        {
            LoadControls();
            LoadGrid();
        }

        private void EditMovimentacao_DoubleClickEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && sender is DataGridView dataGridView)
            {
                var row = dataGridView.SelectedRows[0];

                if (row.DataBoundItem is MovimentacaoModel model)
                {
                    var movimentacao = _movimentacaoRepository.Get().First(x => x.Id == model.Id);

                    adicionarMovimentacaoControl.EditMovimentacao(movimentacao);
                };
            }
        }
        #endregion
    }
}
