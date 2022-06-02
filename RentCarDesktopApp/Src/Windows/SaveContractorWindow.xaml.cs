using System.Windows;
using System.Windows.Input;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Src.ViewModel;

namespace RentCarDesktopApp.Windows;

public partial class SaveContractorWindow : Window
{
    public SaveContractorWindow()
    {
        InitializeComponent();
    }
    
    public void Init(Contractor model = null)
    {
        SaveContractorViewModel viewModel = new SaveContractorViewModel();
        viewModel.Init(model == null ? new Contractor() : model);
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