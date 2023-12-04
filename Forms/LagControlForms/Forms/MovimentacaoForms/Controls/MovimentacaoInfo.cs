namespace LagControlForms.Forms.MovimentacaoForms.Controls
{
    public partial class MovimentacaoInfo : UserControl
    {
        public MovimentacaoInfo(string titulo, string descricao)
        {
            InitializeComponent();

            labelTitulo.Text = titulo;
            labelDescricao.Text = descricao;
        }
    }
}
