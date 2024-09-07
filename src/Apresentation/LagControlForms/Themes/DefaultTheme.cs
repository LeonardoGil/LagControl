namespace LagControlForms.Themes
{
    public static class DefaultTheme
    {
        //  Cor de Fundo Principal:
        //  #1E1E1E - Cinza escuro para o fundo principal.
        public static Color BackgroundColorPrimary { get => Color.FromArgb(30, 30, 30); }

        //  Cor de Destaque:
        //  #2E2E2E - Uma cor mais clara para destacar áreas específicas.
        public static Color BackgroundColorSecondary { get => Color.FromArgb(0, 31, 63); }

        //  Cor do Texto Principal:
        //  #FFFFFF - Branco para o texto principal.
        public static Color TextColorPrimary { get => Color.White; }

        //  Cor de Destaque para Texto:
        //  #A0A0A0 - Cinza claro para textos destacados.
        public static Color TextColorSecondary { get => SystemColors.ButtonShadow; }

        //  Cor de Acentuação(Azul Marinho) :
        //  #001F3F - Azul marinho para elementos acentuados.
        public static Color ColorPrimary { get => Color.FromArgb(0, 31, 63); }

        //Cor de Alerta/Ênfase(Azul Elétrico) :
        //#0074E4 - Azul elétrico para realçar informações importantes.
        public static Color ColorSecondary { get => Color.FromArgb(0, 116, 228); }
    }
}
