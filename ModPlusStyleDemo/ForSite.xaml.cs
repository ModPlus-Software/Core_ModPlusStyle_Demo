namespace ModPlusStyleDemo
{
    using System;
    using ModPlusStyle;
    
    public partial class ForSite
    {
        private readonly string _theme;

        public ForSite(string theme = null)
        {
            InitializeComponent();
            _theme = theme;
                
            ContentRendered += OnContentRendered;
        }

        private void OnContentRendered(object sender, EventArgs e)
        {
            ThemeManager.ChangeTheme(Resources, _theme);
        }
    }
}
