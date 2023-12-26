namespace LagControlForms.Views
{
    public partial class BaseView : UserControl
    {
        private BindingSource view;

        protected BindingSource View 
        {
            get => view; 
            set
            {
                view = value;
                dataGridView.DataSource = view;
            }
        }

        public BaseView()
        {
            InitializeComponent();
        }
    }
}
