namespace LagControlForms.Controls
{
    partial class MenuLateralControl
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
            buttonMovimentacoes = new Button();
            panelLogo = new Panel();
            SuspendLayout();
            // 
            // buttonMovimentacoes
            // 
            buttonMovimentacoes.BackColor = Color.FromArgb(56, 56, 56);
            buttonMovimentacoes.Cursor = Cursors.Hand;
            buttonMovimentacoes.FlatAppearance.BorderSize = 0;
            buttonMovimentacoes.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 153, 153);
            buttonMovimentacoes.FlatStyle = FlatStyle.Flat;
            buttonMovimentacoes.Font = new Font("MesloLGL Nerd Font Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMovimentacoes.ForeColor = Color.FromArgb(214, 214, 214);
            buttonMovimentacoes.Location = new Point(0, 137);
            buttonMovimentacoes.Margin = new Padding(0);
            buttonMovimentacoes.Name = "buttonMovimentacoes";
            buttonMovimentacoes.Size = new Size(200, 60);
            buttonMovimentacoes.TabIndex = 0;
            buttonMovimentacoes.Text = "Movimentações";
            buttonMovimentacoes.UseVisualStyleBackColor = false;
            // 
            // panelLogo
            // 
            panelLogo.BackgroundImage = Properties.Resources.Lag_removebg_preview;
            panelLogo.BackgroundImageLayout = ImageLayout.Zoom;
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(200, 100);
            panelLogo.TabIndex = 1;
            // 
            // MenuLateralControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 31, 31);
            Controls.Add(panelLogo);
            Controls.Add(buttonMovimentacoes);
            Margin = new Padding(0);
            Name = "MenuLateralControl";
            Size = new Size(200, 580);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonMovimentacoes;
        private Panel panelLogo;
    }
}
