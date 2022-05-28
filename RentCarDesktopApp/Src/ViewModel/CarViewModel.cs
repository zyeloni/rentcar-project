using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Services;

namespace RentCarDesktopApp.Src.ViewModel;

public class CarViewModel : ObservableObject
{
    private CarService _carService;
    public Task Initialization { get; private set; }
    public Task DeleteCarTask { get; private set; }

    private IEnumerable<Car> _cars;
    private Car _selectedCar;

    public RelayCommand DeleteCommand { get; set; }

    public IEnumerable<Car> Cars
    {
        get { return _cars; }
        set
        {
            _cars = value;
            OnPropertyChanged(nameof(Cars));
        }
    }

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

        DeleteCommand = new RelayCommand(ob => { DeleteCarTask = DeleteCars(); }, CanDeleteCar);
    }

    private async Task LoadCars()
    {
        Cars = await _carService.GetAll();
        OnPropertyChanged(nameof(Cars));
    }

    private async Task DeleteCars()
    {
        await _carService.Delete(SelectedCar);
        await LoadCars();
        OnPropertyChanged(nameof(Cars));
    }

    private bool CanDeleteCar(object car)
    {
        return SelectedCar != null;
    }
}