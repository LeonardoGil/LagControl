using LagControlForms.Themes;

namespace LagControlForms.Forms.Controls.Buttons
{
    partial class DisplayButton
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
            components = new System.ComponentModel.Container();

            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("SauceCodePro NF", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(0);
            Padding = new Padding(5);
            Size = new Size(100, 100);
            Text = string.Empty;
            TextAlign = ContentAlignment.BottomCenter;
            UseVisualStyleBackColor = true;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.CheckedBackColor = DefaultTheme.BackgroundColorSecondary;
            BackColor = DefaultTheme.BackgroundColorPrimary;
        }

        #endregion
    }
}
