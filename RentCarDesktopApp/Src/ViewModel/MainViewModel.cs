using System.Windows.Controls;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Src.View;

namespace RentCarDesktopApp.Src.ViewModel;

public class MainViewModel : ObservableObject
{
    public CarViewModel _CarViewModel;
    public ContractorsViewModel _ContractorsViewModel;
    public RentsViewModel _RentsViewModel;
    public ReservationsViewModel _ReservationsViewModel;
    
    private object _currentView;
    
    public RelayCommand CarViewCommand { get; set; }
    public RelayCommand ContractorsViewCommand { get; set; }
    public RelayCommand RentsViewCommand { get; set; }
    public RelayCommand ReservationsViewCommand { get; set; }

    public object CurrentView
    {
        get { return _currentView; }
        set { _currentView = value; OnPropertyChanged(); }
    }
    
    public MainViewModel()
    {
        _CarViewModel = new CarViewModel();
        _ContractorsViewModel = new ContractorsViewModel();
        _RentsViewModel = new RentsViewModel();
        _ReservationsViewModel = new ReservationsViewModel();
        
        CurrentView = _CarViewModel;

        CarViewCommand = new RelayCommand(o =>
        {
            CurrentView = _CarViewModel;
        });
        
        ContractorsViewCommand = new RelayCommand(o =>
        {
            CurrentView = _ContractorsViewModel;
        });
        
        RentsViewCommand = new RelayCommand(o =>
        {
            CurrentView = _RentsViewModel;
        });
        
        ReservationsViewCommand = new RelayCommand(o =>
        {
            CurrentView =_ReservationsViewModel;
        });
    }
}