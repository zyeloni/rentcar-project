using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Services;
using RentCarDesktopApp.Windows;

namespace RentCarDesktopApp.Src.ViewModel;

public class CarViewModel : ObservableObject, IViewModel
{
    private CarService _carService;
    public Task Initialization { get; private set; }
    public Task DeleteCarTask { get; private set; }

    private IEnumerable<Car> _cars;
    private Car _selectedCar;

    public RelayCommand DeleteCommand { get; set; }
    public RelayCommand AddCommand { get; set; }
    public RelayCommand EditCommand { get; set; }

    public IEnumerable<Car> Items
    {
        get { return _cars; }
        set
        {
            _cars = value;
            OnPropertyChanged(nameof(Items));
        }
    }

    private IEnumerable<Car> AllData { get; set; }

    public Car SelectedCar
    {
        get { return _selectedCar; }
        set
        {
            _selectedCar = value;
            OnPropertyChanged(nameof(SelectedCar));
        }
    }

    public CarViewModel()
    {
        _carService = new CarService();
        Initialization = LoadCars();

        DeleteCommand = new RelayCommand(ob => { DeleteCarTask = DeleteCars(); }, IsSelected);
        AddCommand = new RelayCommand(ob => { ShowAddModal(); });
        EditCommand = new RelayCommand(ob => { ShowEditModal(); }, IsSelected);
    }

    private async Task LoadCars()
    {
        Items = await _carService.GetAll();
        AllData = Items;
    }

    private async Task DeleteCars()
    {
        await _carService.Delete(SelectedCar);
        await LoadCars();
        SelectedCar = null;
    }

    private bool IsSelected(object car)
    {
        return SelectedCar != null;
    }

    private void ShowAddModal()
    {
        SaveCarWindow save = new SaveCarWindow();
        save.Init();
        save.Show();
        save.Closing += OnSaveClose;
    }

    private void ShowEditModal()
    {
        SaveCarWindow save = new SaveCarWindow();
        save.Init(SelectedCar);
        save.Show();
        //save.Closed += OnSaveClose;
        Items = new List<Car>();
    }

    private void OnSaveClose(object? sender, EventArgs eventArgs)
    {
        Initialization = LoadCars();
    }

    public void Search(string query)
    {
        if (query.Equals(String.Empty))
            Items = AllData;

        Items = (Items as List<Car>).Where(x => x.Brand.Contains(query) || x.Model.Contains(query)).ToList();
    }

    public void ResetSearch()
    {
        Items = AllData;
    }
}