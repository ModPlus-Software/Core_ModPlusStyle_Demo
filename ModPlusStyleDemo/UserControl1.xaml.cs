namespace ModPlusStyleDemo
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1
    {
        public UserControl1()
        {
            InitializeComponent();

            /*
             * When developing plugins, it is impossible to use App.xaml.
             * To apply theme to UserControls, you need to use the method in UserControl constructor:
             *
             * ModPlusAPI.Windows.Helpers.WindowHelpers.ChangeStyleForResourceDictionary(Resources);
             */
        }
    }
}
