using System;
using RentCarDesktopApp.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Services;
using RentCarDesktopApp.Windows;

namespace RentCarDesktopApp.Src.ViewModel;

public class RentsViewModel : ObservableObject, IViewModel
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
        AllData = Items;
    }

    private void ShowEditModal()
    {
        SaveRentWindow save = new SaveRentWindow();
        save.Init(SelectedRent);
        save.Show();
        save.Closing += OnSaveClose;
    }

    private void ShowAddModal()
    {
        SaveRentWindow save = new SaveRentWindow();
        save.Init();
        save.Show();
        save.Closing += OnSaveClose;
    }

    private void OnSaveClose(object? sender, EventArgs eventArgs)
    {
        Initialization = LoadRents();
    }

    private async Task DeleteRents()
    {
        await _rentService.Delete(SelectedRent);
        await LoadRents();

        SelectedRent = null;
    }

    private bool IsSelected(object obj)
    {
        return SelectedRent != null;
    }

    public void Search(string query)
    {
        if (query.Equals(String.Empty))
            Items = AllData;

        Items = (AllData as List<Rent>).Where(x =>
            x.Car.Brand.Contains(query) || x.Car.Model.Contains(query) || x.Contractor.FirstName.Contains(query) ||
            x.Contractor.SurName.Contains(query));
    }

    public void ResetSearch()
    {
        Items = AllData;
    }
}