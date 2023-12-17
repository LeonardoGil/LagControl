using Microsoft.Extensions.DependencyInjection;

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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            dataGridViewMovimentacao = new DataGridView();
            panelSuperior = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimentacao).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMovimentacao
            // 
            dataGridViewMovimentacao.AllowUserToAddRows = false;
            dataGridViewMovimentacao.AllowUserToDeleteRows = false;
            dataGridViewMovimentacao.AllowUserToOrderColumns = true;
            dataGridViewMovimentacao.BackgroundColor = Color.FromArgb(46, 46, 46);
            dataGridViewMovimentacao.BorderStyle = BorderStyle.None;
            dataGridViewMovimentacao.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewMovimentacao.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle5.Font = new Font("MesloLGL NF", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(37, 37, 37);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridViewMovimentacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewMovimentacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridViewMovimentacao.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewMovimentacao.EnableHeadersVisualStyles = false;
            dataGridViewMovimentacao.GridColor = Color.FromArgb(23, 23, 23);
            dataGridViewMovimentacao.Location = new Point(0, 130);
            dataGridViewMovimentacao.Margin = new Padding(0);
            dataGridViewMovimentacao.MultiSelect = false;
            dataGridViewMovimentacao.Name = "dataGridViewMovimentacao";
            dataGridViewMovimentacao.ReadOnly = true;
            dataGridViewMovimentacao.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewMovimentacao.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewMovimentacao.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(46, 46, 46);
            dataGridViewCellStyle8.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewMovimentacao.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewMovimentacao.RowTemplate.Height = 25;
            dataGridViewMovimentacao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMovimentacao.ShowCellErrors = false;
            dataGridViewMovimentacao.ShowCellToolTips = false;
            dataGridViewMovimentacao.ShowRowErrors = false;
            dataGridViewMovimentacao.Size = new Size(600, 470);
            dataGridViewMovimentacao.TabIndex = 0;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(31, 31, 31);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Margin = new Padding(0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(600, 120);
            panelSuperior.TabIndex = 1;
            // 
            // MovimentacaoViewControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 14, 14);
            Controls.Add(panelSuperior);
            Controls.Add(dataGridViewMovimentacao);
            Margin = new Padding(0);
            Name = "MovimentacaoViewControl";
            Size = new Size(600, 580);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimentacao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMovimentacao;
        private Panel panelSuperior;
    }
}
