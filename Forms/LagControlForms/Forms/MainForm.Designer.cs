﻿namespace LagControlForms.Forms
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
            panelView = new Panel();
            panelCenter = new Panel();
            menuLateralControl = new Controls.MenuLateralControl();
            panelCenter.SuspendLayout();
            SuspendLayout();
            // 
            // panelView
            // 
            panelView.BackColor = Color.FromArgb(46, 46, 46);
            panelView.Location = new Point(200, 0);
            panelView.Margin = new Padding(5);
            panelView.Name = "panelView";
            panelView.Size = new Size(600, 580);
            panelView.TabIndex = 1;
            // 
            // panelCenter
            // 
            panelCenter.BackColor = Color.FromArgb(31, 31, 31);
            panelCenter.Controls.Add(menuLateralControl);
            panelCenter.Controls.Add(panelView);
            panelCenter.Location = new Point(0, 10);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new Size(800, 580);
            panelCenter.TabIndex = 2;
            // 
            // menuLateralControl1
            // 
            menuLateralControl.BackColor = Color.FromArgb(14, 14, 14);
            menuLateralControl.Location = new Point(0, 0);
            menuLateralControl.Margin = new Padding(0);
            menuLateralControl.Name = "menuLateralControl1";
            menuLateralControl.Size = new Size(200, 580);
            menuLateralControl.TabIndex = 2;
            // 
            // MainForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 14, 14);
            ClientSize = new Size(800, 600);
            Controls.Add(panelCenter);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            panelCenter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controls.MenuLateralControl menuLateralControl;
        private Panel panelView;
        private Panel panelCenter;
    }
}