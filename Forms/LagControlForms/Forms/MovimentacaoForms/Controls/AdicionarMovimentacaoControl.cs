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

        public List<Categoria> CategoriaSelectList { get; private set; }
        public List<Conta> ContaSelectList { get; private set; }
        public List<Conta> ContaTransferenciaSelectList { get; private set; }

        public event EventHandler UpdateMovimentacaoList;

        public AdicionarMovimentacaoControl()
        {
            InitializeComponent();
        }

        public AdicionarMovimentacaoControl(ICategoriaRepository categoriaRepository,
                                            IContaRepository contaRepository,
                                            IMovimentacaoRepository movimentacaoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _contaRepository = contaRepository;
            _movimentacaoRepository = movimentacaoRepository;

            InitializeComponent();

            LoadCategoriaList();
            LoadContaList();
        }

        private void ResetFields(bool repeat = false)
        {
            textBoxDescricao.Text = string.Empty;
            textBoxValor.Text = string.Empty;

            if (!repeat)
            {
                maskedTextBoxData.Text = DateTime.Now.Date.ToString("d");

                comboBoxCategoria.SelectedItem = CategoriaSelectList.FirstOrDefault();
                comboBoxConta.SelectedItem = ContaSelectList.FirstOrDefault();

                ResetCheckedList();
            }
        }

        private void ResetCheckedList(int index = -1)
        {
            foreach (int ind in checkedListBoxTipoMovimentacao.CheckedIndices)
            {
                if (ind != index)
                    checkedListBoxTipoMovimentacao.SetItemChecked(ind, false);
            }
        }

        private Movimentacao BuildMovimentacao()
        {
            var movimentacao = new Movimentacao
            {
                Descricao = textBoxDescricao.Text,
                Pendente = checkBoxPendente.Checked
            };

            var dataValid = DateTime.TryParse(maskedTextBoxData.Text, out DateTime data);
            var valorValid = decimal.TryParse(textBoxValor.Text, out decimal valor);

            if (!dataValid)
                throw new Exception("Data invalida");

            if (!valorValid)
                throw new Exception("Valor invalido");

            if (checkedListBoxTipoMovimentacao.CheckedItems.Count == 0)
                throw new Exception("Informar tipo movimentaçao!");

            var item = (string)checkedListBoxTipoMovimentacao.CheckedItems[0];
            movimentacao.TipoMovimentacao = Enum.Parse<TipoMovimentacaoEnum>(item);

            movimentacao.Data = data;
            movimentacao.Valor = valor;

            var categoria = (Categoria)comboBoxCategoria.SelectedItem;
            var conta = (Conta)comboBoxConta.SelectedItem;

            movimentacao.CategoriaId = categoria.Id;
            movimentacao.Categoria = categoria;
            movimentacao.ContaId = conta.Id;
            movimentacao.Conta = conta;

            switch (movimentacao.TipoMovimentacao)
            {
                case TipoMovimentacaoEnum.Transferencia:
                    var contaTransferencia = (Conta)comboBoxContaTransferencia.SelectedItem;

                    movimentacao.ContaTransferenciaId = contaTransferencia.Id;
                    movimentacao.ContaTransferencia = contaTransferencia;
                    break;

            }

            return movimentacao;
        }

        private void LoadCategoriaList()
        {
            CategoriaSelectList = _categoriaRepository.Get().ToList();

            comboBoxCategoria.DataSource = CategoriaSelectList;
            comboBoxCategoria.DisplayMember = "Descricao";
        }

        private void LoadContaList()
        {
            var contas = _contaRepository.Get().ToList();

            ContaSelectList = contas;
            comboBoxConta.DataSource = ContaSelectList;
            comboBoxConta.DisplayMember = "Descricao";

            ContaTransferenciaSelectList = contas;
            comboBoxContaTransferencia.DataSource = ContaTransferenciaSelectList;
            comboBoxContaTransferencia.DisplayMember = "Descricao";
        }

        private void Save(bool repeat)
        {
            try
            {
                var movimentacao = BuildMovimentacao();

                _movimentacaoRepository.Add(movimentacao);

                ResetFields(repeat);

                UpdateMovimentacaoList.Invoke(movimentacao, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Events

        private void SetControls_LoadEvent(object sender, EventArgs e)
        {
            checkedListBoxTipoMovimentacao.Items.AddRange(Enum.GetNames<TipoMovimentacaoEnum>());
            maskedTextBoxData.Text = DateTime.Now.ToString("d");
        }

        private void Save_ClickEvent(object sender, EventArgs e) => Save(false);

        private void SaveAndRepeat_ClickEvent(object sender, EventArgs e) => Save(true);

        private void ResetCheckedList_ItemCheckEvent(object sender, ItemCheckEventArgs e) => ResetCheckedList(e.Index);

        private void TipoMovimentacao_SelectedChangedEvent(object sender, EventArgs e)
        {
            if (sender is CheckedListBox checkedListBox)
            {
                var visible = (string)checkedListBox.SelectedItem == TipoMovimentacaoEnum.Transferencia.ToString();

                labelContaTransferencia.Visible = visible;
                comboBoxContaTransferencia.Visible = visible;
            }
        }

        #endregion
    }
}
