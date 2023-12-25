namespace LagControlForms.Controls
{
    partial class DropDownMenuControl
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
            buttonMenu = new Button();
            panel = new Panel();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // buttonMenu
            // 
            buttonMenu.BackColor = Color.FromArgb(38, 38, 38);
            buttonMenu.Cursor = Cursors.Hand;
            buttonMenu.FlatAppearance.BorderSize = 0;
            buttonMenu.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 153, 153);
            buttonMenu.FlatStyle = FlatStyle.Flat;
            buttonMenu.Font = new Font("MesloLGL Nerd Font Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMenu.ForeColor = Color.FromArgb(214, 214, 214);
            buttonMenu.Location = new Point(0, 0);
            buttonMenu.Margin = new Padding(0);
            buttonMenu.Name = "buttonMenu";
            buttonMenu.Size = new Size(200, 50);
            buttonMenu.TabIndex = 1;
            buttonMenu.Text = "Menu";
            buttonMenu.UseVisualStyleBackColor = false;
            buttonMenu.Click += Expandir_e_Recolher_ClickEvent;
            // 
            // panel
            // 
            panel.Controls.Add(buttonMenu);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Margin = new Padding(0);
            panel.Name = "panel";
            panel.Size = new Size(200, 50);
            panel.TabIndex = 2;
            // 
            // DropDownMenuControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel);
            Margin = new Padding(0);
            Name = "DropDownMenuControl";
            Size = new Size(200, 50);
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonMenu;
        private Panel panel;
    }
}
