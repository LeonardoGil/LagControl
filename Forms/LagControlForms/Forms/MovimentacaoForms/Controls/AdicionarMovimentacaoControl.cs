using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagControlForms.Forms.MovimentacaoForms.Controls
{
    public partial class AdicionarMovimentacaoControl : UserControl
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IContaRepository _contaRepository;

        private List<Categoria> CategoriaSelectList;
        private List<Conta> ContaSelectList;

        public AdicionarMovimentacaoControl(ICategoriaRepository categoriaRepository,
                                            IContaRepository contaRepository)
        {
            _categoriaRepository = categoriaRepository;
            _contaRepository = contaRepository;

            InitializeComponent();
        }

        private async Task LoadCategoriaList()
        {
            CategoriaSelectList = await _categoriaRepository.Get().ToListAsync();

            comboBoxCategoria.DataSource = CategoriaSelectList;
            comboBoxCategoria.DisplayMember = "Descricao";
        }

        public async Task LoadContaList()
        {
            ContaSelectList = await _contaRepository.Get().ToListAsync();

            comboBoxConta.DataSource = ContaSelectList;
            comboBoxConta.DisplayMember = "Descricao";
        }

        #region Events

        private void SetControls_LoadEvent(object sender, EventArgs e)
        {
            LoadCategoriaList();
            LoadContaList();

            maskedTextBoxData.Text = DateTime.Now.ToString("d");
        }

        private void Save_ClickEvent(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
