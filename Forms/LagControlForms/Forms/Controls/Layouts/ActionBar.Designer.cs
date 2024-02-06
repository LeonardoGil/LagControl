namespace LagControlForms.Forms.Controls.Layouts
{
    partial class ActionBar
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
            panelLine = new Panel();
            flowLayoutPanel = new FlowLayoutPanel();
            button1 = new Button();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelLine
            // 
            panelLine.BackColor = Color.Gray;
            panelLine.Dock = DockStyle.Bottom;
            panelLine.Location = new Point(0, 30);
            panelLine.Name = "panelLine";
            panelLine.Size = new Size(784, 5);
            panelLine.TabIndex = 0;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.Controls.Add(button1);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Margin = new Padding(0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(784, 30);
            flowLayoutPanel.TabIndex = 1;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 56, 56);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(78, 31);
            button1.TabIndex = 0;
            button1.Text = "Example";
            button1.UseVisualStyleBackColor = true;
            // 
            // ActionBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(flowLayoutPanel);
            Controls.Add(panelLine);
            Name = "ActionBar";
            Size = new Size(784, 35);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelLine;
        private FlowLayoutPanel flowLayoutPanel;
        private Button button1;
    }
}
