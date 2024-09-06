namespace LagControlForms.Forms.Views
{
    partial class InicioView
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
            labelServices = new Label();
            flowPanelServices = new FlowLayoutPanel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(labelServices);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.MaximumSize = new Size(0, 60);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(784, 60);
            panelHeader.TabIndex = 0;
            // 
            // labelServices
            // 
            labelServices.AutoSize = true;
            labelServices.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelServices.Location = new Point(22, 26);
            labelServices.Name = "labelServices";
            labelServices.Size = new Size(83, 25);
            labelServices.TabIndex = 0;
            labelServices.Text = "Serviços";
            // 
            // flowPanelServices
            // 
            flowPanelServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowPanelServices.Location = new Point(0, 60);
            flowPanelServices.MaximumSize = new Size(0, 200);
            flowPanelServices.Name = "flowPanelServices";
            flowPanelServices.Padding = new Padding(25, 10, 10, 25);
            flowPanelServices.Size = new Size(784, 120);
            flowPanelServices.TabIndex = 1;
            flowPanelServices.Resize += FlowPanelServices_ResizeEvent;
            // 
            // InicioView
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowPanelServices);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "InicioView";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelServices;
        private FlowLayoutPanel flowPanelServices;
    }
}
