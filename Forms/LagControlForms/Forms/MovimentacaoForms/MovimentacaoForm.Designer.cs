using LagControlForms.Forms.MovimentacaoForms.Controls;
using Microsoft.Extensions.DependencyInjection;

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
            panelSuperior = new Panel();
            adicionarMovimentacaoControl = new AdicionarMovimentacaoControl();
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
            // panelSuperior
            // 
            resources.ApplyResources(panelSuperior, "panelSuperior");
            panelSuperior.BackColor = SystemColors.ControlDark;
            panelSuperior.Name = "panelSuperior";
            // 
            // adicionarMovimentacaoControl
            // 
            resources.ApplyResources(adicionarMovimentacaoControl, "adicionarMovimentacaoControl");
            adicionarMovimentacaoControl.BackColor = SystemColors.ActiveCaption;
            adicionarMovimentacaoControl.Name = "adicionarMovimentacaoControl";
            // 
            // MovimentacaoForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ControlBox = false;
            Controls.Add(adicionarMovimentacaoControl);
            Controls.Add(panelSuperior);
            Controls.Add(dataGridViewMovimentacao);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MovimentacaoForm";
            ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimentacao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMovimentacao;
        private Panel panelSuperior;
        private AdicionarMovimentacaoControl adicionarMovimentacaoControl;
    }
}