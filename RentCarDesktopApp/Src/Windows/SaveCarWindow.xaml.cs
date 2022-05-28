using System.Windows;
using System.Windows.Input;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Src.ViewModel;

namespace RentCarDesktopApp.Windows;

public partial class SaveCarWindow : Window
{
    public SaveCarWindow()
    {
        InitializeComponent();
    }

    public void Init(Car model = null)
    {
        SaveCarViewModel viewModel = new SaveCarViewModel();
        viewModel.Init(model == null ? new Car() : model);
        DataContext = viewModel;
    }

    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed) return;

        DragMove();
    }

    private void CloseButton_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}