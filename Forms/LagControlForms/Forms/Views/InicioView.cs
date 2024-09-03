using LagControlForms.Forms.Controls.Buttons;

namespace LagControlForms.Forms.Views
{
    public partial class InicioView : BaseView
    {
        public InicioView()
        {
            InitializeComponent();
        }

        private void View_LoadEvent(object sender, EventArgs e)
        {
            var finance = new DisplayButton
            {
                Resource = "dinheiro",
                Text = "Finanças"
            };

            if (ParentForm is MainForm mainForm)
            {
                finance.Click += mainForm.LoadFinanceView_Clicled;
            }

            flowPanelServices.Controls.Add(finance);
        }

        private void FlowPanelServices_ResizeEvent(object sender, EventArgs e)
        {
            if (sender is Control controlParent)
            {
                var size = controlParent.Height - 120 + 100;

                foreach (var control in controlParent.Controls.OfType<Control>())
                {
                    control.Size = new Size(size, size);
                };
            }
        }
    }
}
