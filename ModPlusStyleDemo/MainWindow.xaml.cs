namespace ModPlusStyleDemo
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using ModPlusStyle;
    using ModPlusStyle.Controls;
    using ModPlusStyle.Controls.Dialogs;

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtFlyoutTest_OnClick(object sender, RoutedEventArgs e)
        {
            Flyout.IsOpen = !Flyout.IsOpen;
        }

        private void BtOpenWindowWithoutTitle_OnClick(object sender, RoutedEventArgs e)
        {
            var progressWindow = new Progress();
            progressWindow.ShowDialog();
        }

        private void BtFlyoutModalessTest_OnClick(object sender, RoutedEventArgs e)
        {
            FlyoutModaless.IsOpen = !FlyoutModaless.IsOpen;
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("This is the title", "Some message");
        }

        private async void BtMessageDialog_OnClick(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("Hi!!!", "It's a window's dialog =) It's a window's dialog =) It's a window's dialog =) It's a window's dialog =) It's a window's dialog =) It's a window's dialog =) It's a window's dialog =) It's a window's dialog =)");
        }

        private async void BtMessageDialogAllButtons_OnClick(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("Title of dialog", string.Empty, MessageDialogStyle.AffirmativeAndNegativeAndDoubleAuxiliary,
                new MetroDialogSettings(){FirstAuxiliaryButtonText = "First", SecondAuxiliaryButtonText = "Second"});
        }

        private async void BtShowInputDialog_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await this.ShowInputAsync("Hello!", "What is your name?");

            if (result == null) //// user pressed cancel
                return;

            await this.ShowMessageAsync("Hello", "Hello " + result + "!");
        }

        private async void BtProgressDialog_OnClick(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                NegativeButtonText = "Close now",
                AnimateShow = false,
                AnimateHide = false,
            };

            var controller = await this.ShowProgressAsync("Please wait...", "We are baking some cupcakes!", settings: mySettings);
            controller.SetIndeterminate();

            await Task.Delay(5000);

            controller.SetCancelable(true);

            double i = 0.0;
            while (i < 6.0)
            {
                double val = (i / 100.0) * 20.0;
                controller.SetProgress(val);
                controller.SetMessage("Baking cupcake: " + i + "...");

                if (controller.IsCanceled)
                    break; //// canceled progressDialog auto closes.

                i += 1.0;

                await Task.Delay(2000);
            }

            await controller.CloseAsync();

            if (controller.IsCanceled)
            {
                await this.ShowMessageAsync("No cupcakes!", "You stopped baking!");
            }
            else
            {
                await this.ShowMessageAsync("Cupcakes!", "Your cupcakes are finished! Enjoy!");
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            CbTheme.SelectedIndex = 0;
        }

        private void CbTheme_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox cb && cb.SelectedItem is ModPlusStyle.Theme theme)
            {
                ThemeName = theme.Name;
                ThemeManager.ChangeTheme(Resources, theme, true);
                if (UserControl1 != null)
                    ThemeManager.ChangeTheme(UserControl1.Resources, theme, false);
            }
        }

        private string ThemeName { get; set; }

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            ForSite forSite = new ForSite(ThemeName);
            forSite.ShowDialog();
        }

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start(((Hyperlink)sender).NavigateUri.ToString());
        }

        private void BtShowNotificationTop_OnClick(object sender, RoutedEventArgs e)
        {
            ShowNotification("This is top notification");
        }

        private void BtTopNotificationWithLongText_OnClick(object sender, RoutedEventArgs e)
        {
            ShowNotification(
                "This is top notification with long long long text: Тут какое-то уведомление, которое не желательно делать очень длинным, так как это все-же уведомления, а не окна. Для длинного текста лучше использовать MessageBox",
                millisecondsToClose: 5000);
        }

        private void BtShowNotificationBottom_OnClick(object sender, RoutedEventArgs e)
        {
            ShowNotification("This is bottom notification", NotificationPosition.Bottom);
        }

        private void BtShowTopLeftNotification_OnClick(object sender, RoutedEventArgs e)
        {
            ShowNotification("This is top left notification", NotificationPosition.TopLeft);
        }

        private void BtShowTopRightNotification_OnClick(object sender, RoutedEventArgs e)
        {
            ShowNotification("This is top right notification", NotificationPosition.TopRight);
        }

        private void BtShowBottomLeftNotification_OnClick(object sender, RoutedEventArgs e)
        {
            ShowNotification("This is bottom left notification", NotificationPosition.BottomLeft);
        }

        private void BtShowBottomRightNotification_OnClick(object sender, RoutedEventArgs e)
        {
            ShowNotification("This is bottom right notification", NotificationPosition.BottomRight);
        }
    }
}
