using LagFinanceLib.Domain;
using LagFinanceLib.Domain.Enum;
using LagFinanceLib.Interfaces;
using LagFinanceLib.Repository;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace LagControlForms.Forms.MovimentacaoForms.Controls
{
    public partial class AdicionarMovimentacaoControl : UserControl
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IContaRepository _contaRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        private List<Categoria> CategoriaSelectList;
        private List<Conta> ContaSelectList;

        public event EventHandler UpdateMovimentacaoList;

        public AdicionarMovimentacaoControl(ICategoriaRepository categoriaRepository,
                                            IContaRepository contaRepository,
                                            IMovimentacaoRepository movimentacaoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _contaRepository = contaRepository;
            _movimentacaoRepository = movimentacaoRepository;

            InitializeComponent();
        }

        private void LoadCategoriaList()
        {
            CategoriaSelectList = _categoriaRepository.Get().ToList();

            comboBoxCategoria.DataSource = CategoriaSelectList;
            comboBoxCategoria.DisplayMember = "Descricao";
        }

        public void LoadContaList()
        {
            ContaSelectList = _contaRepository.Get().ToList();

            comboBoxConta.DataSource = ContaSelectList;
            comboBoxConta.DisplayMember = "Descricao";
        }

        #region Events

        private void SetControls_LoadEvent(object sender, EventArgs e)
        {
            LoadCategoriaList();
            LoadContaList();

            checkedListBoxTipoMovimentacao.Items.AddRange(Enum.GetNames<TipoMovimentacaoEnum>());
            maskedTextBoxData.Text = DateTime.Now.ToString("d");
        }

        private void Save_ClickEvent(object sender, EventArgs e)
        {
            var movimentacao = new Movimentacao
            {
                Descricao = textBoxDescricao.Text
            };

            if (DateTime.TryParse(maskedTextBoxData.Text, out DateTime data))
                movimentacao.Data = data;
            else
            {
                MessageBox.Show("Data invalida");
                return;
            }

            if (decimal.TryParse(textBoxValor.Text, out decimal valor))
                movimentacao.Valor = valor;
            else
            {
                MessageBox.Show("Valor invalido");
                return;
            }

            if (checkedListBoxTipoMovimentacao.CheckedItems.Count > 0)
            {
                var item = (string)checkedListBoxTipoMovimentacao.CheckedItems[0];
                movimentacao.TipoMovimentacao = Enum.Parse<TipoMovimentacaoEnum>(item);
            }
            else
            {
                MessageBox.Show("Informar tipo movimentaçao!");
                return;
            }

            var categoria = (Categoria)comboBoxCategoria.SelectedItem;
            var conta = (Conta)comboBoxConta.SelectedItem;

            movimentacao.CategoriaId = categoria.Id;
            movimentacao.Categoria = categoria;
            movimentacao.ContaId = conta.Id;
            movimentacao.Conta = conta;

            _movimentacaoRepository.Add(movimentacao);

            UpdateMovimentacaoList.Invoke(movimentacao, new EventArgs());
        }

        private void ResetCheckedList_ItemCheckEvent(object sender, ItemCheckEventArgs e)
        {
            foreach (int index in checkedListBoxTipoMovimentacao.CheckedIndices)
            {
                if (index != e.Index)
                    checkedListBoxTipoMovimentacao.SetItemChecked(index, false);
            }
        }

        #endregion
    }
}
