using LagControlForms.Themes;

namespace LagControlForms.Forms.Views
{
    partial class BaseView
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
            SuspendLayout();
            // 
            // BaseView
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = DefaultTheme.BackgroundColorPrimary;
            Font = new Font("SauceCodePro NF", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = DefaultTheme.TextColorPrimary;
            Margin = new Padding(0);
            Name = "BaseView";
            Size = new Size(784, 471);
            ResumeLayout(false);
        }

        #endregion
    }
}
