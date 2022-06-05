using System;
using System.Windows.Controls;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Src.View;

namespace RentCarDesktopApp.Src.ViewModel;

public class MainViewModel : ObservableObject
{
    public CarViewModel _CarViewModel;
    public ContractorsViewModel _ContractorsViewModel;
    public RentsViewModel _RentsViewModel;
    private object _currentView;

    public RelayCommand CarViewCommand { get; set; }
    public RelayCommand ContractorsViewCommand { get; set; }
    public RelayCommand RentsViewCommand { get; set; }
    public RelayCommand ReservationsViewCommand { get; set; }

    public object CurrentView
    {
        get { return _currentView; }
        set
        {
            ClearSearchQuery();
            _currentView = value;
            OnPropertyChanged();
        }
    }

    private String _searchText;

    public String SearchText
    {
        get { return _searchText; }
        set
        {
            _searchText = value;
            OnPropertyChanged(nameof(SearchText));
        }
    }

    private void ClearSearchQuery()
    {
        if (CurrentView is IViewModel)
        {
            (CurrentView as IViewModel).ResetSearch();
        }

        SearchText = "";
    }

    public MainViewModel()
    {
        _CarViewModel = new CarViewModel();
        _ContractorsViewModel = new ContractorsViewModel();
        _RentsViewModel = new RentsViewModel();

        CurrentView = _CarViewModel;

        CarViewCommand = new RelayCommand(o => { CurrentView = _CarViewModel; });

        ContractorsViewCommand = new RelayCommand(o => { CurrentView = _ContractorsViewModel; });

        RentsViewCommand = new RelayCommand(o => { CurrentView = _RentsViewModel; });
    }
}