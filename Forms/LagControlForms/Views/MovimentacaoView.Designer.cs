namespace LagControlForms.Views
{
    partial class MovimentacaoView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle1.Font = new Font("MesloLGL NF", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(37, 37, 37);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewMovimentacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewMovimentacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewMovimentacao.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewMovimentacao.EnableHeadersVisualStyles = false;
            dataGridViewMovimentacao.GridColor = Color.FromArgb(23, 23, 23);
            dataGridViewMovimentacao.Location = new Point(0, 130);
            dataGridViewMovimentacao.Margin = new Padding(0);
            dataGridViewMovimentacao.MultiSelect = false;
            dataGridViewMovimentacao.Name = "dataGridViewMovimentacao";
            dataGridViewMovimentacao.ReadOnly = true;
            dataGridViewMovimentacao.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewMovimentacao.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewMovimentacao.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(46, 46, 46);
            dataGridViewCellStyle4.Font = new Font("MesloLGL NF", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewMovimentacao.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewMovimentacao.RowTemplate.Height = 25;
            dataGridViewMovimentacao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMovimentacao.ShowCellErrors = false;
            dataGridViewMovimentacao.ShowCellToolTips = false;
            dataGridViewMovimentacao.ShowRowErrors = false;
            dataGridViewMovimentacao.Size = new Size(600, 450);
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
