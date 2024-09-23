namespace LagControlForms.Forms.Views
{
    partial class FinanceView
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
            panelHeader = new Panel();
            labelFinance = new Label();
            dataGridView = new DataGridView();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(labelFinance);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.MaximumSize = new Size(0, 60);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(784, 60);
            panelHeader.TabIndex = 1;
            // 
            // labelFinance
            // 
            labelFinance.AutoSize = true;
            labelFinance.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelFinance.Location = new Point(22, 26);
            labelFinance.Name = "labelFinance";
            labelFinance.Size = new Size(101, 25);
            labelFinance.TabIndex = 0;
            labelFinance.Text = "Financeiro";
            // 
            // dataGridView1
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(20, 206);
            dataGridView.Name = "dataGridView1";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(744, 251);
            dataGridView.TabIndex = 2;
            // 
            // FinanceView
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView);
            Controls.Add(panelHeader);
            Name = "FinanceView";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelFinance;
        private DataGridView dataGridView;
    }
}
