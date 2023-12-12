namespace LagControlForms.Forms.MovimentacaoForms.Controls
{
    partial class MovimentacaoViewControl
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
            dataGridViewMovimentacao = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimentacao).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMovimentacao
            // 
            dataGridViewMovimentacao.BackgroundColor = Color.FromArgb(46, 46, 46);
            dataGridViewMovimentacao.BorderStyle = BorderStyle.None;
            dataGridViewMovimentacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMovimentacao.Location = new Point(0, 80);
            dataGridViewMovimentacao.Margin = new Padding(0);
            dataGridViewMovimentacao.Name = "dataGridViewMovimentacao";
            dataGridViewMovimentacao.RowTemplate.Height = 25;
            dataGridViewMovimentacao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMovimentacao.Size = new Size(600, 500);
            dataGridViewMovimentacao.TabIndex = 0;
            // 
            // MovimentacaoViewControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 46, 46);
            Controls.Add(dataGridViewMovimentacao);
            Margin = new Padding(0);
            Name = "MovimentacaoViewControl";
            Size = new Size(600, 580);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimentacao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMovimentacao;
    }
}
