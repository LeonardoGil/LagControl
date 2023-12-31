﻿using LagFinanceLib.Domain;
using LagFinanceLib.Domain.Enum;
using LagFinanceLib.Interfaces;

namespace LagControlForms.Controls
{
    public partial class AdicionarMovimentacaoControl : UserControl
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IContaRepository _contaRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public BindingSource CategoriaSelectList { get; private set; }
        public BindingSource ContaSelectList { get; private set; }
        public BindingSource ContaTransferenciaSelectList { get; private set; }

        public event EventHandler UpdateMovimentacaoList;

        private bool Edit { get; set; }

        private Movimentacao Movimentacao { get; set; }

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

        public async Task EditMovimentacao(Movimentacao movimentacao)
        {
            EnableButtons(false);

            var load = LoadFields(movimentacao);

            var edit = SetEdit(movimentacao);

            Task.WaitAll(load, edit);

            EnableButtons();
        }


        #region Private methods
        private async void Save(bool repeat)
        {
            try
            {
                EnableButtons(false);

                await BuildMovimentacao();

                if (Edit)
                {
                    _movimentacaoRepository.Update(Movimentacao);
                }
                else
                {
                    _movimentacaoRepository.Add(Movimentacao);
                }

                Task.Run(() => UpdateMovimentacaoList.Invoke(Movimentacao, new EventArgs()));

                Clear(repeat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                EnableButtons();
            }
        }

        private async Task<Movimentacao> BuildMovimentacao()
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

            Movimentacao = movimentacao;

            return movimentacao;
        }


        private void EnableButtons(bool enable = true)
        {
            buttonGravar.Enabled = enable;
            buttonGravarRepetir.Enabled = enable;
            buttonCancelar.Enabled = enable;
        }

        private void ResetCheckedList(int index = -1)
        {
            foreach (int ind in checkedListBoxTipoMovimentacao.CheckedIndices)
            {
                if (ind != index)
                    checkedListBoxTipoMovimentacao.SetItemChecked(ind, false);
            }
        }


        private async Task Clear(bool repeat = false)
        {
            textBoxDescricao.Text = string.Empty;
            textBoxValor.Text = string.Empty;

            if (!repeat)
            {
                maskedTextBoxData.Text = DateTime.Now.Date.ToString("d");

                comboBoxCategoria.SelectedItem = CategoriaSelectList.List.OfType<Categoria>().FirstOrDefault();
                comboBoxConta.SelectedItem = ContaSelectList.List.OfType<Conta>().FirstOrDefault();
                comboBoxContaTransferencia.SelectedItem = ContaTransferenciaSelectList.List.OfType<Conta>().FirstOrDefault();

                ResetCheckedList();
            }

            Movimentacao = default;
            Edit = false;
        }

        private async Task SetEdit(Movimentacao movimentacao)
        {
            Edit = true;
            Movimentacao = movimentacao;
            buttonGravar.Text = "Editar";
        }

        private async Task LoadCategoriaList()
        {
            CategoriaSelectList = new BindingSource
            {
                DataSource = _categoriaRepository.Get().ToList()
            };

            comboBoxCategoria.DataSource = CategoriaSelectList;
            comboBoxCategoria.DisplayMember = "Descricao";
        }

        private async Task LoadContaList()
        {
            var contas = _contaRepository.Get().ToList();

            // Conta
            comboBoxConta.DataSource = ContaSelectList = new BindingSource
            {
                DataSource = contas
            };
            comboBoxConta.DisplayMember = "Descricao";

            // Conta Transferencia
            comboBoxContaTransferencia.DataSource = ContaTransferenciaSelectList = new BindingSource
            {
                DataSource = contas
            };
            comboBoxContaTransferencia.DisplayMember = "Descricao";
        }

        private async Task LoadFields(Movimentacao movimentacao)
        {
            textBoxDescricao.Text = movimentacao.Descricao;
            checkBoxPendente.Checked = movimentacao.Pendente;

            maskedTextBoxData.Text = movimentacao.Data.ToString("d");
            textBoxValor.Text = movimentacao.Valor.ToString();

            checkedListBoxTipoMovimentacao.SetItemChecked((int)movimentacao.TipoMovimentacao, true);

            comboBoxCategoria.SelectedItem = CategoriaSelectList.List.OfType<Categoria>().FirstOrDefault(x => x.Id == movimentacao.CategoriaId);
            comboBoxConta.SelectedItem = ContaSelectList.List.OfType<Conta>().FirstOrDefault(x => x.Id == movimentacao.ContaId);

            if (movimentacao.TipoMovimentacao == TipoMovimentacaoEnum.Transferencia)
                comboBoxContaTransferencia.SelectedItem = ContaTransferenciaSelectList.List.OfType<Conta>().FirstOrDefault(x => x.Id == movimentacao.ContaTransferenciaId);
        }
        #endregion

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
