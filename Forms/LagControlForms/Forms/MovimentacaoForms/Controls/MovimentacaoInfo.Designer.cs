namespace LagControlForms.Forms.MovimentacaoForms.Controls
{
    partial class MovimentacaoInfo
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
            labelTitulo = new Label();
            labelDescricao = new Label();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("MS Reference Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitulo.Location = new Point(5, 5);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(55, 19);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Titulo";
            // 
            // labelDescricao
            // 
            labelDescricao.AutoSize = true;
            labelDescricao.Font = new Font("MS Reference Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescricao.Location = new Point(5, 25);
            labelDescricao.Name = "labelDescricao";
            labelDescricao.Size = new Size(63, 15);
            labelDescricao.TabIndex = 1;
            labelDescricao.Text = "Descricao";
            // 
            // MovimentacaoInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(labelDescricao);
            Controls.Add(labelTitulo);
            Name = "MovimentacaoInfo";
            Size = new Size(120, 48);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private Label labelDescricao;
    }
}
