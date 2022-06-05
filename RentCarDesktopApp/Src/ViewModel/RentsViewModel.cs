using System;
using RentCarDesktopApp.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Services;

namespace RentCarDesktopApp.Src.ViewModel;

public class RentsViewModel : ObservableObject
{
    private RentService _rentService;
    private IEnumerable<Rent> _rents;
    private Rent _selectedRent;
    
    public Task Initialization { get; private set; }
    public Task DeleteCarTask { get; private set; }
    
    public RelayCommand DeleteCommand { get; set; }
    public RelayCommand AddCommand { get; set; }
    public RelayCommand EditCommand { get; set; }
    
    private IEnumerable<Rent> AllData { get; set; }
    public IEnumerable<Rent> Items
    {
        get { return _rents; }
        set
        {
            _rents = value;
            OnPropertyChanged(nameof(Items));
        }
    }
    
    public Rent SelectedRent
    {
        get { return _selectedRent; }
        set
        {
            _selectedRent = value;
            OnPropertyChanged(nameof(SelectedRent));
        }
    }


    public RentsViewModel()
    {
        _rentService = new RentService();
        Initialization = LoadRents();
        DeleteCommand = new RelayCommand(ob => { DeleteCarTask = DeleteRents(); }, IsSelected);
        AddCommand = new RelayCommand(ob => { ShowAddModal(); });
        EditCommand = new RelayCommand(ob => { ShowEditModal(); }, IsSelected);
    }

    private async Task LoadRents()
    {
        Items = await _rentService.GetAll();
    }

    private void ShowEditModal()
    {
        throw new System.NotImplementedException();
    }

    private void ShowAddModal()
    {
        throw new System.NotImplementedException();
    }

    private Task DeleteRents()
    {
        throw new System.NotImplementedException();
    }

    private bool IsSelected(object obj)
    {
        return SelectedRent != null;
    }
    
    public void Search(string query)
    {
        if (query.Equals(String.Empty))
            Items = AllData;
    }

    public void ResetSearch()
    {
        Items = AllData;
    }
}