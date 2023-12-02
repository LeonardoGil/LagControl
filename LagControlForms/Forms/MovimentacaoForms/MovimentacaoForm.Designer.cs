namespace LagControlForms
{
    partial class MovimentacaoForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovimentacaoForm));
            dataGridViewMovimentacao = new DataGridView();
            panelLateral = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimentacao).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMovimentacao
            // 
            resources.ApplyResources(dataGridViewMovimentacao, "dataGridViewMovimentacao");
            dataGridViewMovimentacao.AllowUserToAddRows = false;
            dataGridViewMovimentacao.AllowUserToDeleteRows = false;
            dataGridViewMovimentacao.BackgroundColor = SystemColors.HotTrack;
            dataGridViewMovimentacao.BorderStyle = BorderStyle.None;
            dataGridViewMovimentacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMovimentacao.Name = "dataGridViewMovimentacao";
            dataGridViewMovimentacao.ReadOnly = true;
            dataGridViewMovimentacao.RowTemplate.Height = 25;
            // 
            // panelLateral
            // 
            resources.ApplyResources(panelLateral, "panelLateral");
            panelLateral.BackColor = SystemColors.MenuHighlight;
            panelLateral.Name = "panelLateral";
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            Controls.Add(panelLateral);
            Controls.Add(dataGridViewMovimentacao);
            Name = "FormMain";
            ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimentacao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMovimentacao;
        private Panel panelLateral;
    }
}