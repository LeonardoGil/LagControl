namespace LagControlForms.Forms.MainForms.Controls
{
    partial class MenuLateral
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
            buttonFinanceiro = new Button();
            SuspendLayout();
            // 
            // buttonFinanceiro
            // 
            buttonFinanceiro.BackColor = Color.FromArgb(56, 56, 56);
            buttonFinanceiro.Cursor = Cursors.Hand;
            buttonFinanceiro.FlatAppearance.BorderSize = 0;
            buttonFinanceiro.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 153, 153);
            buttonFinanceiro.FlatStyle = FlatStyle.Flat;
            buttonFinanceiro.Location = new Point(0, 135);
            buttonFinanceiro.Name = "buttonFinanceiro";
            buttonFinanceiro.Size = new Size(180, 40);
            buttonFinanceiro.TabIndex = 0;
            buttonFinanceiro.Text = "Financeiro";
            buttonFinanceiro.UseVisualStyleBackColor = false;
            // 
            // MenuLateral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 31, 31);
            Controls.Add(buttonFinanceiro);
            Margin = new Padding(0);
            Name = "MenuLateral";
            Size = new Size(180, 600);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonFinanceiro;
    }
}
