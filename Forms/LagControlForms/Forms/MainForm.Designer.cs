namespace LagControlForms.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pictureBoxLogo = new PictureBox();
            panelView = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(84, 8, 28);
            panel1.Controls.Add(pictureBoxLogo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 130);
            panel1.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackgroundImage = Properties.Resources.Lag_removebg_preview;
            pictureBoxLogo.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxLogo.Dock = DockStyle.Left;
            pictureBoxLogo.Location = new Point(0, 0);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(230, 130);
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // panelView
            // 
            panelView.Dock = DockStyle.Fill;
            panelView.Location = new Point(0, 130);
            panelView.Margin = new Padding(0);
            panelView.Name = "panelView";
            panelView.Padding = new Padding(5);
            panelView.Size = new Size(984, 631);
            panelView.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 1, 11);
            ClientSize = new Size(984, 761);
            Controls.Add(panelView);
            Controls.Add(panel1);
            Font = new Font("SauceCodePro NF Medium", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.DarkGray;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Opacity = 0.98D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBoxLogo;
        private Panel panelView;
    }
}