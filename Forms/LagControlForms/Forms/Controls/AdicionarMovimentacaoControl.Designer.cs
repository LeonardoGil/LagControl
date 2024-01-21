namespace LagControlForms.Forms.Controls
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
            checkBoxPendente = new CheckBox();
            buttonCancelar = new Button();
            SuspendLayout();
            // 
            // labelDescricao
            // 
            labelDescricao.AutoSize = true;
            labelDescricao.BackColor = Color.FromArgb(31, 31, 31);
            labelDescricao.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescricao.ForeColor = SystemColors.ControlLightLight;
            labelDescricao.Location = new Point(10, 10);
            labelDescricao.Name = "labelDescricao";
            labelDescricao.Size = new Size(71, 18);
            labelDescricao.TabIndex = 0;
            labelDescricao.Text = "Descricao";
            // 
            // textBoxDescricao
            // 
            textBoxDescricao.BackColor = Color.FromArgb(56, 56, 56);
            textBoxDescricao.BorderStyle = BorderStyle.FixedSingle;
            textBoxDescricao.Font = new Font("MesloLGL NF", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxDescricao.ForeColor = SystemColors.HighlightText;
            textBoxDescricao.Location = new Point(10, 28);
            textBoxDescricao.Name = "textBoxDescricao";
            textBoxDescricao.Size = new Size(144, 25);
            textBoxDescricao.TabIndex = 1;
            // 
            // textBoxValor
            // 
            textBoxValor.BackColor = Color.FromArgb(56, 56, 56);
            textBoxValor.BorderStyle = BorderStyle.FixedSingle;
            textBoxValor.Font = new Font("MesloLGL NF", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxValor.ForeColor = SystemColors.HighlightText;
            textBoxValor.Location = new Point(86, 82);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(68, 25);
            textBoxValor.TabIndex = 7;
            textBoxValor.TextAlign = HorizontalAlignment.Right;
            // 
            // labelValor
            // 
            labelValor.AutoSize = true;
            labelValor.BackColor = Color.FromArgb(31, 31, 31);
            labelValor.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelValor.ForeColor = SystemColors.ControlLightLight;
            labelValor.Location = new Point(86, 62);
            labelValor.Name = "labelValor";
            labelValor.Size = new Size(43, 18);
            labelValor.TabIndex = 6;
            labelValor.Text = "Valor";
            // 
            // checkedListBoxTipoMovimentacao
            // 
            checkedListBoxTipoMovimentacao.BackColor = Color.FromArgb(31, 31, 31);
            checkedListBoxTipoMovimentacao.BorderStyle = BorderStyle.None;
            checkedListBoxTipoMovimentacao.CheckOnClick = true;
            checkedListBoxTipoMovimentacao.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkedListBoxTipoMovimentacao.ForeColor = SystemColors.ControlLightLight;
            checkedListBoxTipoMovimentacao.FormattingEnabled = true;
            checkedListBoxTipoMovimentacao.ImeMode = ImeMode.NoControl;
            checkedListBoxTipoMovimentacao.Location = new Point(281, 45);
            checkedListBoxTipoMovimentacao.Name = "checkedListBoxTipoMovimentacao";
            checkedListBoxTipoMovimentacao.Size = new Size(113, 63);
            checkedListBoxTipoMovimentacao.TabIndex = 10;
            checkedListBoxTipoMovimentacao.ItemCheck += ResetCheckedList_ItemCheckEvent;
            checkedListBoxTipoMovimentacao.SelectedIndexChanged += TipoMovimentacao_SelectedChangedEvent;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.BackColor = Color.FromArgb(56, 56, 56);
            comboBoxCategoria.FlatStyle = FlatStyle.Flat;
            comboBoxCategoria.Font = new Font("MesloLGL NF", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxCategoria.ForeColor = SystemColors.HighlightText;
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(164, 82);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(111, 25);
            comboBoxCategoria.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(31, 31, 31);
            label1.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(164, 62);
            label1.Name = "label1";
            label1.Size = new Size(71, 18);
            label1.TabIndex = 8;
            label1.Text = "Categoria";
            // 
            // labelConta
            // 
            labelConta.AutoSize = true;
            labelConta.BackColor = Color.FromArgb(31, 31, 31);
            labelConta.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelConta.ForeColor = SystemColors.ControlLightLight;
            labelConta.Location = new Point(164, 10);
            labelConta.Name = "labelConta";
            labelConta.Size = new Size(43, 18);
            labelConta.TabIndex = 4;
            labelConta.Text = "Conta";
            // 
            // comboBoxConta
            // 
            comboBoxConta.BackColor = Color.FromArgb(56, 56, 56);
            comboBoxConta.FlatStyle = FlatStyle.Flat;
            comboBoxConta.Font = new Font("MesloLGL NF", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxConta.ForeColor = SystemColors.HighlightText;
            comboBoxConta.FormattingEnabled = true;
            comboBoxConta.Location = new Point(164, 28);
            comboBoxConta.Name = "comboBoxConta";
            comboBoxConta.Size = new Size(111, 25);
            comboBoxConta.TabIndex = 5;
            // 
            // buttonGravar
            // 
            buttonGravar.BackColor = Color.FromArgb(56, 56, 56);
            buttonGravar.Cursor = Cursors.Hand;
            buttonGravar.FlatAppearance.BorderSize = 0;
            buttonGravar.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 153, 153);
            buttonGravar.FlatStyle = FlatStyle.Flat;
            buttonGravar.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonGravar.ForeColor = SystemColors.ControlLightLight;
            buttonGravar.Location = new Point(510, 10);
            buttonGravar.Name = "buttonGravar";
            buttonGravar.Size = new Size(85, 30);
            buttonGravar.TabIndex = 13;
            buttonGravar.Text = "Gravar";
            buttonGravar.UseVisualStyleBackColor = false;
            buttonGravar.Click += Save_ClickEvent;
            // 
            // maskedTextBoxData
            // 
            maskedTextBoxData.BackColor = Color.FromArgb(56, 56, 56);
            maskedTextBoxData.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBoxData.Font = new Font("MesloLGL NF", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            maskedTextBoxData.ForeColor = SystemColors.HighlightText;
            maskedTextBoxData.Location = new Point(10, 82);
            maskedTextBoxData.Mask = "00/00/0000";
            maskedTextBoxData.Name = "maskedTextBoxData";
            maskedTextBoxData.Size = new Size(71, 25);
            maskedTextBoxData.TabIndex = 3;
            maskedTextBoxData.TextAlign = HorizontalAlignment.Center;
            maskedTextBoxData.ValidatingType = typeof(DateTime);
            // 
            // labelData
            // 
            labelData.AutoSize = true;
            labelData.BackColor = Color.FromArgb(31, 31, 31);
            labelData.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelData.ForeColor = SystemColors.ControlLightLight;
            labelData.Location = new Point(10, 62);
            labelData.Name = "labelData";
            labelData.Size = new Size(36, 18);
            labelData.TabIndex = 2;
            labelData.Text = "Data";
            // 
            // comboBoxContaTransferencia
            // 
            comboBoxContaTransferencia.BackColor = Color.FromArgb(56, 56, 56);
            comboBoxContaTransferencia.FlatStyle = FlatStyle.Flat;
            comboBoxContaTransferencia.Font = new Font("MesloLGL NF", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxContaTransferencia.ForeColor = SystemColors.HighlightText;
            comboBoxContaTransferencia.FormattingEnabled = true;
            comboBoxContaTransferencia.Location = new Point(400, 82);
            comboBoxContaTransferencia.Name = "comboBoxContaTransferencia";
            comboBoxContaTransferencia.Size = new Size(86, 25);
            comboBoxContaTransferencia.TabIndex = 12;
            comboBoxContaTransferencia.Visible = false;
            // 
            // buttonGravarRepetir
            // 
            buttonGravarRepetir.BackColor = Color.FromArgb(56, 56, 56);
            buttonGravarRepetir.Cursor = Cursors.Hand;
            buttonGravarRepetir.FlatAppearance.BorderSize = 0;
            buttonGravarRepetir.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 153, 153);
            buttonGravarRepetir.FlatStyle = FlatStyle.Flat;
            buttonGravarRepetir.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonGravarRepetir.ForeColor = SystemColors.ControlLightLight;
            buttonGravarRepetir.Location = new Point(510, 45);
            buttonGravarRepetir.Name = "buttonGravarRepetir";
            buttonGravarRepetir.Size = new Size(85, 30);
            buttonGravarRepetir.TabIndex = 14;
            buttonGravarRepetir.Text = "Repetir";
            buttonGravarRepetir.UseVisualStyleBackColor = false;
            buttonGravarRepetir.Click += SaveAndRepeat_ClickEvent;
            // 
            // labelContaTransferencia
            // 
            labelContaTransferencia.AutoSize = true;
            labelContaTransferencia.BackColor = Color.FromArgb(31, 31, 31);
            labelContaTransferencia.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelContaTransferencia.ForeColor = SystemColors.ControlLightLight;
            labelContaTransferencia.Location = new Point(400, 62);
            labelContaTransferencia.Name = "labelContaTransferencia";
            labelContaTransferencia.Size = new Size(99, 18);
            labelContaTransferencia.TabIndex = 11;
            labelContaTransferencia.Text = "Conta Transf.";
            labelContaTransferencia.Visible = false;
            // 
            // checkBoxPendente
            // 
            checkBoxPendente.AutoSize = true;
            checkBoxPendente.BackColor = Color.FromArgb(31, 31, 31);
            checkBoxPendente.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxPendente.ForeColor = SystemColors.ControlLightLight;
            checkBoxPendente.Location = new Point(400, 14);
            checkBoxPendente.Name = "checkBoxPendente";
            checkBoxPendente.Size = new Size(83, 22);
            checkBoxPendente.TabIndex = 15;
            checkBoxPendente.Text = "Pendente";
            checkBoxPendente.UseVisualStyleBackColor = false;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.FromArgb(56, 56, 56);
            buttonCancelar.Cursor = Cursors.Hand;
            buttonCancelar.FlatAppearance.BorderSize = 0;
            buttonCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 153, 153);
            buttonCancelar.FlatStyle = FlatStyle.Flat;
            buttonCancelar.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCancelar.ForeColor = SystemColors.ControlLightLight;
            buttonCancelar.Location = new Point(510, 80);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(85, 30);
            buttonCancelar.TabIndex = 16;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // AdicionarMovimentacaoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 31, 31);
            Controls.Add(buttonCancelar);
            Controls.Add(checkBoxPendente);
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
            Size = new Size(600, 120);
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
        private CheckBox checkBoxPendente;
        private Button buttonCancelar;
    }
}
