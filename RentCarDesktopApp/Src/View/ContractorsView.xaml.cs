using System.Windows.Controls;
using RentCarDesktopApp.Src.ViewModel;

namespace RentCarDesktopApp.Src.View;

public partial class ContractorsView : UserControl
{
    public ContractorsView()
    {
        InitializeComponent();
        DataContext = new ContractorsViewModel();
    }
}