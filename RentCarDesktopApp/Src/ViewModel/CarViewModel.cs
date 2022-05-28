using System.Collections.Generic;
using System.Threading.Tasks;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Services;

namespace RentCarDesktopApp.Src.ViewModel;

public class CarViewModel : ObservableObject
{
    private CarService _carService;
    public Task Initialization { get; private set; }

    private IEnumerable<Car> _cars;
    private Car _selectedCar;

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
    }

    private async Task LoadCars()
    {
        Cars = await _carService.GetAll();
        OnPropertyChanged(nameof(Cars));
    }
}