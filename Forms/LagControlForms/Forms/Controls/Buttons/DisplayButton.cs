using System.ComponentModel;
using System.Globalization;

namespace LagControlForms.Forms.Controls.Buttons
{
    public partial class DisplayButton : Button
    {
        private readonly int[] sizesIcon = new[] { 16, 24, 32, 64, 128, 256 };

        private int sizeIcon;

        private string resource;

        [Browsable(true)]
        public string Resource
        {
            get => resource;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Resource não pode ser nulo");

                var size = sizesIcon.FirstOrDefault(size => value.EndsWith(size.ToString()));

                if (size > 0)
                {
                    var lenght = value.Length - 1 - (size.ToString().Length - 1);
                    
                    resource = value[..lenght];
                }
                else
                {
                    resource = value;
                }

                sizeIcon = GetSizeIcon();
                SetImageResource(resource);
            }
        }

        public int SizeIcon
        {
            get => sizeIcon;
        }

        public DisplayButton()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            var size = GetSizeIcon();
            
            if (size != sizeIcon)
            {
                sizeIcon = size;
                SetImageResource(resource);
            }
        }

        private void SetImageResource(string image)
        {
            image += $"_{sizeIcon}";

            var result = Properties.Resources.ResourceManager.GetObject(image, CultureInfo.CurrentCulture);

            if (result is null)
                return;

            Image = (Bitmap)result;
        }

        private int GetSizeIcon()
        {
            var size = Height;

            return size < 120 ? sizesIcon[2] :
                   size < 200 ? sizesIcon[3] : sizesIcon[1];
        }
    }
}
