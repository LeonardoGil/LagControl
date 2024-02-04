using LagControlForms.Forms.Views;

namespace LagControlForms.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var inicioView = new InicioView
            {
                Dock = DockStyle.Fill
            };

            panelView.Controls.Add(inicioView);
        }
    }
}
