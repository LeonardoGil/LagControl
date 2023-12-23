namespace LagControlForms.Controls//
{
    public partial class DropDownMenuControl : UserControl
    {
        public bool Aberto { get; set; }

        protected int AlturaDefault = 60;

        protected int LarguraDefault = 200;

        private List<Button> SubMenus = new();

        public DropDownMenuControl()
        {
            InitializeComponent();
        }

        public DropDownMenuControl(string MenuDescricao, Dictionary<string, EventHandler> subMenus)
        {
            InitializeComponent();

            GerarMenu(MenuDescricao, subMenus);
        }

        private Button GerarSubMenuButton(string descricao, EventHandler clickEvent)
        {
            var button = new Button();

            // Default
            button.BackColor = Color.FromArgb(56, 56, 56);
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 153, 153);
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("MesloLGL Nerd Font Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button.ForeColor = Color.FromArgb(214, 214, 214);
            button.Margin = new Padding(0);
            button.Size = new Size(LarguraDefault, AlturaDefault);
            button.TabIndex = 0;
            button.UseVisualStyleBackColor = false;

            // Personalizado
            button.Name = string.Concat("button", descricao);
            button.Text = descricao;
            button.Click += clickEvent;
            button.Location = DefinirLocationSubMenu(SubMenus.Count);

            return button;
        }

        private void GerarMenu(string MenuDescricao, Dictionary<string, EventHandler> subMenus)
        {
            buttonMenu.Text = MenuDescricao;

            foreach (var subMenu in subMenus)
            {
                var button = GerarSubMenuButton(subMenu.Key, subMenu.Value);

                SubMenus.Add(button);
            }
        }

        private Point DefinirLocationSubMenu(int index)
        {
            var y = AlturaDefault * (1 + index);

            return new Point(0, y);
        }

        private void Expandir_e_Recolher_ClickEvent(object sender, EventArgs e)
        {
            if (Aberto)
            {
                Size = new Size(LarguraDefault, AlturaDefault);

                panel.Controls.Clear();
                panel.Controls.Add(buttonMenu);
            }
            else if (SubMenus.Any())
            {
                var altura = buttonMenu.Size.Height + (AlturaDefault * SubMenus.Count);

                Size = new Size(LarguraDefault, altura);

                panel.Controls.AddRange(SubMenus.ToArray());
            }

            Aberto = !Aberto;
        }
    }
}
