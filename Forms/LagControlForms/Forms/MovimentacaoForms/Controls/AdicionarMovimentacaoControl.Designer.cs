namespace LagControlForms.Forms.MovimentacaoForms.Controls
{
    partial class AdicionarMovimentacaoControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelDescricao = new Label();
            textBoxDescricao = new TextBox();
            textBoxValor = new TextBox();
            labelValor = new Label();
            checkedListBoxTipoMovimentacao = new CheckedListBox();
            comboBoxCategoria = new ComboBox();
            label1 = new Label();
            labelConta = new Label();
            comboBoxConta = new ComboBox();
            buttonGravar = new Button();
            maskedTextBoxData = new MaskedTextBox();
            labelData = new Label();
            comboBoxContaTransferencia = new ComboBox();
            buttonGravarRepetir = new Button();
            labelContaTransferencia = new Label();
            SuspendLayout();
            // 
            // labelDescricao
            // 
            labelDescricao.AutoSize = true;
            labelDescricao.Location = new Point(12, 12);
            labelDescricao.Name = "labelDescricao";
            labelDescricao.Size = new Size(58, 15);
            labelDescricao.TabIndex = 0;
            labelDescricao.Text = "Descricao";
            // 
            // textBoxDescricao
            // 
            textBoxDescricao.Location = new Point(12, 30);
            textBoxDescricao.Name = "textBoxDescricao";
            textBoxDescricao.Size = new Size(218, 23);
            textBoxDescricao.TabIndex = 1;
            // 
            // textBoxValor
            // 
            textBoxValor.Location = new Point(12, 136);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(78, 23);
            textBoxValor.TabIndex = 7;
            textBoxValor.TextAlign = HorizontalAlignment.Right;
            // 
            // labelValor
            // 
            labelValor.AutoSize = true;
            labelValor.Location = new Point(12, 118);
            labelValor.Name = "labelValor";
            labelValor.Size = new Size(33, 15);
            labelValor.TabIndex = 6;
            labelValor.Text = "Valor";
            // 
            // checkedListBoxTipoMovimentacao
            // 
            checkedListBoxTipoMovimentacao.CheckOnClick = true;
            checkedListBoxTipoMovimentacao.FormattingEnabled = true;
            checkedListBoxTipoMovimentacao.Location = new Point(12, 171);
            checkedListBoxTipoMovimentacao.Name = "checkedListBoxTipoMovimentacao";
            checkedListBoxTipoMovimentacao.Size = new Size(113, 58);
            checkedListBoxTipoMovimentacao.TabIndex = 10;
            checkedListBoxTipoMovimentacao.ItemCheck += ResetCheckedList_ItemCheckEvent;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(98, 136);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(132, 23);
            comboBoxCategoria.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 118);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 8;
            label1.Text = "Categoria";
            // 
            // labelConta
            // 
            labelConta.AutoSize = true;
            labelConta.Location = new Point(98, 65);
            labelConta.Name = "labelConta";
            labelConta.Size = new Size(39, 15);
            labelConta.TabIndex = 4;
            labelConta.Text = "Conta";
            // 
            // comboBoxConta
            // 
            comboBoxConta.FormattingEnabled = true;
            comboBoxConta.Location = new Point(98, 83);
            comboBoxConta.Name = "comboBoxConta";
            comboBoxConta.Size = new Size(132, 23);
            comboBoxConta.TabIndex = 5;
            // 
            // buttonGravar
            // 
            buttonGravar.Location = new Point(12, 272);
            buttonGravar.Name = "buttonGravar";
            buttonGravar.Size = new Size(102, 35);
            buttonGravar.TabIndex = 13;
            buttonGravar.Text = "Gravar";
            buttonGravar.UseVisualStyleBackColor = true;
            buttonGravar.Click += Save_ClickEvent;
            // 
            // maskedTextBoxData
            // 
            maskedTextBoxData.Location = new Point(12, 83);
            maskedTextBoxData.Mask = "00/00/0000";
            maskedTextBoxData.Name = "maskedTextBoxData";
            maskedTextBoxData.Size = new Size(78, 23);
            maskedTextBoxData.TabIndex = 3;
            maskedTextBoxData.TextAlign = HorizontalAlignment.Center;
            maskedTextBoxData.ValidatingType = typeof(DateTime);
            // 
            // labelData
            // 
            labelData.AutoSize = true;
            labelData.Location = new Point(12, 65);
            labelData.Name = "labelData";
            labelData.Size = new Size(31, 15);
            labelData.TabIndex = 2;
            labelData.Text = "Data";
            // 
            // comboBoxContaTransferencia
            // 
            comboBoxContaTransferencia.FormattingEnabled = true;
            comboBoxContaTransferencia.Location = new Point(131, 206);
            comboBoxContaTransferencia.Name = "comboBoxContaTransferencia";
            comboBoxContaTransferencia.Size = new Size(99, 23);
            comboBoxContaTransferencia.TabIndex = 12;
            comboBoxContaTransferencia.Visible = false;
            // 
            // buttonGravarRepetir
            // 
            buttonGravarRepetir.Location = new Point(126, 272);
            buttonGravarRepetir.Name = "buttonGravarRepetir";
            buttonGravarRepetir.Size = new Size(102, 35);
            buttonGravarRepetir.TabIndex = 14;
            buttonGravarRepetir.Text = "Gravar e Repetir";
            buttonGravarRepetir.UseVisualStyleBackColor = true;
            buttonGravarRepetir.Click += SaveAndRepeat_ClickEvent;
            // 
            // labelContaTransferencia
            // 
            labelContaTransferencia.AutoSize = true;
            labelContaTransferencia.Location = new Point(131, 173);
            labelContaTransferencia.Name = "labelContaTransferencia";
            labelContaTransferencia.Size = new Size(76, 30);
            labelContaTransferencia.TabIndex = 11;
            labelContaTransferencia.Text = "Conta \r\nTransferencia";
            labelContaTransferencia.Visible = false;
            // 
            // AdicionarMovimentacaoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelContaTransferencia);
            Controls.Add(buttonGravarRepetir);
            Controls.Add(comboBoxContaTransferencia);
            Controls.Add(labelData);
            Controls.Add(maskedTextBoxData);
            Controls.Add(buttonGravar);
            Controls.Add(labelConta);
            Controls.Add(comboBoxConta);
            Controls.Add(label1);
            Controls.Add(comboBoxCategoria);
            Controls.Add(checkedListBoxTipoMovimentacao);
            Controls.Add(textBoxValor);
            Controls.Add(labelValor);
            Controls.Add(textBoxDescricao);
            Controls.Add(labelDescricao);
            Name = "AdicionarMovimentacaoControl";
            Size = new Size(240, 320);
            Load += SetControls_LoadEvent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDescricao;
        private TextBox textBoxDescricao;
        private TextBox textBoxValor;
        private Label labelValor;
        private CheckedListBox checkedListBoxTipoMovimentacao;
        private ComboBox comboBoxCategoria;
        private Label label1;
        private Label labelConta;
        private ComboBox comboBoxConta;
        private Button buttonGravar;
        private MaskedTextBox maskedTextBoxData;
        private Label labelData;
        private ComboBox comboBoxContaTransferencia;
        private Button buttonGravarRepetir;
        private Label labelContaTransferencia;
    }
}
