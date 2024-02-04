using LagControlForms.Themes;

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
            panelHeader = new Panel();
            pictureBoxLogo = new PictureBox();
            panelView = new Panel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(0, 31, 63);
            panelHeader.Controls.Add(pictureBoxLogo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(784, 90);
            panelHeader.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackgroundImage = Properties.Resources.Lag_removebg_preview;
            pictureBoxLogo.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxLogo.Dock = DockStyle.Left;
            pictureBoxLogo.Location = new Point(0, 0);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(230, 90);
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // panelView
            // 
            panelView.BackColor = Color.FromArgb(30, 30, 30);
            panelView.Dock = DockStyle.Fill;
            panelView.ForeColor = Color.White;
            panelView.Location = new Point(0, 90);
            panelView.Margin = new Padding(0);
            panelView.Name = "panelView";
            panelView.Size = new Size(784, 471);
            panelView.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(784, 561);
            Controls.Add(panelView);
            Controls.Add(panelHeader);
            Font = new Font("JetBrainsMono NF Medium", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.White;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(800, 600);
            Name = "MainForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += MainForm_Load;
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private PictureBox pictureBoxLogo;
        private Panel panelView;
    }
}