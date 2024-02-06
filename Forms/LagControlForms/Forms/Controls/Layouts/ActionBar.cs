using System.ComponentModel;

namespace LagControlForms.Forms.Controls.Layouts
{
    public partial class ActionBar : UserControl
    {
        [Browsable(true)]
        public List<ActionBarButton> ButtonsBar { get; set; } = new List<ActionBarButton>();

        public ActionBar()
        {
            InitializeComponent();
        }


        protected Button CreateButton(string description, EventHandler clickEvent, Image? icon = null)
        {
            var button = new Button
            {
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = SystemColors.ControlLightLight,
                Name = description,
                Text = description,
                TabIndex = 0,
                UseVisualStyleBackColor = true,
            };

            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 56, 56);

            if (icon is not null)
            {
                button.Image = icon;
                button.TextImageRelation = TextImageRelation.ImageAboveText;
            }

            button.Click += clickEvent;

            return button;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            foreach (var actionBarButton in ButtonsBar)
            {
                var button = CreateButton(actionBarButton.Description, actionBarButton.ClickEvent);
                flowLayoutPanel.Controls.Add(button);
            }
        }
    }

    public class ActionBarButton
    {
        public string Description { get; set; }


        public EventHandler ClickEvent { get; set; }
    }
}
