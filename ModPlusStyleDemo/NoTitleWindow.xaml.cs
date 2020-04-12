namespace ModPlusStyleDemo
{
    using System.Windows;

    /// <summary>
    /// Логика взаимодействия для NoTitleWindow.xaml
    /// </summary>
    public partial class NoTitleWindow 
    {
        public NoTitleWindow()
        {
            InitializeComponent();
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
