using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModPlusStyleDemo
{
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
