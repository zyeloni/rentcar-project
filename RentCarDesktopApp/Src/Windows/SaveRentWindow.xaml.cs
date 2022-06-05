using System.Windows;
using System.Windows.Input;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Src.ViewModel;

namespace RentCarDesktopApp.Windows;

public partial class SaveRentWindow : Window
{
    public SaveRentWindow()
    {
        InitializeComponent();
    }

    public void Init(Rent model = null)
    {
        SaveRentViewModel viewModel = new SaveRentViewModel();
        viewModel.Init(model == null ? new Rent() : model);
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