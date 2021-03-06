using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Src.ViewModel;
using RentCarDesktopApp.Windows;

namespace RentCarDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextLogo_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;

            DragMove();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MaximizedButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow!.WindowState == WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            else
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        private void MinimizedButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow!.WindowState = WindowState.Minimized;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = (sender as FrameworkElement).DataContext;

            if (vm is MainViewModel)
            {
                var mainViewModel = (vm as MainViewModel);
                string Text = (sender as TextBox).Text;

                if (mainViewModel.CurrentView is IViewModel)
                {
                    (mainViewModel.CurrentView as IViewModel).Search(Text);
                }
            }
        }
    }
}