namespace ModPlusStyleDemo
{
    using System;
    using ModPlusStyle;

    
    public partial class ForSite
    {
        public ForSite(string theme = null)
        {
            InitializeComponent();
            this.theme = theme;
                
            ContentRendered += OnContentRendered;
        }

        private string theme;

        private void OnContentRendered(object sender, EventArgs e)
        {
            ThemeManager.ChangeTheme(Resources, theme);
        }
    }
}
